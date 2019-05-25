<template>
    <div class="korisnik-container">
            <div class="kalendar">
            <el-calendar v-model="value" 
            class="kalendar" >
                <template
                    slot="dateCell"
                    slot-scope="{date, data}">
                    <!-- <p :class="data.isSelected ? 'is-active' : ''">
                    </p> -->
                    <el-badge :value="2" class="item" type="warning">
                    <p @click="radi(data.day)" :class="data.isSelected ? 'is-active' : ''">{{data.day.split('-').slice(2).join('-')}}</p>
                    </el-badge>
            </template>
            </el-calendar>
        </div>
        <form-zakazi :date="this.datum" ></form-zakazi>
        <footer-bar></footer-bar>
    </div>
</template>

<script>

import PrikazKalendaraKorisnik from "./PrikazKalendaraKorisnik.vue"
import FormZakazi from "../FormZakazi.vue"
import FooterBar from "../FooterBar.vue"

export default {
    components: {PrikazKalendaraKorisnik, FormZakazi, FooterBar},
    data(){
        return{
            value: new Date(),
            datum: ''
        }
    },
    methods: {
        radi(date){
            this.datum = date
            console.log(this.datum)
        }
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
        background-color: rgba(224, 224, 235, 0.664);
}
.item{
    height: 30px;
    width: 30px;
    font: 20px;
}
.kalendar{
    margin: 50px;
}
footer-bar{
    justify-content: flex-end;
}
</style>


