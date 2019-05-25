<template>
         <div class="profil-container">
             <div class="profil-card">
                <div class="profile-avatar"><img
                    style="min-width: 60px; min-height: 60px; max-width: 100px; max-height: 100px;"
                    src="../../assets/profileAvatar.png"/>
                </div>
                <div class="profile-info-line">
                    <label>Ime:</label>
                    <label>{{ime}}</label>
                </div>
                <div class="profile-info-line">
                    <label>Prezime:</label>
                    <label>{{prezime}}</label>
                </div>
               
                <div class="profile-info-line">
                    <label>Email:</label>
                    <label>{{email}}</label>
                </div>
                <div class="profile-info-line">
                    <label>Password:</label>
                    <label>{{password}}</label>
                </div>
                <div class="profile-info-line">
                    <label>JMBG:</label>
                    <label>{{jmbg}}</label>
                </div>
                <div class="profile-info-line">
                    <label>Adresa:</label>
                    <label>{{adresa}}</label>
                </div>
                <div class="profile-info-line">
                    <label>Broj telefona:</label>
                    <label>{{brojTelefona}}</label>
                </div>
            </div>
        </div>
</template>

<script>
export default {
    data() {
        return{
            userId: '',
            ime: 'Jovan',
            prezime: 'Aritonovic',
            email: 'sdjkad@gmail.com',
            password: '',
            adresa: '',
            brojTelefona: '',
            jmbg: 0,
        }
    }
    
}
</script>

<style scoped>
.profil-container{
        width: 100%;
        height: 100%;
        display: flex;
        justify-content: center;
        align-content: center;
}

.profile-avatar {
    width: 100%;
    display: flex;
    justify-content: center;
    padding-bottom: 20px;
 }

.profil-card {
    padding: 1em;
    width: 42%;
    height: 80%;
    margin-top: 7vh;
    background: rgba(240, 240, 255, 0.8);
    border-radius: 10px;
    display: flex;
    flex-direction: column;
    justify-content: center;
}

.profile-info-line {
    width: 80%;
    display: flex;
    flex-direction: row;
    align-items: center;
    margin: 0 auto;     
    }

.profile-info-line label {
    width: 40%;
    font-size: 1.35vw;
}

.profile-info-line label + label {
    color: rgba(0, 0, 0, 0.7)
}
</style>
