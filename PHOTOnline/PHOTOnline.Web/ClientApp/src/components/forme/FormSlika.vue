<template>
    <div class="slika-prikaz">
        <el-dialog visible width="60%" center
            @close="$emit('zatvoriSliku')"
            :modalAppendToBody="false">
            <img class="slika" :src="photo.Original"/>
        </el-dialog>
    </div>
</template>

<script>
export default {
    data(){
        return{
            photo: this.shownPhoto
        }
    },
    props: ['shownPhoto']
}
</script>

<style scoped>
.el-dialog{
    height: 70%;
}
.slika{
    display: flex;
    height: 100%;
    width: 100%;
}
</style>


