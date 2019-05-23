<template>
    <div class="filter-container">
        <div class="item">
             <label>Ime: </label>
             <el-input v-model="ime"></el-input>
        </div>
        <div class="item">
            <label>Prezime: </label>
            <el-input v-model="prezime"></el-input>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            ime: '',
            prezime: ''
        }
    }
}
</script>
<style>
    .filter-container{
        height: 50px;
        width: 100%;
        justify-content: center;
        display: flex;
        flex-direction: row;
    }
    .item{
        display: flex;
        flex-direction: row;
        margin-left: 20px;
    }
    label{
        margin-top: 5px;
        margin-right: 25px;
        font-family: sans-serif;
        font-size: 20px;
    }

</style>


