<template>
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
</template>

<script>
    import CollapseTransition from 'element-ui/lib/transitions/collapse-transition'
    import {Menu,MenuItem} from 'element-ui'
export default {
    components: {
        Menu,MenuItem,CollapseTransition
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
.body-container{
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: row;
    font-family: 'Lucida Sans Unicode';
}
.side-menu{
   height: 100%;
   width: 13em;
   opacity: 0.8;
}
.side-menu-item{
    display: flex;
    width: 200px;
    justify-content: center;
    background-color: rgba(22, 50, 95, 0.924);
    font-family: sans-serif;
    font-size: 16px;
}
</style>
