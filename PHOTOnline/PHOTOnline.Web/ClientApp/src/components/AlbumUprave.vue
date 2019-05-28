<template>
    <div class="albumuprave-container">
        <div class="dodavanje"  v-if="this.showComp == 'albumi'" >
                <el-button type="primary" size="mini" style="height:35px;" @click="dodajAlbum">Dodaj Album</el-button>
                 <el-input v-model="Pretraga"
                                        size="medium"
                                        style="width:600px; margin-left:220px; margin-right:10px;"
                                        placeholder="Unesite naziv albuma za pretragu">
                </el-input>
                <el-button type="success" size="small" style="height:35px; margin-right:100px;" @click="vratiAlbum">OK</el-button>
                <label style="text-align:center; position:right;">Broj Albuma:</label>
        </div>
        <div class="albumi">
            <prikaz-albuma @otvorialbum="prikaziAlbume"
                v-if="this.showComp == 'albumi'"></prikaz-albuma>
        </div>
        <dodavanje-albuma  @zavrsenoDodavanje="this.zavrsiDodavanje" v-if="showComp === 'dodajalbum'"></dodavanje-albuma>
        <prikaz-sadrzaja-albuma  v-if="this.showComp == 'prikazalbuma'" 
            @zavrsipregled='zavrsiDodavanje'></prikaz-sadrzaja-albuma>
    </div>
</template>

<script>
    import PrikazAlbuma from "./PrikazAlbuma.vue"
    import DodavanjeAlbuma from "./DodavanjeAlbuma.vue"
    import PrikazSadrzajaAlbuma from "./PrikazSadrzajaAlbuma.vue"
export default {
    components: {PrikazAlbuma, DodavanjeAlbuma, PrikazSadrzajaAlbuma},
    data(){
        return{
            Pretraga: '',
            showComp: 'albumi'
        }
    },
    methods:{
        dodajAlbum(){
            this.showComp = 'dodajalbum'
        },
        zavrsiDodavanje(){
            this.showComp = 'albumi'
        },
        prikaziAlbume(){
            this.showComp = 'prikazalbuma'
            console.log("jldjsladjlka")
        },
        vratiAlbum(){
            if(this.Pretraga === ''){
                this.$message({message: "Morate uneti naziv albuma", type: 'warning'})
                return 
            }
            // fecth koji treba da vrati trazeni album
        }
    }
}
</script>

<style>
.albumuprave-container{
         display: flex;
        height: 100%;
        width: 100%;
        flex-direction: column;
        overflow: auto;
        background-color: rgba(224, 224, 235, 0.918);
}
.dodavanje{
    width: 98%;
    height: 7%;
    margin-top: 15px;
    margin-left: 21px;
    display: flex;

}
.albumi{
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
}
</style>


