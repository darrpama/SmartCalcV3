import axios from 'axios'

class CalculatorService {
    apiUri = import.meta.env.VITE_API_URI

    async calculate(expression) {
        let response
        try {
            response = await axios.post(
                this.apiUri + `/calculator/calculate`,
                {expression: this.expression}
            )
        } catch (error) {
            console.error("Error:", error);
        }
        return response.data;
    }
}

export default CalculatorService