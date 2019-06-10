<template>
    <el-dialog center @close="$emit('zatvoriSliku')" :visible="isVisible" :modal-append-to-body="false">
        <div class="photoContainer"><img id="image" :src="shownPhoto.Small.Url"/></div>
    </el-dialog>
</template>

<script>
export default {
    props: ['shownPhoto', 'isVisible']
}
</script>

<style scoped>

.el-dialog {
    height: 100%;
    width: 100%;
}

.photoContainer {
    display: flex;
    justify-content: center;
    height: 100%;
    width: 100%;
}

img {
    width: 100%;
    height: 100%;
}

</style>


