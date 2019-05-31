<template>
    <div class="korpa-container">
        <div class="korpa-table-container">
                    <el-table :data="tableData"
                    style="border-radius: 5px;">
            <el-table-column
                    prop="tip"
                    label="Tip"
                    class="table-column">
            </el-table-column>
             <el-table-column 
                     prop="kolicina"
                    label="Kolicina"
                    class="table-column">
            </el-table-column>
            <el-table-column 
                    prop="format"
                    label="Format"
                    class="table-column">
            </el-table-column>
            <el-table-column align="right">
                <template slot="">
                    <el-button type="danger" icon="el-icon-delete" circle size="mini"
                        @click="$event('obrisiNarudzbinu')"></el-button>
                </template>
            </el-table-column>
        </el-table>
         <el-button @click="Naruci()" type="primary">Naruci</el-button>
        </div>   
    </div>
</template>

<script>
import FormPrikazSolja from "./FormPrikazSolja.vue"
import FooterBar from "../appBar/FooterBar.vue"
export default {
    components: {FormPrikazSolja, FooterBar},
    data(){
        return{
             tableData: [
                {
                    tip: 'Fotografija',
                    kolicina: 4,
                    format: '13x18'
                },
                 {
                    tip: 'Kalendar',
                    kolicina: 1,
                    format: 'Srednji'
                }
            ]
        }
    },
    methods: {
        Naruci: function()
        {   

        }
    }
}
</script>

<style>
.korpa-container{
        display: flex;
        height: 90%;
        width: 100%;
        flex-direction: column;
        overflow: auto;
        background-color: rgba(224, 224, 235, 0.5);  
}
.korpa-table-container{
    display: flex;
    padding: 5px;
    height: 40%;
    width: 60%;
    flex-direction: column;
    align-items: center;
}

.footer-bar{
    justify-content: flex-end;
}

</style>


