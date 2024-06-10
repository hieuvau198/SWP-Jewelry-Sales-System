import axios from 'axios';

export default axios.create({
    baseURL: 'http://localhost:5071/api'
});