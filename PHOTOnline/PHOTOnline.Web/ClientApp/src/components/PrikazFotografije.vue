<template>
    <div class="fotografija-container">
        <div class="download-delete">
            <el-icon class="el-icon-download"></el-icon>
            <el-icon class="el-icon-delete"></el-icon>
            <el-image :src="source" style="height:100px; width:100px;" />
        </div>
        <h6 style="font-size:10px; text-align:center; position:bottom;">{{naziv}}</h6>
    </div>
</template>

<script>
import {} from 'element-ui'
export default {
    data(){
        return{
            naziv: 'DSC_1567',
            source: "../assets/pictures/evidencija.jpg"
            
        }
    }
    // treba dodati props za naziv fotografije koji ce da se prosledi iz listAlbuma!
}
</script>

<style>
.fotografija-container{
     height: 100px;
    width: 80px;
   /* background: linear-gradient(0deg, #d1d356, #e6e88d );*/
    background: linear-gradient(0deg, #a6e1f0e7, #dcf1f8 );
    margin-top: 15px;
    border-radius: 3px;
    margin-left: 10px;
}
.download-delete{
    height: 87px;
    width: 100%;
}
</style>


