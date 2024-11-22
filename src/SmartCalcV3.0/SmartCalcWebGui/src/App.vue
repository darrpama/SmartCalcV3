<script>
import Calculator from './components/Calculator.vue'

export default {
  components: {
    Calculator
  }
};
</script>

<template>
  <div class="app" id="app">
    <div class="calculator-container">
      <Calculator />
    </div>
  </div>
</template>

<style>
html, body {
  height: 100%;
  margin: 0;
  display: flex;
  justify-content: center;
  align-items: center;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  text-align: center;
  color: #c1254c;
  height: 100%; /* Ensure the app takes full height */
}

.calculator-container {
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>