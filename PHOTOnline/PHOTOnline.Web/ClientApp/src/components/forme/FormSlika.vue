<template>
    <el-dialog visible center
        @close="$emit('zatvoriSliku')"
        :modalAppendToBody="false">
        <div class="photoContainer"><img :src="shownPhoto.Medium.Url"/></div>
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

img {
    width: 100%;
    height: 100%;
}

</style>


