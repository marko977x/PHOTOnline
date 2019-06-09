<template>
    <el-dialog center
        @close="$emit('zatvoriSliku')" :visible.sync="dialog" :modal-append-to-body="false">
        <div class="photoContainer"><img :src="shownPhoto.Small.Url"/></div>
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


