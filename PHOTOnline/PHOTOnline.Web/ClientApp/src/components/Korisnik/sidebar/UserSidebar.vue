<template>
         <div class="profil-container">
             <side-bar-profil @changeView="setComponent($event)" :list="this.menuItems" />
             <div class="container">
                <user-profile-info-page v-if="this.showComp == 'profil'" />
                <user-requests v-if="this.showComp == 'zakazivanja'" />
                <narudzbine-korisnik v-if="this.showComp == 'narudzbine'"/>
             </div>
        </div>
</template>

<script>
import FooterBar from "../../appBar/FooterBar.vue";
import SideBarProfil from "../../appBar/SideBarProfil.vue";
import PromenaLozinke from "../../forme/PromenaLozinke.vue";
import {getUserInfo} from "../../../services/contextManagement.js";
import {destinationUrl} from "../../../services/authFetch.js";
import UserProfileInfoPage from "./containers/UserProfileInfo/UserProfileInfoPage.vue";
import UserRequests from "./containers/UserRequests.vue";
import NarudzbineKorisnik from "./containers/NarudzbineKorisnik.vue";
export default {
    components: {
        FooterBar, SideBarProfil, UserRequests, PromenaLozinke, UserProfileInfoPage, NarudzbineKorisnik
    },
    data() {
        return{
            ProfilData: [],
            showComp: 'profil',
            menuItems: [
                {
                    key: 1,
                    label: 'Zakazivanja',
                    index: 'zakazivanja',
                    slika: 'zakazivanje.png'
                },
                {
                    key: 2,
                    label: 'Narudžbine',
                    index: 'narudzbine',
                    slika: 'narudzbine.png'
                },
                {
                    key: 3,
                    label: 'Profil',
                    index: 'profil',
                    slika: 'evidencijaclanova.png'
                    // dodaj sliku!
                }
            ],
            user: {FirstName: '', LastName: '', Email: '', Password: '',
                JMBG: '', Adress: '', PhoneNumber: '' }
        }
    },
    methods: {
        setComponent(component){
            this.showComp = component;
            console.log(component)
        }
    }
}
</script>

<style scoped>
.profil-container{
    width: 100%;
    height: 90%;
    display: flex;
    flex-direction: row;
    background-color: rgba(224, 224, 235, 0.445);
}
.container{
    display: flex;
    justify-content: center;
    height: 100%;
    width: 100%;
    padding: 0px;
}

@media screen and (max-width: 700px){
    .profil-container{
        flex-direction: column;
    }
}
</style>
