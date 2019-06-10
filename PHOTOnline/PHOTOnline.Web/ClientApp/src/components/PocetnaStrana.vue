<template>
    <div class="pocetna">
        <div class="home-page"></div>
        <h1>Dobrodošli</h1>
    </div>
</template>

<script>
export default {
    
}
</script>

<style>
    .pocetna{
        display: flex;
        justify-content: center;
        align-items: center;
        width: 100%;
        background-size: cover;
        background-image: linear-gradient(
            rgba(26, 111, 168, 0.171),
            rgba(57, 63, 61, 0.205)
        ),url("../assets/pictures/1.jpg");
    }
    .home-page{
        z-index: 1;
        height: 100%;
        width: 100%;
        position: absolute;
        top: 0;
        left: 0;
    }
    .pocetna h1{
        color: white;
        font-family: sans-serif;
        font-size: 70px;
        display: flex;
        justify-content: center;
    }
</style>
