<template>
    <div class="proizvodi-container">
        <div class="lista-proizvoda">
            <div v-for="(item, index) in proizvodi" :key="item.value" :list="proizvodi">
            <template>
                <div class="prikaz-proizvoda-container">
                    <div class="part1">
                        <img class="slika" v-bind:src="item.ImageUrl" />
                    </div>
                    <div class="part2part3">
                        <div class="part2">
                            <h4>{{item.Title}}</h4>
                            <p id="opis">{{item.Description}}</p>
                            <input type="file" accept="image/*" @change="uploadImages($event)" id="file-input" >
                        </div>
                        <div class="part3">
                            <h6 id="cena">Cena: {{item.Price}}din</h6>
                            <el-button id="dugmeDodaj" type="success" size="medium" @click="dodajUKorpu(index)"> Dodaj u korpu </el-button>
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
import NarucivanjeFotografija from "./NarucivanjeFotografija.vue"
import { apiFetch, destinationUrl, UserTypes } from '../../services/authFetch';
import { getUserInfo } from '../../services/contextManagement';
export default {
    components: { NarucivanjeFotografija },
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
        },
        dodajUKorpu(index){
            if(getUserInfo().userID != null){            
                const formData = new FormData();
                formData.append("UserId", getUserInfo().userID);
                    formData.append("CartItems[" + 0 + "].ProductType", this.proizvodi[index].ProductType);
                    formData.append("CartItems[" + 0 + "].Format", this.proizvodi[index].Size);
                    formData.append("CartItems[" + 0 + "].Quantity", 1);
                   /* formData.append("CartItems[" + 0 + "].Image.Id", image.Image.Id);
                    formData.append("CartItems[" + 0 + "].Image.Title", image.Image.Title);
                    formData.append("CartItems[" + 0 + "].Image.Original.FileId", image.Image.Original.FileId);
                    formData.append("CartItems[" + 0 + "].Image.Original.Url", image.Image.Original.Url);
                    formData.append("CartItems[" + 0 + "].Image.Thumbnail.FileId", image.Image.Thumbnail.FileId);
                    formData.append("CartItems[" + 0 + "].Image.Thumbnail.Url", image.Image.Thumbnail.Url);
                    formData.append("CartItems[" + 0 + "].Image.Large.FileId", image.Image.Large.FileId);
                    formData.append("CartItems[" + 0 + "].Image.Large.Url", image.Image.Large.Url);
                    formData.append("CartItems[" + 0 + "].Image.Medium.FileId", image.Image.Medium.FileId);
                    formData.append("CartItems[" + 0 + "].Image.Medium.Url", image.Image.Medium.Url);
                    formData.append("CartItems[" + 0 + "].Image.Small.FileId", image.Image.Small.FileId);
                    formData.append("CartItems[" + 0 + "].Image.Small.Url", image.Image.Small.Url);*/
                    formData.append("CartItems[" + 0 + "].Price", this.proizvodi[index].Price);
                    formData.append("CartItems[" + 0 + "].Image", null);

                fetch(destinationUrl + "/Cart/AddToCart", {method: 'POST', body: formData})
                    .then(response => response.ok ? response.json() : new Error())
                    .then(result => { 
                        console.log(result); 
                        this.$message({message: "Uspešno ste dodali proizvod u online korpu.", type: "success"})
                    })
                    .catch(error => { 
                        console.log(error);
                        this.$message({message: "Greška pri dodavanju proizvoda u online korpu.", type: "error"})
                    });
            }
            else{
                this.$message("Da biste naručili proizvod morate se prijaviti ili registrovati.");
                this.$emit("gotoLogin");
            }
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
    height: 290px;
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


