<template>
    <div class="evidencija-container">
        <div class="evidencija-container-inner">
            <filter-clanova hidden></filter-clanova>
            <div id="select"> 
                <div style="flex: 1"></div>
                <h5 style="text-align:center; font-family:sans-serif; flex: 1"> Evidencija članova </h5>
                <div class="select-container" style="flex: 1; justify-content: flex-end; display: flex">
                    <el-select :value="user" @change="setUser($event)">
                        <el-option :value="'Fotograf'">Fotograf</el-option>
                        <el-option :value="'Korisnik'">Korisnik</el-option>
                    </el-select>
                </div>
            </div>
            <el-table style="width: 100%" :data="tableData.filter(data => !search || data.FirstName.toLowerCase().includes(search.toLowerCase()))">
                <el-table-column prop="FirstName" label="Ime" class="table-column"></el-table-column>
                <el-table-column prop="LastName" label="Prezime" class="table-column"></el-table-column>
                <el-table-column prop="UserType" label="Tip" class="table-column"></el-table-column>
                <el-table-column prop="UserName" label="Username" class="table-column"></el-table-column>
                <el-table-column align="right">
                    <template slot="header" slot-scope="scope">
                        <el-input v-model="search" style="margin: 0;" size="big" placeholder="Ime za pretragu" :focus="scope.search">
                        </el-input>
                    </template>
                    <template slot-scope="scope" >
                        <el-button v-if="scope.row.UserType == userTypes[photographUserType]" size="mini" type="danger" @click="deleteUser(scope.row.Id)">
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
import { apiFetch, destinationUrl, UserTypes, PHOTOGRAPH_USER_TYPE } from '../services/authFetch';
import { constants } from 'fs';
    export default {
        components: { FilterClanova, FormDodajClana },
        data() {
            return {
                tableData: [],
                showComp: '',
                search: '',
                photographUserType: PHOTOGRAPH_USER_TYPE,
                userTypes: UserTypes,
                user: '',
            }
        },
        methods: {
            skloni(row){
                console.log(row)
            },
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
            },
            setUser(event){
                this.user = event;
                console.log(this.user)

                if(this.user == UserTypes[PHOTOGRAPH_USER_TYPE]){
                    apiFetch('GET', destinationUrl + "/User/GetAllPhotographs")
                    .then(result => {
                            if(result.Success){
                            this.tableData = result.Data;
                            this.tableData.forEach((data, index) => {
                                data.UserType = UserTypes[result.Data[index].UserType];
                            });
                        }
                        else this.$message({message: "Došlo je do greške!", type: 'error'})
                    });
                    console.log(this.Users)
                }
                else{
                    apiFetch('GET', destinationUrl + "/User/GetAllRegularUsers")
                    .then(result => {
                        if(result.Success){

                            this.tableData = result.Data;
                             this.tableData.forEach((data, index) => {
                                data.UserType = UserTypes[result.Data[index].UserType];
                            });
                        }
                        else this.$message({message: "Došlo je do greške!", type: 'error'})
                    });
                    console.log(this.Users)
                }
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

<style scoped>
    #select{
        display: flex;
        justify-content: space-between;
        margin-bottom: 10px;
    }

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

