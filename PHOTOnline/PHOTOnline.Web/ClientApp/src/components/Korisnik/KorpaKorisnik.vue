<template>
    <div class="korpa-container">
        <div class="korpa-table-container">
                    <el-table
             >
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
            <el-table-column align="right">
                <template slot="">
                      <el-button type="danger" size="mini">Potvrdi</el-button>
                    <el-button type="info" icon="el-icon-message" circle size="mini"
                        @click="$event('poruka')"></el-button>
                </template>
            </el-table-column>
        </el-table>
        </div>
        <footer-bar></footer-bar>
    </div>
</template>

<script>
import FormPrikazSolja from "./FormPrikazSolja.vue"
import FooterBar from "../FooterBar.vue"
export default {
    components: {FormPrikazSolja, FooterBar},
    data(){
        return{
            
        }
    }
}
</script>

<style>
.korpa-container{
        display: flex;
        height: 100%;
        width: 100%;
        flex-direction: column;
        overflow: auto;
        background-color: rgba(224, 224, 235, 0.5);
}
.korpa-table-container{
    display: flex;
    padding: 20px;
}
.footer-bar{
    justify-content: flex-end;
}
</style>


