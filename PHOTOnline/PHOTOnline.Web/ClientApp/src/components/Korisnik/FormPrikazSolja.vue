<template>
    <div class="FormPrikazContainer">
        <div class="gornjiDiv">
            <img class="slika" src="../../assets/slikaSolje.jpg"/>
            <div class="divLabela">
                <label>Šolja za koju je Milica rekla da je predivna.</label>
            </div>          
        </div>
        <div class="donjiDiv">
            <el-form class="form">
                <div class="formDivGore">
                    <file-upload   action="https://jsonplaceholder.typicode.com/posts/" :directory="true" multiple="multiple">
                           <el-button size="small" type="warning">Upload Slika</el-button>
                </file-upload>
                </div>
                <div class="formDivDole">
                    <el-button @click="dodajProizvodUKorpu()" type="primary">Dodaj u korpu</el-button>
                </div>
            </el-form>
        </div>
    </div>
</template>

<script>
    import FileUpload from 'vue-upload-component'
    import {Button} from 'element-ui'
    import {apiFetch, destinationUrl} from "../../services/authFetch";

export default {
    components: { Button, FileUpload },
    data(){
        return{
    
        }
    },
    methods: {
        validacija: function(){
            if(true){                       //dodati logiku za ispitivanje da li je korisnik upload-ovao sliku
                this.$message({message : 'Morate upload-ovati sliku.', type: 'warning'})
                return
            }
            this.dodajProizvodUKorpu()
        },
        dodajProizvodUKorpu: async function(){
         /*       const formData = new FormData();
                for(let key in this.albumData){
					formData.append(key, this.albumData[key]);
				}
                const fetchData = { 
                    body: formData,
                    method: "POST"
                }
                fetch("https://localhost:5001/api//", fetchData)
                    .then(response => {
                        console.log(response);
                        return response.json(); 
                    }) 
                    .then(result => {
                        console.log(result);
                    });
                    this.$emit('editFinished',retAlbum) // ovo retAlbum je DataObject koji se salje drugoj komponenti
            // AddFinished je ime eventa okidaca koji se okida u drugoj kompononeti odnosno parent komponenti!*/
        }
    }
}
</script>

<style scoped>
    .FormPrikazContainer{
        display: flex;
        flex-grow: 1;
        flex-direction: column;
        background: #ebeef5;
    }

    .gornjiDiv{
        display: flex;
        width: 100%;
    }

    .slika{
        min-width: 100px;
        min-height: 100px;
        max-width: 300px;
        max-height: 300px;
        margin: 20px 20px;
    }

    .divLabela{
        display: flex;
        align-items: center;
        justify-content: center;
        width: 50%;
    }

    .donjiDiv{
        display: flex;
        justify-content: center;
    }

    .form{
        width: 90%;
    }

    .formDivGore{
        display: flex;
    }

    .formDivDole{
        display: flex;
        justify-content: flex-end;
    }

    label{
        margin: 20px 20px;
        font-size: 15px;
        text-align: center;
        flex-basis: 80%;
        width: 100%;
    }
</style>