<template>
    <div class="korpa-container">
        <div class="korpa-table-container">
            <div class="cena">
                <h3>Ukupna cena: {{izracunajCenu()}} RSD</h3>
            </div>
            <el-table :data="cartItems"
                    max-height="1000"
                    style="border-radius: 3px;">
                <el-table-column
                    prop="Title"
                    label="Naziv"
                    min-width="100"
                    class="table-column">
                </el-table-column>
                <el-table-column
                        prop="ProductType"
                        label="Tip"
                        min-width="100"
                        class="table-column">
                </el-table-column>
                <el-table-column 
                        prop="Quantity"
                        label="Kolicina"
                        min-width="100"
                        class="table-column">
                </el-table-column>
                <el-table-column 
                        prop="Format"
                        label="Format"
                        min-width="100"
                        class="table-column">
                </el-table-column>
                <el-table-column 
                        prop="Price"
                        label="Cena"
                        min-width="100"
                        class="table-column">
                </el-table-column>
                <el-table-column align="center" prop="Image" min-width="100">
                    <template slot-scope="cartItem">
                        <el-button type="secondary" icon="el-icon-picture" circle size="mini"
                            @click="openImage(cartItem.row)">
                        </el-button>
                        <el-button type="danger" icon="el-icon-delete" circle size="mini"
                            @click="deleteCartItem(cartItem.row)">
                        </el-button>
                    </template>
                </el-table-column>
            </el-table>
        <el-button style="margin-top: 10px;" @click="Naruci()" type="primary">Naruči</el-button>
        </div>   
        <form-slika :isVisible="!isImageHidden" :shownPhoto="shownImage" :hidden="isImageHidden" @zatvoriSliku="closeImage"/>
    </div>
</template>

<script>
import FormPrikazSolja from "./FormPrikazSolja.vue"
import FooterBar from "../appBar/FooterBar.vue"
import FormSlika from "../forme/FormSlika.vue";
import { apiFetch, destinationUrl } from '../../services/authFetch';
import { getUserInfo } from '../../services/contextManagement';
import { preloadImage, preloadImages } from '../../services/preloadingImages';
export default {
    components: {FormPrikazSolja, FooterBar, FormSlika},
    data(){
        return {
            cartItems: [],
            cartId: "",
            isImageHidden: true,
            shownImage: {
                Small: {
                    Url: ""
                }
            },
            preloadedImages: []
        }
    },
    methods: {
        Naruci() {   
            var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0'); 
            var yyyy = today.getFullYear();

            today = yyyy + '-' + mm + '-' + dd  ;
               
            const formData = new FormData();
            formData.append('DeliveryAddress', '');
            formData.append('UserId', getUserInfo().userID);
            formData.append('Date', today);
            formData.append('Price', this.izracunajCenu());
            this.cartItems.forEach((item, index) => {
                formData.append("CartItems[" + index + "].ProductType", item.ProductType);
                formData.append("CartItems[" + index + "].Format", item.Format);
                formData.append("CartItems[" + index + "].Quantity", item.Quantity);
                formData.append("CartItems[" + index + "].Title", item.Title);
                formData.append("CartItems[" + index + "].Image.Id", item.Image.Id);
                formData.append("CartItems[" + index + "].Image.Title", item.Image.Title);
                formData.append("CartItems[" + index + "].Image.Original.FileId", item.Image.Original.FileId);
                formData.append("CartItems[" + index + "].Image.Original.Url", item.Image.Original.Url);
                formData.append("CartItems[" + index + "].Image.Thumbnail.FileId", item.Image.Thumbnail.FileId);
                formData.append("CartItems[" + index + "].Image.Thumbnail.Url", item.Image.Thumbnail.Url);
                formData.append("CartItems[" + index + "].Image.Large.FileId", item.Image.Large.FileId);
                formData.append("CartItems[" + index + "].Image.Large.Url", item.Image.Large.Url);
                formData.append("CartItems[" + index + "].Image.Medium.FileId", item.Image.Medium.FileId);
                formData.append("CartItems[" + index + "].Image.Medium.Url", item.Image.Medium.Url);
                formData.append("CartItems[" + index + "].Image.Small.FileId", item.Image.Small.FileId);
                formData.append("CartItems[" + index + "].Image.Small.Url", item.Image.Small.Url);
                formData.append("CartItems[" + index + "].Price", item.Price);
            });

            fetch(destinationUrl + "/Order/PerformOrder", {
                method: 'POST',
                body: formData
            }).then(response => response.ok ? response.json() : new Error())
            .then(result => {
                if(result.Success) {
                     this.$message({message: "Uspesno odradjena narudzbina", type: "success"});
                     this.cartItems = [];
                }
                else this.$message({message: "Neuspesno odradjena narudzbina", type: "error"});
            }).catch(error => console.log(error));
        },
        izracunajCenu(){
            let result = 0;
            this.cartItems.forEach(element => {
                result += element.Price;
            });
            return result.toFixed(2)
        },
        openImage(cartItem) {
            this.shownImage = cartItem.Image;
            this.isImageHidden = false;
        },
        closeImage() {
            this.isImageHidden = true;
        },
        deleteCartItem(cartItem) {
            this.cartItems = this.cartItems.filter(item => item.Id != cartItem.Id);
            const formData = new FormData();
            formData.append("CartId", this.cartId);
            formData.append("CartItemId", cartItem.Id);
            fetch(destinationUrl + "/Cart/DeleteItem", {method: 'POST', body: formData});
        },
        preloadImages() {
            let images = [];
            this.cartItems.forEach(cartItem => {
                images.push(cartItem.Image);
            });
            this.preloadedImages = preloadImages(images);
        }
    },
    mounted() {
        fetch(destinationUrl + "/Cart/GetCartByUserId/?userId=" + getUserInfo().userID, {method: 'GET'})
            .then(response => response.ok ? response.json() : new Error())
            .then(result => {
                if(result.Success) {
                    this.cartItems = result.Data.CartItems;
                    this.cartId = result.Data.Id;
                }
                this.preloadImages();
            }).catch(error => console.log(error));
    }
}
</script>

<style>
.korpa-container{
        display: flex;
        height: 90%;
        width: 100%;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        overflow: auto;
        background-color: rgba(224, 224, 235, 0.5);  
}
.korpa-table-container{
    display: flex;
    padding: 5px;
    height: 80%;
    width: 60%;
    flex-direction: column;
    align-items: center;
}

.footer-bar{
    justify-content: flex-end;
}
.cena {
    display: flex;
    width: 100%;
    height: 50px;
    justify-content: flex-end;
}

</style>


