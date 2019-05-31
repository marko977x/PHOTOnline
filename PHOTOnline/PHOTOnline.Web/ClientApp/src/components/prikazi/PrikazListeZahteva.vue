<template>
    <div class="zahtev-container">
        <div class="zahtev-container-table">
             <el-table
             :data="this.listaZahteva">
            <el-table-column
                    prop="ime"
                    label="Ime"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="prezime"
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
                    class="table-column">
                    <el-select class="inputPolje" v-model="listaZahteva.fotograf" placeholder="Izaberite fotografa" size="medium">
                         <el-option v-for="item in options" :key="item.foto" :label="item.label" :value="item.foto"></el-option>
                    </el-select>
            </el-table-column>
            <el-table-column align="right">
                <template slot="">
                      <el-button type="danger" size="mini">Potvrdi</el-button>
                    <el-button type="info" icon="el-icon-message" circle size="mini"
                        @click="poruka"></el-button>
                </template>
            </el-table-column>
        </el-table>
        </div>
    </div>
</template>

<script>
import { apiFetch, destinationUrl } from '../../services/authFetch';
import {} from 'element-ui'
export default {
    data(){
        return{
            options: [{
                    foto: 'Vladica Mladenovic',
                    label: 'Vladica Mladenovic'
                    }, {
                    foto: 'Jovan Aritonovic',
                    label: 'Jovan Aritonovic'
                    },
                    {
                    foto: 'Dragan Aritonovic',
                    label: 'Dragan Aritonovic'
                    }
            ],
            listaZahteva: [],
        }
    },
    methods: {
        poruka(){
            this.$emit('poruka');
            
        },
        pribaviListuZahteva: async function(){
            apiFetch('GET', destinationUrl + "/Request/GetAllRequests")
            .then(result => {
                if(result.Success) {
                    this.listaZahteva = result.Data;
                    console.log(this.listaZahteva);
                    this.$emit('datum',this.listaZahteva)
                }
                else this.$message({message: "Doslo je do greske prilikom ucitavanja zahteva!", type: 'error'})   
                 }).catch(error => {console.log(error)});
        }
    },
    beforeMount(){
        this.pribaviListuZahteva()
    }
}
</script>

<style scoped>
.zahtev-container-table{
    display: flex;
    padding: 20px;
}
</style>


