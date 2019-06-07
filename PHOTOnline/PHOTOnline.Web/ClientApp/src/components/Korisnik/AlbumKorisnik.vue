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
            <el-button type="danger" size="large" @click="dodajUKorpu">Dodaj u korpu </el-button>
        </div>
        <div class="album-fotografije">
            <fotografija 
                v-for="image in album.Images" :key="image._id"
                @selectImage="addImageToSelected($event)"
                @unselectImage="removeImageFromSelected($event)"
                @showPhoto="prikazi($event)" :image="image">
            </fotografija>
        </div>
        <form-slika :shownPhoto="this.photo"
            @zatvoriSliku="zatvoriSliku" v-if="this.showPicture == 'photo'">
        </form-slika>
        <!-- <footer-bar></footer-bar> -->
    </div>
</template>

<script>
import FooterBar from "../appBar/FooterBar.vue"
import Fotografija from "./Fotografija.vue"
import FormSlika from "../forme/FormSlika.vue"
import { constants } from 'fs';
import { destinationUrl } from '../../services/authFetch';
import { getUserInfo } from '../../services/contextManagement';
export default {
    components: {FooterBar, Fotografija, FormSlika},
    data(){
        return {
            password: '',
            select: false,
            album: {},
            selectedImages: [],
            photo: {},
            showPicture: ''
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
                    result.Success ? 
                        this.album = result.Data : 
                        this.$message("Pogresna sifra albuma!");
                }).catch(error => console.log(error));
        },
        addImageToSelected(data){
            this.selectedImages.push(data);
            console.log(this.selectedImages);
        },
        removeImageFromSelected(image) {
            this.selectedImages = this.selectedImages
                .filter(item => item.Image.Id != image.Id);
        },
        prikazi(photo){
            this.photo = photo;
            this.showPicture = 'photo'
        },
        zatvoriSliku(){
            this.showPicture = '';
        },
        dodajUKorpu(){
            if(this.selectedImages == null){
                this.$message({message: "Morate selektovati bar jednu fotografiju!",type: 'error'})
                return
            }
            console.log(this.selectedImages)
            
            const formData = new FormData();
            formData.append("UserId", getUserInfo().userID);
            this.selectedImages.forEach((image, index) => {
                formData.append("CartItems[" + index + "].ProductType", "Fotografija");
                formData.append("CartItems[" + index + "].Format", image.Format);
                formData.append("CartItems[" + index + "].Quantity", image.Quantity);
                formData.append("CartItems[" + index + "].Image.Id", image.Image.Id);
                formData.append("CartItems[" + index + "].Image.Title", image.Image.Title);
                formData.append("CartItems[" + index + "].Image.Original.FileId", image.Image.Original.FileId);
                formData.append("CartItems[" + index + "].Image.Original.Url", image.Image.Original.Url);
                formData.append("CartItems[" + index + "].Image.Thumbnail.FileId", image.Image.Thumbnail.FileId);
                formData.append("CartItems[" + index + "].Image.Thumbnail.Url", image.Image.Thumbnail.Url);
                formData.append("CartItems[" + index + "].Image.Large.FileId", image.Image.Large.FileId);
                formData.append("CartItems[" + index + "].Image.Large.Url", image.Image.Large.Url);
                formData.append("CartItems[" + index + "].Image.Medium.FileId", image.Image.Medium.FileId);
                formData.append("CartItems[" + index + "].Image.Medium.Url", image.Image.Medium.Url);
                formData.append("CartItems[" + index + "].Image.Small.FileId", image.Image.Small.FileId);
                formData.append("CartItems[" + index + "].Image.Small.Url", image.Image.Small.Url);
                formData.append("CartItems[" + index + "].Price", 100);
            });

            fetch(destinationUrl + "/Cart/AddToCart", {method: 'POST', body: formData})
                .then(response => response.ok ? response.json() : new Error())
                .then(result => console.log(result))
                .catch(error => console.log(error));
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
    width: 100px;
}
.el-input{
    margin-left: 20px;
}
.dodavanje{
    display: flex;
    flex-direction: row;
    justify-content: flex-start;
    margin-top: 10px;
}
</style>

