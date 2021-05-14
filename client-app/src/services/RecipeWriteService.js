import axios from 'axios';

const apiClient = axios.create({
  baseURL: `https://localhost:8083`,
  withCredentials: false, // This is the default
  headers: {
    Accept: 'application/json',
    'Content-Type': 'application/json',
  },
  timeout: 10000,
});

export default {
  postRecipe(recipe) {
    return apiClient.post('/recipe', recipe);
  },
};
