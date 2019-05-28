<template>
    <div class="albumuprave-container">
        <div class="dodavanje"  v-if="showComp == 'albumi'" >
            <el-button type="primary" size="mini" style="height:35px;" @click="dodajAlbum">Dodaj Album</el-button>
            <el-input
                v-model="Pretraga" size="medium"
                style="width:600px; margin-left:220px; margin-right:205px;"
                placeholder="Unesite naziv albuma za pretragu">
            </el-input>
        </div>
        <div class="albumi" v-for="(album, index) in Albums" v-bind:key="index">
            <prikaz-albuma 
                v-bind:Album="album" 
                @otvorialbum="prikaziAlbume(index)" 
                v-if="showComp == 'albumi'">
            </prikaz-albuma>
        </div>
        <dodavanje-albuma  @zavrsenoDodavanje="zavrsiDodavanje" v-if="showComp === 'dodajalbum'"></dodavanje-albuma>
        <prikaz-sadrzaja-albuma v-bind:Album="Albums[OpenedAlbumIndex]" v-if="showComp == 'prikazalbuma'" 
            @zavrsipregled='zavrsiDodavanje'></prikaz-sadrzaja-albuma>
    </div>
</template>

<script>
    import PrikazAlbuma from "./prikazi/PrikazAlbuma"
    import DodavanjeAlbuma from "./DodavanjeAlbuma.vue"
    import PrikazSadrzajaAlbuma from "./prikazi/PrikazSadrzajaAlbuma"
import { apiFetch, destinationUrl } from '../services/authFetch';
export default {
    components: {PrikazAlbuma, DodavanjeAlbuma, PrikazSadrzajaAlbuma},
    data(){
        return{
            Pretraga: '',
            showComp: 'albumi',
            Albums: [],
            OpenedAlbumIndex: 0
        }
    },
    methods:{
        dodajAlbum(){
            this.showComp = 'dodajalbum'
        },
        zavrsiDodavanje(){
            this.showComp = 'albumi'
        },
        prikaziAlbume(index){
            this.showComp = 'prikazalbuma'
            this.OpenedAlbumIndex = index;
            console.log(this.OpenedAlbumIndex);
        }
    },
    mounted: function() {
        apiFetch('GET', destinationUrl + "/Album/GetAllAlbums").then(result => {
            if(result.Success) this.Albums = result.Data;
            console.log(this.Albums);
        }).catch(error => {console.log(error)});
    }
}
</script>

<style>
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
    display: flex;

}
.albumi{
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
}
</style>


