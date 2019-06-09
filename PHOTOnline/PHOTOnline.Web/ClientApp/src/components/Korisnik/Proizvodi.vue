<template>
    <div class="proizvodi-container">
        <div class="lista-proizvoda">
            <div v-for="item in proizvodi" :key="item.value" :list="proizvodi">
            <template>
                <div class="prikaz-proizvoda-container">
                    <div class="part1">
                        <img class="slika" v-bind:src="item.ImageUrl" />
                    </div>
                    <div class="part2part3">
                        <div class="part2">
                            <h4>{{item.Title}}</h4>
                            <p id="opis">{{item.Description}}</p>
                            <el-upload
                                class="upload-demo"
                                action="https://jsonplaceholder.typicode.com/posts/"
                                multiple
                                :limit="3">
                                <el-button size="big" type="primary">Click to upload</el-button>
                            </el-upload>
                        </div>
                        <div class="part3">
                            <h6 id="cena">Cena: {{item.Price}}din</h6>
                            <el-button id="dugmeDodaj" type="success" size="medium"> Dodaj u korpu </el-button>
                        </div>
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
import { apiFetch, destinationUrl, UserTypes } from '../../services/authFetch';
export default {
    components: {PrikazProizvoda, NarucivanjeFotografija},
    data(){
        return{
            proizvodi: []
        }
    },
    methods: {
        loadDataTable() {
                apiFetch('GET', destinationUrl + "/Product/GetAllProducts")
                .then(result => {
                    this.proizvodi = result.Data;
                });
            }
    },
    mounted: function() {
            this.$emit('loadDataTable');
    },
    created() {
            this.$on('loadDataTable', this.loadDataTable);
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
    width: 75%;
   /* background: linear-gradient(0deg, #d1d356, #e6e88d );*/
    background: linear-gradient(0deg, #bccecfc7, #fcfcfcab );
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
.part2part3{
    display: flex;
    width: 75%;
}
.part2{
     height: 100%;
    width: 60%;
    display: flex;
    justify-content: space-around;
    align-items: center;
    flex-direction: column;
}
.part3{
    height: 100%;
    width: 40%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}
#cena{
    margin-bottom:20%; 
    margin-top:20%;
}
#dugmeDodaj{
    width: 50%;
    margin-bottom:20%;
}
.slika{
    height: 80%;
    width: 80%;
}
@media screen and (max-width: 1210px) {
    #dugmeDodaj{
        width: 70%;
        white-space: unset;
    }
}
@media screen and (max-width: 800px) {
    .part2part3{
        flex-direction: column;
        width: 60%;
    }
    .part1{
        width: 40%;
    }
    .part2{
        width: 100%;
    }
    .part3{
        width: 100%;
    }
    #cena{
        margin-bottom:2%; 
        margin-top:2%;
    }
    #dugmeDodaj{
        width: 60%;
        margin-bottom:2%;
    }
    #opis{
        display: none;
    }
}

</style>


