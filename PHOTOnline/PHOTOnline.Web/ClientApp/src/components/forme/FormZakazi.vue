<template>
    <div class="form-zakazi-container">
        <el-form class="zakazi-forma"> 
            <div class="divOpcija">
                <label>Lokacija:</label>
                <el-input type="text" class="inputPolje" v-model="podaciZakazi.Location"></el-input>
            </div>
            <div class="divOpcija">
                <label>Datum:</label>
                <el-input class="inputPolje" :disabled="false" :value="podaciZakazi.Date" v-model="datum1" placeholder="Izaberite datum iz kalendara">{}</el-input>
            </div>
            <div class="divOpcija">
                <label>Dodatni zahtevi:</label>
                <el-input type="textarea"
                 :autosize="{ minRows: 4, maxRows: 4}"  class="inputPolje" v-model="podaciZakazi.AdditionalRequests"></el-input>
            </div>
            <div class="divOpcija">
                <label>Tip fotografisanja:</label>
                <el-select class="inputPolje" v-model="podaciZakazi.EventType" placeholder="Izaberite tip fotografisanja">
                    <el-option v-for="item in options" :key="item.tip" :label="item.label" :value="item.tip"></el-option>
                </el-select>
            </div>
            <div class="divOpcija">
                <label>Vreme:</label>
                <el-time-select class="inputPolje" v-model="podaciZakazi.Time" :picker-options="{ start: '08:00', step: '00:15', end: '23:00' }" placeholder="Select time"></el-time-select>
            </div>
            <div class="divDugmeZakazi">
                <el-button id="dugmeZakazi" type="primary" @click="proslediZahtev">Zakaži</el-button>
            </div>
        </el-form>
    </div>
</template>

<script>
import { apiFetch, destinationUrl } from '../../services/authFetch';
export default {
    data(){
        return{
            podaciZakazi: {
                Location: '',
                Date: this.date,
                AdditionalRequests: '',  
                EventType: '',
                Time: ''
            },
            datum1: this.date,
            options: [{
                    tip: 'Svadba',
                    label: 'Svadba'
                    }, {
                    tip: 'Krstenje',
                    label: 'Krstenje'
                    }, {
                    tip: 'Veridba',
                    label: 'Veridba'
                    }, {
                    tip: 'Rodjendan',
                    label: 'Rodjendan'
                    }, {
                    tip: 'PhotoSession',
                    label: 'PhotoSession'
                    }, {
                    tip: 'Drugo',
                    label: 'Drugo'
            }],
        }
    },
    props: {date:String},
    watch:{
        date: function(pom){
            this.Date = pom
        }
    },
    methods: {
        validacija(){
            if(this.podaciZakazi.Location === '' || this.podaciZakazi.Date === '' || this.podaciZakazi.EventType === ''
                 || this.podaciZakazi.Time === ''){
                this.$message({message: "Morate popuniti sva polja!", type:'warning' })
                return false
            }
            return true
        },
        proslediZahtev() {
            //  if(!this.validacija())
            //      return
            console.log(this.podaciZakazi);
                // apiFetch('POST', destinationUrl + "/Request/CreateRequest", this.podaciZakazi)
                // .then(result => {
                //     if(result.success){
                //        this.$message({message: "Uspesno ste zakazali termin.", type: 'success'});
                //        console.log(result);
                //     }
                //     else this.$message("Doslo je do greske!");
                //     console.log(result)
                // }).catch(error => {
                //     console.log(error);
                // });
        }
    }
}
</script>

<style scoped>

.form-zakazi-container{
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: 100%;
    padding:50px;
    padding-top: 0px;
}

.zakazi-forma{
    height: 500px;
    width: 450px;
    display: flex;
    flex-direction: column;
    justify-content: flex-end;
}

.divOpcija{
    flex-direction: column;
    width: 100%;
    justify-content: center;
}

.inputPolje{
    display: block;
    width: 100%;
}

.divDugmeZakazi{
    display: flex;
    flex-direction: row-reverse;
    margin: 5px;
    width: 100%;
} 

</style>