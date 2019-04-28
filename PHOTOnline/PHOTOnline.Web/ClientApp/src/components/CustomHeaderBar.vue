<template>
    <div class="menuContainer">
        <el-menu class="headerBar" mode="horizontal" text-color="white" :router=false>
                <div class="header">
                    <h3 id='logoHeader'>Foto Aritonovic</h3>
                    <div class="top-menu-button-container">
                        <el-button class="top-menu-button" @click="klik" >
                            <el-icon class="el-icon-menu"></el-icon>
                        </el-button>
                        <el-button class="top-menu-button">Odjavi se</el-button>
                    </div>
                </div>
         </el-menu>
        <div class="body-container">
            <el-collapse-transition>
            <div class="side-menu" v-if="this.menuShown">
                    <el-menu v-show="klik" mode="vertical" style="height: 100%; border:none;"
                            text-color= "white" :router="false"  default-active="2" background-color="#1A417F">
                        <el-menu-item v-for="item in itemList" :key="item.key" class="side-menu-item" background-color="#3062b2">
                            {{item.label}}
                        </el-menu-item>
                    </el-menu>
            </div>
             </el-collapse-transition>
              <slot></slot>
        </div>
    </div>
</template>

<script>
    import CollapseTransition from 'element-ui/lib/transitions/collapse-transition'
    import {Button,Menu,MenuItem,Icon} from 'element-ui'
export default {
    components: {
        Button,Menu,MenuItem,Icon,CollapseTransition
    },
    data() {
        return{
            arrowShow: true,
            menuShown: true,
            itemList: this.list
        }
    },
    methods:{
        klik: function() {
            this.menuShown = !this.menuShown;
        }
    },
    props: ['list']

}
</script>

<style scoped>
.header{
    display: flex;
    justify-content: flex-end;
}
.body-container{
    height: 100%;
    width: 100%;
    position: absolute;
    flex-direction: row;
    display: flex;
    flex-direction: row;
}
.menuContainer{
    height: 100%;
    font-family: 'Lucida Sans Unicode';
    flex-direction: column;
}
 .headerBar{
     display: flex;
     flex-direction: column;
     margin-top: 14px;
     border: 5px blue;
     position: relative;
     height: 50px;
     background-color:  rgb(22, 103, 156);
 }
 #logoHeader {
        margin-top: 0.3em;
        margin-left: 0.5em;
        margin-right: 0.5em;
        font-family:sans-serif;
        font-size: 26px;
        justify-content: flex-start;
 }
.top-menu-button{
    display: flex;
    height: 3em;
    justify-content:right; 
}
.top-menu-button-container{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
    padding-right: 5px;
    padding-top: 4px;
}
.side-menu{
   height: 100%;
   width: 16em;
}
.side-menu-item{
    display: flex;
    width: 220px;
    justify-content: center;
    background-color: rgba(22, 50, 95, 0.924);
    font-family: sans-serif;
    font-size: 16px;
}
</style>


