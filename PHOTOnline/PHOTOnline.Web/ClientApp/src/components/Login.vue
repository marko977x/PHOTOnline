<template>
    <div class="login-container">
        <el-dialog visible width="30%"  @close="$emit('zavrsiPrijavu')" >
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
                    <el-button type="primary">Prijavi se</el-button>
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
                    username: '',
                    password:''
                }
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
        margin-bottom: 10px;
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
        el-dialog{
            width: 100%;
        }
    }
</style>