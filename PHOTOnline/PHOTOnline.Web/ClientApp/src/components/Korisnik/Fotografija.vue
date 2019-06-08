<template>
    <div class="fotografije">
        <div class="download-delete">
           <el-checkbox v-model="select" style="color:white;" @change="onImageSelectionChange($event)">Odaberi
            </el-checkbox>
            <img :src="image.Thumbnail.Url" height="130px" width="120px" style="border-radius:2px;" @click="prosledi"/>
        </div>
        <div class="izbor">
            <el-input-number size="small" style="width:100%;"
                 v-model="num" :min="1" :max="20">
            </el-input-number>
            <el-select :value="format" @input="setFormat" placeholder="Format Slike" size="mini">
                <el-option
                    v-for="item in options"
                    :key="item"
                    :label="item"
                    :value="item">
                </el-option>
             </el-select>
        </div>
    </div>
</template>

<script>
import {IMAGE_FORMAT} from "../../services/productPriceCalculator.js";
import { getAlbumKorisnikState } from '../../services/contextManagement';
export default {
    data(){
        return{
            num: 1,
            format: '',
            options: IMAGE_FORMAT,
            select: false
        }
    },
    props: ['image'],
    methods: {
        onImageSelectionChange(selected){
            if(selected == true) {
                let data = {
                    Image: this.image,
                    Quantity: this.num,
                    Format: this.format
                };
                console.log(data);

                this.$emit("selectImage", data);
            }
            else {
                this.$emit("unselectImage", this.image);
            }
        },
        prosledi(){
            let image = this.image;
            this.$emit("showPhoto", image);
        },
        setFormat(event) {
            this.format = event;
            console.log(event);
        }
    },
    mounted: function() {
        const state = getAlbumKorisnikState();
        if(state != null) {
            this.selectedImages = state.selectedImages;
            console.log(this.selectedImages);
            const image = this.selectedImages.find(item => item.Image.Id == this.image.Id);
            console.log(image);
            if(image != null) {
                this.format = image.Format;
                this.num = image.Quantity;
                this.select = true;
            }
        }
    }
}
</script>

<style scoped>
.fotografije{
    height: 210px;
    width: 120px;
    display: flex;
    flex-direction: column;
   /* background: linear-gradient(0deg, #d1d356, #e6e88d );*/
    background: linear-gradient(0deg, #f1727228, #3a37376c );
    margin-top: 15px;
    border-radius: 3px;
    margin-left: 22px;
}
.download-delete{
    height: 150px;
    width: 100%;
    display: flex;
    flex-direction: column;
}
.el-checkbox{
    margin: 0px;
    padding: 0px;
}
.izbor{
    display: flex;
    flex-direction: column;
    width: 100%;
    margin: 0px;
}
.el-input__inner{
    display: flex;
    margin: 0px;
    padding: 0px;
}
.el-input.el-input--mini.el-input--suffix{
    padding: 0px;
    margin: 0px;
}
.el-input{
    margin: 0px;
    padding: 0px;
}
</style>

