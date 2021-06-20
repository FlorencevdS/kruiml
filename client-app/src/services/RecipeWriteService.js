import axios from 'axios';
import store from '../store';

const apiClient = axios.create({
  baseURL: `https://localhost:8083`,
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
  postRecipe(recipe) {
    return apiClient.post('/Recipe', recipe);
  },
  deleteRecipe(id) {
    return apiClient.delete('/Recipe/' + id);
  },
  deleteAccount(id) {
    return apiClient.delete('/Account/' + id);
  },
};
