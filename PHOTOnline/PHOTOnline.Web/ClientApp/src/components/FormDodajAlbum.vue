<template>
    <div class="formFotografAlbumContainer">
        <el-form>
            <div class="stavka">
                <label>Naziv:</label>
                <el-input class="input-polje" v-model="naziv" align="left"></el-input>
            </div>
            <div class="stavka">
                <el-date-picker v-model="datum" type="datetime" placeholder="Izaberi dan" align="right">
                </el-date-picker>
            </div>
            <div class="stavka">
                <label>Mesto:</label>
                <el-input class="input-polje" v-model="mesto"></el-input>
            </div>
            <div class="stavka">
                 <el-upload multiple wdith="40%"
                    class="upload-demo"
                    action="https://jsonplaceholder.typicode.com/posts/" 
                    >
                    <el-button size="small" type="primary">Upload Slika</el-button>
                </el-upload>
            </div>
            <div class="stavka">
                <label> Password: </label>
                <el-input type="password" class="input-polje" v-model="password"></el-input> 
            </div>
            <el-button @click="this.dodajAlbum()">Sačuvaj</el-button>
            <el-button @click="this.prekiniDodavanjeAlbuma()">Odustani</el-button>
            
        </el-form>
    </div>
</template>

<script>
    import {Button} from 'element-ui'
export default {
    components: {
        Button
    },
    data(){
        return{
            naziv: '',
            datum: '', // Nisam siguran da li bi trebalo da se pamti kao string ili kao Date?
            mesto: '',
            password: '',
        }
    },
    methodes: {
        validacija: function(){
            if(this.naziv === '' || this.mesto === '' || this.datum === ''){
                this.$message({message : 'Sva polja moraju biti popunjena', type: 'warning'})
                return false;
            }
            return true;
        },
        dodajAlbum: async function(){
            if(!this.validacija())
                return;
            var retAlbum = {
                naziv: this.naziv,
                mesto: this.mesto,
                password: this.password,
                datum: this.datum
            }
              console.log(this.naziv + this.mesto + this.password);
            this.$emit('AddFinished',retAlbum) // ovo retAlbum je DataObject koji se salje drugoj komponenti
            // AddFinished je ime eventa okidaca koji se okida u drugoj kompononeti odnosno parent komponenti!
        },
        prekiniDodavanjeAlbuma: function(){
            this.$emit('AddFinished','cancel') // takodje je i ovde 'cancel' podatak koji se salje i koji 
            //ce biti ispisan!
        }
    }
}
</script>

<style>
    .stavka{
        margin-bottom: 5%;
    }
</style>


