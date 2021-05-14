import axios from 'axios';

const apiClient = axios.create({
  baseURL: `https://localhost:8081`,
  withCredentials: false, // This is the default
  headers: {
    Accept: 'application/json',
    'Content-Type': 'application/json',
  },
  timeout: 10000,
});

export default {
  getRecipes(perPage, page) {
    // ?_limit=' + perPage + '&_page=' + page
    return apiClient.get('/recipe');
  },
  getRecipe(id) {
    return apiClient.get('/recipe/' + id);
  },
};
