<template>
    <div class="narudzbina-container">
        <div class="narudzbina-container-table">
            <el-table
                :data="listaNarudzbina"
                :default-sort = "{prop:'Order.Date', order: 'descending'}"
                height="1000"
                style="width:100%"
                :row-class-name="tableColumn"
                highlight-current-row
                @current-change="handleCurrentChange">
                <el-table-column min-width="20%" prop="Order.Date" label="Datum" sortable="true"></el-table-column>
                <el-table-column min-width="20%" prop="Order.DeliveryAddress" label="Adresa"></el-table-column>
                <el-table-column min-width="20%" prop="Cart.Price" label="Ukupna cena"></el-table-column>
                <el-table-column min-width="20%" prop="PhoneNumber" label="Telefon"></el-table-column>
                <el-table-column fixed="right" width="50">
                    <el-button type="info" icon="el-icon-message" circle size="mini" @click="prikaziPoruku"></el-button>
                </el-table-column>
            </el-table>
        </div>
        <prikaz-korpe :korpa="itemsinCart"></prikaz-korpe>
    </div>
</template>

<script>
import {} from 'element-ui'
import PrikazKorpe from "../../../prikazi/PrikazKorpe"
import ObavestiKorisnika from "../../../ObavestiKorisnika.vue"
import { apiFetch, destinationUrl } from '../../../../services/authFetch';
import { getUserInfo } from '../../../../services/contextManagement';
export default {
    components: {PrikazKorpe,ObavestiKorisnika},
    data(){
        return{
            listaNarudzbina: [],
            currentRow: null,
            orderFinished: false,
            itemsinCart: [],
            poruka1: 'Vaš zahtev je prihvaćen.',
            poruka2: 'Vaš zahtev je odbijen.',
            poruka3: 'Vaš zahtev se obrađuje.',
        }
    },
    methods:{
        loadOrders() {
            let userId = getUserInfo().userID;
            console.log(userId)
            fetch(destinationUrl + '/Order/GetOrdersByUserId/?userId=' + userId, {method: "GET"})
                .then(response => response.ok ? response.json() : new Error())
                .then(result => {
                    this.listaNarudzbina = result.Data;
                    console.log(this.listaNarudzbina);
            })
        },
        handleCurrentChange(val) {
            this.currentRow = val;
            this.itemsinCart = this.currentRow.Cart.CartItems;
        },
        prikaziPoruku(){
            if(this.currentRow.Order.RequestStatus == 1)  this.$notify({title: "OBAVEŠTENJE", message: this.currentRow.Order.Notification==null ? this.poruka1 : this.currentRow.Order.Notification, type: 'success',  position: 'bottom-right' })
            else if(this.currentRow.Order.RequestStatus == 2) this.$notify({title: "OBAVEŠTENJE", message: this.currentRow.Order.Notification==null ? this.poruka2 : this.currentRow.Order.Notification, type: 'error', position: 'bottom-right'})
            else this.$notify({title: "OBAVEŠTENJE", message: this.poruka3, type: 'warning', position: 'bottom-right'})
        },
        tableColumn({row, rowIndex}) {
            if (this.task == true) {
                return 'success-row';
            }
            else{
                return '';
            }
            console.log(this.task);
        },
        
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


