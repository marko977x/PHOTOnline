<template>
    <div class="foto-container">
        <div class="foto-background"></div>
            <custom-header-bar :list="this.menuItems">
            <dodavanje-albuma v-if="s"></dodavanje-albuma>
            <prikaz-obaveza></prikaz-obaveza>
            </custom-header-bar>
    </div>
</template>

<script>
import Button from 'element-ui'
import CustomHeaderBar from "../components/CustomHeaderBar"
import DodavanjeAlbuma from "../components/DodavanjeAlbuma"
import PrikazObaveza from "../components/PrikazObaveza"

export default {
    components: {
        DodavanjeAlbuma,CustomHeaderBar,PrikazObaveza
    },
    data() {
        return {
            menuItems: [
                {
                    key: 1,
                    label: 'Dodaj Album',
                    index: 'dodajalbum'
                    // dodaj sliku!
                },
                {
                    key:2,
                    label: 'Raspored Aktivnosti',
                    index: 'raspored'
                    //slika!
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


