<template>
    <div class="fotografija-container">
        <div class="download-delete">
            <a :href="downloadLink" download ><el-icon class="el-icon-download"></el-icon></a>
            <a @click="deleteImage()"><el-icon class="el-icon-delete"></el-icon></a>
            <img :src="Image.Thumbnail.Url" height="100%" width="100%" @click="prosledi"/>
        </div>
        <h6 style="font-size:14px; text-align:center; position:bottom; margin-top:30px;" >{{this.Image.Title}}</h6>
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
            slika: "",
            downloadLink: ""
        }
    },
    props: ['Image'],
    methods: {
        deleteImage() {
            const formData = new FormData();
            formData.append('AlbumId', sessionStorage.AlbumId);
            formData.append('ImageId', this.Image.Id);
            console.log(this.Image);
            
            fetch(destinationUrl + "/Image/DeleteImage", {method: 'POST', body: formData})
                .then(response => response.ok ? response.json() : new Error())
                .then(result => {
                    if(result.Success) {
                        this.$message({message: "Uspesno obrisana slika!", type: "success"});
                        this.$emit('ImageDeleted', this.Image.Id);
                    }
                    else this.$message("Greska, pokusajte ponovo");
                }).catch(error => console.log(error));
        },
        prosledi(){
            let image = this.Image;
            this.$emit("showPhoto", image);
        }
    },
    mounted: function() {
        fetch(this.Image.Original.Url, {method: 'GET'}).then(response => {
            return response.blob();
        }).then(blob => {
            this.downloadLink = URL.createObjectURL(blob);
        });
    }
}
</script>

<style scoped>
.fotografija-container{
    height: 150px;
    width: 130px;
    background: linear-gradient(0deg, #a6e1f065, #dcf5f8a9 );
    margin-top: 35px;
    margin-bottom: 15px;
    border-radius: 3px;
    margin-left: 10px;
}
.download-delete{
    height: 150px;
    width: 130px;
}
.el-icon-download{
    margin: 0 10px;
}
</style>


