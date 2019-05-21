<template>
    <div class="albumuprave-container">
        <div class="dodavanje" hidden >
                <el-button type="primary" size="mini" style="height:35px;">Dodaj Album</el-button>
                 <el-input v-model="Pretraga"
                                        size="medium"
                                        style="width:600px; margin-left:220px; margin-right:205px;"
                                        placeholder="Unesite naziv albuma za pretragu">
                                </el-input>
                <label style="text-align:center; position:right;">Broj Albuma:</label>
        </div>
        <div class="albumi">
            <prikaz-albuma hidden v-for="item in 30" :key="item"></prikaz-albuma>
        </div>
        <dodavanje-albuma hidden></dodavanje-albuma>
        <prikaz-sadrzaja-albuma ></prikaz-sadrzaja-albuma>
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
            Pretraga: ''
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
    margin-right: 10px;
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


