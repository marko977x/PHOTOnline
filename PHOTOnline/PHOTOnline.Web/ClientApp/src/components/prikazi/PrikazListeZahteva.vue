<template>
    <div class="zahtev-container">
        <h3>Neobrađeni zahtevi</h3>
        <div class="zahtev-container-table">
            <el-table
                :data="this.listaZahteva"
                highlight-current-row
                @current-change="handleCurrentChange">
            <el-table-column
                    prop="FirstName"
                    label="Ime"
                    width="100px"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="LastName"
                    label="Prezime"
                    width="100px"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                    prop="Location"
                    label="Lokacija"
                    width="150px"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                     prop="Date"
                    label="Datum"
                    width="100px"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="AdditionalRequests"
                    label="Dodatni zahtevi"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="EventType"
                    label="Tip"
                    width="120px"
                    class="table-column">
            </el-table-column>
              <el-table-column 
                     prop="Time"
                    label="Vreme"
                    width="80px"
                    class="table-column">
            </el-table-column>
            </el-table>
            <div class="zahtevDugmici">
                <el-select class="inputPolje" v-model="fotografId" placeholder="Izaberite fotografa" size="medium">
                    <el-option v-for="item in fotografi" :key="item.Id" :label="item.FirstName+' '+item.LastName" :value="item.Id"></el-option>
                </el-select>
                <div class="dugmici">
                    <el-button type="success" size="mini" style="margin-left: 20%;" @click="potvrdiZahtev()">Potvrdi</el-button>
                    <el-button type="danger" size="mini" style="margin-left: 20%;" @click="odbijZahtev()">Odbij</el-button>
                    <el-button type="info" icon="el-icon-message" style="padding: 12px; margin-left: 20%;" circle size="mini" @click="poruka"></el-button>
                </div>
            </div>
        </div>
        <h3>Potvrđeni zahtevi</h3>
         <div class="zahtev-container-table">
            <el-table
             :data="this.listaPotvrdjenihZahteva" max-height="400">
            <el-table-column
                    prop="FirstName"
                    label="Ime"
                    width="100px"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="LastName"
                    label="Prezime"
                    width="100px"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                    prop="Location"
                    label="Lokacija"
                    width="120px"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                     prop="Date"
                    label="Datum"
                    width="100px"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="AdditionalRequests"
                    label="Dodatni zahtevi"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="EventType"
                    label="Tip"
                    width="120px"
                    class="table-column">
            </el-table-column>
              <el-table-column 
                     prop="Time"
                    label="Vreme"
                    width="80px"
                    class="table-column">
            </el-table-column>
             </el-table>
        </div>
    </div>
</template>

<script>
const eventTypes = ['Svadba','Krstenje', 'Veridba', 'Rodjendan', 'PhotoSession', 'Drugo']

import { apiFetch, destinationUrl } from '../../services/authFetch';
import {} from 'element-ui'
import { getUserInfo } from '../../services/contextManagement';
import { sortReuquestByDate } from '../../services/sort';
import { ERRORS } from '../../data/errorsCode';
export default {
    data(){
        return{
            fotografi: [],
            fotografId: '',
            listaZahteva: [],
            listaPotvrdjenihZahteva: [],
            currentRow: null,
        }
    },
    methods: {
        poruka(){
            this.$emit('poruka');   
        },
        pribaviListuZahteva() {
            apiFetch('GET', destinationUrl + "/Request/GetAllRequests")
            .then(result => {
                if(result.Success) {
                    this.listaZahteva = sortReuquestByDate(result.Data.filter(x => x.RequestStatus == 3), false);
                    this.listaPotvrdjenihZahteva = sortReuquestByDate(result.Data.filter(x => x.RequestStatus == 1), false);
                    this.$emit('datum',this.listaZahteva);
                    this.$emit('potvrdjeni', this.listaPotvrdjenihZahteva);
                }
                else this.$message({message: "Doslo je do greske prilikom ucitavanja zahteva!", type: 'error'})   
                 }).catch(error => {console.log(error)});
        },
        pribaviFotografe(){
              apiFetch('GET', destinationUrl + "/User/GetAllPhotographs")
                .then(result => {
                if(result.Success) {
                    this.fotografi = result.Data;
                }
                else this.$message({message: "Doslo je do greske prilikom ucitavanja fotografa!", type: 'error'})   
                 }).catch(error => {console.log(error)});
        },
        potvrdiZahtev(){
            if(this.currentRow != null && this.fotografId != ''){
                let Data = {Location:'',Date:'', Time: '', Note: '', PhotographId: '', EventType: 1, RequestId: '', Notification: '',CustomerId: '' };
                Data.Location = this.currentRow.Location;
                Data.Date = this.currentRow.Date;
                Data.Time = this.currentRow.Time;
                Data.Note = this.currentRow.AdditionalRequests;
                Data.PhotographId = this.fotografId;
                Data.RequestId = this.currentRow.Id;
                Data.EventType = eventTypes.indexOf(this.currentRow.EventType);
                Data.Notification = this.notification;
                Data.CustomerId = this.currentRow.UserId;
                apiFetch('POST', destinationUrl + "/Task/AssignTask", Data)
                    .then(result => {
                        if(result.Success){
                        this.$message({message: "Uspesno dodeljivanje obaveze fotografu.", type: 'success'})
                            this.listaZahteva.splice(this.listaZahteva.indexOf(this.currentRow),1);
                            this.listaPotvrdjenihZahteva.push(this.currentRow);
                            this.$emit('datum',this.listaZahteva);
                            this.$emit('potvrdjeni', this.listaPotvrdjenihZahteva);
                            this.fotografId = '';
                        }
                        else this.$message({message: ERRORS[result.Errors[0].Code], type: "warning"});
                    }).catch(error => {
                        console.log(error);
                    });
            }
            else if(this.currentRow == null){
                this.$message({message: "Morate selektovati zahtev pre potvrde.", type: 'error'})
            }
            else if(this.fotografId == ''){
                this.$message({message: "Morate angažovati fotografa pre potvrde.", type: 'error'})
            }
        },
        odbijZahtev(){
            if(this.currentRow != null){
                let Data = {Id: '', Notification: '' };
                Data.Id = this.currentRow.Id;
                Data.Notification = this.notification;
                apiFetch('POST', destinationUrl + "/Request/RejectRequest", Data)
                    .then(result => {
                        if(result.Success){
                        this.$message({message: "Uspesno ste odbili zahtev za fotografisanje.", type: 'warning'})
                            this.listaZahteva.splice(this.listaZahteva.indexOf(this.currentRow),1);
                            this.$emit('datum',this.listaZahteva);
                            this.fotografId = '';
                        }
                        else this.$message("Doslo je do greske!");
                    }).catch(error => {
                        console.log(error);
                    });
            }
            else {
                this.$message({message: "Morate selektovati zahtev pre odbijanja.", type: 'error'})
            }
        },
        handleCurrentChange(val) {
            this.currentRow = val;
        }
    },
    mounted: function() {
        this.pribaviFotografe();
        this.pribaviListuZahteva();
    },
    props: ['notification']
}
</script>

<style scoped>
.zahtev-container-table{
    display: flex;
    flex-direction: column;
    padding: 20px;
    height: 250px;
}

.zahtevDugmici{
    display: flex;
    justify-content: center;
    margin-top: 1%;
    margin-bottom: 1%;
}

h3{
    text-align: center;
    font-family: sans-serif;
}

.dugmici{
    display: flex;
    margin-left: 1%;
}
</style>


