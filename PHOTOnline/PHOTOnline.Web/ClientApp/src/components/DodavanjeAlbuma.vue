<template>
    <div class="dodavanje-albuma-container">
        <el-dialog 
            @close="$emit('zavrsenoDodavanje')" 
            :visible.sync="dialogVisible" title="Dodavanje Albuma" width="28%">
            <form-dodaj-album @editFinished="potvrdiFormu($event)" :dodavanje-albuma="true"></form-dodaj-album>
       </el-dialog>
    </div>
</template>

<script>
    import {Dialog} from 'element-ui'
    import FormDodajAlbum from  "./forme/FormDodajAlbum"

export default {
    components: { FormDodajAlbum},
    data() {
        return {
            dialogVisible: true
        }
    },
    methods: {
        potvrdiFormu: function(event){
            this.$emit("zavrsenoDodavanje")
        },
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


