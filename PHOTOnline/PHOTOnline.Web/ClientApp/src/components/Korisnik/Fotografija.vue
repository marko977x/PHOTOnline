<template>
    <div class="fotografije">
        <div class="download-delete">
           <el-checkbox v-model="select" style="color:white;" @change="promena($event)">Odaberi
            </el-checkbox>
            <img :src="imageUrl" height="130px" width="120px" style="border-radius:2px;"/>
        </div>
        <div class="izbor">
            <el-input-number size="small"
                style="width:120px;" v-model="num" :min="1" :max="20">
            </el-input-number>
            <el-select v-model="options[0].value" placeholder="Format Slike" size="mini">
                <el-option
                    v-for="item in options"
                    :key="item.value"
                    :label="item.label"
                    :value="item.value">
                </el-option>
             </el-select>
        </div>
    </div>
</template>

<script>
import { constants } from 'fs';
export default {
    data(){
        return{
            num: 1,
            options: [
                {value: '13x18',label: '13x18'},
                {value: '15x20',label: '15x20'},
                {value: '9x13',label: '9x13'}
            ],
            select: false
        }
    },
    props: ['imageUrl'],
    methods: {
        promena(sel){
            this.$emit("selectPhoto",sel);
            console.log(sel)
        }
    }
}
</script>

<style scoped>
.fotografije{
    height: 210px;
    width: 120px;
   /* background: linear-gradient(0deg, #d1d356, #e6e88d );*/
    background: linear-gradient(0deg, #f1727228, #3a37376c );
    margin-top: 15px;
    border-radius: 3px;
    margin-left: 22px;
}
.download-delete{
    height: 150px;
    width: 100%;
    display: flex;
    flex-direction: column;
}
.el-checkbox{
    margin: 0px;
    padding: 0px;
}
</style>

