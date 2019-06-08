<template>
    <div class="evidencija-container">
        <div class="evidencija-container-inner">
            <filter-clanova hidden></filter-clanova>
            <h5 style="text-align:center; font-family:sans-serif;"> Evidencija članova </h5>
            <el-table :data="tableData.filter(data => !search || data.FirstName.toLowerCase().includes(search.toLowerCase()))">
                <el-table-column prop="FirstName" label="Ime" class="table-column" width="250px"></el-table-column>
                <el-table-column prop="LastName" label="Prezime" class="table-column"  width="250px"></el-table-column>
                <el-table-column prop="UserType" label="Tip" class="table-column"  width="250px"></el-table-column>
                <el-table-column prop="UserName" label="Username" class="table-column"  width="200px"></el-table-column>
                <el-table-column align="right" width="200px">
                    <template slot="header" slot-scope="scope">
                        <el-input v-model="search" style="margin: 0;" size="big" placeholder="Ime za pretragu" :focus="scope.search">
                        </el-input>
                    </template>
                    <template slot-scope="scope">
                        <el-button size="mini" type="danger" @click="deleteUser(scope.row.Id)">
                            Obriši
                        </el-button>
                    </template>
                </el-table-column>
            </el-table>
            <div class="dodaj-button">
                <el-button type="primary" size="mini" style="height:40px;width:95px;" @click="dodajClana">
                    Dodaj člana
                </el-button>
            </div>
        </div>
        <form-dodaj-clana v-if="this.showComp == 'album'" @zatvoriDodavanjeClana="zavrsiDodavanje"></form-dodaj-clana>
    </div>
</template>

<script>
    import FilterClanova from './FilterClanova'
    import FormDodajClana from './forme/FormDodajClana'
    import { } from 'element-ui'
    import { setPageShown } from '../services/contextManagement';
import { apiFetch, destinationUrl, UserTypes } from '../services/authFetch';
    export default {
        components: { FilterClanova, FormDodajClana },
        data() {
            return {
                tableData: [],
                showComp: '',
                search: ''
            }
        },
        methods: {
            dodajClana: function () {
                this.showComp = 'album';
                setPageShown('album');
                console.log(this.tableData);
            },
            handleEdit(index, row) {
                console.log(index);
                console.log(row);
            },
            deleteUser(id) {
                apiFetch('POST', destinationUrl + "/User/DeleteUserById?id=" + id)
                .then(result => {
                    if(result.Success) {
                        this.$message("Korisnik je uspešno obrisan!");
                        this.$emit("loadDataTable");
                    }
                }).catch(error => {console.log(error)});
            },
            zavrsiDodavanje() {
                this.showComp = '';
                this.loadDataTable();
            },
            loadDataTable() {
                apiFetch('GET', destinationUrl + "/User/GetAllUsers").then(result => {
                    this.tableData = result.Data;
                    this.tableData.forEach((data, index) => {
                        data.UserType = UserTypes[result.Data[index].UserType];
                    });
                });
            }
        },
        mounted: function() {
            this.$emit('loadDataTable');
        },
        created() {
            this.$on('loadDataTable', this.loadDataTable);
        }
    }
</script>

<style>

    .evidencija-container {
        display: flex;
        height: 100%;
        width: 100%;
        justify-content: center;
        align-items: center;
    }

    .evidencija-container-inner {
        height: 85%;
        width: 90%;
        display: flex;
        flex-direction: column;
        background-color: rgba(204,204,211,0.931);
        opacity: 1;
        padding: 1em;
    }

    .dodaj-button {
        height: 50px;
        width: 100%;
        display: flex;
        justify-content: flex-end;
    }

    .el-table {
        margin-bottom: 15px;
        width: 100%;
    }

    @media screen and (max-width: 700px) {
        .evidencija-container-inner {
            height: 100%;
            width: 100%;
            padding: 0.5em;
        }
    }
</style>

