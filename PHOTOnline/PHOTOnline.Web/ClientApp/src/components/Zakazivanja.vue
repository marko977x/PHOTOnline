<template>
    <div class="zakazivanja-container">
        <ds-calendar></ds-calendar>
    </div>
</template>

<script>
import DaySpanVuetify from 'dayspan-vuetify'
export default {
    components: {DaySpanVuetify}
}
</script>

<style>
.zakazivanja-container{
       display: flex;
        height: 100%;
        width: 100%;
        flex-direction: column;
        overflow: auto;
        background-color: rgba(224, 224, 235, 0.918);
}
</style>


