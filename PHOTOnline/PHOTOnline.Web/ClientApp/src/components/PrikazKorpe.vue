<template>
    <div class="korpa-container">
        <el-table 
        :data="tableData"
          style="width:50%; border:1px solid black;">
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
            <el-table-column>
                <template slot="header">
                    <el-checkbox  border size="small" label="Obradjeno"></el-checkbox>
                </template>
                <template slot="">
                    <el-button class="el-icon-download" size="small"></el-button>
                </template>
            </el-table-column>
        </el-table>
    </div>
</template>

<script>
export default {
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
            ],
            endTask: false,
        }
    },
    methods: {
          zavrsi: function(){
              this.endTask = !this.endTask;
          }

    }
}
</script>

<style>
.korpa-container{
        height: 47%;
        width: 90%;
        display: flex;
        flex-direction: column;
        background-color: rgba(204,204,211,0.931);
        opacity: 1;
        padding: 1em;
        justify-content: center;
        align-items: center;
}
.el-icon-download{
    margin-right: 10px;
}
</style>


