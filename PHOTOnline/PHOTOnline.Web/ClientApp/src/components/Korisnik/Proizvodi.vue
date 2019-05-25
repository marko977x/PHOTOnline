<template>
    <div class="proizvodi-container">
        <div class="lista-proizvoda">
            <prikaz-proizvoda v-for="item in proizvodi" :key="item.value" :list="proizvodi"></prikaz-proizvoda>
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
                {   slika: '../../assets/bell.png',
                    text: 'Foto šolje sa Vašim dizajnom - natpisom ili fotografijom'+
                '- u punom koloru, na komad, su naš prepoznatljivi proizvod već preko 15 godina.'+
                ' Danas štampu na šoljma radimo isključivo sublimacionim postupkom. Šolja sa slikom ,'+
                'predstavlja idealan poklon za svaku priliku'},
                {   slika: '../../assets/slikaSolje.jpg',
                    text: 'Fotogg šolje sa Vašim dizajnom - natpisom ili fotografijom'+
                '- u punom koloru, na komad, su naš prepoznatljivi proizvod već preko 15 godina.'+
                ' Danas štampu na šoljma radimo isključivo sublimacionim postupkom. Šolja sa slikom ,'+
                'predstavlja idealan poklon za svaku priliku'}
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
</style>


