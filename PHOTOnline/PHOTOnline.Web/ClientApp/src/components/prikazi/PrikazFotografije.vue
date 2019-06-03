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
            formData.append('Id', this.Image.Id);
            formData.append('Title', this.Image.Title);
            formData.append('Original.BlobId', this.Image.Original.BlobId);
            formData.append('Original.Url', this.Image.Original.Url);
            formData.append('Large.BlobId', this.Image.Large.BlobId);
            formData.append('Large.Url', this.Image.Large.Url);
            formData.append('Medium.BlobId', this.Image.Medium.BlobId);
            formData.append('Medium.Url', this.Image.Medium.Url);
            formData.append('Small.BlobId', this.Image.Small.BlobId);
            formData.append('Small.Url', this.Image.Small.Url);
            formData.append('Thumbnail.BlobId', this.Image.Thumbnail.BlobId);
            formData.append('Thumbnail.Url', this.Image.Thumbnail.Url);

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


