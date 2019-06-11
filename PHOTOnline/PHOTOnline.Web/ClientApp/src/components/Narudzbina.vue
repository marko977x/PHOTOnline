<template>
    <div class="narudzbina-container-1">
        <div class="narudzbina-container-table-1">
            <h3>Lista narudžbina</h3>
            <el-table
                    :data="listaNarudzbina"
                    max-height="1000"
                    style="width:100%"
                    :row-class-name="tableRowClassName"
                    highlight-current-row
                    @row-click="handleCurrentChange">
                <el-table-column class-name="status" min-width="120" prop="Order.RequestStatus" label="Status"></el-table-column>
                <el-table-column min-width="100" prop="Order.Date" label="Datum"></el-table-column>
                <el-table-column min-width="150" prop="FirstName" label="Ime"></el-table-column>
                <el-table-column min-width="150" prop="LastName" label="Prezime"></el-table-column>
                <el-table-column min-width="220" prop="Address" label="Adresa"></el-table-column>
                <el-table-column min-width="140" prop="PhoneNumber" label="Telefon"></el-table-column>
                <el-table-column min-width="140" prop="Order.Price" label="Ukupna cena"></el-table-column>
                <el-table-column width="125">
                    <template slot-scope="scope">
                        <div class="kolonaDugmici-1">
                            <el-button 
                                type="info" icon="el-icon-message" 
                                circle size="mini" 
                                @click="dodajPoruku(scope.$index)">
                            </el-button>
                            <el-button 
                                type="success" 
                                icon="el-icon-success" circle size="mini" 
                                @click="updateOrderStatus(scope.$index,1)"
                                :disabled="scope.row.Order.RequestStatus == 'Obradjena'">
                            </el-button>
                            <el-button 
                                type="danger" icon="el-icon-error" 
                                circle size="mini" 
                                @click="updateOrderStatus(scope.$index,2)"
                                :disabled="scope.row.Order.RequestStatus == 'Odbijena'">
                            </el-button>
                        </div>
                    </template>
                </el-table-column>
            </el-table>
        </div>
        <prikaz-korpe :korpa="itemsinCart"></prikaz-korpe>
        <obavesti-korisnika v-if="this.showComp == 'obavestenje'" @zatvoriPoruku="zatvori" @proslediPoruku="prosledi($event)"></obavesti-korisnika>
    </div>
</template>

<script>
const Status = ['Obradjena','Odbijena', 'Na čekanju'];

import {} from 'element-ui'
import PrikazKorpe from "./prikazi/PrikazKorpe"
import ObavestiKorisnika from "./ObavestiKorisnika.vue"
import { apiFetch, destinationUrl } from '../services/authFetch';
import { Stats } from 'fs';
import { preloadImages } from '../services/preloadingImages';
import {sortOrdersByDate} from "../services/sort.js";
export default {
    components: {PrikazKorpe,ObavestiKorisnika},
    data(){
        return{
            listaNarudzbina: [],
            currentRow: null,
            itemsinCart: [],
            showComp: '',
            selectedIndex: '',
            preloadedImages: []
        }
    },
    methods:{
        loadOrders() {
            fetch(destinationUrl + '/Order/GetAllOrders', {method: "GET"})
                .then(response => response.ok ? response.json() : new Error())
                .then(result => {
                    this.listaNarudzbina = result.Data;
                    this.odrediStatusNarudzbine();
                    this.sortiraj();
                    this.preloadImages();
            })
        },
        handleCurrentChange(val) {
            this.currentRow = val;
            this.itemsinCart = this.currentRow.Order.CartItems;
        },
        tableRowClassName({row, rowIndex}) {
            if (this.listaNarudzbina[rowIndex].Order.RequestStatus === Status[0]) {
                return 'success-row';
            }
            else if (this.listaNarudzbina[rowIndex].Order.RequestStatus === Status[1]){
                return 'rejected-row';
            }
            else if (this.listaNarudzbina[rowIndex].Order.RequestStatus === Status[2]) {
                return 'odHold-row';
            }
            else{
                return '';
            }
        },
        odrediStatusNarudzbine(){
            this.listaNarudzbina.forEach(element => {
                element.Order.RequestStatus = Status[element.Order.RequestStatus-1];
            })
        },
        sortiraj(){
            let onHold = [];
            let approved = [];
            let rejected = [];
            this.listaNarudzbina.forEach(item => {
                if(item.Order.RequestStatus == Status[0]) approved.push(item);
                if(item.Order.RequestStatus == Status[1]) rejected.push(item);
                if(item.Order.RequestStatus == Status[2]) onHold.push(item);
            });
            onHold = sortOrdersByDate(onHold);
            rejected = sortOrdersByDate(rejected);
            approved = sortOrdersByDate(approved);
            this.listaNarudzbina = [];
            this.listaNarudzbina = this.listaNarudzbina.concat(onHold);
            this.listaNarudzbina = this.listaNarudzbina.concat(rejected);
            this.listaNarudzbina = this.listaNarudzbina.concat(approved);
        },
        dodajPoruku(index){
            this.showComp = 'obavestenje'
            this.selectedIndex = index
        },
        zatvori(){
            this.showComp = ''
            this.selectedIndex = ''
        },
        prosledi(prosledjenoObavestenje){
            this.listaNarudzbina[this.selectedIndex].Order.Notification = prosledjenoObavestenje;
            this.showComp = '';
            this.selectedIndex = ''
        },
        updateOrderStatus(index,vrednost){
            const formData = new FormData();
            formData.append('OrderId', this.listaNarudzbina[index].Order.Id);
            formData.append('RequestStatus', vrednost);
            formData.append('Notification', this.listaNarudzbina[index].Order.Notification);

            fetch(destinationUrl + "/Order/UpdateOrderState", {
                method: 'POST',
                body: formData
            }).then(response => response.ok ? response.json() : new Error())
            .then(result => {
                if(result.Success) {
                    this.$set(this.listaNarudzbina[index].Order, 'RequestStatus', Status[vrednost - 1]);
                    this.sortiraj();
                    if(vrednost == 1){
                        this.$message({message: "Uspešno ste potvrdili narudžbinu.", type: 'success'})
                    }
                    else if (vrednost == 2){
                        this.$message({message: "Uspešno ste odbili narudžbinu.", type: 'success'})
                    }}
                else this.$message({message: "Doslo je do greske!", type: "error"});
            }).catch(error => console.log(error));
        },
        preloadImages() {
            console.log(this.listaNarudzbina);
            let images = [];
            this.listaNarudzbina.forEach(order => {
                order.Order.CartItems.forEach(cartItem => {
                    images.push(cartItem.Image);
                })
            });
            this.preloadedImages = preloadImages(images);
        }
    },
    mounted: function() {
        this.loadOrders();
    }
}
</script>

<style>
/*ne stavljati scoped zbog boje kolona*/
.narudzbina-container-1{
    display: flex;
    height: 100%;
    width: 100%;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    overflow: auto;
}
.narudzbina-container-table-1{
    height: 47%;
    width: 90%;
    display: flex;
    flex-direction: column;
    background-color: rgba(204,204,211,0.931);
    opacity: 1;
    padding: 1em 1em 0em 1em;
}
.el-table .success-row {
    background: #f0f9eb;
    color: green;
}

.el-table .odHold-row{
    background: oldlace;
    color: rgb(255, 166, 0);
}

.el-table .rejected-row{
    background: rgb(255, 180, 180);
    color: rgb(255, 0, 0)
}

.kolonaDugmici-1{
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    flex-wrap: wrap;
}

h3{
    text-align: center;
    font-family: sans-serif;
}
</style>


