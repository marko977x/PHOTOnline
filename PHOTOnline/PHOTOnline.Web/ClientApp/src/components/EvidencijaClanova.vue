<template>
    <div class="evidencija-container">
        <div class="evidencija-container-inner">
            <filter-clanova hidden></filter-clanova>
            <h5 style="text-align:center; font-family:sans-serif;"> Evidencija Članova </h5>
                 <el-table
                 :data="tableData.filter(data => !search || data.ime.toLowerCase().includes(search.toLowerCase()))"
                  style="width:100%">
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
                            prop="tip"
                            label="Tip"
                            class="table-column">
                        </el-table-column>
                        <el-table-column 
                            prop="username"
                            label="Username"
                            class="table-column">
                        </el-table-column>
                         <el-table-column 
                            prop="password"
                            label="Password"
                            class="table-column">
                        </el-table-column>
                        <el-table-column
                            align="right">
                            <template slot="header">
                                <el-input v-model="search"
                                        size="big"
                                        placeholder="Unesite ime za pretragu">
                                </el-input>
                            </template>
                            <template slot-scope="">
                                <el-button size="mini">Izmeni</el-button>
                                <el-button size="mini" type="danger"> Otpusti </el-button>
                            </template>
                        </el-table-column>
                 </el-table>
                 <div class="dodaj-button">
                     <el-button type="primary" size="mini" style="height:40px;width:95px;">Dodaj Člana</el-button>
                 </div>
        </div>
          <form-dodaj-clana hidden ></form-dodaj-clana>
    </div>
</template>

<script>
import FilterClanova from './FilterClanova'
import FormDodajClana from './FormDodajClana'
import {} from 'element-ui'
export default {
    components: {FilterClanova,FormDodajClana},
    data(){
        return{
            search: '',
            tableData: [
                {
                    ime: 'Vladica',
                    prezime: 'Stojanovic',
                    datumrodj: '21.06.1984',
                    tip: 'Fotograf',
                    username: 'vladica@fotoa.com',
                    password: '12345'

                },
                 {
                    ime: 'Mladjan',
                    prezime: 'Ristic',
                    datumrodj: '21.06.1984',
                    tip: 'Kamerman',
                     username: 'vladica@fotoa.com',
                    password: '12345'
                },
                 {
                    ime: 'Jovica',
                    prezime: 'Kovacevic',
                    datumrodj: '21.06.1984',
                    tip: 'Kamerman',
                     username: 'vladica@fotoa.com',
                    password: '12345'
                },
                {
                    ime: 'Djordje',
                    prezime: 'Jankovic',
                    datumrodj: '28.02.1997',
                    tip: 'Korisnik',
                     username: 'vladica@fotoa.com',
                    password: '12345'
                }

            ]
        }
    }
}
</script>

<style>
    .evidencija-container{
        display: flex;
        height: 100%;
        width: 100%;
        justify-content: center;
        align-items: center;
    }
    .evidencija-container-inner{
        height: 85%;
        width: 90%;
        display: flex;
        flex-direction: column;
        background-color: rgba(204,204,211,0.931);
        opacity: 1;
        padding: 1em;
    }
    .dodaj-button{
        height: 50px;
        width: 100%;
        display: flex;
        justify-content: flex-end;
    }
    .el-table{
        margin-bottom: 15px;
    }

    @media screen and (max-width: 700px){
        .evidencija-container-inner{
            height: 100%;
            width: 100%;
            padding: 0.5em;
        }
    }
</style>

