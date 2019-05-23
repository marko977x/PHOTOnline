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
                      <a class="navbar-item" href="./Pocetna" style="color:white; font-size:17px; 
                       font-family: Montserrat,Helvetica Neue,Arial,sans-serif; text-decoration:none;" slot="reference">Foto Aritonovic</a> 
                   </el-popover>
                </div>
                <div class="navbar-right">
                    <ul class="items">
                        <li class="list-item"> <a href='' style="color:white;text-decoration: none;">Početna</a> </li>
                        <li class="list-item"> <a href='' style="color:white;text-decoration: none;"> Albumi </a> </li>
                        <li class="list-item"> <a href='' style="color:white;text-decoration: none;">Proizvodi </a> </li> 
                        <li> <el-button type="primary"> Log in </el-button> </li>
                    </ul>
                </div>
            </nav>
        </div>
</template>

<script>
 import popover from 'element-ui'
export default {
    components: {popover}
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
      will-change: auto;
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
  .items{
      display: flex;
      justify-content: space-between;
      list-style-type: none;
      margin: 0;
      align-content: center;
  }
  .list-item{
      margin-right: 25px;
      margin-left: 15px;
      font-size: 18px;
      width: 75px;
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


