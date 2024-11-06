import axios from 'axios'

class CalculatorService {
    apiUri = import.meta.env.VITE_API_URI

    async calculate(expression) {
        try {
            const payload = { expression: expression }
            const response = await axios.post(
                this.apiUri + '/calculator/calculate', payload 
            );
            if (response.status === 200)
            {
                const answer = response.data;
                return answer;
            }
        } catch (error) {
            console.error("Error calculating expression:", error);
        }
    }
}

export default CalculatorService