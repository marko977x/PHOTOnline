<template>
    <div class="dodaj-clana-container">
        <el-dialog visible width="28%" heigth="30%" title="Dodavanje Zaposlenog" @close="$emit('zatvoriDodavanjeClana')">
            <el-form>
               <!-- <h3 style="text-align:center; font-family:sans-serif; font-size:20px;">Dodavanje Zaposlenog </h3> -->
                <div class="stavka">
                    <label>Ime:</label>
                    <el-input v-model="zaposleni.ime" placeholder="Ime" size="small"></el-input>
                </div>
                 <div class="stavka">
                    <label>Prezime:</label>
                    <el-input v-model="zaposleni.prezime" placeholder="Prezime" size="small"></el-input>
                </div>
                 <div class="stavka">
                   <label>Email:</label>
                    <el-input v-model="zaposleni.Email" placeholder="korisnik@primer.com" size="small"></el-input>
                </div>
                 <div class="stavka">
                    <label>Username:</label>
                    <el-input v-model="zaposleni.username" placeholder="username" size="small"></el-input>
                </div>
                 <div class="stavka">
                    <label>Password:</label>
                    <el-input v-model="zaposleni.password" placeholder="password" type="password" size="small"></el-input>
                </div>
                <el-button type="primary" size="mini" @click="prihvatiUnosForme()">Potvrdi</el-button>
            </el-form>
        </el-dialog>
    </div>
</template>

<script>

 const FOTOGRAF_USER_TYPE = 2;

 import {apiFetch, destinationUrl} from "../services/authFetch";
export default {
    data(){
        return{
            zaposleni: {FirstName:'',LastName: '', Email: '', Username: '', Password: '', UserType: FOTOGRAF_USER_TYPE},
            tip: [
                {
                    value: 'Kamerman'
                },
                {
                    value: 'Fotograf'
                },
                {
                    value: 'Korisnik'
                }
            ]
        }
    },
    methods: {
        dodajClana(){
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
        },
        prihvatiUnosForme() {
            apiFetch('POST', destinationUrl + "/User/CreateUserAsync", this.zaposleni)
                .then(result => {console.log(result)});
        }
    }
}
</script>

<style scoped>
    .dodaj-clana-container{
        
        justify-content: center;
    }
    label{
        font-size: 15px;
        text-align: left;
        flex-basis: 30%;
    }
    .stavka{
        display: flex;
        flex-direction: row;
        margin: 10px;
    }
    .input{
    flex-basis: 70%;
    }
    .stavka-2{
        display: flex;
        justify-content: flex-end;
        margin: 10px;
    }
</style>


