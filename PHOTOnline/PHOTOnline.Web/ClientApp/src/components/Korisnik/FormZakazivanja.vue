<template>
    <div class="zakazivanja-korisnik-profil">
         <el-table :data="tableData"
            :default-sort = "{prop: 'Date', order: 'descending'}"
                style="font-size: 17px;">
                <el-table-column prop="Date" label="Datum" class="table-column"></el-table-column>
                <el-table-column prop="Time" label="Vreme" class="table-column"></el-table-column>
                <el-table-column prop="Location" label="Lokacija" class="table-column"></el-table-column>
                <el-table-column prop="eventType" label="Tip" class="table-column"></el-table-column>
                <el-table-column align="right" label="Status">
                    <template slot-scope="" label="Status">
                        <el-button v-if="this.status == true" type="success" 
                            icon="el-icon-check" circle @click="obavestenje"></el-button>

                         <el-button v-if="this.status == false" type="danger"
                            icon="el-icon-close" circle  @click="obavestenje"></el-button>

                    </template>
                </el-table-column>
            </el-table>
    </div>
</template>

<script>
export default {
    data(){
        return{
            status: true,
            poruka: 'Vas zahtev se obradjuje, dobicete potvrdu mailom!',
            tableData: [
                {Date: '2011-05-23',Time: '08:00',Location: 'Junior', eventType: 'Svadba'},
                {Date: '2014-05-26',Time: '08:00',Location: 'Junior', eventType: 'Svadba'},
                {Date: '2019-05-24',Time: '08:00',Location: 'Junior', eventType: 'Svadba'},
                {Date: '2016-05-21',Time: '08:00',Location: 'Junior', eventType: 'Svadba'},
            ]
        }
    },
    methods: {
        obavestenje(){
            if(this.status)  this.$notify({title: "OBAVEŠTENJE", message: this.poruka, type: 'success',  position: 'bottom-right' })
            else this.$notify({title: "OBAVEŠTENJE", message: this.poruka, type: 'error', position: 'bottom-right'})
        }
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


