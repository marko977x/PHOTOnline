<template>
    <div class="signup-container">
        <el-dialog visible width="30%"  @close="$emit('zavrsiPrijavu')">
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
                const formData = new FormData();
                for(let key in this.signupData){
					formData.append(key, this.signupData[key]);
				}
                const fetchData = { 
                    body: formData,
                    method: "POST"
                }
                fetch("https://localhost:5001/api/User/CreateUserAsync", fetchData)
                    .then(response => {
                        console.log(response);
                        return response.json(); 
                    }) 
                    .then(result => {
                        console.log(result);
                    });
            }
        }
    }
</script>

<style scoped>

    .stavka {
        display: flex;
        flex-direction: row;
        padding: 5px;
    }

    .input {
        flex-basis: 70%;
    }

    label {
        flex-basis: 30%;
        font-size: 15px;
    }

    .dugme {
        display: flex;
        justify-content: flex-end;
    }
</style>

