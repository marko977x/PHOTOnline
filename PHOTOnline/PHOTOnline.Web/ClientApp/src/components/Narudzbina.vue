<template>
    <div class="narudzbina-container">
        <div class="narudzbina-container-table">
            <el-table
                :data="listaNarudzbina"
                :default-sort = "{prop:'Order.RequestStatus', order: 'descending'}"
                height="1000"
                style="width:100%"
                :row-class-name="tableColumn"
                highlight-current-row
                @row-click="handleCurrentChange">
                <el-table-column min-width="20%" prop="Order.RequestStatus" label="Status" sortable="true"></el-table-column>
                <el-table-column min-width="20%" prop="Order.Date" label="Datum"></el-table-column>
                <el-table-column min-width="20%" prop="FirstName" label="Ime"></el-table-column>
                <el-table-column min-width="20%" prop="LastName" label="Prezime"></el-table-column>
                <el-table-column min-width="20%" prop="Address" label="Adresa"></el-table-column>
                <el-table-column min-width="20%" prop="PhoneNumber" label="Telefon"></el-table-column>
                <el-table-column min-width="20%" prop="Order.Price" label="Ukupna cena"></el-table-column>
                
                <el-table-column fixed="right" width="100" align="right">
                    <el-button type="warning" size="mini">Korpa</el-button>
                </el-table-column>
                <el-table-column fixed="right" width="50">
                    <el-button type="info" icon="el-icon-message" circle size="mini"></el-button>
                </el-table-column>
            </el-table>
        </div>
        <prikaz-korpe :korpa="itemsinCart"></prikaz-korpe>
        <obavesti-korisnika hidden></obavesti-korisnika>
    </div>
</template>

<script>
import {} from 'element-ui'
import PrikazKorpe from "./prikazi/PrikazKorpe"
import ObavestiKorisnika from "./ObavestiKorisnika.vue"
import { apiFetch, destinationUrl } from '../services/authFetch';
export default {
    components: {PrikazKorpe,ObavestiKorisnika},
    data(){
        return{
            listaNarudzbina: [],
            currentRow: null,
            itemsinCart: [],
            Obavestenje: ''
        }
    },
    methods:{
        loadOrders() {
            fetch(destinationUrl + '/Order/GetAllOrders', {method: "GET"})
                .then(response => response.ok ? response.json() : new Error())
                .then(result => {
                    this.listaNarudzbina = result.Data;
                    console.log(this.listaNarudzbina);
            })
        },
        handleCurrentChange(val) {
            this.currentRow = val;
            this.itemsinCart = this.currentRow.Order.CartItems;
        },
        tableColumn({row, rowIndex}) {
            if (row.Order.RequestStatus == 1) {
                return 'success-row';
            }
            else{
                return '';
            }
        }
    },
    mounted: function() {
        this.loadOrders();
    }
}
</script>

<style scoped>
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

.buttons {
    display: flex !important;
    flex-direction: column !important;
    justify-content: center !important;
}
</style>


