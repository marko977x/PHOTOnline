<template>
     <div class="header-container">
            <nav class="container">
                <div class="navbar-left"> 
                   <el-popover
                         placement="top-start"
                         title="Foto-Aritonovic"
                         width="212"
                         trigger="hover"
                        content="Iskustvo duze od 20 godina"> 
                      <a class="navbar-item" href="./Pocetna" style="color:#c3cfe2; 
                        margin-top:5px; font-family:Arial Black, Gadget, sans-serif; 
                        font-size:20px; text-decoration:none;" slot="reference">Foto Aritonović</a> 
                   </el-popover>
                </div>
                <div class="navbar-right">
                    <ul class="items">
                        <!-- <li class="list-item"> <a href='' style="color:white;text-decoration: none;">Zakazivanja</a> </li>
                        <li class="list-item"> <a href='' style="color:white;text-decoration: none;"> Albumi </a> </li>
                        <li class="list-item"> <a href='' style="color:white;text-decoration: none;">Proizvodi </a> </li> 
                        <li> <el-button type="primary" @click="$emit('login')"> Log in </el-button> </li>
                        <li> <el-button type="primary" 
                        style="margin-left:10px;" @click="$emit('signup')" plain >SIGN UP</el-button> </li> -->
                        <li class="list-item" v-for="item in itemList" :key="item.value" @click="emitMenuSelect(item.index)"><a 
                           style="text-decoration:none; color:white;" href="#">{{item.label}}</a></li>
                        <li v-if="this.type == 'pocetna'"> <el-button type="primary" @click="$emit('login')"> Log in </el-button> </li>
                        <li v-if="this.type == 'korisnik'"> <el-button type="primary" @click="$emit('login')">Log out </el-button> </li>
                        <li v-if="this.type == 'pocetna'"> <el-button type="primary" style="margin-left:10px;" @click="$emit('signup')" plain >SIGN UP</el-button> </li>
                        <li v-if="this.type == 'korisnik'" @click="emitMenuSelect('korpa')">
                                <el-button type="primary" style="margin-left:10px;" @click="$emit('signup')" plain >
                                <el-icon class="el-icon-shopping-cart-2"></el-icon>
                            </el-button> 
                        </li>
                        <li v-if="this.type == 'korisnik'"  @click="emitMenuSelect('profil')"> 
                                <el-button type="primary" style="margin-left:10px;" @click="$emit('signup')" plain >
                                <el-icon class="el-icon-user-solid"></el-icon>
                            </el-button> 
                        </li>
                    </ul>
                </div>
                <div class="navbar-right-menu" hidden>
                    <el-button class="el-icon-menu" 
                        style="background-color:#737982; color:white;opacity:0.9;"> </el-button>
                    <el-button type="primary" @click="$emit('loguj')"> Log in </el-button>
                    <el-button type="primary" @click="$emit('signup')">SIGN UP</el-button>
                </div>
            </nav>
        </div>
</template>

<script>
 import popover from 'element-ui'
export default {
    components: {popover},
    data(){
        return{
           itemList: this.list,
           type: this.korisnik
        }
    },
    methods: {
          emitMenuSelect: function(event){
            this.$emit('changeView', event)
            console.log(event);
        }
    },
    props: ['list','korisnik']
}
</script>

<style scoped>
  .header-container{
      display: flex;
      flex-direction: row;
      justify-content: center;
      overflow: hidden;
      height: 10%;
      background-color: rgba(26, 104, 168, 0.678);
      flex: 0 0 70px;
  }
  .header-container:hover{
      background-color: rgb(26, 104, 168);
      transition-duration: .7s;
  }
  .container{
      padding: 1em;
      display: flex;
      color: white;
      flex-direction: row;
  }
  .navbar-left{
      text-transform: uppercase;
      width: 20%;
      display: flex;
      justify-content: center;
      align-items: center;
  }
  .navbar-right{
      display: flex;
      width: 80%;
      justify-content: flex-end;
      flex-direction: row;
      align-items:stretch;
  }
  .navbar-right-menu{
      display: flex;
      justify-content: flex-end;
      width: 80%;
  }
  .items{
      display: flex;
      justify-content: space-between;
      list-style-type: none;
      margin: 0;
      align-content: center;
  }
  .list-item{
      margin-top: 5px;
      margin-right: 25px;
      margin-left: 15px;
      font-size: 18px;
      width: 95px;
      height: 38px;
      justify-content: center;
      display: flex;
  }
  .list-item:hover{
      background-color: hsl(199, 75%, 54%);
      transition-duration: 500ms;
      border-radius: 6px;
      height: 41px;
  }
</style>


