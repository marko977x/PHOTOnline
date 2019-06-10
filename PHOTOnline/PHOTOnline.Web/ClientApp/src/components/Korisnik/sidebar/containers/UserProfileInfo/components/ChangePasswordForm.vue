<template>
    <div class="promena-lozinke-container">
        <div class="form-lozinka-line">
            <label>Unesite staru lozinku:</label>
            <el-input class="elInput" type="password" v-model="oldPass"></el-input>
        </div>
        <div class="form-lozinka-line">
            <label>Unesite novu lozinku:</label>
            <el-input class="elInput" type="password" v-model="newPass"></el-input>
        </div>
        <div class="form-lozinka-line">
            <label>Ponovite lozinku:</label>
            <el-input class="elInput" type="password" v-model="newPassRe"></el-input>
        </div>
        <div class="form-lozinka-buttons">
            <el-button @click="potvrdiUnos" >Potvrdi</el-button>
            <el-button @click="ponistiUnos" type="danger">Poništi</el-button>
        </div>
    </div>
</template>
<script>
    import {} from 'element-ui'
import { apiFetch, destinationUrl } from '../../../../../../services/authFetch';
import { getUserInfo, clearFormMode } from '../../../../../../services/contextManagement';
import { ERRORS} from "../../../../../../data/errorsCode.js";
    export default {
        components:{

        },
        data(){
            return{
                oldPass: '',
                newPass: '',
                newPassRe: '',
            }
        },
        methods: {
            validacijaPassworda: function(){
                if(this.oldPass == "" || this.newPass == "" || this.newPassRe == "") {
                    this.$message({message: "Morate uneti sva polja", type: 'error'});
                    return false;
                }
                if(this.newPass != this.newPassRe){
                    this.$message({message: "Lozinke se ne podudaraju", type: 'error'});
                    this.newPass = '';
                    this.newPassRe = '';
                    return false;
                }
                if(this.newPass.length < 6){
                    this.$message({message: "Lozinka mora da ima bar 6 karaktera", type: 'warning'});
                    this.newPass = '';
                    this.newPassRe = '';
                    return false;
                }
                return true;
            },
            potvrdiUnos: function(){
                if(this.validacijaPassworda()){
                    apiFetch('POST', destinationUrl + "/User/ResetPassword", {
                        UserId: getUserInfo().userID,
                        OldPassword: this.oldPass,
                        NewPassword: this.newPass
                    }).then(result => {
                        console.log(result);
                        if(result.Success) {
                            this.$message({message: "Uspesno ste promenili lozinku", type: "success"});
                            this.clearFormFilds();
                            this.$emit("closeChangePasswordForm");
                        }
                        else if(result.Errors != null) {
                            result.Errors.forEach(error => this.$message({
                                message: ERRORS[error.Code],
                                type: "warning"
                            }));
                        }
                    });
                }
            },
            ponistiUnos: function(){
                this.clearFormFilds();
                this.$emit("closeChangePasswordForm");
            },
            clearFormFilds() {
                this.newPass = "";
                this.newPassRe = "";
                this.oldPass = "";
            }
        }
    }
</script>

<style scoped>
    .promena-lozinke-container{
        width: 100%;
        height: 100%;
        margin-top: 30px;
    }

    .promena-lozinke-container h1{
        font-size: 23px;
        margin-bottom: 1.5em;
    }

    .form-lozinka-line{
        display: flex;
        align-content: center;
        justify-content: center;
        margin-top: 2vh;
    }

    .form-lozinka-line label{
        flex: 1;
        font-size: 14px;
    }

    .elInput {
        flex: 1;
    }

    /* .form-lozinka-line label + * {
        width: 30%;
    } */

    .form-lozinka-buttons{
        margin-top: 1.5em;
        width: 100%;
        display: flex;
        justify-content: flex-end;
    }
</style>