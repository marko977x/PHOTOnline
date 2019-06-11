<template>
    <div class="main-container">
        <header-bar :list="this.menuItems" @showHomePage="setComponent($event)"
             @changeView="setComponent($event)" :type="this.userType">
        </header-bar>
        <div class="main" v-if="this.showComp == 'pocetna'">
            <el-carousel height="100%" :interval="5000" class="slideshow">
                <el-carousel-item v-for="photo in this.Album.Images" :key="photo.id">
                    <img :src="photo.Large.Url"/>
                </el-carousel-item>
            </el-carousel>
            <div class="information">
                <div class="info2">
                    <h3>Foto Studio Aritonović</h3>
                    <p>Fotografska radnja Foto Aritonović osnovana je 1991 godine u Žitkovcu
                        , malom mestu blizu Aleksinca sa ciljem da zabeleži najepše trenutke života naših mušterija sa poverenjem
                        dužim od 20 godina. Profesionalna fotografisanja i snimanja svih vrsta proslava. 
                    </p>
                </div>
            </div>
        </div>
        <album-korisnik v-if="this.showComp == 'albumi'"></album-korisnik>
        <proizvodi v-if="this.showComp == 'proizvodi'"></proizvodi>
        <korpa-korisnik v-if="this.showComp == 'korpa'" ></korpa-korisnik>
        <zakazivanja-korisnik v-if="this.showComp == 'zakazivanja'" ></zakazivanja-korisnik>
        <user-sidebar v-if="this.showComp == 'profil'" ></user-sidebar>
        <footer-bar class="footer"></footer-bar>
    </div>
</template>

<script>
import HeaderBar from '../components/appBar/HeaderBar.vue'
import FooterBar from '../components/appBar/FooterBar.vue'
import AlbumKorisnik from "../components/Korisnik/AlbumKorisnik.vue"
import Proizvodi from "../components/Korisnik/Proizvodi.vue"
import NarucivanjeFotografija from "../components/Korisnik/NarucivanjeFotografija.vue"
import { setPageShown, getPageToShow, getUserInfo, setUserInfo } from '../services/contextManagement';
import UserSidebar from "../components/Korisnik/sidebar/UserSidebar.vue";
import KorpaKorisnik from "../components/Korisnik/KorpaKorisnik.vue";
import ZakazivanjaKorisnik from "../components/Korisnik/ZakazivanjaKorisnik.vue";
import { ANONYMOUS_USER_TYPE, ALBUM_PASSWORD } from '../services/authFetch';
import { apiFetch, destinationUrl } from '../services/authFetch';
import { preloadImages } from '../services/preloadingImages';
 
export default {
    components: { HeaderBar, FooterBar, NarucivanjeFotografija, AlbumKorisnik, Proizvodi, 
        UserSidebar, Proizvodi, KorpaKorisnik, ZakazivanjaKorisnik },
    data() {
        return {
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
            userType: '',
            showComp: 'pocetna',
            Album: {},
            preloadedImages: []
        }
    },
    methods: {
        setComponent(component){
            this.showComp = component;
            setPageShown(this.showComp);
        },
         loadAlbum() {
            apiFetch('GET', destinationUrl + "/Album/GetAlbumByPassword?=" + ALBUM_PASSWORD)
            .then(result => {
                if(result.Success) {
                    this.Album = result.Data;
                    this.preloadedImages = preloadImages(this.Album.Images);
                }
            }).catch(error => {console.log(error)});
        }
    },
    mounted: function() {
        setPageShown("Pocetna");
        if(getUserInfo().userType == undefined){
            setUserInfo('',ANONYMOUS_USER_TYPE);
        }
        this.userType = getUserInfo().userType;
        this.loadAlbum();
        this.showComp = "pocetna";
    }
}
</script>

<style scoped>
    img {
        height: 100%;
        width:100%;
        position: relative;
    }

    .slideshow {
        width: 100%;
        height: 100%;
        overflow: hidden;
        z-index: 2;
    }

    .main-container {
        width: 100%;
        height: 100%;
        position: absolute;
        background-size: cover;
        background-position: bottom;
        /* background-image: linear-gradient(
            rgba(26, 111, 168, 0.171),
            rgba(57, 63, 61, 0.205)
        ),url("../assets/pictures/ho.jpg"); */
    }

    .main {
        height: 100%;
        z-index: 5;
    }

    .information {
        /* width: 100%; */
        /*height: 100%;*/
        position: absolute;
        top: 15%;
        bottom: 15%;
        left: 55%;
        right: 5%;
        z-index: 4;
    }

    .info2{
        width: 100%;
        height: 70%;
        padding: 60px 60px;
        padding-top: 80px;
        margin-top: 100px;
        justify-content: center;
        background-color: rgba(231, 231, 236, 0.4);
        border-radius: 8px;
    }

    p {
        font-family:sans-serif;
        font-size:18px;
        color: black;
        text-align: center;
    }

    h3 {
        text-align: center;
    }

  @media screen and (max-width: 800px) {
      .information{
          flex-direction: column;
          height: 800px;
          margin: 0px;
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



// .main-container{
//         display: flex;
//         width: 100%;
//         height: 100%;
//         position: absolute;
//         flex-direction: column;
//         justify-content: space-between;
//         overflow: auto;
//         margin-left: auto;
//         margin-right: auto;
//         background-size: cover;
//         background-position: bottom;
//         background-image: linear-gradient(
//                 rgba(26, 111, 168, 0.171),
//                 rgba(57, 63, 61, 0.205)
//             ),url("../assets/pictures/ho.jpg");
//     }