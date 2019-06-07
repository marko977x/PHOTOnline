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
                      <a class="navbar-item" href="./Pocetna" slot="reference">Foto Aritonović</a> 
                   </el-popover>
                </div>
                <div class="navbar-right">
                    <ul class="items">
                        <li class="list-item" v-for="item in itemList" :key="item.value" @click="emitMenuSelect(item.index)"><a 
                           style="text-decoration:none; color:white;" href="#">{{item.label}}</a></li>
                        <li v-if="this.type == 'pocetna'"> <el-button type="primary" @click="$emit('login')"> Log in </el-button> </li>
                        <li v-if="this.type == 'korisnik'"> <el-button type="primary" @click="signOut()">Log out </el-button> </li>
                        <li v-if="this.type == 'pocetna'"> <el-button type="primary" style="margin-left:10px;" @click="$emit('signup')" plain >SIGN UP</el-button></li>
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
                <div class="navbar-right-menu">
                    <el-button  style="opacity:0.9;
                         height: 50px; width: 50px;"> 
                        <el-icon class="el-icon-menu"></el-icon>
                         </el-button>
                    <!-- <el-button type="primary" @click="$emit('login')"> Log in </el-button>
                    <el-button type="primary" @click="$emit('signup')">SIGN UP</el-button> -->
                </div>
            </nav>
        </div>
</template>

<script>
 import popover from 'element-ui'
 import menu from '../../assets/menu.png'
import { apiFetch, destinationUrl } from '../../services/authFetch';
import { clearUserInfo } from '../../services/contextManagement';
export default {
    components: {popover},
    data(){
        return{
           itemList: this.list,
           type: this.korisnik,
           slika: menu
        }
    },
    methods: {
        emitMenuSelect: function(event){
            this.$emit('changeView', event)
            console.log(event);
        },
        signOut() {
            apiFetch('POST', destinationUrl + "/User/SignOut")
                .then(result => {
                    if(result.Success) {
                        clearUserInfo();
                        window.location.href = "/";
                    }
                    else console.log(result);
                });
        }
    },
    props: ['list','korisnik']
}
</script>

<style scoped>
    .header-container{
        display: flex;
        flex-direction: column;
        justify-content: center;
        overflow: hidden;
        height: 10%;
        background-color: rgba(26, 104, 168, 0.678);
        flex: 0 0 70px;
    }
    .header-container:hover{
        background-color: rgb(26, 104, 168);
        transition-duration: 1s;
    }

    .container{
        padding: 1em;
        display: flex;
        color: white;
        flex-direction: row;
    }

    .navbar-item{
        color:#c3cfe2; 
        margin-top:5px; 
        font-family:Arial Black, Gadget, sans-serif; 
        font-size:20px; text-decoration:none;
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
        align-items:stretch;
    }
    .navbar-right-menu{
        display: none;
    }
    .items{
        display: flex;
        justify-content: space-between;
        list-style-type: none;
        margin: 0;
        align-items: center;
    }
    .list-item{
        margin-top: 5px;
        margin-bottom: 5px;
        margin-right: 25px;
        margin-left: 15px;
        font-size: 16px;
        width: 95px;
        height: 38px;
        justify-content: center;
        display: flex;
        align-items: center;
    }
    .list-item:hover{
        background-color: hsl(199, 75%, 54%);
        transition-duration: 500ms;
        border-radius: 6px;
    }

    @media screen and (max-width: 640px){
    .navbar-right{
        display: none;
        width:60%;
    }
    .navbar-right-menu{
        display: block;
        display: flex;
        flex-direction: row-reverse;
        width: 100%;
        margin-left: 10%;
    }
    .navbar-item{
        font-size: 15px;
        margin-left: 20px;
    }
    .navbar-left{
        width: 40%;
    }
}

</style>


