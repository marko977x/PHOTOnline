<template>
<div class="user-container">
    <header-bar></header-bar>
    <user-bar :list="this.menuItems" >
    </user-bar>
    <footer-bar></footer-bar>
</div>
</template>

<script>
import FooterBar from "../components/appBar/FooterBar"
import UserBar from "../components/UserBar.vue"
import HeaderBar from '../components/appBar/HeaderBar.vue'

export default {
    components: {FooterBar,HeaderBar,UserBar},
    data() {
        return {
            menuItems: [
                {
                    key: 1,
                    label: 'Profil',
                    index: 'profil'
                    // dodaj sliku!
                },
                {
                    key:2,
                    label: 'Narudžbine',
                    index: 'raspored'
                    //slika!
                },
                {
                    key:3,
                    label: 'Korpa',
                    index: 'korpa'
                    //slika!
                },
                {
                    key:4,
                    label: 'Zakazivanja',
                    index: 'zakazivanja'
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
      display: flex;
      width: 100%;
      height: 100%;
      position: absolute;
      flex-direction: column;
      overflow: auto;
    background-size: cover;
    background-position: bottom;
    background-image: linear-gradient(
            rgba(26, 111, 168, 0.171),
            rgba(57, 63, 61, 0.205)
        ),url("../assets/pictures/ho.jpg");
  }

</style>