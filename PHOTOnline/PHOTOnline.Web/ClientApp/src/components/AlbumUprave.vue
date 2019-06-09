<template>
    <div class="albumuprave-container">
        <div class="dodavanje"  v-if="showComp == 'albumi'" >
            <el-button type="primary" size="mini" style="height:35px;" @click="dodajAlbum">Dodaj album</el-button>
            <el-input v-model="Pretraga" size="medium" placeholder="Unesite naziv albuma za pretragu" @input="filtriraj()">
            </el-input>
        </div>
        <div class="albumi">
            <div v-for="(album, index) in FiltriraniAlbumi" v-bind:key="index">
                <prikaz-albuma 
                    v-bind:Album="album" 
                    @otvorialbum="prikaziAlbum(index)" 
                    v-if="showComp == 'albumi'">
                </prikaz-albuma>
            </div>
        </div>
        <dodavanje-albuma  @zavrsenoDodavanje="reloadPage" v-if="showComp === 'dodajalbum'"></dodavanje-albuma>
        <prikaz-sadrzaja-albuma 
            v-bind:Album="Albums[OpenedAlbumIndex]" 
            v-if="showComp == 'prikazalbuma'" 
            @zavrsipregled='reloadPage'
            @ImageDeleted="DeleteImage($event)"
            @AlbumDeleted="reloadPage">
        </prikaz-sadrzaja-albuma>
    </div>
</template>

<script>
import PrikazAlbuma from "./prikazi/PrikazAlbuma"
import DodavanjeAlbuma from "./DodavanjeAlbuma.vue"
import PrikazSadrzajaAlbuma from "./prikazi/PrikazSadrzajaAlbuma"
import {setOpenedAlbumId} from "../services/contextManagement";
import { apiFetch, destinationUrl } from '../services/authFetch';
export default {
    components: {PrikazAlbuma, DodavanjeAlbuma, PrikazSadrzajaAlbuma},
    data(){
        return{
            Pretraga: '',
            showComp: 'albumi',
            Albums: [],
            FiltriraniAlbumi: [],
            OpenedAlbumIndex: 0,
            spinner: {}
        }
    },
    methods:{
        dodajAlbum(){
            this.showComp = 'dodajalbum'
        },
        reloadPage(){
            this.showComp = 'albumi';
            this.loadAlbums();
        },
        prikaziAlbum(index){
            this.showComp = 'prikazalbuma'
            this.OpenedAlbumIndex = index;
            setOpenedAlbumId(this.Albums[this.OpenedAlbumIndex].Id);
        },
        DeleteImage(imageId) {
            this.Albums[this.OpenedAlbumIndex].Images = 
                this.Albums[this.OpenedAlbumIndex].Images
                    .filter(image => image.Id != imageId);
        },
        loadAlbums() {
            this.openSpinner();
            apiFetch('GET', destinationUrl + "/Album/GetAllAlbums").then(result => {
                if(result.Success) {
                    this.Albums = result.Data;
                    this.FiltriraniAlbumi = this.Albums.slice();
                }
                this.closeSpinner();
            }).catch(error => {console.log(error)});
        },
        filtriraj(){
            if(this.Pretraga == ''){
                this.FiltriraniAlbumi = this.Albums.slice();
            }
            else{
                this.FiltriraniAlbumi.splice(0,this.FiltriraniAlbumi.length);
                this.Albums.forEach(element => {
                    if(element.Title.includes(this.Pretraga)){
                        this.FiltriraniAlbumi.push(Object.assign({},element));
                    }
                });
            }
        },
        openSpinner() {
            this.spinner = this.$loading({
                text: 'Loading',
                spinner: 'el-icon-loading',
                background: 'rgba(0, 0, 0, 0.75)'
            });
        },
        closeSpinner() {
            this.spinner.close();
        }
    },
    mounted: function() {
        this.loadAlbums();
    }
}
</script>

<style scoped>
.albumuprave-container{
    display: flex;
    height: 100%;
    width: 100%;
    flex-direction: column;
    overflow: auto;
    background-color: rgba(224, 224, 235, 0.918);
}
.dodavanje{
    width: 98%;
    height: 7%;
    margin-top: 15px;
    margin-left: 21px;
    margin-right: 21px;
    display: flex;

}
.albumi{
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
}

.el-input{
    width:50%; 
    margin-left:25%; 
    margin-right:25%;
}

@media screen and (max-width: 700px){
    .dodavanje{
        flex-direction: column;
        justify-content: space-between;
        height: 8%;
        width: auto;
    }

    .el-input{
        width: auto;
        margin: 0 0;
    }    
}
</style>


