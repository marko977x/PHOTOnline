<template>
    <div class="formFotografAlbumContainer">
        <el-form  style="word break: false">
            <div class="stavka">
                <label>Naziv:</label>
                <el-input class="input-polje" v-model="album.Title"></el-input>
            </div>
            <div class="stavka">
                <label>Datum:</label>
                    <el-date-picker class="picker" v-model="album.Date" type="date" placeholder="Izaberi dan">
                    </el-date-picker>
              
            </div>
            <div class="stavka">
                <label>Mesto:</label>
                <el-input class="input-polje" v-model="album.Location"></el-input>
            </div>
            <div class="stavka-2">
                <input multiple type="file" accept="image/*" @change="uploadImages($event)" id="file-input" >
            </div>
            <div class="stavka">
                <label> Password: </label>
                <el-input type="password" class="input-polje" v-model="album.Password"></el-input> 
            </div>
            <div class="dugmici">
            <el-button class="dugme" @click="dodajAlbum()" type="primary">Sačuvaj</el-button>
            <el-button class="dugme1" @click="prekiniDodavanjeAlbuma">Zatvori</el-button>
            </div>
        </el-form>
    </div>
</template>

<script>
    import {destinationUrl} from "../../services/authFetch";
export default {
    data() {
        return {
            album: {
                Title: '',
                Date: '',
                Location: '',
                Password: '',
                Images: []
            }
        }
    },
    methods: {
        validacija: function(){
            if(this.album.Title === '' || this.album.Location === '' || this.album.Date === ''){
                this.$message({message : 'Sva polja moraju biti popunjena', type: 'warning'})
                return
            }
            this.dodajAlbum()
        },
        dodajAlbum: async function(){
            const formData = new FormData();
            formData.append("Title", this.album.Title);
            formData.append("Date", this.album.Date);
            formData.append("Location", this.album.Location);
            formData.append("Password", this.album.Password);
            this.album.Images.forEach((image, index) => {
                formData.append("Images[" + index + "].Id", image.Id);
                formData.append("Images[" + index + "].Title", image.Title);
                formData.append("Images[" + index + "].Original.FileId", image.Original.BlobId);
                formData.append("Images[" + index + "].Original.Url", image.Original.Url);
                formData.append("Images[" + index + "].Thumbnail.FileId", image.Thumbnail.BlobId);
                formData.append("Images[" + index + "].Thumbnail.Url", image.Thumbnail.Url);
                formData.append("Images[" + index + "].Small.FileId", image.Small.BlobId);
                formData.append("Images[" + index + "].Small.Url", image.Small.Url);
                formData.append("Images[" + index + "].Medium.FileId", image.Medium.BlobId);
                formData.append("Images[" + index + "].Medium.Url", image.Medium.Url);
                formData.append("Images[" + index + "].Large.FileId", image.Large.BlobId);
                formData.append("Images[" + index + "].Large.Url", image.Large.Url);
            });
            console.log(formData);
            fetch(destinationUrl + "/Album/AddAlbum", {
                body: formData,
                method: 'POST'
            }).then(response => response.json()).then(
                () => this.$emit('editFinished','cancel')
            ).catch(error => console.log(error));
        },
        prekiniDodavanjeAlbuma: function(){
            this.$emit('editFinished','cancel') // takodje je i ovde 'cancel' podatak koji se salje i koji 
            //ce biti ispisan!
        },
        uploadImages(event) {
            for(let index = 0; index < event.target.files.length; index++) {
                const formData = new FormData();
                formData.append("image", event.target.files[index]);
                fetch(destinationUrl + "/Image/UploadImage", {method: 'POST', body: formData})
                    .then(response => {
                        return response.ok ? response.json() : new Error();
                    }).then(result => {
                        console.log(result.Data);
                        this.album.Images.push(result.Data.Image);
                    }).catch(error => {console.log(error)});
            }
        },
    },
    mounted: function() {console.log(this.album)}
}
</script>

<style scoped>
    .formFotografAlbumContainer{
       width: 100%;
        
    }
    .stavka{   
        display: flex;
        flex-direction: row;
        margin-bottom: 10px;
        width: 100%;
    }
    label{
       font-size: 14px;
       text-align: left;
       flex-basis: 30%;
    }
 
    .input-polje{
        display: flex;
        flex-basis: 70%;
        margin: 0;
    }
    .input-polje.el-input{
        width: 100%;
    }
    .dugmici{
        display: flex;
        justify-content: flex-end;
       
    }
    label{
        width: 30%;
    }
    .dugme{
        width:30%;
        font-size: 14px;
        overflow: hidden;
        text-overflow: ellipsis; 
    }
    .dugme1{
        width:30%;
        font-size: 14px;
        overflow: hidden;
        text-overflow: ellipsis; 
    }
    .picker{
        display: flex;
        flex-basis: 70%;
        margin: 0;
         
    }
    .stavka-2{
        display: flex;
        justify-content: flex-start;
        margin-bottom: 10px;
    }

   @media screen and (max-width: 850px){
    .stavka{
        flex-direction: column;
        margin-bottom: 1%;
    }
    .stavka-2{
        flex-direction: column;
        margin-bottom: 1%;
        margin-top: 1%;
    }
    
    label{
        margin-bottom: 1%;
    }
    .picker{
        width: 70%;
    }
    .dugmici{
        flex-direction: column;

    }
    .dugme{
        width: 60%;
         margin-left: 6%;
    }
    .dugme1{
        width: 60%;  
    }
    }


</style>


