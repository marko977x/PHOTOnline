<template>
    <div class="FormZakaziContainer">
        <el-form class="ZakaziForma"> 
            <div class="divOpcija">
                <label>Lokacija:</label>
                <el-input type="text" class="inputPolje" v-model="podaciZakazi.lokacija"></el-input>
            </div>
            <div class="divOpcija">
                <label>Datum:</label>
                <el-date-picker class="inputPolje" v-model="podaciZakazi.datum" type="date" placeholder="Izaberite datum iz kalendara" :disabled="true"></el-date-picker>
            </div>
            <div class="divOpcija">
                <label>Dodatni zahtevi:</label>
                <el-input type="textarea" autosize class="inputPolje" v-model="podaciZakazi.dodatniZahtevi"></el-input>
            </div>
            <div class="divOpcija">
                <label>Tip fotografisanja:</label>
                <el-select class="inputPolje" v-model="podaciZakazi.tip" placeholder="Izaberite tip fotografisanja">
                    <el-option v-for="item in options" :key="item.tip" :label="item.label" :value="item.tip"></el-option>
                </el-select>
            </div>
            <div class="divOpcija">
                <label>Vreme:</label>
                <el-time-select class="inputPolje" v-model="podaciZakazi.vreme" :picker-options="{ start: '08:00', step: '00:15', end: '23:00' }" placeholder="Select time"></el-time-select>
            </div>
            <div class="divDugmeZakazi">
                <el-button id="dugmeZakazi">Zakazi</el-button>
            </div>
        </el-form>
    </div>
</template>

<script>

export default {
    data(){
        return{
            podaciZakazi: {
                lokacija: "",
                datum: this.izabraniDatum,
                dodatniZahtevi: "",  
                tip: '',
                vreme: ""
            },
            options: [{
                    tip: 'Svadba',
                    label: 'Svadba'
                    }, {
                    tip: 'Krstenje',
                    label: 'Krstenje'
                    }, {
                    tip: 'Veridba',
                    label: 'Veridba'
                    }, {
                    tip: 'Rodjendan',
                    label: 'Rodjendan'
                    }, {
                    tip: 'PhotoSession',
                    label: 'PhotoSession'
                    }, {
                    tip: 'Drugo',
                    label: 'Drugo'
            }],
        }
    },
    props: ['izabraniDatum']
}
</script>

<style scoped>

.FormZakaziContainer{
    display: flex;
    flex-direction: column;
    flex-grow: 1;
    justify-content: center;
    width: 50%;
    padding: 2% 5%;
}

.ZakaziForma{
    display: flex;
    flex-direction: column;
    width: 70%;
    height: 90%;
}

.divOpcija{
    flex-direction: column;
    width: 100%;
    justify-content: center;
}

.inputPolje{
    display: block;
    width: 100%;
}

.divDugmeZakazi{
    display: flex;
    flex-direction: row-reverse;
    margin: 5px;
    width: 100%;
}

</style>