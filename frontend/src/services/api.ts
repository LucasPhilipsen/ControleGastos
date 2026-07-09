import axios from 'axios';

// Criação de uma instância do axios com o endereço base local em C#
const api = axios.create({
    baseURL: 'https://localhost:7007/api',
});

export default api;