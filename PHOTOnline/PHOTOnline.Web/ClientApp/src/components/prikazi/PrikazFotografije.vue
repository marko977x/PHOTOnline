<template>
    <div class="fotografija-container">
        <div class="download-delete">
            <a :href="`${Image.Original}`" download><el-icon class="el-icon-download"></el-icon></a>
            <el-icon class="el-icon-delete"></el-icon>
            <img :src="Image.Thumbnail" height="100%" width="100%"/>
        </div>
        <h6 style="font-size:10px; text-align:center; position:bottom;">{{naziv}}</h6>
    </div>
</template>

<script>
import {} from 'element-ui'
import slika from "../../assets/pictures/1.jpg"
export default {
    data(){
        return{
            naziv: 'DSC_1567',
            slika: ""
        }
    },
    props: ['Image'],
    mounted: function() {
        console.log(this.Image);
    }
}
</script>

<style scoped>
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


