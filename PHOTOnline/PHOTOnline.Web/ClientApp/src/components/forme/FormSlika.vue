<template>
    <el-dialog visible center
        @close="$emit('zatvoriSliku')"
        :modalAppendToBody="false">
        <div class="photoContainer"><img :src="photo.Thumbnail.Url"/></div>
    </el-dialog>
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
    height: 100%;
}

.photoContainer {
    display: flex;
    justify-content: center;
}

</style>


