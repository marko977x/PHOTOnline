<template>
    <div class="album-container">
        <div class="info">
            <label style="font-size:12px;">{{Album.Date}}</label>
            <label style="font-size:12px;">{{Album.Location}}</label>
            <h5 style="font-family:sans-serif; font-size:16px; text-align:center; margin-top:30px;">
                {{Album.Title}}</h5>
        </div>
        <el-button 
            type="primary" size="mini" 
            style="width:140px; position:bottom; border-radius:10px;" 
            @click="$emit('otvorialbum')"> Otvori </el-button>
    </div>
</template>

<script>
import {} from 'element-ui'
export default {
    data(){
        return{
            info: ['Datum:', 'Lokacija:']
        }
    },
    props: ['Album']
}
</script>

<style>
.album-container{
    height: 180px;
    width: 140px;
   /* background: linear-gradient(0deg, #d1d356, #e6e88d );*/
    background: linear-gradient(0deg, #f17272e7, #c3b3b3 );
    margin-top: 15px;
    border-radius: 10px;
    margin-left: 20px;
}
.info{
    display: flex;
    width: 100%;
    height: 145px;
    flex-direction: column;
}
</style>


