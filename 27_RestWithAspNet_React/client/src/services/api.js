import axios from "axios";

const api = axios.create({
    baseURL: 'https://localhost:44336',
})

export default api;