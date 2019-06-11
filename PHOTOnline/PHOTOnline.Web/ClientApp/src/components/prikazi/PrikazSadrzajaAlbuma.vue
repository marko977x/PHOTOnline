<template>
    <div class="sadrzaj-albuma">
        <div class="dodavanje" style="margin:none;">
            <div class="left">
                <el-button class="el-icon-arrow-left" type="success" size="mini" 
                    style="size:10px;" @click="onClickBack()"></el-button>
                <div class="naslovi">
                    <h4 style="text-align:center; margin-left:20px; margin-top:7px; font-family: sans-serif;">Naslov:</h4>
                    <h4 style="text-align:center; margin-left:20px; margin-top:7px; font-family: Arial Black, Gadget, sans-serif;">{{album.Title}}</h4>
                </div>
                <div class="naslovi">
                    <h4 style="text-align:center; margin-left:20px; margin-top:7px; font-family: sans-serif;">Šifra:</h4>
                    <h4 style="text-align:center; margin-left:20px; margin-top:7px; font-family: Arial Black, Gadget, sans-serif;">{{album.Password}}</h4>
                </div>
            </div>
            <div class="right">
                <input multiple v-if="this.album.Password == 'home'" type="file" accept="image/*" @change="uploadImages($event)" id="file-input" >
                <el-button v-else type="danger" size="mini" class="el-icon-delete"
                    style="margin-right: 5%; margin-left: 5%; height:35px; font-family:sans-serif;"
                    @click="deleteAlbum"> Obriši album
                </el-button>
                
            </div>
        </div>
        <div class="sadrzaj-albuma-inner">
            <prikaz-fotografije 
                v-for="(image, index) in album.Images" :key="index" v-bind:Image="image"
                @ImageDeleted="passDeletedImageToParent($event)" @showPhoto="prikazi($event)">
            </prikaz-fotografije>
        </div>
        <form-slika :shownPhoto="this.photo"
            @zatvoriSliku="zatvoriSliku" :isVisible="this.showPicture == 'photo'" v-if="this.showPicture == 'photo'">
        </form-slika>
    </div>
</template>

<script>
import PrikazFotografije from "./PrikazFotografije.vue"
import FormSlika from "../forme/FormSlika.vue"
import { destinationUrl } from '../../services/authFetch';
import { closeSpinner, openSpinner } from '../../data/spinner';
export default {
    components: {PrikazFotografije, FormSlika},
    data(){
        return{
            PretragaFotografije: '',
            showPicture: '',
            photo: {},
            album: this.Album,
            Images: []
        }
    },
    methods:{
        prikazi(photo){
            this.photo = photo;
            this.showPicture = 'photo';
        },
        zatvoriSliku(){
            this.showPicture = '';
        },
        passDeletedImageToParent(imageId) {
            this.$emit('ImageDeleted', imageId);
        },
        deleteAlbum() {
            if(this.Album.Password == 'home'){
                this.$message({message: "Nije moguce obrisati album!", type: 'warning'});
                return
            }
            fetch(destinationUrl + "/Album/DeleteAlbum/?id=" + this.Album.Id, {method: 'POST'})
                .then(response => response.ok ? response.json() : new Error())
                .then(() => {
                    this.$message({message: "Uspešno ste obrisali album " + this.Album.Title, type: "success"});
                    this.$emit('AlbumDeleted')
                }).catch(error => console.log(error));
        },
        onClickBack() {
            this.$emit('zavrsipregled', this.Album);
        },
        async uploadImages(event) {
            const promises = [];
            for(let index = 0; index < event.target.files.length; index++) {
                const formData = new FormData();
                formData.append("image", event.target.files[index]);
                console.log(event.target.files[0]);
                promises.push(fetch(destinationUrl + "/Image/UploadImage", {method: 'POST', body: formData})
                    .then(response => {
                        return response.ok ? response.json() : new Error();
                    }).then(result => {
                        console.log(result.Data);
                        this.Images.push(result.Data.Image);
                    }).catch(error => {console.log(error)}));
            }
            await Promise.all(promises);
            this.album.Images = this.album.Images.concat(this.Images);
            this.isUploadingDone = true;
            this.Images = [];
            this.dodajSlike();
        },
        dodajSlike(){
                const formData = new FormData();
                console.log(this.Images)
                formData.append("AlbumId", this.album.Id);
                this.Images.forEach((image, index) => {
                    formData.append("Images[" + index + "].Id", image.Id);
                    formData.append("Images[" + index + "].Title", image.Title);
                    formData.append("Images[" + index + "].Original.FileId", image.Original.FileId);
                    formData.append("Images[" + index + "].Original.Url", image.Original.Url);
                    formData.append("Images[" + index + "].Thumbnail.FileId", image.Thumbnail.FileId);
                    formData.append("Images[" + index + "].Thumbnail.Url", image.Thumbnail.Url);
                    formData.append("Images[" + index + "].Small.FileId", image.Small.FileId);
                    formData.append("Images[" + index + "].Small.Url", image.Small.Url);
                    formData.append("Images[" + index + "].Medium.FileId", image.Medium.FileId);
                    formData.append("Images[" + index + "].Medium.Url", image.Medium.Url);
                    formData.append("Images[" + index + "].Large.FileId", image.Large.FileId);
                    formData.append("Images[" + index + "].Large.Url", image.Large.Url);
                });
                console.log(formData);
                fetch(destinationUrl + "/Album/AddImagesToAlbum", {
                    body: formData,
                    method: 'POST'
                })
                .then(response => response.json())
                .catch(error => console.log(error));
        }
    },
    props: ['Album']
}
</script>

<style scoped>
.sadrzaj-albuma{
    display: flex;
    height: 100%;
    width: 100%;
    flex-direction: column;
    overflow: auto;
}
.dodavanje{
    display: flex;
    flex-direction: row;
    margin: 2%;
}
.right{
    width: 50%;
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.naslovi{
    display: flex;
    flex-direction: row; 
    flex-wrap: wrap;
}
.left{
    width: 50%;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
}
.sadrzaj-albuma-inner{
    width: 100%;
    display: flex;
    flex-wrap: wrap;
    flex-direction: row;
}
@media screen and (max-width: 900px){
    .dodavanje{
        flex-direction: column;
        justify-content: space-between;
        height: 15%;
        width: auto;
    } 

    .left{
        width: 90%;
    }

    .right{
        width: 90%;
    }
}
</style>


