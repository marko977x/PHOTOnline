<template>
    <div class="main-container">
        <header-bar :list="this.menuItems" @showHomePage="setComponent($event)"
             @changeView="setComponent($event)" :type="this.userType">
        </header-bar>
        <div class="main" v-if="this.showComp == 'pocetna'">
            <el-carousel height="100%" class="slideshow">
                <el-carousel-item v-for="photo in photos" :key="photo">
                    <img :src="photo"/>
                </el-carousel-item>
            </el-carousel>
            <div class="information">
                <div class="info2">
                    <h3>Foto Studio Aritonović</h3>
                    <p>Fotografska radnja Foto Aritonović osnovana je 1991 godine u Zitkovcu
                        , malom mestu blizu Aleksinca sa ciljem da zabelezi najepse trenutke života naših mušterija sa poverenjem
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
        <footer-bar class="footer" v-if="this.showComp != 'proizvodi'"></footer-bar> 
    </div>
</template>

<script>
 import HeaderBar from '../components/appBar/HeaderBar.vue'
import FooterBar from '../components/appBar/FooterBar.vue'
import AlbumKorisnik from "../components/Korisnik/AlbumKorisnik.vue"
import Proizvodi from "../components/Korisnik/Proizvodi.vue"
import slika1 from "../assets/pictures/p1.jpg"
import slika2 from "../assets/pictures/p2.jpg"
import slika3 from "../assets/pictures/p3.jpg"
import slika4 from "../assets/pictures/p4.jpg"
import slika5 from "../assets/pictures/p5.jpg"
import NarucivanjeFotografija from "../components/Korisnik/NarucivanjeFotografija.vue"
import { setPageShown, getPageToShow, getUserInfo, setUserInfo } from '../services/contextManagement';
import UserSidebar from "../components/Korisnik/sidebar/UserSidebar.vue";
import KorpaKorisnik from "../components/Korisnik/KorpaKorisnik.vue";
import ZakazivanjaKorisnik from "../components/Korisnik/ZakazivanjaKorisnik.vue";
import { ANONYMOUS_USER_TYPE } from '../services/authFetch';
 
export default {
    components: { HeaderBar, FooterBar, NarucivanjeFotografija, AlbumKorisnik, Proizvodi, 
        UserSidebar, Proizvodi, KorpaKorisnik, ZakazivanjaKorisnik },
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
            userType: '',
            showComp: 'pocetna'
        }
    },
    methods: {
        setComponent(component){
            this.showComp = component;
            setPageShown(this.showComp);
        }
    },
    mounted: function() {
        setPageShown("Pocetna");
        this.userType = getUserInfo().userType;
        this.showComp = "pocetna";
        console.log(getUserInfo().userType);
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
        height: 100%;
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
        justify-content: center;
        background-color: rgba(231, 231, 236, 0.4);
        border-radius: 8px;
    }

    p {
        font-family:sans-serif;
        font-size:18px;
        color: black;
    }

    h3 {
        text-align: center;
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