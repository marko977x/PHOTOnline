<template>
    <div class="signup-container">
        <el-dialog visible width="35%" @close="$emit('zavrsiDodavanje')">
             <div class="forma">
                <el-form>
                    <h3 style="text-align:center; margin-bottom:40px;
                    font-size:23px;">SIGN UP</h3>
                    <div class="stavka">
                        <label>Ime:</label>
                        <el-input class="input" v-model="signupData.ime"
                        placeholder="ime"></el-input>
                    </div>
                    <div class="stavka">
                        <label>Prezime:</label>
                        <el-input class="input" v-model="signupData.prezime"
                        placeholder="prezime"></el-input>
                    </div>
                      <div class="stavka">
                        <label>Adresa:</label>
                        <el-input class="input" v-model="signupData.adresa"
                        placeholder="ulica bb"></el-input>
                    </div>
                     <div class="stavka">
                        <label>Broj Telefona:</label>
                        <el-input class="input" v-model="signupData.broj"
                        placeholder="06X xxx xxx"></el-input>
                    </div>
                     <div class="stavka">
                        <label>Email:</label>
                        <el-input class="input" v-model="signupData.email"
                        placeholder="korisnik@primer.com"></el-input>
                    </div>
                     <div class="stavka">
                        <label>Username:</label>
                        <el-input class="input" v-model="signupData.username"
                        placeholder="username"></el-input>
                    </div>
                      <div class="stavka">
                        <label>Password:</label>
                        <el-input class="input" v-model="signupData.password"
                        placeholder="*****"></el-input>
                    </div>
                    <div class="dugme">
                    <el-button type="primary">Sačuvaj</el-button>
                    </div>
                </el-form>
            </div>
        </el-dialog>

    </div>
</template>

<script>
import {} from 'element-ui'
export default {
    data(){
        return{
            signupData: {
                ime: '',
                prezime: '',
                adresa: '',
                broj: '',
                email: '',
                username: '',
                password: ''
            }
        }
    }
}
</script>

<style scoped>
.stavka{
    display: flex;
    flex-direction: row;
}
.input{
    flex-basis: 80%;
}
label{
    flex-basis: 20%;
}
.dugme{
    display: flex;
    justify-content: flex-end;
}
</style>

