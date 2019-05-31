<template>
    <div class="side-bar-profil">
         <el-menu style="
                         background: linear-gradient(0deg, rgba(173, 202, 226, 0.938), rgba(10, 102, 177, 0.979) );  font-size:20px;"
                    background-color="rgba(16, 123, 199, 0.986)"
                    mode="vertical"
                    text-color="white" 
                    active-text-color="rgba(144, 225, 240, 0.938)"
                    @select="emitMenuSelect($event)" :router="false">
                    <el-menu-item v-for="item in itemList" :key="item.key" class="side-menu-item" :index="item.index"
                        style=" background: linear-gradient(0deg, rgba(39, 114, 175, 0.938), rgba(10, 102, 177, 0.979) );">
                       <img v-if="item.slika != undefined" style="height:30%; margin-right: 1em; margin-left:0.1em; position:left;
                       margin-top:20px;" :src="getImgUrl(item.slika)"/>{{item.label}}
                    </el-menu-item>
                </el-menu>
    </div>
</template>

<script>
export default {
    data(){
        return{
            itemList: this.list
        }
    },
    methods: {
      emitMenuSelect: function(event){
            this.$emit('changeView', event)
        },
         getImgUrl(slika){
            return require("../../assets/" + slika)
        }
    },
    props: ['list']
}
</script>

<style scoped>
.side-bar-profil{
    display: flex;
    position: relative;
    justify-content: flex-start;
}
.el-menu{
    width: 250px;
}
@media screen and (max-width: 700px){
    .el-menu{
        width: 100%;
    }
}
</style>

