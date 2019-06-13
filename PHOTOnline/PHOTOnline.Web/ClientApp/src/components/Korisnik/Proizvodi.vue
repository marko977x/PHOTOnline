<template>
    <div class="proizvodi-container">
        <div class="lista-proizvoda" v-loading="isSpinnerActive" 
            :loading-options="{text: 'text', background: 'rgb(0, 0, 0, 0.6)'}" 
            v-if="this.Images == ''" >
            <div v-for="(item, index) in proizvodi" :key="item.value" :list="proizvodi">
            <template>
                <div class="prikaz-proizvoda-container">
                    <div class="part1">
                        <img class="slika" v-bind:src="item.ImageUrl" />
                    </div>
                    <div class="part2part3">
                        <div class="part2" >
                            <h4>{{item.Title}}</h4>
                            <p id="opis">{{item.Description}}</p>
                            <input type="file" :disabled="omoguciDugme" accept="image/*" @change="uploadImage($event)" id="file-input" >
                        </div>
                        <div class="part3">
                            <h6 id="cena">Cena: {{item.Price}}din</h6>
                            <el-button id="dugmeDodaj" type="success" size="medium" @click="onClickDodajUKorpu(index)"> Dodaj u korpu </el-button>
                        </div>
                    </div>
                </div>
            </template>
            </div>
            <narucivanje-fotografija 
                @showPhotos="pribaviSlike($event)"
                @startSpinner="() => isSpinnerActive = true"
                @stopSpinner="() => isSpinnerActive = false">
            </narucivanje-fotografija>
        </div>
        <div class="album-fotografije" v-if="isOnlineOrderingVisible">
            <div id="dugme">
                <el-button type="danger" size="mini" @click="dodajUKorpuPhoto">Dodaj u korpu</el-button>
            </div>
            <div id="photo">
                <fotografija 
                        v-for="(item, index) in Images" :key="item.Id"
                        @selectImage="addImageToSelected($event, index)"
                        @unselectImage="removeImageFromSelected($event, index)"
                        @showPhoto="prikazi($event)" :item="item"
                        @formatChange="onFormatChange($event, index)"
                        @quantityChange="onQuantityChange($event, index)">
                </fotografija>
            </div>
        </div>
    </div>
</template>

<script>
import NarucivanjeFotografija from "./NarucivanjeFotografija.vue"
import Fotografija from "./Fotografija.vue"
import { apiFetch, destinationUrl, UserTypes, REGULAR_USER_TYPE } from '../../services/authFetch';
import { Promise } from 'q';
import { getUserInfo, setAlbumKorisnikState, getAlbumKorisnikState, clearAlbumKorisnikState } from '../../services/contextManagement';
import {IMAGE_FORMAT_PRICE_PAIR_LIST} from "../../data/formatPricePairList";
export default {
    components: { NarucivanjeFotografija, Fotografija },
    data(){
        return{
            proizvodi: [],
            uploadedImage: {},
            isSpinnerActive: false,
            isUploadingDone: false,
            indeksIzabranogProizvoda: null,
            omoguciDugme: '',
            Images: [],
            photo: {}
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
            if(getUserInfo().userType == REGULAR_USER_TYPE){
                this.indeksIzabranogProizvoda = index;
                this.dodajUKorpu(); 
            }
            else{
                this.$message("Da biste naručili proizvod morate se prijaviti ili registrovati.");
                this.$emit("gotoLogin");
            }
        },
        pribaviSlike(data){
            data.forEach(image => {
                this.Images.push({
                    selected: false,
                    format: '',
                    quantity: 1,
                    image: image
                });
            })
        },
        dodajUKorpu(){
            if(this.isUploadingDone && !this.isSpinnerActive) {    
                const formData = new FormData();
                formData.append("UserId", getUserInfo().userID);
                formData.append("CartItems[" + 0 + "].ProductType", this.proizvodi[this.indeksIzabranogProizvoda].ProductType);
                formData.append("CartItems[" + 0 + "].Format", this.proizvodi[this.indeksIzabranogProizvoda].Size);
                formData.append("CartItems[" + 0 + "].Quantity", 1);
                formData.append("CartItems[" + 0 + "].Title", this.proizvodi[this.indeksIzabranogProizvoda].Title);
                formData.append("CartItems[" + 0 + "].Image.Id", this.uploadedImage.Id);
                formData.append("CartItems[" + 0 + "].Image.Title", this.uploadedImage.Title);
                formData.append("CartItems[" + 0 + "].Image.Original.FileId", this.uploadedImage.Original.FileId);
                formData.append("CartItems[" + 0 + "].Image.Original.Url", this.uploadedImage.Original.Url);
                formData.append("CartItems[" + 0 + "].Image.Thumbnail.FileId", this.uploadedImage.Thumbnail.FileId);
                formData.append("CartItems[" + 0 + "].Image.Thumbnail.Url", this.uploadedImage.Thumbnail.Url);
                formData.append("CartItems[" + 0 + "].Image.Large.FileId",this.uploadedImage.Large.FileId);
                formData.append("CartItems[" + 0 + "].Image.Large.Url", this.uploadedImage.Large.Url);
                formData.append("CartItems[" + 0 + "].Image.Medium.FileId", this.uploadedImage.Medium.FileId);
                formData.append("CartItems[" + 0 + "].Image.Medium.Url", this.uploadedImage.Medium.Url);
                formData.append("CartItems[" + 0 + "].Image.Small.FileId", this.uploadedImage.Small.FileId);
                formData.append("CartItems[" + 0 + "].Image.Small.Url", this.uploadedImage.Small.Url);
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
        async uploadImage(event) {
            const promises = [];
            const formData = new FormData();
            formData.append("image", event.target.files[0]);
            promises.push(fetch(destinationUrl + "/Image/UploadImage", {method: 'POST', body: formData})
                .then(response => {
                    return response.ok ? response.json() : new Error();
                }).then(result => {
                    this.uploadedImage = result.Data.Image;
                }).catch(error => {console.log(error)}));
            await Promise.all(promises);
            this.isUploadingDone = true;
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
        },
        addImageToSelected(data, index){
            this.$set(this.Images, index, {
                ... this.Images[index], selected: true, quantity: data.quantity, format: data.format
            });
        },
        removeImageFromSelected(image, index) {
            this.Image[index].selected = false;
        },
        prikazi(photo){
            this.photo = photo;
            this.showPicture = 'photo'
        },
        onFormatChange(format, index) {
            this.$set(this.Images, index, {...this.Images[index], format: format});
        },
        onQuantityChange(quantity, index) {
            this.$set(this.Images, index, {...this.Images[index], quantity: quantity});
        },
         dodajUKorpuPhoto() {
            setAlbumKorisnikState({Images: this.Images});
            if(this.Images.filter(item => item.selected == true).length == 0) {
                this.$message({message: "Morate izabrati bar jednu fotografiju", type: "warning"});
                return;
            }
            if(getUserInfo().userType == REGULAR_USER_TYPE) {
                clearAlbumKorisnikState();
                if(this.Images.length == 0) {
                    this.$message({message: "Morate selektovati bar jednu fotografiju!",type: 'error'})
                    return
                }
                
                const formData = new FormData();
                formData.append("UserId", getUserInfo().userID);
                this.Images.filter(item => item.selected == true).forEach((item, index) => {
                    formData.append("CartItems[" + index + "].ProductType", "Fotografija");
                    formData.append("CartItems[" + index + "].Format", item.format);
                    formData.append("CartItems[" + index + "].Quantity", item.quantity);
                    formData.append("CartItems[" + index + "].Title", item.image.Title);
                    formData.append("CartItems[" + index + "].Image.Id", item.image.Id);
                    formData.append("CartItems[" + index + "].Image.Title", item.image.Title);
                    formData.append("CartItems[" + index + "].Image.Original.FileId", item.image.Original.FileId);
                    formData.append("CartItems[" + index + "].Image.Original.Url", item.image.Original.Url);
                    formData.append("CartItems[" + index + "].Image.Thumbnail.FileId", item.image.Thumbnail.FileId);
                    formData.append("CartItems[" + index + "].Image.Thumbnail.Url", item.image.Thumbnail.Url);
                    formData.append("CartItems[" + index + "].Image.Large.FileId", item.image.Large.FileId);
                    formData.append("CartItems[" + index + "].Image.Large.Url", item.image.Large.Url);
                    formData.append("CartItems[" + index + "].Image.Medium.FileId", item.image.Medium.FileId);
                    formData.append("CartItems[" + index + "].Image.Medium.Url", item.image.Medium.Url);
                    formData.append("CartItems[" + index + "].Image.Small.FileId", item.image.Small.FileId);
                    formData.append("CartItems[" + index + "].Image.Small.Url", item.image.Small.Url);
                    formData.append("CartItems[" + index + "].Price", this.izracunajCenu(item));
                });

                for(let index = 0; index < this.Images.length; index++) {
                    this.$set(this.Images, index, {
                        ...this.Images[index], 
                        selected: false,
                        quantity: 1,
                        format: ""
                    });
                }
                
                fetch(destinationUrl + "/Cart/AddToCart", {method: 'POST', body: formData})
                    .then(response => response.ok ? response.json() : new Error())
                    .then(() => this.$message({message: "Uspesno ste dodali fotografije u korpu", type: "success"}))
                    .catch(error => console.log(error));
            }
            else {
                this.$message("Da biste naručili fotografije morate se prijaviti ili registrovati.");
                this.$emit("gotoLogin");
            }
        },
        izracunajCenu(image){
            const formatPricePair = IMAGE_FORMAT_PRICE_PAIR_LIST.find(item => item.format == image.format);
            return formatPricePair.price * image.quantity;
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
.album-fotografije{
    display: flex;
    flex-direction: column;
}
#photo{
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
}
#dugme{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
    margin-top: 2%;
    margin-right: 2%;
}
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
        background-color: rgba(224, 224, 235, 0.445);
        overflow: auto;
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
    width: 35%;
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


