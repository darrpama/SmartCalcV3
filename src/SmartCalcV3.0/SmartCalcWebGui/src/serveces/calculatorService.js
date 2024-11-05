import axios from 'axios'

class CalculatorService {
    apiUri = import.meta.env.VITE_API_URI

    async calculate(expression) {
        let response
        try {
            response = await axios.post(
                this.apiUri + `/calculator/calculate?${expression}`,
            )
        } catch (error) {
            console.error("Error:", error);
        }
        console.log(response)
        return response;
    }
}

export default CalculatorService