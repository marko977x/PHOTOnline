<template>
    <div class="proizvodi-container">
        <div class="proizvodi-container-inner">
            <h5 style="text-align:center; font-family:sans-serif;"> Lista proizvoda </h5>
            <el-table :data="this.listaProizvoda">
                <el-table-column prop="Title" label="Naziv" class="table-column" width="250px"></el-table-column>
                <el-table-column prop="Price" label="Cena" class="table-column"  width="250px"></el-table-column>
                <el-table-column prop="ProductType" label="Tip" class="table-column"  width="250px"></el-table-column>
                <el-table-column align="right">
                    <template slot-scope="scope">
                        <el-button type="danger" icon="el-icon-delete" circle size="mini"
                            @click="deleteProductItem(scope.row.Id)">
                        </el-button>
                    </template>
                </el-table-column>
            </el-table>
            <div class="dodaj-button">
                <el-button type="primary" size="mini" style="height:40px;" @click="dodajProizvod">
                    Dodaj proizvod
                </el-button>
            </div>
        </div>
        <form-dodaj-proizvod v-if="this.showComp == 'dodaj'" @zatvoriDodavanjeProizvoda="zavrsiDodavanje"></form-dodaj-proizvod>
    </div>
</template>

<script>
    import FormDodajProizvod from './forme/FormDodajProizvod'
    import { } from 'element-ui'
    import { setPageShown } from '../services/contextManagement';
    import { apiFetch, destinationUrl, UserTypes } from '../services/authFetch';
    export default {
        components: { FormDodajProizvod },
        data() {
            return {
                listaProizvoda: [],
                showComp: ''
            }
        },
        methods: {
            deleteProductItem(id){
                /*apiFetch('POST', destinationUrl + "/User/DeleteUserById?id=" + id)
                .then(result => {
                    if(result.Success) {
                        this.$message("Korisnik je uspešno obrisan!");
                        this.$emit("loadDataTable");
                    }
                }).catch(error => {console.log(error)});*/
            },
            dodajProizvod: function () {
                this.showComp = 'dodaj';
                setPageShown('dodaj');
            },
            zavrsiDodavanje() {
                this.showComp = '';
                //this.loadDataTable();
            },
            loadDataTable() {
                apiFetch('GET', destinationUrl + "/Product/GetAllProducts")
                .then(result => {
                    this.listaProizvoda = result.Data;
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

<style scoped>
    .proizvodi-container {
        display: flex;
        height: 100%;
        width: 100%;
        justify-content: center;
        align-items: center;
    }

    .proizvodi-container-inner {
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
        .proizvodi-container-inner {
            height: 100%;
            width: 100%;
            padding: 0.5em;
        }
    }
</style>