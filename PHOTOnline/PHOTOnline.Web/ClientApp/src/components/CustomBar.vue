<template>
    <div class="menu-container">
        <div class="header-bar" text-color="white">
            <div class="naslov"><h3> Foto Aritonovic </h3> </div>
            <div class="top-menu-button-container">
                <el-button class="top-menu-button" @click="zatvoriMeni">
                    <el-icon class="el-icon-menu"></el-icon>
                </el-button>
                <el-button> <el-icon class="el-icon-user"></el-icon>Nalog</el-button>
                <el-button class="odjava" type="primary"> Odjavi se </el-button>
            </div>
        </div>
        <div class="body-container">
            <div class="side-menu" v-if="this.menuShown">
                <el-menu style="height:100%" mode="vertical" 
                    background-color="#2980c7d3">
                    <el-menu-item v-for="item in itemList" :key="item.key" class="side-menu-item">
                        {{item.label}}
                    </el-menu-item>
                </el-menu>
            </div>
            <slot></slot>
        </div>
    </div>
</template>

<script>
import CollapseTransition from 'element-ui/lib/transitions/collapse-transition'
import {Button,Menu, MenuItem,Icon} from 'element-ui'
export default {
    components: {Icon,Button,Menu,MenuItem},
    data() {
        return{
            itemList: this.list,
            menuShown: true
        }
    },
    methods: {
        zatvoriMeni: function(){
            this.menuShown = !this.menuShown;
        }
    },
    props: ['list']
    
}
</script>

<style>
.naslov{
    display: flex;
    margin-top: 5px;
    padding-left: 2em;
}
.menu-container{
    flex-direction: column;
    height: 100%;
}
.header-bar{
    width: 100%;
    height: 50px;
    display: flex;
    flex-direction: column;
    position: relative;
    background-color: rgba(26, 104, 168, 0.904);
}
.top-menu-button-container{
    display: flex;
    width: 100%;
    justify-content: flex-end;
    opacity: 0.95;
    position: absolute;
    top: 0;
    padding-right: 3em;
    padding-top: 0.5em;
    padding-bottom: 0.3em;
}
.odjava{
    display: flex;
}
.body-container{
    display: flex;
    flex-direction: row;
    height: calc(100% - 50px);
    width: 100%;
    position: absolute;
    flex-direction: row;
}
.side-menu{
    height: 100%;
    width: 14em;
     background-color: #2980c7d3;

}
.side-menu-item{
    display: flex;
    justify-content: center;
}
@media screen and (max-width: 700px){
    .body-container{
        flex-direction: column;
    }
    .side-menu{
        height: 170px;
        width: 100%;
    }
}

</style>


