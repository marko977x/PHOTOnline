<template>
    <div class="obavestenje-container">
        <el-dialog width="30%" @close="$emit('zatvoriPoruku')" :visible.sync="dialog">
            <h5 style="text-align:center; font-family:sans-serif; font-size:15px;"> Obaveštenje korisniku </h5>
            <el-input v-model="obavestenje"
             type="textarea"
            :rows="2"
            placeholder="Please input"
            style="height:200px;"
            size="small"
            :autosize="{ minRows: 9, maxRows: 10}"
            >
            </el-input>
            <el-button type="primary" style="position:right;" size="small" @click="proslediPoruku">Pošalji</el-button>
        </el-dialog>
    </div>
</template>
<script>
export default {
    data(){
        return{
            obavestenje: '',
            dialog: true,
            mounted: function() {
                this.dialog = true
            }
        }
    },
    methods:{
        proslediPoruku(){
            this.$emit("proslediPoruku",this.obavestenje);
        }
    }
}
</script>

