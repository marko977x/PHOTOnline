<template>
    <div class="korpa-container">
        <div class="korpa-table-container">
            <div class="cena">
            <h3>Ukupna cena: {{izracunajCenu()}} RSD</h3>
            </div>
                    <el-table :data="tableData"
                    style="border-radius: 3px;">
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
            <el-table-column 
                    prop="cena"
                    label="Cena"
                    class="table-column">
            </el-table-column>
            <el-table-column align="right">
                <template slot="">
                    <el-button type="danger" icon="el-icon-delete" circle size="mini"
                        @click="$event('obrisiNarudzbinu')"></el-button>
                </template>
            </el-table-column>
        </el-table>
         <el-button @click="Naruci()" type="primary">Naruči</el-button>
        </div>   
        <form-slika :hidden="false" />
    </div>
</template>

<script>
import FormPrikazSolja from "./FormPrikazSolja.vue"
import FooterBar from "../appBar/FooterBar.vue"
import FormSlika from "../forme/FormSlika.vue";
export default {
    components: {FormPrikazSolja, FooterBar, FormSlika},
    data(){
        return{
             tableData: [
                {
                    tip: 'Fotografija',
                    kolicina: 4,
                    format: '13x18',
                    cena: 90
                },
                 {
                    tip: 'Kalendar',
                    kolicina: 1,
                    format: 'Srednji',
                    cena: 450
                }
            ],
        }
    },
    methods: {
        Naruci: function()
        {   

        },
        izracunajCenu(){
            let novacena = 0;
            this.tableData.forEach(element => {
                novacena += element.cena;
            });
            return novacena
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
    height: 80%;
    width: 60%;
    flex-direction: column;
    align-items: center;
}

.footer-bar{
    justify-content: flex-end;
}
.cena {
    display: flex;
    width: 100%;
    height: 50px;
    justify-content: flex-end;
}

</style>


