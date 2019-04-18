import Vue from 'vue'
import VueRouter from 'vue-router'
import Fotograf from '../pages/Fotograf.vue'

Vue.use(VueRouter)

const router = new VueRouter({
    mode: 'history',
    routes: [
        {
            path: '*',
            redirect: '/',
            path: '/fotograf',
        },
        {
            path: '/pocetna',
            name: 'Pocetna',
        }
    ]
})


export default router