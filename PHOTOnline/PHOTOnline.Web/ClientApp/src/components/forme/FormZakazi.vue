<template>
    <div class="form-zakazi-container">
        <el-form class="zakazi-forma"> 
            <div class="divOpcija">
                <label>Lokacija:</label>
                <el-input type="text" v-model="podaciZakazi.Location"></el-input>
            </div>
            <div class="divOpcija">
                <label>Datum:</label>
                <el-input 
                    :disabled="false" :value="this.date" readonly
                    v-model="this.date" placeholder="Izaberite datum iz kalendara">{}</el-input>
            </div>
            <div class="divOpcija">
                <label>Dodatni zahtevi:</label>
                <el-input type="textarea"
                 :autosize="{ minRows: 4, maxRows: 4}" v-model="podaciZakazi.AdditionalRequests"></el-input>
            </div>
            <div class="divOpcija">
                <label>Tip fotografisanja:</label>
                <el-select  v-model="podaciZakazi.EventType" placeholder="Izaberite tip fotografisanja">
                    <el-option v-for="item in options" :key="item.tip" :label="item.label" :value="item.tip"></el-option>
                </el-select>
            </div>
            <div class="divOpcija">
                <label>Vreme:</label>
                <el-time-select  v-model="podaciZakazi.Time" :picker-options="{ start: '08:00', step: '00:15', end: '23:00' }" placeholder="Select time"></el-time-select>
            </div>
            <div class="divDugmeZakazi">
                <el-button id="dugmeZakazi" type="primary" @click="proslediZahtev">Zakaži</el-button>
            </div>
        </el-form>
    </div>
</template>

<script>
import { apiFetch, destinationUrl } from '../../services/authFetch';
import { constants } from 'fs';
import { getUserInfo } from '../../services/contextManagement';
import { ERRORS } from '../../data/errorsCode';
export default {
    data(){
        return{
            podaciZakazi: {
                Location: '',
                Date: '',
                AdditionalRequests: '',  
                EventType: '',
                Time: '',
                UserId: ''
            },
            user: {FirstName:'', LastName: ''},
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
            this.podaciZakazi.Date = pom
        }
    },
    methods: {
        validacija(){
            if(this.podaciZakazi.Location == '' || this.podaciZakazi.Date == '' || this.podaciZakazi.EventType == ''
                 || this.podaciZakazi.Time == ''){
                this.$message({message: "Morate popuniti sva polja!", type:'warning' })
                return false
            }
            return true
        },
        proslediZahtev() {
             if(!this.validacija())
                 return

            this.podaciZakazi.Date = this.date;
            this.podaciZakazi.FirstName = this.user.FirstName;
            this.podaciZakazi.LastName = this.user.LastName;
            this.podaciZakazi.UserId = getUserInfo().userID;
            apiFetch('POST', destinationUrl + "/Request/CreateRequest", this.podaciZakazi)
            .then(result => {
                if(result.Success){
                    this.$message({message: "Uspesno ste zakazali termin.", type: 'success'});
                    this.$emit("zakazano",this.podaciZakazi);
                    this.clearForm();
                }
                else if(result.Errors != null) {
                    result.Errors.forEach(error => {
                        this.$message({message: ERRORS[error.Code], type: "warning"});
                    })
                }
            }).catch(error => {
                console.log(error);
            });


        },
        pribaviKorisnika(){
            let userId = getUserInfo().userID;
            fetch(destinationUrl + '/User/GetUserById/?id=' + userId, {method: "GET"})
                .then(response => response.ok ? response.json() : new Error())
                .then(result => {
                    this.user.FirstName = result.Data.FirstName;
                    this.user.LastName = result.Data.LastName;
                })
        },
        clearForm() {
            this.podaciZakazi.Date = "";
            this.podaciZakazi.AdditionalRequests = "";
            this.podaciZakazi.EventType = "";
            this.podaciZakazi.Time = "";
            this.podaciZakazi.Location = "";
        }
    },
    beforeMount(){
        this.pribaviKorisnika()
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
    display: flex;
    flex-direction: column;
    width: 100%;
    justify-content: center;
}
.el-select{
    display: flex;
    width: 100%;
    margin: 0px;
}
.el-input{
    display: flex;
    width: 100%;
    margin: 0px;
}

.divDugmeZakazi{
    display: flex;
    flex-direction: row-reverse;
    margin: 5px;
    width: 100%;
} 

</style>