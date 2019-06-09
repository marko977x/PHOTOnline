<template>
    <div class="korpa-container">   
        <el-table 
        :data="this.korpa"
        style="width:80%; border:1px solid black;">
            <el-table-column
                prop="ProductType"
                label="Tip"
                class="table-column">
            </el-table-column>
             <el-table-column
                prop="Quantity"
                label="Kolicina"
                class="table-column">
            </el-table-column>
            <el-table-column
                prop="Format"
                label="Format"
                class="table-column">
            </el-table-column>
            <el-table-column
                prop="Price"
                label="Cena"
                class="table-column">
            </el-table-column>
            <el-table-column label="Slika">
                <template slot-scope="cartItem" >
                    <el-button type="secondary" icon="el-icon-picture" circle size="mini" @click="openImage(cartItem.row)">
                    </el-button>
                </template>
            </el-table-column>
        </el-table>
        <form-slika :visible="this.isImageHidden" :shownPhoto="this.shownImage" :hidden="isImageHidden" @zatvoriSliku="closeImage"/>
    </div>
</template>

<script>
import FormSlika from "../forme/FormSlika.vue";
export default {
    components: { FormSlika },
    data(){
        return{
            endTask: false,
            isImageHidden: true,
            shownImage: {
                Small: {
                    Url: ""
                }
            },
        }
    },
    methods: {
            zavrsi: function(){
                this.endTask = !this.endTask;
            },
            openImage(cartItem) {
                this.shownImage = cartItem.Image;
                this.isImageHidden = false;
            },
            closeImage() {
                this.isImageHidden = true;
            },

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
.el-icon-download{
    margin-right: 10px;
}
</style>


