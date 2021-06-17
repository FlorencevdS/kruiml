import axios from 'axios';
import store from '../store';

const apiClient = axios.create({
  baseURL: `https://localhost:8081`,
  withCredentials: false, // This is the default
  headers: {
    Accept: 'application/json',
    'Content-Type': 'application/json',
  },
  timeout: 10000,
});

apiClient.interceptors.request.use((config) => {
  config.headers = { Authorization: 'Bearer ' + store.state.user.token };
  return config;
});

export default {
  getRecipes(perPage, page) {
    // ?_limit=' + perPage + '&_page=' + page
    return apiClient.get('/recipe');
  },
  getRecipesByUserId(id) {
    return apiClient.get('/recipe/user/' + id);
  },
  getRecipe(id) {
    return apiClient.get('/recipe/' + id);
  },
};
