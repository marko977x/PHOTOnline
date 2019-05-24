<template>
    <div class="formFotografAlbumContainer">
        <el-form>
            <div class="stavka">
                <label>Naziv:</label>
                <el-input class="input-polje" v-model="naziv" align="left"></el-input>
            </div>
            <div class="stavka">
                <label>Datum:</label>
                <div class="datum">
                <el-date-picker v-model="datum" type="datetime" placeholder="Izaberi dan">
                </el-date-picker></div>
            </div>
            <div class="stavka">
                <label>Mesto:</label>
                <el-input class="input-polje" v-model="mesto"></el-input>
            </div>
            <div class="stavka-2">
                 <file-upload   action="https://jsonplaceholder.typicode.com/posts/" :directory="true" multiple="multiple">
                           <el-button size="small" type="warning">Upload Slika</el-button>
                </file-upload>
            </div>
            <div class="stavka">
                <label> Password: </label>
                <el-input type="password" class="input-polje" v-model="password"></el-input> 
            </div>
            <div class="dugmici">
            <el-button @click="dodajAlbum()" type="primary">Sačuvaj</el-button>
            <el-button @click="prekiniDodavanjeAlbuma">Odustani</el-button>
            </div>
            
        </el-form>
    </div>
</template>

<script>
    import FileUpload from 'vue-upload-component'
    import {Button} from 'element-ui'
    import {apiFetch, destinationUrl} from "../services/authFetch";
export default {
    components: {
        Button,
         FileUpload
    },
    data(){
        return{
            albumData:{
                naziv: '',
                datum: '',
                mesto: '',
                password: ''
            }
        }
    },
    methods: {
        validacija: function(){
            if(this.naziv === '' || this.mesto === '' || this.datum === ''){
                this.$message({message : 'Sva polja moraju biti popunjena', type: 'warning'})
                return
            }
            this.dodajAlbum()
        },
        dodajAlbum: async function(){
                const formData = new FormData();
                for(let key in this.albumData){
					formData.append(key, this.albumData[key]);
				}
                const fetchData = { 
                    body: formData,
                    method: "POST"
                }
                fetch("https://localhost:5001/api//", fetchData)
                    .then(response => {
                        console.log(response);
                        return response.json(); 
                    }) 
                    .then(result => {
                        console.log(result);
                    });
                    this.$emit('editFinished',retAlbum) // ovo retAlbum je DataObject koji se salje drugoj komponenti
            // AddFinished je ime eventa okidaca koji se okida u drugoj kompononeti odnosno parent komponenti!
        },
        prekiniDodavanjeAlbuma: function(){
            this.$emit('editFinished','cancel') // takodje je i ovde 'cancel' podatak koji se salje i koji 
            //ce biti ispisan!
        }
    }
}
</script>

<style scoped>
    .stavka{
        display: flex;
        flex-direction: row;
        margin-bottom: 10px;
        justify-content: space-between;
    }
    label{
       font-size: 15px;
        text-align: left;
        flex-basis: 30%;
    }
    .input-polje{
        flex-basis: 70%
    }
    .dugmici{
        display: flex;
        justify-content: flex-end;
    }
    .datum{
        display: flex;
        justify-content: flex-end;
        margin-top: 10px;
        margin-bottom: 10px;
    }
    .stavka-2{
        display: flex;
        justify-content: flex-end;
        margin-bottom: 10px;
    }
</style>


