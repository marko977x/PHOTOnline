<template>
    <div class="dodaj-proizvod-container">
        <el-dialog visible width="28%" 
            heigth="30%" title="Dodavanje proizvoda" 
            @close="$emit('zatvoriDodavanjeProizvoda')" 
            :modal-append-to-body="false">
            <el-form v-loading="isSpinnerActive">
                <div class="stavka">
                    <label>Naziv:</label>
                    <el-input v-model="proizvod.Title" placeholder="Naziv proizvoda" size="small"></el-input>
                </div>
                <div class="stavka">
                    <label>Cena:</label>
                    <el-input v-model="proizvod.Price" placeholder="Cena proizvoda" size="small"></el-input>
                </div>
                <div class="stavka">
                    <label>Tip:</label>
                    <el-input v-model="proizvod.ProductType" placeholder="Tip proizvoda" size="small"></el-input>
                </div>
                <div class="stavka">
                    <label>Opis:</label>
                    <el-input type="textarea" :autosize="{ minRows: 4 }" v-model="proizvod.Description" placeholder="Opis"></el-input>
                </div>
                <div class="stavka">
                    <label>Slika:</label>
                    <input type="file" accept="image/*" @change="uploadImages($event)" id="file-input" >
                </div>
                <div class="stavka-2">
                    <el-button  type="primary" size="mini" @click="addProduct()">Potvrdi</el-button>
                </div>
            </el-form>
        </el-dialog>
    </div>
</template>

<script>

    import { apiFetch, destinationUrl } from "../../services/authFetch";
    export default {
        data() {
            return {
                proizvod: { 
                    Title: '', 
                    Price: '',
                    Size: 'Univerzalni',
                    Description: '',
                    ProductType: '',
                    ImageUrl: '' 
                },
                isSpinnerActive: false,
                isUploadingDone: false,
                uploadingImagesInProgress: false
            }
        },
        methods: {
            validacija(){
                if(this.proizvod.Title == '' || this.proizvod.Price == '' || this.proizvod.ProductType == '' || this.proizvod.Description == '') {
                    this.$message({message : "Morate uneti polja za naziv, cenu i tip proizvoda, kao i upload-ovati sliku.", type: "warning"});
                    return false;
                }
                else if(this.proizvod.ImageUrl == '' && !this.uploadingImagesInProgress) {
                    this.$message({message: "Morate upload-ovati bar jednu sliku", type: "warning"});
                    return false;
                }
                else return true;
            },
            async addProduct() {
                if(!this.validacija()) return;
                if(this.isUploadingDone && !this.isSpinnerActive) {
                    apiFetch('POST', destinationUrl + "/Product/AddShopProduct", this.proizvod)
                        .then(result => {
                            this.$message("Uspešno ste dodali novi proizvod!");
                            this.$emit("zatvoriDodavanjeProizvoda");
                        }).catch(error => {
                            console.log(error);
                        });
                }
                else this.isSpinnerActive = true;
            },
            uploadImages(event) {
                this.uploadingImagesInProgress = true;
                const formData = new FormData();
                formData.append("image", event.target.files[0]);
                fetch(destinationUrl + "/Image/UploadImage", {method: 'POST', body: formData})
                    .then(response => {
                        return response.ok ? response.json() : new Error();
                    }).then(result => {
                        this.proizvod.ImageUrl = result.Data.Image.Small.Url;
                        this.uploadingImagesInProgress = false;
                        this.isUploadingDone = true;
                        if(this.isSpinnerActive) {
                            this.isSpinnerActive = false;  
                            this.addProduct();
                        }
                    }).catch(error => {console.log(error)});
            }
        }
    }
</script>

<style scoped>

    .dodaj-proizvod-container {
        justify-content: center;
    }

    label {
        font-size: 15px;
        text-align: left;
        flex-basis: 30%;
        width: 30%;
    }

    .stavka {
        display: flex;
        flex-direction: row;
        margin: 5px;
    }

    .el-input {
        flex-basis: 70%;
        width: 70%;
    }
    .el-input.el-input--small{
        width: 100%;
        margin: 0px;
    }

    .stavka-2 {
        display: flex;
        justify-content: flex-end;
        margin-top: 10px;
        margin-right: 5px;
    }
</style>
