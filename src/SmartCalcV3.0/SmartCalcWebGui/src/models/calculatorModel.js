import CalculatorService from "@/serveces/calculatorService";

class CalculatorModel {

    answer = null;
    calculatorService = new CalculatorService()

    async calculateExpression(expression) {
        this.answer = await this.calculatorService.calculate(expression)
    }
}

export default CalculatorModel