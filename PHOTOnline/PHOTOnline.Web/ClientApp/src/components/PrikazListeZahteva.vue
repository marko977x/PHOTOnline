<template>
    <div class="zahtevi-container">
        <div class="zahtevi-container-table">
            <h1>ovo radi </h1>
        </div>
    </div>
</template>

<script>
import {} from 'element-ui'
export default {
    data(){
        return{

        }
    }
}
</script>

<style scoped>
.zahtevi-container{
        display: flex;
        height: 1000px;
        width: 100%;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        overflow: auto;
}
.zahtevi-container-table{
        height: 47%;
        width: 90%;
        display: flex;
        flex-direction: column;
        background-color: rgba(204,204,211,0.931);
        opacity: 1;
        padding: 1em;
}
</style>


