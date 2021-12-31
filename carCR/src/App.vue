<template>
    <div id="app">
        <div class="carSaveLogo">
            <img alt="Vue logo" src="./assets/logo.png">
        </div>
        <CarSave />
    </div>
</template>

<script>
import CarSave from './components/CarSave.vue'

export default {
  name: 'App',
        components: {
            CarSave
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 46px;
}
.carSaveLogo {
    text-align: center;
}
</style>
