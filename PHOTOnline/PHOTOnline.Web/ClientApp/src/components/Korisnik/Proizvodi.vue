<template>
    <div class="proizvodi-container">
        <div class="lista-proizvoda" v-loading="isSpinnerActive" :loading-options="{text: 'text', background: 'rgb(0, 0, 0, 0.6)'}">
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
                            <input type="file" :disabled="omoguciDugme" accept="image/*" @change="uploadImage($event, index)" id="file-input" >
                        </div>
                        <div class="part3">
                            <h6 id="cena">Cena: {{item.Price}}din</h6>
                            <el-button id="dugmeDodaj" type="success" size="medium" @click="onClickDodajUKorpu(index)"> Dodaj u korpu </el-button>
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
import { apiFetch, destinationUrl, UserTypes, REGULAR_USER_TYPE, ANONYMOUS_USER_TYPE } from '../../services/authFetch';
import { getUserInfo } from '../../services/contextManagement';
import { Promise } from 'q';
export default {
    components: { NarucivanjeFotografija },
    data(){
        return{
            proizvodi: [],
            uploadedImage: [],
            isSpinnerActive: false,
            isUploadingDone: false,
            indeksIzabranogProizvoda: null,
            uploadingImageInProgress: [],
            omoguciDugme: ''
        }
    },
    methods: {
        loadDataTable() {
            apiFetch('GET', destinationUrl + "/Product/GetAllProducts")
                .then(result => {
                    this.proizvodi = result.Data;
                });
        },
        onClickDodajUKorpu(index) {
            if(getUserInfo().userType == ANONYMOUS_USER_TYPE){
                this.$message("Da biste naručili proizvod morate se prijaviti ili registrovati.");
                this.$emit("gotoLogin");
            }
            else if(this.uploadedImage[index] == null &&
                !this.uploadingImageInProgress[index]) {
                this.$message({message: "Morate izabrati fotografiju", type: "warning"});
            }
            else {
                this.indeksIzabranogProizvoda = index;
                this.dodajUKorpu(); 
            }
        },
        dodajUKorpu(){
            if(this.isUploadingDone && !this.isSpinnerActive) {    
                const image = this.uploadedImage[this.indeksIzabranogProizvoda];
                const formData = new FormData();
                formData.append("UserId", getUserInfo().userID);
                formData.append("CartItems[" + 0 + "].ProductType", this.proizvodi[this.indeksIzabranogProizvoda].ProductType);
                formData.append("CartItems[" + 0 + "].Format", this.proizvodi[this.indeksIzabranogProizvoda].Size);
                formData.append("CartItems[" + 0 + "].Quantity", 1);
                formData.append("CartItems[" + 0 + "].Image.Id", image.Id);
                formData.append("CartItems[" + 0 + "].Image.Title", image.Title);
                formData.append("CartItems[" + 0 + "].Image.Original.FileId", image.Original.FileId);
                formData.append("CartItems[" + 0 + "].Image.Original.Url", image.Original.Url);
                formData.append("CartItems[" + 0 + "].Image.Thumbnail.FileId", image.Thumbnail.FileId);
                formData.append("CartItems[" + 0 + "].Image.Thumbnail.Url", image.Thumbnail.Url);
                formData.append("CartItems[" + 0 + "].Image.Large.FileId",image.Large.FileId);
                formData.append("CartItems[" + 0 + "].Image.Large.Url", image.Large.Url);
                formData.append("CartItems[" + 0 + "].Image.Medium.FileId", image.Medium.FileId);
                formData.append("CartItems[" + 0 + "].Image.Medium.Url", image.Medium.Url);
                formData.append("CartItems[" + 0 + "].Image.Small.FileId", image.Small.FileId);
                formData.append("CartItems[" + 0 + "].Image.Small.Url", image.Small.Url);
                formData.append("CartItems[" + 0 + "].Price", this.proizvodi[this.indeksIzabranogProizvoda].Price);

                fetch(destinationUrl + "/Cart/AddToCart", {method: 'POST', body: formData})
                    .then(response => response.ok ? response.json() : new Error())
                    .then(result => { 
                        this.$message({message: "Uspešno ste dodali proizvod u online korpu.", type: "success"});
                        this.resetSpinner();
                    })
                    .catch(error => { 
                        this.$message({message: "Greška pri dodavanju proizvoda u online korpu.", type: "error"})
                        this.resetSpinner();
                    });
            }
            else {
                this.isSpinnerActive = true;
            }
        },
        async uploadImage(event, index) {
            if(getUserInfo().userType == ANONYMOUS_USER_TYPE){
                this.$message("Da biste naručili proizvod morate se prijaviti ili registrovati.");
                this.$emit("gotoLogin");
                return;
            }
            this.uploadingImageInProgress[index] = true;
            const promises = [];
            const formData = new FormData();
            formData.append("image", event.target.files[0]);
            promises.push(fetch(destinationUrl + "/Image/UploadImage", {method: 'POST', body: formData})
                .then(response => {
                    return response.ok ? response.json() : new Error();
                }).then(result => {
                    this.uploadedImage[index] = result.Data.Image;
                }).catch(error => {console.log(error)}));

            await Promise.all(promises);
            this.isUploadingDone = true;
            this.uploadingImageInProgress[index] = false;
            if(this.isSpinnerActive) {
                this.isSpinnerActive = false;  
                this.dodajUKorpu();
            }
        },
        resetSpinner() {
            this.isUploadingDone = false;
            this.isSpinnerActive = false;
        },
        proveraPrijavljen(){
            if(getUserInfo().userType == REGULAR_USER_TYPE){
                this.omoguciDugme = false;
            }
            else{
                this.omoguciDugme = true;
            }
        }
    },
    mounted: function() {
        this.$emit('loadDataTable');
    },
    created() {
        this.$on('loadDataTable', this.loadDataTable);
        this.proveraPrijavljen();
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


