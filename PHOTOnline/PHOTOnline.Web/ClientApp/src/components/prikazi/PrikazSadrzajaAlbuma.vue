<template>
    <div class="sadrzaj-albuma">
        <div class="dodavanje" style="margin:none;">
            <div class="left">
                <el-button class="el-icon-arrow-left" type="success" size="mini" 
                    style="size:10px;" @click="$emit('zavrsipregled')"></el-button>
                <div class="naslovi">
                    <h4 style="text-align:center; margin-left:20px; margin-top:7px; font-family: sans-serif;">Naslov:</h4>
                    <h4 style="text-align:center; margin-left:20px; margin-top:7px; font-family: Arial Black, Gadget, sans-serif;">{{Album.Title}}</h4>
                </div>
                <div class="naslovi">
                    <h4 style="text-align:center; margin-left:20px; margin-top:7px; font-family: sans-serif;">Šifra:</h4>
                    <h4 style="text-align:center; margin-left:20px; margin-top:7px; font-family: Arial Black, Gadget, sans-serif;">{{Album.Password}}</h4>
                </div>
            </div>
            <div class="right">
                <el-button type="primary" size="mini" style="height:35px; font-family:sans-serif;" class="el-icon-download"> Download album</el-button>
                <el-button type="danger" size="mini" class="el-icon-delete"
                    style="margin-right: 5%; margin-left: 5%; height:35px; font-family:sans-serif;"
                    @click="deleteAlbum"> Obriši Album
                </el-button>
            </div>
        </div>
        <div class="sadrzaj-albuma-inner">
            <prikaz-fotografije 
                v-for="(image, index) in Album.Images" :key="index" v-bind:Image="image"
                @ImageDeleted="passDeletedImageToParent($event)" @showPhoto="prikazi($event)">
            </prikaz-fotografije>
        </div>
        <form-slika :shownPhoto="this.photo"
            @zatvoriSliku="zatvoriSliku" v-if="this.showPicture == 'photo'">
        </form-slika>
    </div>
</template>

<script>
import PrikazFotografije from "./PrikazFotografije.vue"
import FormSlika from "../forme/FormSlika.vue"
import { destinationUrl } from '../../services/authFetch';
export default {
    components: {PrikazFotografije, FormSlika},
    data(){
        return{
            PretragaFotografije: '',
            showPicture: '',
            photo: {}
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
            fetch(destinationUrl + "/Album/DeleteAlbum/?id=" + this.Album.Id, {method: 'POST'})
                .then(response => response.ok ? response.json() : new Error())
                .then(() => this.$emit('AlbumDeleted'))
                .catch(error => console.log(error));
        }
    },
    props: ['Album'],
    mounted: function() {
        console.log(this.Album.Images);
    }
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


