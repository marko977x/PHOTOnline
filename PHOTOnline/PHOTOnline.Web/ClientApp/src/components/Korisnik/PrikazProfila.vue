<template>
         <div class="profil-container">
             <side-bar-profil @changeView="setComponent($event)" :list="this.menuItems"></side-bar-profil>
             <div class="container">
                <div class="profil-card" v-if="this.showComp == 'profil'">
                    <div class="profile-avatar"><img
                        style="min-width: 60px; min-height: 60px; max-width: 100px; max-height: 100px;"
                        src="../../assets/profileAvatar.png"/>
                    </div>
                    <div class="profile-info-line">
                        <label>Ime:</label>
                        <label>{{user.FirstName}}</label>
                    </div>
                    <div class="profile-info-line">
                        <label>Prezime:</label>
                        <label>{{user.LastName}}</label>
                    </div>
                
                    <div class="profile-info-line">
                        <label>Email:</label>
                        <label>{{user.Email}}</label>
                    </div>
                    <div class="profile-info-line">
                        <label>Password:</label>
                        <label>{{user.Password}}</label>
                    </div>
                    <div class="profile-info-line">
                        <label>Adresa:</label>
                        <label>{{user.Adress}}</label>
                    </div>
                    <div class="profile-info-line">
                        <label>Broj telefona:</label>
                        <label>{{user.PhoneNumber}}</label>
                    </div>
                    <div class="dugme">
                    <el-button class="dugme-lozinka" type="primary" @click="promeniLozinku"> Promeni Lozinku</el-button>
                    </div>
                     <promena-lozinke></promena-lozinke>
                </div>
                <form-zakazivanja v-if="this.showComp == 'zakazivanja'"></form-zakazivanja>
             </div>
        </div>
</template>

<script>
import FooterBar from "../appBar/FooterBar.vue"
import SideBarProfil from "../appBar/SideBarProfil.vue"
import FormZakazivanja from "./FormZakazivanja.vue"
import PromenaLozinke from "../forme/PromenaLozinke.vue"
import {getUserInfo} from "../../services/contextManagement";
import {destinationUrl} from "../../services/authFetch";
export default {
    components: {
        FooterBar, SideBarProfil, FormZakazivanja, PromenaLozinke
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
        },
         pribaviKorisnika(){
            let userId = getUserInfo().userID;
            console.log(userId)
            fetch(destinationUrl + '/User/GetUserById/?id=' + userId, {method: "GET"})
                .then(response => response.ok ? response.json() : new Error())
                .then(result => {
                    console.log(result)
                    this.user.FirstName = result.Data.FirstName
                    this.user.LastName = result.Data.LastName
                    this.user.Email = result.Data.Email
                    this.user.Password = "*****"
                    this.user.Adress = result.Data.Address
                    this.user.PhoneNumber = result.Data.PhoneNumber
                })
        }
    },
    beforeMount(){
        this.pribaviKorisnika()
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
.dugme-lozinka{
    width: 200px;
    font-size: 15px;
}
.dugme{
     display: flex;
     height: 100px;
    justify-content: center;
    align-items: center;
}
.profile-avatar {
    width: 100%;
    display: flex;
    justify-content: center;
    padding-bottom: 20px;
 }

.profil-card {
    padding: 1em;
    width: 60%;
    height: 90%;
    margin-top: 3vh;
    background: rgba(240, 240, 255, 0.8);
    border-radius: 10px;
    display: flex;
    flex-direction: column;
    justify-content: center;
}

.profile-info-line {
    width: 80%;
    display: flex;
    flex-direction: row;
    align-items: center;
    margin: 0 auto;     
    }

.profile-info-line label {
    width: 40%;
    font-size: 1.35vw;
}

.profile-info-line label + label {
    color: rgba(0, 0, 0, 0.7)
}
@media screen and (max-width: 700px){
    .profil-container{
        flex-direction: column;
    }
}
</style>
