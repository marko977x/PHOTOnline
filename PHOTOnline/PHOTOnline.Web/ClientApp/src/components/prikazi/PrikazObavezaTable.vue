<template>
    <div class="prikaz-obaveza">
        <el-table v-if="this.ListaObaveza.length > 0"
            :data="tableData">
            <el-table-column
                    prop="datum"
                    label="Datum"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="dan"
                    label="Dan u nedelji"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                    prop="vreme"
                    label="Vreme"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                     prop="lokacija"
                    label="Lokacija"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="tip"
                    label="Tip"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="info"
                    label="Dodatne informacije"
                    class="table-column">
            </el-table-column>
        </el-table>
        <label v-else> Trenutno nemate dodeljene obaveze </label>
    </div>
</template>

<script>
export default {
    data() {
        return{
            ListaObaveza: 'lista',
            tableData: [
                {datum: '21.09.1997', dan: 'Utorak', vreme: '18:00h', lokacija: 'Restoran Junior', tip: 'Svadba', info: '0614210997'},
                {datum: '21.09.1997', dan: 'Utorak', vreme: '18:00h', lokacija: 'Restoran Junior', tip: 'Svadba', info: '0614210997'},
                {datum: '21.09.1997', dan: 'Utorak', vreme: '18:00h', lokacija: 'Restoran Junior', tip: 'Svadba', info: '0614210997'},
                {datum: '21.09.1997', dan: 'Utorak', vreme: '18:00h', lokacija: 'Restoran Junior', tip: 'Svadba', info: '0614210997'},
            ]
        }
    }
}
</script>

<style scoped>
 .prikaz-obaveza{
     display: flex;
     justify-content: center;
     
 }
</style>


