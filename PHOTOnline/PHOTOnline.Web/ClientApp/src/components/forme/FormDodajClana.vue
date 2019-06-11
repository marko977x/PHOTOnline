<template>
    <div class="dodaj-clana-container">
        <el-dialog visible width="28%" heigth="30%" title="Dodavanje zaposlenog" @close="$emit('zatvoriDodavanjeClana')" :modal-append-to-body="false">
            <el-form>
                <!-- <h3 style="text-align:center; font-family:sans-serif; font-size:20px;">Dodavanje Zaposlenog </h3> -->
                <div class="stavka">
                    <label>Ime:</label>
                    <el-input v-model="zaposleni.FirstName" placeholder="Ime" size="small"></el-input>
                </div>
                <div class="stavka">
                    <label>Prezime:</label>
                    <el-input v-model="zaposleni.LastName" placeholder="Prezime" size="small"></el-input>
                </div>
                <div class="stavka">
                    <label>Email:</label>
                    <el-input v-model="zaposleni.Email" placeholder="korisnik@primer.com" size="small"></el-input>
                </div>
                <div class="stavka">
                    <label>Username:</label>
                    <el-input v-model="zaposleni.Username" placeholder="username" size="small"></el-input>
                </div>
                <div class="stavka">
                    <label>Password:</label>
                    <el-input v-model="zaposleni.Password" placeholder="password" type="password" size="small"></el-input>
                </div>
                <el-button type="primary" size="mini" @click="prihvatiUnosForme()">Potvrdi</el-button>
            </el-form>
        </el-dialog>
    </div>
</template>

<script>

    import { apiFetch, destinationUrl, PHOTOGRAPH_USER_TYPE } from "../../services/authFetch";
    import openSpinner from "./FormDodajAlbum.vue";
import { ERRORS } from '../../data/errorsCode';
    export default {
        data() {
            return {
                zaposleni: { FirstName: '', LastName: '', Email: '', Username: '', Password: '', UserType: PHOTOGRAPH_USER_TYPE },
            }
        },
        methods: {
            prihvatiUnosForme() {
                apiFetch('POST', destinationUrl + "/User/CreatePhotographAsync", this.zaposleni)
                    .then(result => {
                        if(result.Success) {
                            this.$message("Uspesno ste dodali novog fotografa!");
                            this.$emit("zatvoriDodavanjeClana");
                        }
                        else if(result.Errors != null && result.Errors.length != 0) {
                            this.$message({message: ERRORS[result.Errors[0].Code], type: "error"});
                        }
                    }).catch(error => {
                        console.log(error);
                    });
            }
        }
    }
</script>

<style scoped>

    .dodaj-clana-container {
        justify-content: center;
    }

    label {
        font-size: 15px;
        text-align: left;
        flex-basis: 30%;
        width: 30%;
    }

    .stavka {
        display: flex;
        flex-direction: row;
        margin: 5px;
    }

    .el-input {
        flex-basis: 70%;
        width: 70%;
    }
    .el-input.el-input--small{
        width: 100%;
        margin: 0px;
    }

    .stavka-2 {
        display: flex;
        justify-content: flex-end;
        margin: 10px;
    }
</style>


