<template>
    <div class="GlavniContainer">
        <vc-calendar />
    </div>
</template>

<script>
//https://vcalendar.io/guide/#component - gde se nalazi komponenta
import Vue from 'vue';
import VCalendar from 'v-calendar';

// Use v-calendar & v-date-picker components
Vue.use(VCalendar, {
  componentPrefix: 'vc',  // Use <vc-calendar /> instead of <v-calendar />          
});

export default {
    data(){
        return{
            datum: '2019-01-01'
        }
    }
}
</script>

<style scoped>

.GlavniContainer{
    display: flex;
    justify-content: center;
    width: 50%;
}

</style>
