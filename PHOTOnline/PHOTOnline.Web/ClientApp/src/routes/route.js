import Vue from 'vue'
import VueRouter from 'vue-router'
import Fotograf from '../pages/Fotograf.vue'
import Uprava from '../pages/Uprava.vue'
import Pocetna from '../pages/Pocetna'
import Korisnik from '../pages/Korisnik.vue'
import { getUserInfo } from '../services/contextManagement'
import { UserTypes, ANONYMOUS_USER_TYPE, PHOTOGRAPH_USER_TYPE, ADMIN_USER_TYPE } from '../services/authFetch';

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
            path: '/fotograf',
            name: 'Fotograf',
            component: Fotograf
        },
        {
            path: '/korisnik',
            name: 'Korisnik',
            component: Korisnik
        },
        {
            path: '*',
            component: Pocetna
        }
    ]
})

router.beforeEach((to, from, next) => {
    if (getUserInfo().userType == ANONYMOUS_USER_TYPE && (to.path != '/pocetna' || to.path == '/'))
        next("/pocetna");
    else if (getUserInfo().userType == PHOTOGRAPH_USER_TYPE || getUserInfo().userType == ADMIN_USER_TYPE) {
        let userType = getUserInfo().userType;
        console.log(userType);
        if (userType != null && to.path != ("/" + UserTypes[userType]))
            next("/" + UserTypes[userType]);
    }
    next();
});

export default router