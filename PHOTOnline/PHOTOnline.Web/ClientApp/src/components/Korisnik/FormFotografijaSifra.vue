<template>
    <div class="SifraContainer">
        <el-form class="SifraForma">           
            <label>Unesite šifru albuma čiji sadržaj želite da pogledate:</label>
            <el-input type="text" class="inputPolje" v-model="sifra"></el-input>
            <div class="divDugmePrikazi">
                <el-button v-on:click="prikaziAlbum">Prikaži</el-button>
            </div>
        </el-form>
    </div>
</template>

<script>

export default {
    data(){
        return{
            sifra: ""
        }
    },
    methods: {
        prikaziAlbum() {
            
        }
    }
}
</script>

<style scoped>

.SifraContainer{
    display: flex;
    flex-grow: 1;
    justify-content: center;
    align-items: center;
}

.SifraForma{
    display: flex;
    flex-direction: column;
    width: 45%;
    height: 45%;
    padding: 40px 40px;
    background: #ebeef5;
    opacity: 0.95;
    font-size: 16px;
}

.inputPolje{
    display: block;
    width: 100%;
}

.divDugmePrikazi{
    display: flex;
    flex-direction: row-reverse;
    margin-top: auto;
}

</style>