<template>
    <div class="album-container">
        <div class="info">
            <label style="font-size:12px; margin-left: 7%;">{{Album.Date}}</label>
            <label style="font-size:12px; margin-left: 7%;">{{Album.Location}}</label>
            <h5 style="font-family:sans-serif; font-size:16px; text-align:center; margin-top:30px; 
                font-family: Arial,Gadget, sans-serif; font-weight: bold;">{{Album.Title}}</h5>
        </div>
        <el-button 
            type="primary" size="mini" 
            style="width:130px; margin-left:5.5px; position:bottom; border-radius:10px;" 
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

<style scoped>
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
    justify-content: flex-start;
}
label{
    margin-bottom: 0%;
}
</style>


