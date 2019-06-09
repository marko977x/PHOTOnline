<template>
    <el-dialog :visible.sync="this.d" center
        @close="$emit('zatvoriSliku')" :modal-append-to-body="false">
        <div class="photoContainer"><img :src="shownPhoto.Small.Url"/></div>
    </el-dialog>
</template>

<script>
export default {
    props: ['shownPhoto', 'visible'],
    data() {
        return {
            d: false
        }
    }
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


