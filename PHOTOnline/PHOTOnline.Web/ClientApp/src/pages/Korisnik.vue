<template>
<div class="user-container">
    <header-bar 
        :list="this.menuItems" :korisnik="this.userType"
        @changeView="setComponent($event)">
    </header-bar>
    <zakazivanja-korisnik v-if="this.showComp == 'zakazivanja'" ></zakazivanja-korisnik>
    <prikaz-profila v-if="this.showComp == 'profil'" ></prikaz-profila>
    <album-korisnik v-if="this.showComp == 'albumi'"></album-korisnik>
    <korpa-korisnik v-if="this.showComp == 'korpa'" ></korpa-korisnik>
    <proizvodi v-if="this.showComp == 'proizvodi'"></proizvodi>
    <!-- <footer-bar></footer-bar> -->
</div>
</template>

<script>
import CustomBar from "../components/CustomBar.vue"
import HeaderBar from "../components/appBar/HeaderBar.vue"
import FooterBar from "../components/appBar/FooterBar.vue"
import ZakazivanjaKorisnik  from "../components/Korisnik/ZakazivanjaKorisnik.vue"
import PrikazProfila from "../components/Korisnik/PrikazProfila.vue"
import AlbumKorisnik from "../components/Korisnik/AlbumKorisnik.vue"
import KorpaKorisnik from "../components/Korisnik/KorpaKorisnik.vue"
import Proizvodi from "../components/Korisnik/Proizvodi.vue"
import { setPageShown } from '../services/contextManagement';

export default {
    components: {CustomBar, ZakazivanjaKorisnik,
    PrikazProfila, AlbumKorisnik, KorpaKorisnik, 
    HeaderBar, Proizvodi, FooterBar},
    data() {
        return {
            menuItems: [
                {
                    key: 1,
                    label: 'Zakaži',
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
            showComp: 'profil',
            userType: 'korisnik'
        }
    },
     methods: {
        setComponent(component){
            this.showComp = component;
            console.log(component);
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