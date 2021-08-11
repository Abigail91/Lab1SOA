export class StarWarsClient {
    async getStarWarsData() {
        const response = await fetch('http://localhost:5000/api/spaces');
        const data = await response.json();
        return data;

    }
    
}