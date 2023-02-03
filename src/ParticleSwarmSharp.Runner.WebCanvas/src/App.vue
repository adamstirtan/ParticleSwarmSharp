<template>
    <WebCanvas />
</template>

<script>
import WebCanvas from './components/WebCanvas.vue'

export default {
  name: 'App',
  components: {
    WebCanvas
  }
}
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>
