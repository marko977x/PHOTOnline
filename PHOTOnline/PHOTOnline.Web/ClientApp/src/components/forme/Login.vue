<template>
    <div class="login-container">
        <el-dialog visible width="28%"  @close="$emit('closeLoginForm')" >
            <div class="forma">
                <el-form>
                    <h3 style="text-align:center; margin-bottom:40px;
                    font-size:23px;">LOG IN</h3>
                    <div class="stavka">
                        <label>Username:</label>
                        <el-input class="input" v-model="loginData.Email"
                        placeholder="korisnik@primer.com"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Password:</label>
                        <el-input type="password"
                        class="input" v-model="loginData.Password"></el-input>
                    </div>
                    <div class="stavka2">
                        <h6><a>Sign up</a></h6>
                    </div>
                    <el-button @click="onLoginSubmit()" type="primary">Prijavi se</el-button>
                </el-form>
            </div>
        </el-dialog>
    </div>
</template>

<script>
import { apiFetch, destinationUrl, UserTypes } from '../../services/authFetch';
import {setUserInfo} from '../../services/contextManagement';
export default {
    data() {
        return{
            loginData: {
                Email: '',
                Password: ''
            }
        }
    },
    methods: {
        onLoginSubmit() {
            apiFetch('POST', destinationUrl + "/User/SignIn", this.loginData)
                .then(result => {
                    if(result.Success){
                        setUserInfo(result.Data.Id, result.Data.UserType);
                        console.log(result);
                        window.location.href = "/" + UserTypes[result.Data.UserType];
                    }
                    else this.$message("Pogreska lozinka ili email adresa!");
                }).catch(error => {
                    console.log(error);
                });
        }
    }
}
</script>

<style scoped>
    .login-container{
        display: flex;
        height: 100%;
        width: 100%;
        justify-content: center;
    }
    .stavka{
        display: flex;
        justify-content: space-between;
        margin-bottom: 10px;
    }
    .stavka2 {
        display: flex;
        justify-content: center;
        color:dodgerblue;
    }
    .el-input{
        margin: 0;
        width: 60%;
    }

    @media screen and (max-width: 1250px){
        /*.el-dialog{
            display: flex;
            justify-content: center;
            width: 70%;
            position: absolute;
            padding: 0;
            margin: 0px 0px 0px;
        }
        el-dialog{
            width: 100%;
        }*/
        .stavka{
            flex-direction: column;
        }
    }
</style>