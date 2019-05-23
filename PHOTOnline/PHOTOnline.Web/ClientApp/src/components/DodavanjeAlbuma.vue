<template>
    <div class="dodavanje-albuma-container">
        <el-dialog  visible title="Dodavanje Albuma"
                width="30%">
            <form-dodaj-album @AddFinished="potvrdiFormu($event)"
                                            :dodavanje-albuma="true"></form-dodaj-album>
       </el-dialog>
    </div>
</template>

<script>
    import {Dialog} from 'element-ui'
    import FormDodajAlbum from  "./FormDodajAlbum"

export default {
    components: { FormDodajAlbum},
    data() {
        return {
            visible: true
        }
    },
    methodes: {
     //    potvrdiFormu: function(event){
       //     this.$emit("zavrsiDodavanje")
        //},
        zatvori: function() {
            this.visible = !this.visible;
        }
    }
}
</script>

<style scoped>
    .dodavanje-albuma-container{
        display: flex;
        height: 100%;
        width: 100%;
        justify-content: center;
        position: relative;
    }
    .dialog-dodavanje-albuma >{
        width: 60%;
        flex-shrink: initial;
    }
</style>


