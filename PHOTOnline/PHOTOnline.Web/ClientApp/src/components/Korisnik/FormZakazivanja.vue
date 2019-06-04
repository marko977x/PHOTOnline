<template>
    <div class="zakazivanja-korisnik-profil">
         <el-table :data="this.listaZahteva"
            :default-sort = "{prop: 'Date', order: 'descending'}"
                style="font-size: 17px;">
                <el-table-column prop="Date" label="Datum" class="table-column"></el-table-column>
                <el-table-column prop="Time" label="Vreme" class="table-column"></el-table-column>
                <el-table-column prop="Location" label="Lokacija" class="table-column"></el-table-column>
                <el-table-column prop="EventType" label="Tip" class="table-column"></el-table-column>
                <el-table-column prop="RequestStatus" align="right" label="Status">
                    <template slot-scope="scope" label="Status">
                        <el-button v-if="scope.row.RequestStatus == 1" type="success" 
                            icon="el-icon-check" circle @click="obavestenje(scope.row)"></el-button>
                        <el-button v-if="scope.row.RequestStatus == 2" type="danger"
                            icon="el-icon-close" circle  @click="obavestenje(scope.row)"></el-button>
                        <el-button v-if="scope.row.RequestStatus == 3" type="warning"
                            icon="el-icon-question" circle  @click="obavestenje(scope.row)"></el-button>
                    </template>
                </el-table-column>
            </el-table>
    </div>
</template>

<script>
import { apiFetch, destinationUrl } from '../../services/authFetch';
import { getUserInfo } from '../../services/contextManagement';
export default {
    data(){
        return{
            poruka1: 'Vas zahtev je prihvacen.',
            poruka2: 'Vas zahtev je odbijen.',
            poruka3: 'Vas zahtev se obradjuje, dobicete potvrdu mailom!',
            listaZahteva: []
        }
    },
    methods: {
        obavestenje(row){
            if(row.RequestStatus == 1)  this.$notify({title: "OBAVEŠTENJE", message: row.Notification==null ? this.poruka1 : row.Notification, type: 'success',  position: 'bottom-right' })
            else if(row.RequestStatus == 2) this.$notify({title: "OBAVEŠTENJE", message: row.Notification==null ? this.poruka2 : row.Notification, type: 'error', position: 'bottom-right'})
            else this.$notify({title: "OBAVEŠTENJE", message: this.poruka3, type: 'warning', position: 'bottom-right'})
        },
        pribaviZahteve(){
            let userId = getUserInfo().userID;
            console.log(userId)
            fetch(destinationUrl + '/Request/GetRequestsByUserId/?id=' + userId, {method: "GET"})
                .then(response => response.ok ? response.json() : new Error())
                .then(result => {
                    this.listaZahteva = result.Data
                })
        }
    },
    beforeMount(){
        this.pribaviZahteve()
    }
}
</script>

<style scoped>
.zakazivanja-korisnik-profil{
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100%;
}
.el-table{
    width: 100%;
    height: 60%;;
}
</style>


