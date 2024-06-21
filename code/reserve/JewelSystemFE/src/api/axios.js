import axios from 'axios';
const BASE_URL = 'http://localhost:5071/api';

export default axios.create({
    baseURL: BASE_URL
});