<script setup>
import CalculatorModel from '@/models/calculatorModel.js'
import { reactive } from 'vue';

var result = null;

const calculatorModel = reactive(new CalculatorModel())

async function calculate() {
    try {
        await calculatorModel.calculate(expression)
    } catch ({ message }) {
        alert(message)
    }
    result = calculatorModel.answer
}

</script>

<template>
    <div class="calculator">
        <h1>Simple Calculator</h1>
        <input v-model="expression" placeholder="Enter expression"/>
        <button @click="calculate">Calculate</button>
        <div v-if="result !== null">Result: {{ result }}</div>
    </div>
</template>


<style scoped>
.calculator {
  text-align: center;
  margin-top: 50px;
}

input {
  padding: 10px;
  font-size: 16px;
  width: 250px;
}

button {
  padding: 10px 15px;
  font-size: 16px;
  margin-left: 10px;
}
</style>