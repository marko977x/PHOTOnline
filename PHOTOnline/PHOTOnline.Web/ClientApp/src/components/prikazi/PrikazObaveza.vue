<template>
    <div class="obaveza-container" v-if="this.obaveza">
        <div class="obaveza-container-inner">
            <div class="tabela-obaveza-container">
                <prikaz-obaveza-table></prikaz-obaveza-table>
            </div>
        </div>
    </div>
</template>

<script>
import PrikazObavezaTable from './PrikazObavezaTable'
export default {
    data() {
        return{
            broj: 0,
            obaveza: true
        }
    },
    components: {PrikazObavezaTable},
    methods: {
        decrement: function()
        {
            if(this.broj > 0)
                this.broj--;
            else
                this.broj = 0;
        },
        increment: function(){
            if(this.broj < 11)
                this.broj++;
            else
                this.broj = 11;
        },
        zatvori: function(){
              this.$emit('editFinished','cancel')
        }
    }
}
</script>

<style scoped>
    .obaveza-container{
        display: flex;
        height: 100%;
        width: 100%;
        justify-content: center;
        align-items: center;
    }
    .obaveza-container-inner{
        flex-direction: column;
        justify-content: center;
        align-items: center;
        height: 80%;
        width: 90%;
        background-color:  #ccccd3e5;
        opacity: 1;
        padding: 1em;
    }
    .month{
        flex-direction: row;
        justify-content: center;
        display: flex;
    }
    #logoObligation{
        width: 4em;
        height: 2.5em;
    }
    .month-button{
        display: flex;
        flex-direction: row;
        justify-content: center;
    }
    .button-arrow{
        margin-right: 30px;
        margin-left: 30px;
    }
    .tabela-obaveza-container{
        height: calc(95% - 6em);
        overflow: auto;
        margin-top: 10px;
        margin-bottom: 25px;
    }
</style>


