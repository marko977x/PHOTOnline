<template>
    <div class="prikaz-proizvoda-container">
        <label>Online Naručivanje Fotografija</label>
         <el-upload
                class="upload-demo"
                action="https://jsonplaceholder.typicode.com/posts/"
                multiple
                :limit="3">
                <el-button size="small" type="primary">Click to upload</el-button>
            </el-upload>
    </div>
</template>

<script>
export default {
    data(){
        return{
            proiz: this.list,
        }
    },
    props: ['list']
}
</script>

<style scoped>
.prikaz-proizvoda-container{
     height: 100px;
    width: 75%;
   /* background: linear-gradient(0deg, #d1d356, #e6e88d );*/
    background: linear-gradient(0deg, #bccecfe7, #fcfcfc );
    margin-top: 15px;
    border-radius: 3px;
    margin-left: 15%;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
}

</style>
