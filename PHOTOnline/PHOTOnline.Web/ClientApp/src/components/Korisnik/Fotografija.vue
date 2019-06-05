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
            <el-select v-model="options.value" placeholder="Format Slike" size="mini">
                <el-option
                    v-for="item in options"
                    :key="item.value"
                    :label="item.label"
                    :value="item.value">
                </el-option>
             </el-select>
        </div>
    </div>
</template>

<script>
import { constants } from 'fs';
export default {
    data(){
        return{
            num: 1,
            options: [
                {value: '13x18',label: '13x18'},
                {value: '15x20',label: '15x20'},
                {value: '9x13',label: '9x13'}
            ],
            select: false,

        }
    },
    props: ['image'],
    methods: {
        onImageSelectionChange(selected){
            if(selected = true) {
                let data = {
                    image: this.image,
                    Num: this.num,
                    Option: this.options.value
                };

                this.$emit("selectImage", data);
            }
            else {
                this.$emit("unselectImage", this.image);
            }
        },
        prosledi(){
            let image = this.image;
            this.$emit("showPhoto", image);
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

