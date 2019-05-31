<template>
    <div class="prikaz-proizvoda-container">
        <div class="part1">
            <img class="slika" src="">
        </div>
        <div class="part2">
            <!-- <p>Foto šolje sa Vašim dizajnom - natpisom ili fotografijom
                u punom koloru, na komad, su naš prepoznatljivi proizvod već preko 15 godina.
                Danas štampu na šoljma radimo isključivo sublimacionim postupkom. Šolja sa slikom 
                predstavlja idealan poklon za svaku priliku</p> -->
            <el-upload
                class="upload-demo"
                action="https://jsonplaceholder.typicode.com/posts/"
                multiple
                :limit="3">
                <el-button size="small" type="primary">Click to upload</el-button>
            </el-upload>
        </div>
        <div class="part3">
            <el-button type="success"> Dodaj u korpu </el-button>
        </div>
    </div>
</template>

<script>
export default {
    data(){
        return{
            proiz: this.list
        }
    },
    props: ['list']
}
</script>

<style>
.prikaz-proizvoda-container{
     height: 290px;
    width: 75%;
   /* background: linear-gradient(0deg, #d1d356, #e6e88d );*/
    background: linear-gradient(0deg, #bccecfe7, #fcfcfc );
    margin-top: 15px;
    border-radius: 3px;
    margin-left: 15%;
    display: flex;
    flex-direction: row;
}
.part1{
    height: 100%;
    width: 25%;
    display: flex;
    justify-content: center;
    align-items: center;
}
.part2{
     height: 100%;
    width: 50%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
}
.part3{
     height: 100%;
    width: 25%;
     display: flex;
    justify-content: center;
    align-items: center;
}
.slika{
    height: 80%;
    width: 90%;
}

</style>


