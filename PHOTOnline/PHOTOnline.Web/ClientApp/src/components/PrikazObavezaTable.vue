<template>
    <div class="prikaz-obaveza">
        <el-table v-if="this.ListaObaveza.length > 0">
            <el-table-column
                    prop="datum"
                    label="Datum"
                    class="table-column"
                    width="150">
            </el-table-column>
             <el-table-column 
                     prop="dan"
                    label="Dan u nedelji"
                    class="table-column"
                    width="200">
            </el-table-column>
            <el-table-column 
                    prop="vreme"
                    label="Vreme"
                    class="table-column"
                    width="150">
            </el-table-column>
            <el-table-column 
                     prop="lokacija"
                    label="Lokacija"
                    class="table-column"
                   width="150">
            </el-table-column>
             <el-table-column 
                     prop="tip"
                    label="Tip"
                    class="table-column"
                    width="150">
            </el-table-column>
             <el-table-column 
                     prop="info"
                    label="Dodatne informacije"
                    class="table-column"
                    width="250">
            </el-table-column>
        </el-table>
        <label v-else> Trenutno nemate dodeljene obaveze </label>
    </div>
</template>

<script>
export default {
    data() {
        return{
            ListaObaveza: 'lista'
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


