<template>
    <div class="main-container">
        <header-bar></header-bar>
        <div class="main">
            <div class="information">
                <div class="info1">
                    <h2 id="naslov1">Foto Studio Aritonović</h2>
                </div>
                <div class="info2">
                    <h3  style="text-align:center;">Foto Aritonović</h3>
                    <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Aut inventore,
                         voluptas nostrum et libero quisquam nemo dolor, architecto similique rerum 
                         eos ullam porro voluptates excepturi, placeat dicta facere a nisi? Sed
                          perspiciatis quasi quidem sit, sequi, in animi reprehenderit maxime non tempora
                           magnam excepturi minus quisquam corrupti veritatis aliquid laudantium? 
                              repellendus rerum dolores magni hic harum. Dolore, veniam! Facere, ducimus
                               iusto! Eius temporibus dignissimos commodi cupiditate ea, voluptates consequatur
                                nulla illum!.</p>
                </div>
            </div>
            <el-carousel  class="carousel">
                <el-carousel-item v-for="photo in photos" :key="photo">
                <img :src="photo" height="200" width="400"/>
                <h1>{{photo}}</h1>
                </el-carousel-item>
            </el-carousel>
        </div>
        <login></login>
        <footer-bar class="footer"></footer-bar>
    </div>
</template>

<script>
 import HeaderBar from '../components/HeaderBar.vue'
 import FooterBar from '../components/FooterBar.vue'
 import Login from "../components/Login.vue"
export default {
    components: { HeaderBar, FooterBar, Login},
    data() {
        return {
            photos:[
                '../assets/pictures/h1.JPG',
                '../assets/pictures/h2.JPG',
                '../assets/pictures/h3.JPG',
            ],
            count: 0
        }
    }
}
</script>

<style scoped>
    .el-carousel__item h3 {
    color: #475669;
    font-size: 18px;
    opacity: 0.75;
    line-height: 300px;
    margin: 0;
  }

  .el-carousel__item:nth-child(n) {
    background-color: #99a9bf;
  }
  .carousel{
      height: 310px;
      width: 60%;
      margin-left: 280px;
      border-radius: 5px;
  }
  .main-container{
      display: flex;
      width: 100%;
      height: 100%;
      position: absolute;
      flex-direction: column;
      overflow: auto;
    background-size: cover;
    background-position: bottom;
    background-image: linear-gradient(
            rgba(26, 111, 168, 0.171),
            rgba(57, 63, 61, 0.205)
        ),url("../assets/pictures/ho.jpg");
  }
  .el-carousel__container{
      height: 100%;
      width: 100%;
  }
  .main{
      display: flex;
      flex-direction: column;
      
  }
  .information{
      width: 100%;
      height: 680px;
      display: flex;
      flex-direction: row;
      padding: 50px;
  }
  .info1{
      width: 50%;
      align-items: center;
      justify-content: center;
      display: flex;
  }
  .info2{
      width: 40%;
      padding: 60px 60px 60px;
      margin-left: 100px;
      background-color: rgba(231, 231, 236, 0.801);
      border-radius: 8px;
      transition-duration: 1000ms;
  }
  .info2:hover{
       background-color: rgb(231, 231, 236);
  }
  #naslov1{
      color:white; 
      font-size:100px;
       margin-left:30px;
       font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva;
  }
  @media screen and (max-width: 1100px) {
      .information{
          flex-direction: column;
          height: 800px;
          padding: 10px;
          display: flex;
          justify-content: center;
          align-items: center;
      }
      #naslov1{
          font-size: 60px;
          padding: 0;
          margin-bottom: 100px;

      }
      .info1{
          width: 100%;
          align-items: center;
          display: flex;
          justify-content: center;
      }
      .info2{
          width: 100%;
          margin: 0;
          padding: 15px;
          justify-content: center;
      }
      .carousel{
          width: 100%;
          margin: 0;
      }
      @media screen and (max-width: 390px){
          #naslov1{
              font-size: 50px;
          }
          .carousel{
              margin: 0;
          }
      }
  }
</style>

