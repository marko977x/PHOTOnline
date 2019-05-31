import Vue from 'vue'
import VueRouter from 'vue-router'
import Fotograf from '../pages/Fotograf.vue'
import Uprava from '../pages/Uprava.vue'
import Pocetna from '../pages/Pocetna'
import Korisnik from '../pages/Korisnik.vue'
import {getCredentials} from '../services/authFetch'
import {getUserInfo} from '../services/contextManagement'

Vue.use(VueRouter)

const router = new VueRouter({
    mode: 'history',
    routes: [
        {
            path: '/pocetna',
            name: 'Pocetna',
            component: Pocetna
        },
        {
            path: '/uprava',
            name: 'Uprava',
            component: Uprava
        },
        {
            path:'/fotograf',
            name: 'Fotograf',
            component: Fotograf
        },
        {
            path: '/korisnik',
            name: 'Korisnik',
            component: Korisnik
        }
    ]
})

    router.beforeEach((to, from, next) => {
        console.log(getUserInfo().userID);
        if (getUserInfo().userID == null && (to.path != '/pocetna' || to.path == '/' ))
            next("/pocetna")
        else {
            let x = getUserInfo().userType
            if (x != null && to.path != ("/" + "fotograf"))
               next("/" + "fotograf")
        }
        next()
    });

export default router