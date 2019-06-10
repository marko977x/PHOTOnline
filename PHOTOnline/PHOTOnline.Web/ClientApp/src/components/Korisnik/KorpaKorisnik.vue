<template>
    <div class="korpa-container">
        <div class="korpa-table-container">
            <div class="cena">
                <h3>Ukupna cena: {{izracunajCenu()}} RSD</h3>
            </div>
            <el-table :data="cartItems"
                    style="border-radius: 3px;">
                <el-table-column
                        prop="ProductType"
                        label="Tip"
                        class="table-column">
                </el-table-column>
                <el-table-column 
                        prop="Quantity"
                        label="Kolicina"
                        class="table-column">
                </el-table-column>
                <el-table-column 
                        prop="Format"
                        label="Format"
                        class="table-column">
                </el-table-column>
                <el-table-column 
                        prop="Price"
                        label="Cena"
                        class="table-column">
                </el-table-column>
                <el-table-column align="center" prop="Image">
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
            dummy: {}
        }
    },
    methods: {
        Naruci() {   
            var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0'); 
            var yyyy = today.getFullYear();

            today = yyyy + '-' + mm + '-' + dd  ;
               
            apiFetch('POST', destinationUrl + "/Order/PerformOrder", {
                DeliveryAddress: "",
                UserId: getUserInfo().userID,
                Date: today,
                CartId: this.cartId
            }).then(result => console.log(result))
            .catch(error => console.log(error));
        },
        izracunajCenu(){
            let result = 0;
            this.cartItems.forEach(element => {
                result += element.Price;
            });
            return result
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
        }
    },
    mounted() {
        fetch(destinationUrl + "/Cart/GetCartByUserId/?userId=" + getUserInfo().userID, {method: 'GET'})
            .then(response => response.ok ? response.json() : new Error())
            .then(result => {
                console.log(result);
                if(result.Success)
                    this.cartItems = result.Data.CartItems;
                    this.cartId = result.Data.Id;
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


