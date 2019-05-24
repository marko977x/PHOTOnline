<template>
    <div class="login-container">
        <el-dialog visible width="28%"  @close="$emit('closeLoginForm')" >
            <div class="forma">
                <el-form>
                    <h3 style="text-align:center; margin-bottom:40px;
                    font-size:23px;">Foto Aritonovic</h3>
                    <div class="stavka">
                        <label>Username:</label>
                        <el-input class="input" v-model="loginData.username"
                        placeholder="korisnik@primer.com"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Password:</label>
                        <el-input type="password"
                        class="input" v-model="loginData.password"></el-input>
                    </div>
                    <el-button @click="onLoginSubmit()" type="primary">Prijavi se</el-button>
                </el-form>
            </div>
        </el-dialog>
    </div>
</template>

<script>
export default {
    data() {
        return{
            loginData: {
                Username: '',
                Password: ''
            }
        }
    },
    methods: {
        onLoginSubmit() {
            const formData = new FormData();
            for(let key in this.loginData)
                formData.append(key, this.loginData[key]);

            const fetchData = { 
                    body: formData,
                    method: "POST"
                }
            fetch("https://localhost:5001/api/User/SignIn", fetchData)
                .then(response => {
                    if(response.ok) return response.json();
                    else return new Error(response.Error);
                }).then(result => {
                    if(result.success){
                        setUserInfo(result.data.id, result.data.userType);
                        window.location.href = "/korisnik";
                    }
                    else this.$message(result.error);
                });
        }
    }
}
</script>

<style>
    .login-container{
        display: flex;
        height: 100%;
        width: 100%;
        justify-content: center;
    }
    @media screen and (max-width: 600px){
        .el-dialog{
            display: flex;
            justify-content: center;
            width: 70%;
            position: absolute;
            padding: 0;
            margin: 0px 0px 0px;
        }
    }
</style>