import Vue from "vue";
import App from "./App.vue";
import router from './routes/route'
import ElementUI from "element-ui";
import "element-ui/lib/theme-chalk/index.css";
import Korisnik from "../src/pages/Korisnik"
import Uprava from "../src/pages/Uprava"
import Pocetna from "../src/pages/Pocetna"
import Fotograf from "../src/pages/Fotograf"
import BootstrapVue from "bootstrap-vue";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import locale from 'element-ui/lib/locale/lang/en'

Vue.use(ElementUI, {locale});
Vue.config.productionTip = false;
Vue.use(BootstrapVue);

new Vue({
    router,
    render: 
        h => h(Uprava)
}).$mount("#app");
