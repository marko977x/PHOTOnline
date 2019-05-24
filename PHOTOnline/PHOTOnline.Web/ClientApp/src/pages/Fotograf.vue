<template>
    <div class="foto-container">
        <div class="foto-background"></div>
            <custom-bar :list="this.menuItems"  @changeView="setComponent($event)">
            <dodavanje-albuma @zavrsenoDodavanje="this.zavrsiDodavanje" v-if="showComp === 'dodajalbum'"></dodavanje-albuma>
            <prikaz-obaveza v-if="this.showComp === 'raspored'"  @editFinished="this.zavrsiDodavanje"></prikaz-obaveza>
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
import {setPageShown, getPageToShow, getUserInfo, clearUserInfo, clearFormMode} from "../services/contextManagement";

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
            showComp: 'raspored',
            userID: -1,
            userType: 'fotograf'
        }
    },
    methods: {
        radi: function(){
            console.log("Ovo radi!")
        },
        setComponent(index){
            this.showComp = index
            setPageShown(index);
        },
        changeComp: function(event){
            if(event == '')
                this.showComp = 'raspored'
            else
                this.showComp = event;
                setPageShown(this.showComp)
        },
        zavrsiDodavanje(){
            this.showComp = ''
            setPageShown('')
        }
    },
    beforeMount(){
       var index = getPageToShow().page
       this.userID = getUserInfo().userID
       if(index != null){
           this.showComp = index;
           return;
       }
       this.showComp = ''
    }
}
</script>

<style scoped>
    .foto-container{
        height: 100%;
        width: 100%;
        position: absolute;
        top: 0;
        left:0;
        z-index: -1;
        background-size: cover;
        background-position: bottom;
        background-image: linear-gradient(
            rgba(26, 111, 168, 0.555),
            rgba(37, 41, 40, 0.781)
        ),url("../assets/pictures/1.jpg");
    }
   /* .foto-background{
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
    }*/
</style>


