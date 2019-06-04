<template>
    <div class="fotografija-container">
        <div class="download-delete">
            <a :href="`${Image.Original.Url}`" download="image" target="target" ><el-icon class="el-icon-download"></el-icon></a>
            <a @click="deleteImage()"><el-icon class="el-icon-delete"></el-icon></a>
            <img :src="Image.Thumbnail.Url" height="100%" width="100%"/>
        </div>
        <h6 style="font-size:10px; text-align:center; position:bottom;">{{naziv}}</h6>
    </div>
</template>

<script>
import {} from 'element-ui'
import slika from "../../assets/pictures/1.jpg"
import { destinationUrl, apiFetch } from '../../services/authFetch';
export default {
    data(){
        return{
            naziv: 'DSC_1567',
            slika: ""
        }
    },
    props: ['Image'],
    methods: {
        deleteImage() {
            const formData = new FormData();
            formData.append('AlbumId', sessionStorage.AlbumId);
            formData.append('ImageId', this.Image.Id);
            formData.append('BlobsIds', this.Image.Original.BlobId);
            formData.append('BlobsIds', this.Image.Thumbnail.BlobId);
            formData.append('BlobsIds', this.Image.Large.BlobId);
            formData.append('BlobsIds', this.Image.Medium.BlobId);
            formData.append('BlobsIds', this.Image.Small.BlobId);
            
            fetch(destinationUrl + "/Image/DeleteImage", {method: 'POST', body: formData})
                .then(response => response.ok ? response.json() : new Error())
                .then(result => {
                    if(result.Success) {
                        this.$message("Uspesno obrisana slika!");
                        this.$emit('ImageDeleted', this.Image.Id);
                    }
                    else this.$message("Greska, pokusajte ponovo");
                }).catch(error => console.log(error));
        }
    }
}
</script>

<style scoped>
.fotografija-container{
    height: 100px;
    width: 80px;
    background: linear-gradient(0deg, #a6e1f0e7, #dcf1f8 );
    margin-top: 15px;
    border-radius: 3px;
    margin-left: 10px;
}
.download-delete{
    height: 87px;
    width: 100%;
}
</style>


