import Vue from "vue";
import App from "./App.vue";
import router from './routes/route'
import Fotograf from './pages/Fotograf.vue'
import Pocetna from './pages/Pocetna.vue'
import Uprava from './pages/Uprava.vue'
import ElementUI from "element-ui";
import "element-ui/lib/theme-chalk/index.css";
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
