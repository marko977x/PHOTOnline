<template>
    <div class="album-korisnik-container">
          <div class="dodavanje" >
                 <el-input v-model="password"
                            type="password"
                            show-password
                            size="medium"
                            style="width:300px; margin-right:50px;"
                            placeholder="Unesite šifru albuma">
                </el-input>
                <el-button type="primary" size="mini" style="height:35px;">Prikaži Album</el-button>
                  <div class="potvrdi">
                     <el-button type="danger"  size="medium">Poruči </el-button>
                 </div>
        </div>
         <div class="album-fotografije">
            <fotografije v-for="item in 40" :key="item.key" ></fotografije>
        </div>
        <footer-bar hidden></footer-bar>
    </div>
</template>

<script>
import FooterBar from "../FooterBar.vue"
import Fotografije from "./Fotografije.vue"
export default {
    components: {FooterBar, Fotografije},
    data(){
        return {
            password: ''
        }
    }
}
</script>

<style>
.album-korisnik-container{
        display: flex;
        height: 100%;
        width: 100%;
        flex-direction: column;
        overflow: auto;
        background-color: rgba(224, 224, 235, 0.445);
}
.album-fotografije{
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
}
.potvrdi{
    display: flex;
    flex-direction: row-reverse;
    width: 100%;
    height: 35px;
    margin-right: 15px;
}
</style>

