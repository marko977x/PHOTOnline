<template>
    <div class="zakazivanja-container">
        <el-calendar v-model="value" 
        class="kalendar" >
            <template
                slot="dateCell"
                slot-scope="{asdsa, data}" @click="radi">
                <p :class="data.isSelected ? 'is-active' : ''" v-if="zahtevi(data)">
                </p>
                <p :class="data.isSelected ? 'is-active' : ''">{{data.day.split('-').slice(2).join('-')}}</p>
                <div class="obavestenje">
                   <img  v-if="data.isSelected" style="width:30px; height:30px;" src="../assets/bell.png"/>
                </div>
        </template>
        </el-calendar>
        <prikaz-liste-zahteva></prikaz-liste-zahteva>
        <obavesti-korisnika v-if="this.showComp == 'obavestenje'"
             @zatvoriPoruku="zatvori"
             ></obavesti-korisnika>
    </div>
</template>

<script>
import {Calendar} from 'element-ui'
import FormZakazi from "./FormZakazi.vue"
import PrikazListeZahteva from "./PrikazListeZahteva.vue"
import ObavestiKorisnika from "./ObavestiKorisnika.vue"
export default {
    components: {Calendar, FormZakazi, PrikazListeZahteva, ObavestiKorisnika},
    data(){
        return{
            value: new Date(),
            bell: '',
            datum: ['2019-05-24','2019-05-25','2019-07-26','2019-05-27','2019-05-28'],
            showComp: 'obavestenje'
        }
    },
    methods: {
        zahtevi: function(data){
           this.datum.forEach(element => {
               if(data.day == element)
                    data.isSelected = true
           });
        },
        zatvori(){
            this.showComp = ''
        }
    }
    
}
</script>

<style>
.zakazivanja-container{
       display: flex;
        height: 100%;
        width: 100%;
        flex-direction: column;
        overflow: auto;
        background-color: rgba(224, 224, 235, 0.918);
}
.kalendar{
    margin: 50px;
}
.is-active{
    color:rgb(235, 15, 15);
    margin-bottom: 8px;
    align-items: center;
}
.el-calendar-day{
    display: flex;
    flex-direction: column;
    padding: 0;
    background-color:  rgba(229, 240, 248, 0.938)
}
.obavestenje{
    display: flex;
    justify-content: center;
}
td{
    padding: 2px;
    border-radius: 10px;
}
</style>


