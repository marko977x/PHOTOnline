<template>
    <div class="album-korisnik-container">
        <div class="dodavanje" >
            <el-input 
                v-model="password"
                type="password" show-password size="medium"
                style="width:350px; margin-right:30px;"
                placeholder="Unesite šifru albuma">
            </el-input>
            <el-button type="primary" size="mini"  @click="vratiAlbum">Prikaži album</el-button>
            <el-button type="danger" size="mini" @click="dodajUKorpu">Dodaj u korpu </el-button>
        </div>
        <div class="album-fotografije">
            <fotografija 
                v-for="(item, index) in items" :key="item._id"
                @selectImage="addImageToSelected($event, index)"
                @unselectImage="removeImageFromSelected($event, index)"
                @showPhoto="prikazi($event)" :item="item"
                @formatChange="onFormatChange($event, index)"
                @quantityChange="onQuantityChange($event, index)">
            </fotografija>
        </div>
        <form-slika :shownPhoto="this.photo" :isVisible="this.showPicture == 'photo'"
            @zatvoriSliku="zatvoriSliku" v-if="this.showPicture == 'photo'">
        </form-slika>
    </div>
</template>

<script>
import FooterBar from "../appBar/FooterBar.vue"
import Fotografija from "./Fotografija.vue"
import FormSlika from "../forme/FormSlika.vue"
import { constants } from 'fs';
import { destinationUrl, ANONYMOUS_USER_TYPE, REGULAR_USER_TYPE } from '../../services/authFetch';
import { getUserInfo, setAlbumKorisnikState, getAlbumKorisnikState, clearAlbumKorisnikState } from '../../services/contextManagement';
import { IMAGE_FORMAT_PRICE_PAIR_LIST } from '../../data/formatPricePairList';
import { preloadImages } from '../../services/preloadingImages';
export default {
    components: {FooterBar, Fotografija, FormSlika},
    data(){
        return {
            password: '',
            select: false,
            items: [],
            itemData: {
                image: {},
                selected: false,
                format: "",
                quantity: 1
            },
            photo: {},
            showPicture: {}
        }
    },
    methods: {
        validacija(){
            if(this.password === ''){
                this.$message({message:"Morate uneti šifru albuma", type: 'warning'})
                return false
            }
            return true
        },
        vratiAlbum(){
            if(!this.validacija())
                return
            fetch(destinationUrl + "/Album/GetAlbumByPassword/?password=" + this.password, {method: 'GET'})
                .then(response => response.ok ? response.json() : new Error())
                .then(result => {
                    this.items = [];
                    result.Success ? 
                        result.Data.Images.forEach(image => {
                            this.items.push({
                                selected: false,
                                format: '',
                                quantity: 1,
                                image: image
                            });
                        }) : 
                        this.$message("Pogresna sifra albuma!");
                    preloadImages(result.Data.Images);
                }).catch(error => console.log(error));
        },
        addImageToSelected(data, index){
            this.$set(this.items, index, {
                ... this.items[index], selected: true, quantity: data.quantity, format: data.format
            });
        },
        removeImageFromSelected(image, index) {
            this.items[index].selected = false;
        },
        prikazi(photo){
            this.photo = photo;
            this.showPicture = 'photo'
        },
        zatvoriSliku(){
            this.showPicture = '';
        },
        dodajUKorpu() {
            setAlbumKorisnikState({items: this.items});
            if(this.items.filter(item => item.selected == true).length == 0) {
                this.$message({message: "Morate izabrati bar jednu fotografiju", type: "warning"});
                return;
            }
            if(getUserInfo().userType == REGULAR_USER_TYPE) {
                clearAlbumKorisnikState();
                if(this.items.length == 0) {
                    this.$message({message: "Morate selektovati bar jednu fotografiju!",type: 'error'})
                    return
                }
                const formData = new FormData();
                formData.append("UserId", getUserInfo().userID);
                this.items.filter(item => item.selected == true).forEach((item, index) => {
                    formData.append("CartItems[" + index + "].ProductType", "Fotografija");
                    formData.append("CartItems[" + index + "].Format", item.format);
                    formData.append("CartItems[" + index + "].Quantity", item.quantity);
                    formData.append("CartItems[" + index + "].Image.Id", item.image.Id);
                    formData.append("CartItems[" + index + "].Image.Title", item.image.Title);
                    formData.append("CartItems[" + index + "].Image.Original.FileId", item.image.Original.FileId);
                    formData.append("CartItems[" + index + "].Image.Original.Url", item.image.Original.Url);
                    formData.append("CartItems[" + index + "].Image.Thumbnail.FileId", item.image.Thumbnail.FileId);
                    formData.append("CartItems[" + index + "].Image.Thumbnail.Url", item.image.Thumbnail.Url);
                    formData.append("CartItems[" + index + "].Image.Large.FileId", item.image.Large.FileId);
                    formData.append("CartItems[" + index + "].Image.Large.Url", item.image.Large.Url);
                    formData.append("CartItems[" + index + "].Image.Medium.FileId", item.image.Medium.FileId);
                    formData.append("CartItems[" + index + "].Image.Medium.Url", item.image.Medium.Url);
                    formData.append("CartItems[" + index + "].Image.Small.FileId", item.image.Small.FileId);
                    formData.append("CartItems[" + index + "].Image.Small.Url", item.image.Small.Url);
                    formData.append("CartItems[" + index + "].Price", this.getCartItemPrice(item));
                });

                for(let index = 0; index < this.items.length; index++) {
                    this.$set(this.items, index, {
                        ...this.items[index], 
                        selected: false,
                        quantity: 1,
                        format: ""
                    });
                }
                
                fetch(destinationUrl + "/Cart/AddToCart", {method: 'POST', body: formData})
                    .then(response => response.ok ? response.json() : new Error())
                    .then(() => this.$message({message: "Uspesno ste dodali fotografije u korpu", type: "success"}))
                    .catch(error => console.log(error));
            }
            else {
                this.$message("Da biste naručili fotografije morate se prijaviti ili registrovati.");
                this.$emit("gotoLogin");
            }
        },
        onFormatChange(format, index) {
            console.log(this.items[index]);
            this.$set(this.items, index, {...this.items[index], format: format});
        },
        onQuantityChange(quantity, index) {
            this.$set(this.items, index, {...this.items[index], quantity: quantity});
        },
        getCartItemPrice(cartItem) {
            const formatPricePair = IMAGE_FORMAT_PRICE_PAIR_LIST.find(item => item.format == cartItem.format);
            return formatPricePair.price;
        }
    },
    mounted: function() {
        const state = getAlbumKorisnikState();
        if(state != null) {
            this.items = state.items;
        }
    }
}
</script>

<style scoped>
.album-korisnik-container{
    display: flex;
    height: 90%;
    width: 100%;
    flex-direction: column;
    overflow: auto;
    background-color: rgba(224, 224, 235, 0.445);
}
.album-fotografije{
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
}
.el-button{
    margin-right: 10px;
    height: 35px;
}
.el-input{
    margin-left: 20px;
}
.dodavanje{
    display: flex;
    flex-direction: row;
    justify-content: center;
    margin-top: 2%;
}
</style>

