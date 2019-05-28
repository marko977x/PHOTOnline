<template>
    <div class="footer-container">
        <div class="pad-group">
            <div class="grid-one-half" style="color:white;">
                <p>Foto Aritonovic © 2019. All Rights Reserved.</p>
                <p>Designed by Group-ArT Team</p>
            </div>
            <div class="grid-one-half-last">
                <ul id="social-links" style="list-style-type: none; color:white; margin:0">
                    <li style="font-size:18px;"> <a href="https://www.facebook.com/foto.aritonovic/">Facebook</a> </li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    
}
</script>

<style scoped>
    .footer-container{
        display: flex;
        justify-content: end;
        width: 100%;
         background-color:  rgba(51, 54, 56, 0.925);
         
    }
    .pad-group{
        padding: 15px 30px 15px;
        width: 100%;
        flex-direction: row;
        display: flex;
    }
    .grid-one-half{
        display: flex;
        flex-direction: column;
        justify-content: space-around;
        width: 50%;
        position: relative;
    }
    p{
        line-height: 1.5em;
        margin-bottom: 0em;
        font-size: 13px;
    }
    .grid-one-half-last{
        width: 50%;
    }
    #social-links{
        flex-direction: row;
        display: flex;
        justify-content: flex-end;
    }
    @media screen and (max-width: 750px){
        .pad-group{
            flex-direction: column;
        }
        .grid-one-half{
            width: 100%;
            justify-content: center;
            align-items: center;
        }
        .grid-one-half-last{
            width: 100%;
            justify-content: center;
            align-items: center;
            display: flex;
        }
        
    }
</style>
