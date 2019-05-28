<template>
    <div class="obaveza-container" v-if="this.obaveza">
        <div class="obaveza-container-inner">
            <div class="month-button">
                <el-button class="button-arrow" @click="decrement"> <el-icon class="el-icon-arrow-left"></el-icon> </el-button>
                <h5>{{months[broj].name}}</h5>
                <el-button class="button-arrow" @click="increment">  <el-icon class="el-icon-arrow-right"></el-icon> </el-button>
            </div>
            <div class="tabela-obaveza-container">
                <prikaz-obaveza-table></prikaz-obaveza-table>
            </div>
            <el-button @click="zatvori" type="primary">Zatvori</el-button>
        </div>
    </div>
</template>

<script>
    import PrikazObavezaTable from './PrikazObavezaTable'
export default {
    data() {
        return{
            months: [
                {name: 'Januar'},
                {name: 'Februar'},
                {name: 'Mart'},
                {name: 'April'},
                {name: 'Maj'},
                {name: 'Jun'},
                {name: 'Jul'},
                {name: 'Avgust'},
                {name: 'Septembar'},
                {name: 'Oktobar'},
                {name: 'Novembar'},
                {name: 'Decembar'},
            ],
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
    },
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
        width: 80%;
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


