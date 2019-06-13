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
                    <el-badge v-if="data.isSelected" :value="counts[data.day]" class="item" type="warning" aria-setsize="big">
                        <p :class="data.isSelected ? 'is-active' : ''"></p>
                    </el-badge>
                    </div>
            </template>
            </el-calendar>
        </div>
        <form-zakazi :date="datum" @zakazano="osveziPrikaz"></form-zakazi>
    </div>
</template>

<script>

import PrikazKalendaraKorisnik from "./PrikazKalendaraKorisnik.vue"
import FormZakazi from "../forme/FormZakazi.vue"
import { getUserInfo } from '../../services/contextManagement';
import { apiFetch, destinationUrl } from '../../services/authFetch';

export default {
    components: {PrikazKalendaraKorisnik, FormZakazi},
    data(){
        return{
            value: new Date(),
            datum: '',
            listaZahteva: [],
            datumi: [],
            counts: {},
            userId: ''
        }
    },
    methods: {
        radi(date){
            var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
            var yyyy = today.getFullYear();
            today = yyyy + '-' + mm + '-' + dd  ;
            if(date > today){
                this.datum = date
            }    
            else{
                this.$message({message: "Morate izabrati predstojeći datum!", type: 'warning'})
                this.datum = ''
            }
        },
        vratiZahteve(data){
           this.datumi.forEach(element => {
               if(data.day == element)
                    data.isSelected = true
           });
        },
        pribaviListuZahteva: async function(){
            apiFetch('GET', destinationUrl + "/Request/GetAllRequests")
            .then(result => {
                if(result.Success) {
                    this.listaZahteva = result.Data;
                    this.listaZahteva = this.listaZahteva.filter(x => x.RequestStatus != 2);
                    this.pribaviDatum(this.listaZahteva);
                }
                else this.$message({message: "Došlo je do greske prilikom učitavanja zahteva!", type: 'error'})   
                 }).catch(error => {console.log(error)});
        },
        pribaviDatum(datumi){
            let i =0;
            let novidatumi = [];
            datumi.forEach(el => {
                novidatumi[i++] = el.Date;
            })
            this.datumi = novidatumi;
            this.countDate(this.datumi)
        },
        countDate(datumi){
            var counts = {}
            datumi.forEach(function(x) { counts[x] = (counts[x] || 0)+1; });
            this.counts = counts;
        },
        osveziPrikaz(zahtev){
            this.listaZahteva.push(zahtev);
            this.pribaviDatum(this.listaZahteva);
        }
    },
    beforeMount(){
        this.pribaviListuZahteva()
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
    height: 60px;
    width: 60px;
    font: 20px;
}
.kalendar{
    margin: 20px 100px 50px;
}
footer-bar{
    justify-content: flex-end;
}
/*ovo treba da se postavi za kruic da bude veci, ali mu se iz nekog razloga ne moze pristupiti???*/
.el-badge__content {
    border-radius: 50%;
    height: 40px;
    width: 40px;
}
</style>


