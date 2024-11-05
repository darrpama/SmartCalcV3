import CalculatorService from "@/serveces/calculatorService";

class CalculatorModel {

    answer = null;
    calculatorService = new CalculatorService()

    async calculateExpresson(expression) {
        let answer = await this.calculatorService.calculate(expression)
    }
}

export default CalculatorModel