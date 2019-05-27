<template>
    <div class="zahtev-container">
        <div class="zahtev-container-table">
             <el-table
             :data="this.tableData">
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
                    prop="lokacija"
                    label="Lokacija"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                     prop="datum"
                    label="Datum"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="zahtevi"
                    label="Dodatni zahtevi"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="tip"
                    label="Tip"
                    class="table-column">
            </el-table-column>
              <el-table-column 
                     prop="vreme"
                    label="Vreme"
                    class="table-column">
            </el-table-column>
            <el-table-column align="right">
                <template slot="">
                      <el-button type="danger" size="mini">Potvrdi</el-button>
                    <el-button type="info" icon="el-icon-message" circle size="mini"
                        @click="$event('poruka')"></el-button>
                </template>
            </el-table-column>
        </el-table>
        </div>
    </div>
</template>

<script>
import {} from 'element-ui'
export default {
    data(){
        return{
            tableData: [
                    {
                        datum: '2019-05-12',
                        ime: 'Jovan',
                        prezime: 'Aritonovic',
                        lokacija: 'Restoran',
                        datum: '2019-05-12',
                        zahtevi: 'Slikanje u prirodi',
                        tip: 'Krstenje',
                        vreme: '09:00'
                    }
            ]
        }
    }
}
</script>

<style scoped>
.zahtev-container-table{
    display: flex;
    padding: 20px;
}
</style>


