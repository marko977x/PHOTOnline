<template>
    <div class="prikaz-obaveza">
        <el-table v-if="this.ListaObaveza.length > 0"
            :data="this.ListaObaveza"
             :default-sort = "{prop: 'Date'}">
            <el-table-column
                    prop="Date"
                    label="Datum"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                    prop="Time"
                    label="Vreme"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                     prop="Location"
                    label="Lokacija"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="EventType"
                    label="Tip"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="Note"
                    label="Dodatne informacije"
                    class="table-column">
            </el-table-column>
        </el-table>
        <label v-else> Trenutno nemate dodeljene obaveze </label>
    </div>
</template>

<script>
const eventTypes = ['Svadba','Krstenje', 'Veridba', 'Rodjendan', 'PhotoSession', 'Drugo'];

import { apiFetch, destinationUrl } from '../../services/authFetch';
import { getUserInfo } from '../../services/contextManagement';
export default {
    data() {
        return{
            ListaObaveza: [],
        }
    },
    methods:{
         pribaviListuZahteva:  function(){
             let userid = getUserInfo().userID;
             console.log(userid)
            fetch(destinationUrl + "/Task/GetAllTasksByUserId/?id=" + userid, {method: 'GET'})
            .then(response => response.ok ? response.json() : new Error())
            .then(result => {
                if(result.Success) {
                    this.ListaObaveza = result.Data;
                    this.odrediTipDogadjaja();
                }
                else this.$message({message: "Doslo je do greske prilikom ucitavanja zahteva!", type: 'error'})   
                 }).catch(error => {console.log(error)});
        },
        odrediTipDogadjaja(){
            this.ListaObaveza.forEach(element => {
                element.EventType = eventTypes[element.EventType];
            })
        }
    },
    beforeMount(){
        this.pribaviListuZahteva();
    }
}
</script>

<style scoped>
 .prikaz-obaveza{
     display: flex;
     justify-content: center;
     
 }
</style>


