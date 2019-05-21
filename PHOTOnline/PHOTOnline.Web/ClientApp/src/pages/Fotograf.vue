<template>
    <div class="foto-container">
        <div class="foto-background"></div>
            <custom-bar :list="this.menuItems">
            <dodavanje-albuma hidden></dodavanje-albuma>
            <prikaz-obaveza ></prikaz-obaveza>
            <pocetna-strana hidden></pocetna-strana>
            </custom-bar>
    </div>
</template>

<script>
import Button from 'element-ui'
import CustomBar from "../components/CustomBar"
import DodavanjeAlbuma from "../components/DodavanjeAlbuma"
import PrikazObaveza from "../components/PrikazObaveza"
import PocetnaStrana from "../components/PocetnaStrana"

export default {
    components: {
        DodavanjeAlbuma,PrikazObaveza,CustomBar,PocetnaStrana
    },
    data() {
        return {
            menuItems: [
                {
                    key: 1,
                    label: 'Dodaj Album',
                    index: 'dodajalbum',
                    slika: 'album.png'
                },
                {
                    key:2,
                    label: 'Raspored Aktivnosti',
                    index: 'raspored',
                    slika: 'zakazivanje.png'
                }
            ],
            showComp: '',
            userType: 'fotograf'
        }

    },
    methodes: {
        setCompononet(component){
            this.showComp = component;

        },
       // zavrsenoDodavanje(){
        //    this.showComp = 'dodajalbum'
       // }
    }

}
</script>

<style scoped>
    .foto-container{
        height: 100%;
        width: 100%;
        position: absolute;
    }
    .foto-background{
        position: absolute;
        top: 0;
        left:0;
        z-index: -1;
        height: 100%;
        width:100%;
        background-size: cover;
        background-position: bottom;
        background-image: linear-gradient(
            rgba(26, 111, 168, 0.555),
            rgba(37, 41, 40, 0.781)
        ),url("../assets/pictures/1.jpg");
    }
</style>


