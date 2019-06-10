<template>
    <div class="fotografije">
        <div class="download-delete">
            <el-checkbox v-model="select" style="color:white;" @change="onImageSelectionChange($event)">Odaberi
            </el-checkbox>
            <img :src="item.image.Thumbnail.Url" height="130px" width="120px" style="border-radius:2px;" @click="prosledi"/>
        </div>
        <div class="izbor">
            <el-input-number size="small" style="width:100%;"
                 v-model="num" @input="setQuantity" :min="1" :max="20">
            </el-input-number>
            <el-select :value="format" @input="setFormat" placeholder="Format Slike" size="mini">
                <el-option
                    v-for="item in formatPricePairList"
                    :key="item.format"
                    :label="item.format"
                    :value="item.format">
                </el-option>
             </el-select>
        </div>
    </div>
</template>

<script>
import {IMAGE_FORMAT, IMAGE_FORMAT_PRICE_PAIR_LIST} from "../../data/formatPricePairList";
import { getAlbumKorisnikState } from '../../services/contextManagement';
export default {
    data(){
        return{
            num: 1,
            format: '',
            formatPricePairList: IMAGE_FORMAT_PRICE_PAIR_LIST,
            select: false
        }
    },
    props: ['item'],
    methods: {
        onImageSelectionChange(selected){
            if(selected == true) {
                this.$emit("selectImage", {quantity: this.num, format: this.format});
            }
            else {
                this.$emit("unselectImage", this.image);
            }
        },
        prosledi(){
            this.$emit("showPhoto", this.item.image);
        },
        setFormat(format) {
            this.$emit("formatChange", format);
        },
        setQuantity(quantity) {
            this.$emit('quantityChange', quantity);
        }
    },
    mounted: function() {
        console.log(this.select);
    },
    updated() {
        this.select = this.item.selected;
        this.num = this.item.quantity;
        this.format = this.item.format;
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

