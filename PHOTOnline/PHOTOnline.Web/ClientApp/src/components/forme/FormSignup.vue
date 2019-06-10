<template>
    <div class="signup-container">
        <el-dialog visible width="30%" @close="$emit('zavrsiPrijavu')">
            <div class="forma">
                <el-form>
                    <h3 style="text-align:center; margin-bottom:40px;
                    font-size:23px;">
                        SIGN UP
                    </h3>
                    <div class="stavka">
                        <label>Ime:</label>
                        <el-input class="input" v-model="signupData.FirstName"
                                  placeholder="Petar"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Prezime:</label>
                        <el-input class="input" v-model="signupData.LastName"
                                  placeholder="Petrovic"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Adresa:</label>
                        <el-input class="input" v-model="signupData.Address"
                                  placeholder="Ulica bb"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Broj telefona:</label>
                        <el-input class="input" v-model="signupData.PhoneNumber"
                                  placeholder="06X xxx xxx"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Email:</label>
                        <el-input class="input" v-model="signupData.Email"
                                  placeholder="korisnik@primer.com"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Username:</label>
                        <el-input class="input" v-model="signupData.Username"
                                  placeholder="Username"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Password:</label>
                        <el-input class="input" v-model="signupData.Password"
                                  placeholder="****"></el-input>
                    </div>
                    <div class="dugme">
                        <el-button @click="onSignUpClick()" type="primary" style="margin-right:5px;">Sačuvaj</el-button>
                    </div>
                </el-form>
            </div>
        </el-dialog>

    </div>
</template>

<script>
    import { } from 'element-ui'
    import {setUserInfo} from "../../services/contextManagement";
import { apiFetch, destinationUrl, UserTypes, REGULAR_USER_TYPE } from '../../services/authFetch';
import { ERRORS } from '../../data/errorsCode';
    export default {
        data() {
            return {
                signupData: {
                    FirstName: '',
                    LastName: '',
                    Address: '',
                    PhoneNumber: '',
                    Email: '',
                    Username: '',
                    Password: ''
                }
            }
        },
        methods: {
            onSignUpClick() {
                if(!this.isDataValid()) this.$message({message: "Morate popuniti sva polja", type: "warning"});
                else if(!this.isPhoneNumberValid()) this.$message({message: "Broj telefona nije validan", type: "warning"});
                else {
                    apiFetch('POST', destinationUrl + "/User/CreateUserAsync", this.signupData)
                        .then(result => {
                            console.log(result);
                            if(result.Success) {
                                setUserInfo(result.Data, REGULAR_USER_TYPE);
                                window.location.href = "/" + UserTypes[REGULAR_USER_TYPE];
                            }
                            else if(result.Errors != null && result.Errors.length != 0) {
                                console.log("Error");
                                this.$message({message: ERRORS[result.Errors[0].Code], type: "error"});
                            }
                        });
                }
            },
            isDataValid() {
                const {FirstName, LastName, Address, PhoneNumber, Email, Username, Password} = this.signupData;
                return !FirstName || !LastName || !Address || !PhoneNumber || !Email || !Username || !Password ? 
                    false : true;
            },
            isPhoneNumberValid() {
                console.log(parseInt(this.signupData.PhoneNumber));
                if(isNaN(parseInt(this.signupData.PhoneNumber)) || this.signupData.PhoneNumber == "")
                    return false;
                return true;
            }
        }
    }
</script>

<style scoped>

    .stavka {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        padding: 5px;
    }

    .input {
        flex-basis: 70%;
        margin: 0;
    }

    label {
        flex-basis: 30%;
        font-size: 15px;
    }

    .dugme {
        display: flex;
        justify-content: flex-end;
        padding: 5px;
    }
    @media screen and (max-width: 1250px){
        .stavka{
            flex-direction: column;
            padding: 0;
        }
        .dugme{
            margin-top: 5px;
        }
        label{
            margin-bottom: 0;
        }
    }
</style>

