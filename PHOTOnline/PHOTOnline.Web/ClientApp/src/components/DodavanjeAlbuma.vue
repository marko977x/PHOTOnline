<template>
    <div class="dodavanje-abluma-container">
        <el-dialog @close="$emit('zavrsiDodavanje')" visible title="Dodavanje Albuma"
                width="30%">
            <forma-dodavanje-albuma @AddFinished="potvrdiFormu($event)"
                                            :dodavanje-albuma="true"></forma-dodavanje-albuma>
       </el-dialog>
    </div>
</template>

<script>
    import {Dialog} from 'element-ui'
    import FormaDodavanjeAlbuma from  "./FormaDodavanjeAlbuma"

export default {
    components: { Dialog, FormaDodavanjeAlbuma},
    data() {
        return {}
    },
    methodes: {
        potvrdiFormu(event){
            console.log("Dodavanje je zavrseno!")
            console.log(event);
            this.$emit("zavrsiDodavanje")
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
    }
    .dialog-dodavanje-albuma >{
        width: 60%;
        flex-shrink: initial;
    }
</style>


