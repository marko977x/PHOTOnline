<template>
    <div class="zahtev-container">
        <h3>Neobrađeni zahtevi</h3>
        <div class="zahtev-container-table">
             <el-table
             :data="this.listaZahteva">
            <el-table-column
                    prop="FirstName"
                    label="Ime"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="LastName"
                    label="Prezime"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                    prop="Location"
                    label="Lokacija"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                     prop="Date"
                    label="Datum"
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
                    class="table-column">
            </el-table-column>
              <el-table-column 
                     prop="Time"
                    label="Vreme"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                     prop="fotograf"
                    label="Fotograf"
                    class="table-column"
                    width="200">
                    <el-select class="inputPolje" v-model="fotografId" placeholder="Izaberite fotografa" size="medium">
                         <el-option v-for="item in fotografi" :key="item.Id" :label="item.FirstName+' '+item.LastName" :value="item.Id"></el-option>
                    </el-select>
            </el-table-column>
            <el-table-column align="right">
                <template slot-scope="scope">
                    <div class="dugmici">
                        <el-button type="success" size="mini" @click.native.prevent="potvrdiZahtev(scope.$index, scope.row)">Potvrdi</el-button>
                        <el-button type="danger" size="mini">Odbij</el-button>
                        <el-button type="info" icon="el-icon-message" circle size="mini" @click="poruka"></el-button>
                    </div>
                </template>    
            </el-table-column>
        </el-table>
        </div>
        <h3>Potvrđeni zahtevi</h3>
         <div class="zahtev-container-table">
             <el-table
             :data="this.listaPotvrdjenihZahteva">
            <el-table-column
                    prop="FirstName"
                    label="Ime"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="LastName"
                    label="Prezime"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                    prop="Location"
                    label="Lokacija"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                     prop="Date"
                    label="Datum"
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
                    class="table-column">
            </el-table-column>
              <el-table-column 
                     prop="Time"
                    label="Vreme"
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
export default {
    data(){
        return{
            fotografi: [],
            fotografId: '',
            listaZahteva: [],
            listaPotvrdjenihZahteva: []
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
                    this.listaZahteva = result.Data.filter(x => x.RequestStatus == 3);
                    this.listaPotvrdjenihZahteva = result.Data.filter(x => x.RequestStatus == 1);
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
        potvrdiZahtev(index,row){
            let Data = {Location:'',Date:'', Time: '', Note: '', PhotographId: '', EventType: 1, RequestId: '', Notification: '' };
            Data.Location = row.Location;
            Data.Date = row.Date;
            Data.Time = row.Time;
            Data.Note = row.AdditionalRequests;
            Data.PhotographId = this.fotografId;
            Data.RequestId = row.Id;
            Data.EventType = eventTypes.indexOf(row.EventType);
            Data.Notification = this.notification;
            console.log(Data.Notification);
            console.log(Data.EventType);
             apiFetch('POST', destinationUrl + "/Task/AssignTask", Data)
                .then(result => {
                    if(result.Success){
                       this.$message({message: "Uspesno dodeljivanje obaveze fotografu.", type: 'success'})
                       this.listaZahteva.splice(index,1);
                        this.listaPotvrdjenihZahteva.push(row);
                        this.$emit('datum',this.listaZahteva);
                        this.$emit('potvrdjeni', this.listaPotvrdjenihZahteva);
                    }
                    else this.$message("Doslo je do greske!");
                    console.log(result)
                }).catch(error => {
                    console.log(error);
                });
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
    padding: 20px;
}

h3{
    text-align: center;
    font-family: sans-serif;
}

.dugmici{
    display: flex;
    flex-wrap: wrap;
}

</style>


