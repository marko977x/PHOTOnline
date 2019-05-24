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
                 <div class="stavka-2">
                   <el-select v-model="tip" placeholder="Izaberi Tip" size="small">
                       <el-option v-for="item in tip" :key="item.value" :value="item.value" :label="item.value">{{item.value}}</el-option>
                   </el-select>
                </div>
                 <div class="stavka">
                    <label>Username:</label>
                    <el-input v-model="zaposleni.username" placeholder="korisnik@primer.com" size="small"></el-input>
                </div>
                 <div class="stavka">
                    <label>Password:</label>
                    <el-input v-model="zaposleni.password" placeholder="password" type="password" size="small"></el-input>
                </div>
                <el-button type="primary" size="mini" @click="$emit('dodaj')">Potvrdi</el-button>
            </el-form>
        </el-dialog>
    </div>
</template>

<script>
export default {
    data(){
        return{
            zaposleni: {ime:'',prezime: '', username: '', password: ''},
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


