<template>
    <div class="korpa-container">   
        <h3>Sadržaj narudžbine</h3>
        <el-table 
        :data="this.korpa"
        max-height="1000"
        style="width:80%; border:1px solid black;">
            <el-table-column
                prop="ProductType"
                label="Tip"
                class="table-column"
                min-width="100">
            </el-table-column>
             <el-table-column
                prop="Quantity"
                label="Kolicina"
                class="table-column"
                min-width="100">
            </el-table-column>
            <el-table-column
                prop="Format"
                label="Format"
                class="table-column"
                min-width="100">
            </el-table-column>
            <el-table-column
                prop="Price"
                label="Cena"
                class="table-column"
                min-width="100">
            </el-table-column>
            <el-table-column label="Slika" min-width="100">
                <template slot-scope="cartItem" >
                    <div class="kolonaDugmici-1">
                        <el-button type="secondary" icon="el-icon-picture" circle size="medium" @click="openImage(cartItem.row)"></el-button>
                        <el-button type="text" @click="skiniSliku(cartItem.$index)" v-if="uprava">Download</el-button>
                    </div>
                </template>
            </el-table-column>
        </el-table>
        <form-slika :isVisible="!this.isImageHidden" :shownPhoto="this.shownImage" :hidden="isImageHidden" @zatvoriSliku="closeImage"/>
    </div>
</template>

<script>
import FormSlika from "../forme/FormSlika.vue";
import { UserTypes, REGULAR_USER_TYPE } from '../../services/authFetch';
import { getUserInfo } from '../../services/contextManagement';
import { Promise } from 'q';
export default {
    components: { FormSlika },
    data(){
        return{
            isImageHidden: true,
            shownImage: {
                Small: {
                    Url: ""
                }
            },
            downloadLink: [],
            uprava: ''
        }
    },
    methods: {
        openImage(cartItem) {
            this.shownImage = cartItem.Image;
            this.isImageHidden = false;
        },
        closeImage() {
            this.isImageHidden = true;
        },
        skiniSliku(index) {
            let aTag = document.createElement('a');
            aTag.download = "image.png";
            aTag.href = this.downloadLink[index];
            document.body.appendChild(aTag);
            aTag.click();
            document.body.removeChild(aTag);
        }
    },
    updated: function() {
        this.korpa.forEach( (element, index) => {
            fetch(element.Image.Original.Url, {method: 'GET'}).then(response => {
                    return response.blob();
                }).then(blob => {
                    this.downloadLink[index] = URL.createObjectURL(blob);
                });
        });
    },
    beforeMount: function() {
        if(getUserInfo().userType == REGULAR_USER_TYPE){
            this.uprava = false;
        }
        else{
            this.uprava = true;
        }
    },
    props: ['korpa']
}
</script>

<style scoped>
.korpa-container{
        height: 47%;
        width: 90%;
        display: flex;
        flex-direction: column;
        background-color: rgba(204,204,211,0.931);
        opacity: 1;
        padding: 1em;
        justify-content: center;
        align-items: center;
}
h3{
    text-align: center;
    font-family: sans-serif;
}
</style>


