<template>
    <div class="obaveza-container" v-if="this.obaveza">
        <div class="obaveza-container-inner">
            <div class="month">
                <h3>Mesečne obaveze</h3>
            </div>
            <div class="month-button">
                <el-button class="button-arrow" @click="decrement"> <el-icon class="el-icon-arrow-left"></el-icon> </el-button>
                <h5>{{months[broj].name}}</h5>
                <el-button class="button-arrow" @click="increment">  <el-icon class="el-icon-arrow-right"></el-icon> </el-button>
            </div>
            <div class="tabela-obaveza-container">
                <prikaz-obaveza-table></prikaz-obaveza-table>
            </div>
            <el-button @click="zatvori">Zatvori</el-button>
        </div>
    </div>
</template>

<script>
    import PrikazObavezaTable from './PrikazObavezaTable'
export default {
    data() {
        return{
            months: [
                {name: 'Januar', key: 1},
                {name: 'Februar', key: 2},
                {name: 'Mart', key: 3},
                {name: 'April', key: 4},
                {name: 'Maj', key: 5},
                {name: 'Jun', key: 6},
                {name: 'Jul', key: 7},
                {name: 'Avgust', key: 8},
                {name: 'Septembar', key: 9},
                {name: 'Oktobar', key: 10},
                {name: 'Novembar', key: 11},
                {name: 'Decembar', key: 12},
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
                this.broj=0;
        },
        increment: function(){
            if(this.broj < 12)
                this.broj++;
            else
                this.broj=12;
        },
        zatvori: function(){
            this.obaveza = !this.obaveza;
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
        height: 70%;
        width: 80%;
        background-color:  rgba(204, 204, 211, 0.897);
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
        justify-content: center;
        align-items: center;
    }
</style>


