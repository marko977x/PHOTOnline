<template>
    <el-dialog visible center
        @close="$emit('zatvoriSliku')"
        :modalAppendToBody="false">
        <div class="photoContainer"><img :src="shownPhoto.Thumbnail.Url"/></div>
    </el-dialog>
</template>

<script>
export default {
    props: ['shownPhoto']
}
</script>

<style scoped>
.photoContainer {
    display: flex;
    justify-content: center;
}
</style>


