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
                        <label>{{FirstName}}</label>
                    </div>
                    <div class="profile-info-line">
                        <label>Prezime:</label>
                        <label>{{LastName}}</label>
                    </div>
                
                    <div class="profile-info-line">
                        <label>Email:</label>
                        <label>{{Email}}</label>
                    </div>
                    <div class="profile-info-line">
                        <label>Password:</label>
                        <label>{{Password}}</label>
                    </div>
                    <div class="profile-info-line">
                        <label>JMBG:</label>
                        <label>{{JMBG}}</label>
                    </div>
                    <div class="profile-info-line">
                        <label>Adresa:</label>
                        <label>{{Adress}}</label>
                    </div>
                    <div class="profile-info-line">
                        <label>Broj telefona:</label>
                        <label>{{PhoneNumber}}</label>
                    </div>
                </div>
                <form-zakazivanja v-if="this.showComp == 'zakazivanja'"></form-zakazivanja>
             </div>
        </div>
</template>

<script>
import FooterBar from "../appBar/FooterBar.vue"
import SideBarProfil from "../appBar/SideBarProfil.vue"
import FormZakazivanja from "./FormZakazivanja.vue"
export default {
    components: {
        FooterBar, SideBarProfil, FormZakazivanja
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
             ]
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

.profile-avatar {
    width: 100%;
    display: flex;
    justify-content: center;
    padding-bottom: 20px;
 }

.profil-card {
    padding: 1em;
    width: 60%;
    height: 80%;
    margin-top: 7vh;
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
