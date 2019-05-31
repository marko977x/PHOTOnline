<template>
    <div class="album-korisnik-container">
        <div class="dodavanje" >
            <el-input 
                v-model="password"
                type="password" show-password size="medium"
                style="width:300px; margin-right:50px;"
                placeholder="Unesite šifru albuma">
            </el-input>
            <el-button type="primary" size="mini" style="height:35px;" @click="vratiAlbum">Prikaži Album</el-button>
            <div class="potvrdi">
                <el-button type="danger" size="medium" @click="dodajUKorpu">Poruči </el-button>
            </div>
        </div>
        <div class="album-fotografije">
            <fotografija 
                v-for="image in album.Images" :key="image.Id"
                :imageUrl="image.Thumbnail" @selectPhoto="selektovane($event)"></fotografija>
        </div>
        <!-- <footer-bar></footer-bar> -->
    </div>
</template>

<script>
import FooterBar from "../appBar/FooterBar.vue"
import Fotografija from "./Fotografija.vue"
import { constants } from 'fs';
import { destinationUrl } from '../../services/authFetch';
export default {
    components: {FooterBar, Fotografija},
    data(){
        return {
            password: '',
            select: false,
            album: {}
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
                    console.log(this.album);
                }).catch(error => console.log(error));
        },
        selektovane(event){
            this.select = event;
            console.log(event)
        },
        dodajUKorpu(){
            if(this.select === false){
                this.$message({message: "Morate selektovati bar jednu Fotografiju!",type: 'error'})
                return false
            }
            // ovde treba fetch za dodavanje selektovanih slika u korpu
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
.potvrdi{
    display: flex;
    flex-direction: row-reverse;
    width: 100%;
    height: 35px;
    margin-right: 15px;
}
</style>

