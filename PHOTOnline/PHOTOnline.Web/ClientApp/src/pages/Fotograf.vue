<template>
    <div class="foto-kontejner">
        <div class="foto-background"></div>
            <dodavanje-albuma @zavrsiDodavanje="this.zavrsenoDodavanje()" ></dodavanje-albuma>
    </div>
</template>

<script>
import Button from 'element-ui'
import DodavanjeAlbuma from "../components/DodavanjeAlbuma"

export default {
    components: {
        DodavanjeAlbuma
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
        zavrsenoDodavanje(){
            this.showComp = 'dodajalbum'
            console.log(this.showComp);
        }
    }

}
</script>

<style scoped>
    .foto-kontejner{
        height: 100%;

    }
    .foto-background{
        position: absolute;
        top: 0;
        left:0;
        z-index: -1;
        height: 100%;
        width:100%;
        background-size: cover;
        background-image: linear-gradient(
            rgba(179, 51, 46, 0.452),
            rgba(185, 190, 133, 0.466)
        ),url("../assets/pictures/1.jpg");
    }
    .stranica{
        background-color:rgba(6, 125, 180, 0.733);
        height: 100%;
        width: 100%;
    }
</style>


