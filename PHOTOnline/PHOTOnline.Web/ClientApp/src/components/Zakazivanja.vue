<template>
    <div class="zakazivanja-container">
        <el-calendar v-model="value" 
        class="kalendar" >
            <template
                slot="dateCell"
                slot-scope="{asdsa, data}">
                <p :class="data.isSelected ? 'is' : ''">
                {{ data.day.split('-').slice(1).join('-') }}
                <el-icon v-if="data.isSelected" class="el-icon-bell"></el-icon>
                </p>
        </template>
        </el-calendar>
    </div>
</template>

<script>
import {Calendar} from 'element-ui'
import FormZakazi from "./FormZakazi.vue"
    import locale from 'element-ui/lib/locale/lang/en'
//import bell from "../assets/narudzbine.png"
export default {
    components: {Calendar, FormZakazi, locale},
    data(){
        return{
            value: new Date(),
            bell: '',
        }
    },
    methods: {
        fja: function(data){
            console.log(data)
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
el-calendar{
    height: 200px;
    width: 300px;
}
.kalendar{
    margin: 50px;
}
.is{
    color:red;
    background-color: blue;
}
.el-calendar-day{
    background-color: yellow;
}
</style>


