<template>
<div class="user-container">
    <!-- <custom-bar :list="this.menuItems"> -->
            <header-bar></header-bar>
            <zakazivanja-korisnik hidden ></zakazivanja-korisnik>
            <prikaz-profila hidden ></prikaz-profila>
            <album-korisnik hidden></album-korisnik>
            <korpa-korisnik hidden ></korpa-korisnik>
            <proizvodi></proizvodi>
    <!-- </custom-bar> -->
    <!-- <footer-bar></footer-bar> -->
</div>
</template>

<script>
import CustomBar from "../components/CustomBar.vue"
import HeaderBar from "../components/HeaderBar.vue"
import ZakazivanjaKorisnik  from "../components/Korisnik/ZakazivanjaKorisnik.vue"
import PrikazProfila from "../components/Korisnik/PrikazProfila.vue"
import AlbumKorisnik from "../components/Korisnik/AlbumKorisnik.vue"
import KorpaKorisnik from "../components/Korisnik/KorpaKorisnik.vue"
import Proizvodi from "../components/Korisnik/Proizvodi.vue"
import vuex from 'vuex'

export default {
    components: {CustomBar, ZakazivanjaKorisnik, PrikazProfila, AlbumKorisnik, KorpaKorisnik, HeaderBar, Proizvodi},
    data() {
        return {
            menuItems: [
                {
                    key: 1,
                    label: 'Albumi',
                    index: 'albumi'
                    // dodaj sliku!
                },
                {
                    key:2,
                    label: 'Proizvodi',
                    index: 'proizvodi'
                    //slika!
                },
                {
                    key:3,
                    label: 'Zakazivanja',
                    index: 'zakazivanja'
                    //slika!
                },
                {
                    key:4,
                    label: 'Korpa',
                    index: 'korpa'
                    //slika!
                }
            ],
            showComp: '',
            userType: 'korisnik'
        }
    },
     methodes: {
        setCompononet(component){
            this.showComp = component;
        },
    }
}
</script>

<style scoped>
.user-container{
        height: 100%;
        width: 100%;
        position: absolute;
        top: 0;
        left:0;
        z-index: -1;
        background-size: cover;
        background-position: bottom;
        background-image: linear-gradient(
            rgba(26, 111, 168, 0.171),
            rgba(57, 63, 61, 0.205)
        ),url("../assets/pictures/ho.jpg");
  }

</style>