import axios from 'axios';

// Cria uma instância do axios com o endereço base da sua API em C#
const api = axios.create({
    baseURL: 'https://localhost:7007/api',
});

export default api;