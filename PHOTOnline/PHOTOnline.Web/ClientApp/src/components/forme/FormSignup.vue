<template>
    <div class="signup-container">
        <el-dialog @close="$emit('closeSignUpForm')" visible width="35%">
            <div class="forma">
                <el-form>
                    <h3 style="text-align:center; margin-bottom:40px;
                    font-size:23px;">
                        SIGN UP
                    </h3>
                    <div class="stavka">
                        <label>Ime:</label>
                        <el-input class="input" v-model="signupData.FirstName"
                                  placeholder="ime"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Prezime:</label>
                        <el-input class="input" v-model="signupData.LastName"
                                  placeholder="prezime"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Adresa:</label>
                        <el-input class="input" v-model="signupData.Address"
                                  placeholder="ulica bb"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Broj Telefona:</label>
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
                                  placeholder="username"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Password:</label>
                        <el-input class="input" v-model="signupData.Password"
                                  placeholder=""></el-input>
                    </div>
                    <div class="dugme">
                        <el-button @click="onSignUpClick()" type="primary">Sačuvaj</el-button>
                    </div>
                </el-form>
            </div>
        </el-dialog>

    </div>
</template>

<script>
    import { } from 'element-ui';
import { setUserInfo } from '../../services/contextManagement';
import { destinationUrl } from '../../services/authFetch';

    const REGULAR_USER_TYPE = 1;

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
                    Password: '',
                    UserType: REGULAR_USER_TYPE
                }
            }
        },
        methods: {
            onSignUpClick() {
                apiFetch('POST', destinationUrl + "/User/CreateUserAsync", this.signupData)
                    .then(result => {
                        if(result.success){
                            setUserInfo(result.data, REGULAR_USER_TYPE);
                            window.location.href = "/korisnik";
                        } 
                        else this.$message("Pogresni podaci");
                    }).catch(error => {
                        console.log(error);
                    });
            }
        }
    }
</script>

<style scoped>

    .stavka {
        display: flex;
        flex-direction: row;
    }

    .input {
        flex-basis: 80%;
    }

    label {
        flex-basis: 20%;
    }

    .dugme {
        display: flex;
        justify-content: flex-end;
    }
</style>

