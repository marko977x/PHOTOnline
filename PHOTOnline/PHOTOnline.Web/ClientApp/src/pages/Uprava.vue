<template>
    <div class="uprava-container">
       <custom-bar :list="menuItems" @changeView="setComponent($event)">
           <evidencija-clanova v-if="this.showComp == 'evidencijaclanova'"></evidencija-clanova>
           <narudzbina v-if="this.showComp == 'narudzbina'"></narudzbina>
           <pocetna-strana hidden></pocetna-strana>
           <album-uprave v-if="this.showComp == 'albumuprave'"></album-uprave>
           <zakazivanja v-if="this.showComp == 'zakazivanja'" ></zakazivanja>
       </custom-bar>
    </div>
</template>

<script>
    import {} from 'element-ui'
    import PrikazObaveza from "../components/PrikazObaveza"
    import CustomBar from "../components/CustomBar"
    import PocetnaStrana from "../components/PocetnaStrana.vue"
    import EvidencijaClanova from "../components/EvidencijaClanova.vue"
    import Narudzbina from "../components/Narudzbina.vue"
    import AlbumUprave from "../components/AlbumUprave.vue"
    import Zakazivanja from "../components/Zakazivanja.vue"
    import {setPageShown, getPageToShow, getUserInfo, clearUserInfo, clearFormMode} from "../services/contextManagement"
export default {
    components: { CustomBar, PrikazObaveza, EvidencijaClanova, Narudzbina, PocetnaStrana, AlbumUprave, Zakazivanja },
    data(){
        return{
            menuItems: [
                {
                    key: 1,
                    label: 'Zakazivanja',
                    index: 'zakazivanja',
                    slika: 'zakazivanje.png'
                },
                {
                    key: 2,
                    label: 'Narudzbine',
                    index: 'narudzbina',
                    slika: 'narudzbine.png'
                },
                {
                    key: 3,
                    label: 'Albumi',
                    index: 'albumuprave',
                    slika: 'album.png'
                },
                {
                    key: 4,
                    label: 'Evidencija članova',
                    index: 'evidencijaclanova',
                    slika: 'evidencijaclanova.png'
                }
            ],
            showComp: 'albumuprave'
        }
        
    },
    methods: {
         setComponent(index){
            this.showComp = index
            setPageShown(index);
         }
    }
}
</script>

<style scoped>
    .uprava-container{
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
            rgba(37, 41, 40, 0.575)
        ),url("../assets/pictures/evidencija.jpg");
    }
</style>


