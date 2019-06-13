<template>
    <div class="GlavniContainer">
        <!--<vc-calendar :attributes='attrs' v-model="datum" v-on:select='izabranDatum'/>-->
        <vc-date-picker v-model="datum" v-on:input="$emit('izabranDatum',datum)" mode="single" is-inline/>
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
            // attrs: [
            //  {
            //     key: 'select',
            //     highlight: true,
            //     dates: null
            // }
            // ],
            datum: ""
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
