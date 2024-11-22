<script setup>
import CalculatorModel from '@/models/calculatorModel.js'
import { reactive, ref } from 'vue';

const calculatorModel = reactive(new CalculatorModel())
const expression = ref('');
const result = ref(null);
const calculated = false;

async function calculate() {
    try {
        await calculatorModel.calculateExpression(expression.value)
        result.value = calculatorModel.answer
    } catch ({ message }) {
        alert(message)
    }
}

function handleClick(value) {
  this.expression += value;
}

function handleClear() {
  this.expression = "";
}

function handleClearEntry() {
  if (this.expression && this.expression.length > 0)
  {
    this.expression = this.expression.slice(0, -1);
    if (this.expression.length === 0)
    {
      this.handleClear();
    }
  }
  else 
  {
    this.handleClear();
  }
}

</script>

<template>
    <div class="calculator">
        <h1>Calculator</h1>
        <input v-model="expression" placeholder="Expression" readonly/>
        <div class="buttons">
          <button class="number" @click="handleClick('7')">7</button>
          <button class="number" @click="handleClick('8')">8</button>
          <button class="number" @click="handleClick('9')">9</button>
          <button class="operator" @click="handleClick('-')">-</button>
          <button class="operator" @click="handleClick('sqrt')">sqrt</button>
          <button class="operator" @click="handleClick('log')">log</button>

          <button class="number" @click="handleClick('4')">4</button>
          <button class="number" @click="handleClick('5')">5</button>
          <button class="number" @click="handleClick('6')">6</button>
          <button class="operator" @click="handleClick('/')">/</button>
          <button class="operator" @click="handleClick('*')">*</button>
          <button class="operator" @click="handleClick('ln')">ln</button>

          <button class="number" @click="handleClick('1')">1</button>
          <button class="number" @click="handleClick('2')">2</button>
          <button class="number" @click="handleClick('3')">3</button>
          <button class="operator" @click="handleClick('+')">+</button>
          <button class="operator" @click="handleClick('e')">e</button>
          <button class="operator" @click="handleClick('.')">.</button>

          <button class="operator" @click="handleClick('sin')">sin</button>
          <button class="operator" @click="handleClick('cos')">cos</button>
          <button class="operator" @click="handleClick('tan')">tan</button>
          <button class="operator" @click="handleClick('asin')">asin</button>
          <button class="operator" @click="handleClick('acos')">acos</button>
          <button class="operator" @click="handleClick('atan')">atan</button>

          <button class="operator" @click="handleClick('(')">(</button>
          <button class="operator" @click="handleClick(')')">)</button>
          <button class="clear" @click="handleClear()">C</button>
          <button class="clear" @click="handleClearEntry()">CE</button>
          <button class="operator" @click="handleClick('-')">-</button>
          <button class="equal" @click="calculate">=</button>
        </div>
        <div v-if="result !== null">Result: {{ result }}</div>
    </div>
</template>


<style scoped>
.calculator {
  width: 600px;
  margin: 0;
  border: 1px solid #ccc;
  border-radius: 10px;
  padding: 15px;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
  background-color: #f9f9f9;
}

input {
  padding: 15px;
  font-size: 20px;
  width: 100%;
  border: 1px solid #ccc;
  border-radius: 5px;
  margin-bottom: 15px;
  text-align: right;
}

button {
  padding: 15px;
  font-size: 18px;
  margin: 5px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
}

.number, .operator {
  background-color: #e0e0e0;
}

.number:hover, .operator:hover {
  background-color: #d0d0d0;
}

.clear {
  background-color: #ff6666;
}

.clear:hover {
  background-color: #ff4c4c;
}

.equal {
  background-color: #4caf50;
  color: white;
}

.equal:hover {
  background-color: #45a049;
}

.buttons {
  display: grid;
  grid-template-columns: repeat(6, 1fr);
  gap: 10px;
}

.result {
  margin-top: 20px;
  font-size: 18px;
  font-weight: bold;
}
</style>