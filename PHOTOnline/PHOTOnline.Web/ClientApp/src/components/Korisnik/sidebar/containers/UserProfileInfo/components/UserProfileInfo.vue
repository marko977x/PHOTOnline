<template>
    <div class="profil-card">
        <div class="profile-avatar"><img
            :src="profileAvatarUrl"/>
        </div>
        <div class="profile-info-line">
            <label>Ime:</label>
            <label>{{user.FirstName}}</label>
        </div>
        <div class="profile-info-line">
            <label>Prezime:</label>
            <label>{{user.LastName}}</label>
        </div>
    
        <div class="profile-info-line">
            <label>Email:</label>
            <label>{{user.Email}}</label>
        </div>
        <div class="profile-info-line">
            <label>Password:</label>
            <label>{{user.Password}}</label>
        </div>
        <div class="profile-info-line">
            <label>Adresa:</label>
            <label>{{user.Adress}}</label>
        </div>
        <div class="profile-info-line">
            <label>Broj telefona:</label>
            <label>{{user.PhoneNumber}}</label>
        </div>
        <div class="dugme">
            <el-button
                class="dugme-lozinka" 
                type="primary"
                @click="() => $emit('openChangePasswordForm')"> 
                Promeni Lozinku
            </el-button>
        </div>
    </div>
</template>

<script>

import profileAvatar from "../../../../../../assets/profile_avatar.png";
import { getUserInfo } from '../../../../../../services/contextManagement';
import { destinationUrl } from '../../../../../../services/authFetch';

export default {
    data() {
        return {
            profileAvatarUrl: profileAvatar,
            user: {
                FirstName: '',
                LastName: '',
                Email: '',
                Password: '',
                Adress: '',
                PhoneNumber: ''
            }
        }
    },
    methods: {
        getUser(){
            let userId = getUserInfo().userID;
            console.log(userId)
            fetch(destinationUrl + '/User/GetUserById/?id=' + userId, {method: "GET"})
                .then(response => response.ok ? response.json() : new Error())
                .then(result => {
                    console.log(result)
                    this.user.FirstName = result.Data.FirstName;
                    this.user.LastName = result.Data.LastName;
                    this.user.Email = result.Data.Email;
                    this.user.Password = "*****";
                    this.user.Adress = result.Data.Address;
                    this.user.PhoneNumber = result.Data.PhoneNumber;
                })
        }
    },
    mounted: function() {
        this.getUser();
    }
}
</script>


<style scoped>

.profile-avatar {
    width: 100%;
    display: flex;
    justify-content: center;
 }

 .profile-info-line {
    width: 80%;
    display: flex;
    flex-direction: row;
    align-items: center;
    margin: 0 auto;     
}

.profil-card {
    width: 100%;
    padding: 1em;
    background: rgba(240, 240, 255, 0.8);
    border-radius: 10px;
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
}

.dugme-lozinka{
    width: 200px;
    font-size: 15px;
}
.dugme{
     display: flex;
     height: 100px;
    justify-content: center;
    align-items: center;
}


.profile-info-line label {
    width: 40%;
    font-size: 1.35vw;
}

.profile-info-line label + label {
    color: rgba(0, 0, 0, 0.7)
}

</style>
