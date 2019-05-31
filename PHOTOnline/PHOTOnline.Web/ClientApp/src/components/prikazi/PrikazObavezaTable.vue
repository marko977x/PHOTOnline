<template>
    <div class="prikaz-obaveza">
        <el-table v-if="this.ListaObaveza.length > 0"
            :data="this.ListaObaveza">
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
                     prop="AdditionalRequests"
                    label="Dodatne informacije"
                    class="table-column">
            </el-table-column>
        </el-table>
        <label v-else> Trenutno nemate dodeljene obaveze </label>
    </div>
</template>

<script>
import { apiFetch, destinationUrl } from '../../services/authFetch';
export default {
    data() {
        return{
            ListaObaveza: [],
        }
    },
    methods:{
         pribaviListuZahteva: async function(){
             // ovo treba da se ispravi jer fotograf treba da dobije listu koju mu uprava dodeli kad ga izabere u select
            apiFetch('GET', destinationUrl + "/Request/GetAllRequests")
            .then(result => {
                if(result.Success) {
                    this.ListaObaveza = result.Data;
                    console.log(this.ListaObaveza);
                   this.$notify({
                        title: 'Success',
                        message: 'Uspesno ucitavanje podataka!',
                        type: 'success'
                        });
                }
                else this.$message({message: "Doslo je do greske prilikom ucitavanja zahteva!", type: 'error'})   
                 }).catch(error => {console.log(error)});
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


