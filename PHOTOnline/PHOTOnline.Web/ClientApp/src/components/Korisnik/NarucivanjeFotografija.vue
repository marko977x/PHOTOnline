<template>
    <div class="prikaz-proizvoda-container">
        <label>Online Naručivanje Fotografija</label>
         <input type="file" :disabled="omoguciDugme" accept="image/*" @click="uploadImage($event)" id="file-input" >
    </div>
</template>

<script>
import { getUserInfo } from '../../services/contextManagement';
import { apiFetch, destinationUrl, UserTypes, REGULAR_USER_TYPE } from '../../services/authFetch';
export default {
    data(){
        return{
            proiz: this.list,
            omoguciDugme: false
        }
    },
    methods:{
        uploadImage(data){
            this.proveraPrijavljen();
            console.log(data);
        },
         proveraPrijavljen(){
             console.log(getUserInfo().userType)
            if(getUserInfo().userType == REGULAR_USER_TYPE){
                this.omoguciDugme = false;
            }
            else{
                this.omoguciDugme = true;
            }
        }
    },
    props: ['list']
}
</script>

<style scoped>
.prikaz-proizvoda-container{
     height: 100px;
    width: 75%;
   /* background: linear-gradient(0deg, #d1d356, #e6e88d );*/
    background: linear-gradient(0deg, #bccecfe7, #fcfcfc );
    margin-top: 15px;
    border-radius: 3px;
    margin-left: 15%;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
}

</style>
