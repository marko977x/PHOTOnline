<template>
    <div class="korisnik-container">
            <div class="kalendar">
            <el-calendar v-model="value" 
            class="kalendar" >
                <template
                    slot="dateCell"
                    slot-scope="{date, data}">
                    <p v-if="vratiZahteve(data)"></p>
                    <div class="element" @click="radi(data.day)">
                     <p :class="data.isSelected ? 'is-active' : ''" >{{data.day.split('-').slice(2).join('-')}}</p>
                    <el-badge v-if="data.isSelected" :value="1" class="item" type="danger" aria-setsize="big">
                    <p :class="data.isSelected ? 'is-active' : ''"></p>
                    </el-badge>
                    </div>
            </template>
            </el-calendar>
        </div>
        <form-zakazi :date="datum" ></form-zakazi>
        <footer-bar></footer-bar>
    </div>
</template>

<script>

import PrikazKalendaraKorisnik from "./PrikazKalendaraKorisnik.vue"
import FormZakazi from "../forme/FormZakazi.vue"
import FooterBar from "../appBar/FooterBar.vue"
import { getUserInfo } from '../../services/contextManagement';

export default {
    components: {PrikazKalendaraKorisnik, FormZakazi, FooterBar},
    data(){
        return{
            value: new Date(),
            datum: '',
            listaZahteva: ['2019-05-24','2019-05-25','2019-05-26','2019-05-27'],
            userId: ''
        }
    },
    methods: {
        radi(date){
            this.datum = date
            // console.log(this.datum)
            //ovde treba da se sredi jer ne vidi lepo datum!!!
        },
        vratiZahteve(data){
           this.listaZahteva.forEach(element => {
               if(data.day == element)
                    data.isSelected = true
           });
        },
        pribaviDatume(){
            // ovde treba fetch za listu datuma!
        }
    },
    beforeMount(){
        this.pribaviDatume()
        this.userId = getUserInfo().userID
    }
}
</script>

<style scoped>
.korisnik-container{
     display: flex;
        height: 90%;
        width: 100%;
        flex-direction: column;
        overflow: auto;
        background-color: rgba(224, 224, 235, 0.445);
}
.element{
    height: 100%;
    width: 100%;
}
.item{
    height: 30px;
    width: 30px;
    font: 20px;
}
.kalendar{
    margin: 20px 100px 50px;
}
footer-bar{
    justify-content: flex-end;
}
</style>


