<template>
    <div class="sadrzaj-albuma">
         <div class="dodavanje" style="margin:none;">
             <div class="left">
                <el-button class="el-icon-arrow-left" type="success" size="mini" 
                    style="size:10px;" @click="$emit('zavrsipregled')"></el-button>
                <el-button type="primary" size="mini" style="height:35px; font-family:sans-serif;" class="el-icon-download"> Download Album</el-button>
                 <el-input v-model="PretragaFotografije"
                    size="medium" style="width:300px; margin-left:50px;"
                    placeholder="Unesite naziv fotografije za pretragu">
                </el-input>
                <h6 style="text-align:center; margin-left:20px; margin-top:7px; font-size:14px;">{{Album.Password}}</h6>
            </div>
            <div class="right">
                <el-button type="danger" size="mini" class="el-icon-delete"
                    style="margin-right: 50px; height:35px; font-family:sans-serif;"> Obriši Album</el-button>
            </div>
        </div>
        <div class="sadrzaj-albuma-inner">
            <prikaz-fotografije v-for="(image, index) in Album.Images" :key="index" v-bind:Image="image"
             @showPhoto="prikazi($event)">
            </prikaz-fotografije>
        </div>
        <form-slika :shownPhoto="this.photo"
            @zatvoriSliku="zatvoriSliku" v-if="this.showPicture == 'photo'"></form-slika>
    </div>
</template>

<script>
import PrikazFotografije from "./PrikazFotografije.vue"
import FormSlika from "../forme/FormSlika.vue"
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
            this.showPicture = 'photo'
            console.log(this.photo)
        },
        zatvoriSliku(){
            this.showPicture = ''
        }
    },
    props: ['Album'],
    mounted: function() {
        console.log(this.Album.Images);
    }
}
</script>

<style>
.sadrzaj-albuma{
    display: flex;
    height: 100%;
    width: 100%;
    flex-direction: column;
    overflow: auto;
}
.right{
    width: 50%;
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
.left{
    width: 50%;
    display: flex;
    flex-direction: row;
}
.sadrzaj-albuma-inner{
    height: 100%;
    width: 100%;
    display: flex;
    flex-wrap: wrap;
    flex-direction: row;
}
</style>


