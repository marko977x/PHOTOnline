<template>
    <div class="narudzbina-container">
        <div class="narudzbina-container-table">
            <el-table
                :data="tableData"
                :default-sort = "{prop:'datum', order: 'descending'}"
                height="1000"
                style="width:100%;"
                :row-class-name="tableColumn">
                <el-table-column 
                    prop="datum"
                    label="Datum"
                    sortable="true">
                </el-table-column>
                <el-table-column
                     prop="ime"
                    label="Ime">
                </el-table-column>
                <el-table-column
                     prop="prezime"
                    label="Prezime">
                </el-table-column>
                <el-table-column
                     prop="adresa"
                    label="Adresa">
                </el-table-column>
                <el-table-column
                     prop="brtelefona"
                    label="Broj Telefona">
                </el-table-column>
                <el-table-column align="right">
                    <template slot="">
                        <el-button type="warning" size="mini">Otvori Korpu</el-button>
                        <el-button type="info" icon="el-icon-message" circle size="mini"></el-button>
                    </template>
                </el-table-column>
            </el-table>
        </div>
        <prikaz-korpe :endTask="task"></prikaz-korpe>
        <obavesti-korisnika hidden></obavesti-korisnika>
    </div>
</template>

<script>
import {} from 'element-ui'
import PrikazKorpe from "./prikazi/PrikazKorpe"
import ObavestiKorisnika from "./ObavestiKorisnika.vue"
export default {
    components: {PrikazKorpe,ObavestiKorisnika},
    data(){
        return{
            tableData: [
                {
                    datum: '2019-05-12',
                    ime: 'Jovan',
                    prezime: 'Aritonovic',
                    adresa: 'Prvomajska 61 Zitkovac',
                    brtelefona: '0614210997'

                },
                  {
                    datum: '2019-05-8',
                    ime: 'Jovan',
                    prezime: 'Aritonovic',
                    adresa: 'Prvomajska 61 Zitkovac',
                    brtelefona: '0614210997'

                },
                  {
                    datum: '2019-01-2',
                    ime: 'Jovan',
                    prezime: 'Aritonovic',
                    adresa: 'Prvomajska 61 Zitkovac',
                    brtelefona: '0614210997'
                },
                 {
                    datum: '2019-01-2',
                    ime: 'Jovan',
                    prezime: 'Aritonovic',
                    adresa: 'Prvomajska 61 Zitkovac',
                    brtelefona: '0614210997'
                },
                 {
                    datum: '2019-01-2',
                    ime: 'Jovan',
                    prezime: 'Aritonovic',
                    adresa: 'Prvomajska 61 Zitkovac',
                    brtelefona: '0614210997'
                }
            ],
            orderFinished: false,
            itemsinCart: '',
            Obavestenje: '',
            task: this.endTask
        }
    },
    methods:{
        tableColumn({row, rowIndex}) {
            if (this.task == true) {
                return 'success-row';
            }
            else{
                return '';
            }
            console.log(this.task);
        }
    },
    props:['endTask']
}
</script>

<style>
.narudzbina-container{
        display: flex;
        height: 100%;
        width: 100%;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        overflow: auto;
}
.narudzbina-container-table{
       height: 47%;
        width: 90%;
        display: flex;
        flex-direction: column;
        background-color: rgba(204,204,211,0.931);
        opacity: 1;
        padding: 1em;
}
.el-table .success-row {
    background: #f0f9eb;
  }
</style>


