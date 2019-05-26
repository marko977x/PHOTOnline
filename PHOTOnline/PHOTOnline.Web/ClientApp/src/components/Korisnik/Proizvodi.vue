<template>
    <div class="proizvodi-container">
        <div class="lista-proizvoda">
            <div v-for="item in proizvodi" :key="item.value" :list="proizvodi">
                <template>
    <div class="prikaz-proizvoda-container">
        <div class="part1">
            <img class="slika" v-bind:src="item.slika" />
        </div>
        <div class="part2">
            <p>{{item.text}}</p>
            <el-upload
                class="upload-demo"
                action="https://jsonplaceholder.typicode.com/posts/"
                multiple
                :limit="3">
                <el-button size="small" type="primary">Click to upload</el-button>
            </el-upload>
        </div>
        <div class="part3">
            <el-button type="success"> Dodaj u korpu </el-button>
        </div>
    </div>
</template>
            </div>
              <narucivanje-fotografija></narucivanje-fotografija>
        </div>
    </div>
</template>

<script>
import PrikazProizvoda from "./PrikazProizvoda.vue"
import NarucivanjeFotografija from "./NarucivanjeFotografija.vue"
export default {
    components: {PrikazProizvoda, NarucivanjeFotografija},
    data(){
        return{
            proizvodi: [
                {   
                    tip: 'Solja',
                    slika: require('../../assets/proizvodi/slikaSolje.jpg'),
                    text: 'Foto šolje sa Vašim dizajnom - natpisom ili fotografijom'+
                '- u punom koloru, na komad, su naš prepoznatljivi proizvod već preko 15 godina.'+
                ' Danas štampu na šoljma radimo isključivo sublimacionim postupkom. Šolja sa slikom ,'+
                'predstavlja idealan poklon za svaku priliku'},
                {   
                    tip: 'Kalendar',
                    slika: require('../../assets/proizvodi/kalendar.jpg'),
                    text: 'Foto kalendar sa Vašom slikom'},
                {   
                    tip: 'Kalendar',
                    slika: require('../../assets/proizvodi/kalendar1.jpg'),
                    text: 'Foto kalendar sa Vašim slikama'}
            ]
        }
    }
}
</script>

<style  scoped>
.lista-proizvoda{
  display: flex;
    flex-direction: column;
    flex-wrap: wrap;
}
.proizvodi-container{
        display: flex;
        height: 90%;
        width: 100%;
        flex-direction: column;
        overflow: auto;
        background-color: rgba(224, 224, 235, 0.445);
}

.prikaz-proizvoda-container{
     height: 290px;
    width: 75%;
   /* background: linear-gradient(0deg, #d1d356, #e6e88d );*/
    background: linear-gradient(0deg, #bccecfe7, #fcfcfc );
    margin-top: 15px;
    border-radius: 3px;
    margin-left: 15%;
    display: flex;
    flex-direction: row;
}
.part1{
    height: 100%;
    width: 25%;
    display: flex;
    justify-content: center;
    align-items: center;
}
.part2{
     height: 100%;
    width: 50%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
}
.part3{
     height: 100%;
    width: 25%;
     display: flex;
    justify-content: center;
    align-items: center;
}
.slika{
    height: 80%;
    width: 90%;
}
</style>


