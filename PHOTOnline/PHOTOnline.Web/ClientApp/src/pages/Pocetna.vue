<template>
    <div class="main-container">
        <header-bar @signup="Signup" @login='logovanje' :list="this.menuItems" 
             @changeView="setComponent($event)" :korisnik="this.userType"></header-bar>
        <div class="main" v-if="this.showComp == ''">
            <div class="information">
                <div class="info1">
                    <!-- <h2 id="naslov1">Foto Studio Aritonović</h2> -->
                    <el-carousel style=""  class="carousel">
                        <el-carousel-item v-for="photo in photos" :key="photo">
                        <img :src="photo"/>
                        </el-carousel-item>
                    </el-carousel>
                </div>
                <div class="info2">
                    <h3  style="text-align:center;">Foto Studio Aritonović</h3>
                    <p style="font-family:sans-serif; font-size:16px;">Fotografska radnja Foto Aritonović osnovana je 1991 godine u Zitkovcu
                        , malom mestu blizu Aleksinca sa ciljem da zabelezi najepse trenutke života naših mušterija sa poverenjem
                        dužim od 20 godina. Profesionalna fotografisanja i snimanja svih vrsta proslava. 
                    </p>
                    <narucivanje-fotografija
                         style="height:100px; width:100%; margin:0px; margin-top:10px; font-size:10px;">
                    </narucivanje-fotografija>
                </div>
            </div>
            <!-- <el-carousel style=""  class="carousel">
                <el-carousel-item v-for="photo in photos" :key="photo">
                <img :src="photo"/>
                </el-carousel-item>
            </el-carousel> -->
        </div>
        <album-korisnik v-if="this.showComp == 'albumi'" @gotoLogin='logovanje'></album-korisnik>
        <proizvodi v-if="this.showComp == 'proizvodi'"></proizvodi>
        <login v-if="this.showComp == 'login'" @closeLoginForm="signupEnd" @goToSignUpForm="Signup"></login>
        <form-signup v-if="this.showComp == 'signup'" @zavrsiPrijavu="signupEnd" ></form-signup>
        <footer-bar></footer-bar>
    </div>
</template>

<script>
 import HeaderBar from '../components/appBar/HeaderBar.vue'
 import FooterBar from '../components/appBar/FooterBar.vue'
 import Login from "../components/forme/Login.vue"
 import FormSignup from "../components/forme/FormSignup.vue"
 import AlbumKorisnik from "../components/Korisnik/AlbumKorisnik.vue"
 import Proizvodi from "../components/Korisnik/Proizvodi.vue"
 import slika1 from "../assets/pictures/p1.jpg"
import slika2 from "../assets/pictures/p2.jpg"
import slika3 from "../assets/pictures/p3.jpg"
import slika4 from "../assets/pictures/p4.jpg"
 import slika5 from "../assets/pictures/p5.jpg"
 import NarucivanjeFotografija from "../components/Korisnik/NarucivanjeFotografija.vue"
import { setPageShown } from '../services/contextManagement';
 
export default {
    components: { HeaderBar, FooterBar, Login, FormSignup, NarucivanjeFotografija,
                AlbumKorisnik, Proizvodi },
    data() {
        return {
            photos:[
                slika1,
                slika2,
                slika3,
                slika4,
                slika5
            ],
            count: 0,
            showComp:'',
            menuItems: [
                {
                    key: 1,
                    label: 'Zakazivanja',
                    index: 'zakazivanja'
                },
                {
                    key:2,
                    label: 'Albumi',
                    index: 'albumi'
                },
                {
                    key:3,
                    label: 'Proizvodi',
                    index: 'proizvodi'
                }
            ],
            userType: 'pocetna',
            showComp: ''
        }
    },
    methods: {
        Signup: function(){
            this.showComp = 'signup'
        },
        logovanje: function(){
            this.showComp = 'login'
        },
        signupEnd: function(){
            this.showComp = ''
            setPageShown('')
        },
         setComponent(component){
             if(component == 'zakazivanja') this.showComp = 'login'
             else  this.showComp = component;
        }
    }
}
</script>

<style scoped>
    .el-carousel__item h3 {
        font-size: 18px;
        opacity: 0.75;
        line-height: 500px;
        margin: 0;
    }
    img{
        position: absolute;
        height: 100%;
        width:100%;
    }
    .carousel el-carousel el-carousel--horizontal{
        height: 100%;
        width: 100%;
    }
    .el-carousel__item:nth-child(n) {
        background-color: #99a9bf;
        height: 620px;
    }
    .carousel{
        height: 630px;
        width: 100%;
        margin-left: 50px;
        border-radius: 5px;
    }
    .main-container{
        display: flex;
        width: 100%;
        height: 100%;
        position: absolute;
        flex-direction: column;
        justify-content: space-between;
        overflow: auto;
        margin-left: auto;
        margin-right: auto;
        background-size: cover;
        background-position: bottom;
        background-image: linear-gradient(
                rgba(26, 111, 168, 0.171),
                rgba(57, 63, 61, 0.205)
            ),url("../assets/pictures/ho.jpg");
    }
    .el-carousel__container{
        height: 100%;
        width: 100%;
    }
    .main{
        display: flex;
        flex-direction: column;
        
    }
    .information{
        width: 100%;
        height: 870px;
        display: flex;
        flex-direction: row;
        padding-right: 30px;
        padding-top: 20px;
    }
    .info1{
        width: 80%;
        align-items: center;
        justify-content: center;
        display: flex;
        font-family: sans-serif;
        margin-left: 20px;
    }
    .info2{
        width: 40%;
        height: 73%;
        padding: 60px 60px 60px;
        padding-top: 80px;
        margin-top: 110px;
        justify-content: center;
        margin-bottom: 70px;
        margin-left: 100px;
        background-color: rgba(231, 231, 236, 0.801);
        border-radius: 8px;
        transition-duration: 500ms;
    }
    .info2:hover{
        background-color: rgb(231, 231, 236);
    }
    #naslov1{
        color:white; 
        font-size:100px;
        margin-left:30px;
        font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva;
    }
    @media screen and (max-width: 995px){
        .main-container{
            display: -webkit-box;
        }
    }

    @media screen and (max-width: 800px) {
        .information{
            flex-direction: column;
            height: 800px;
            padding: 10px;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        #naslov1{
            font-size: 60px;
            padding: 0;
            margin-bottom: 100px;

        }
        .info1{
            width: 100%;
            align-items: center;
            display: flex;
            justify-content: center;
        }
        .info2{
            width: 100%;
            margin: 0;
            padding: 15px;
            justify-content: center;
        }
        .carousel{
            height: 350px;
            width: 100%;
            margin-left: 0px;
            margin-bottom: 20px;
            border-radius: 5px;
        }
        .el-carousel__item:nth-child(n) {
                background-color: #99a9bf;
                height: 340px;
        }
        @media screen and (max-width: 390px){
            #naslov1{
                font-size: 50px;
            }
            .carousel{
                margin: 0;
            }
        }
    }
</style>

