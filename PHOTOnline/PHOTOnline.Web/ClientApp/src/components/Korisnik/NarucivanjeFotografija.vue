<template>
    <div class="prikaz-proizvoda-container">
        <label>Online Naručivanje Fotografija</label>
         <input  multiple type="file" :disabled="omoguciDugme" accept="image/*" @change="uploadImages($event)" id="file-input" >
    </div>
</template>

<script>
import { getUserInfo } from '../../services/contextManagement';
import { apiFetch, destinationUrl, UserTypes, REGULAR_USER_TYPE } from '../../services/authFetch';
export default {
    data(){
        return{
            proiz: this.list,
            omoguciDugme: '',
            Images: [],
        }
    },
    methods:{
         proveraPrijavljen(){
             console.log(getUserInfo().userType)
            if(getUserInfo().userType == REGULAR_USER_TYPE){
                this.omoguciDugme = false;
            }
            else{
                this.omoguciDugme = true;
            }
        },
        async uploadImages(event) {
            this.$emit('startSpinner');
            const promises = [];
            for(let index = 0; index < event.target.files.length; index++) {
                const formData = new FormData();
                formData.append("image", event.target.files[index]);
                promises.push(fetch(destinationUrl + "/Image/UploadImage", {method: 'POST', body: formData})
                    .then(response => {
                        return response.ok ? response.json() : new Error();
                    }).then(result => {
                        this.Images.push(result.Data.Image);
                    }).catch(error => {console.log(error)}));
            }
            await Promise.all(promises);
            this.showPhotos();
            this.$emit('stopSpinner');
        },
        showPhotos(){
            this.$emit("showPhotos",this.Images);
        }
    },
    mounted(){
        this.proveraPrijavljen();
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
