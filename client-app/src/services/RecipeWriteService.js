import axios from 'axios';

const apiClient = axios.create({
  baseURL: `http://localhost:80`,
  withCredentials: false, // This is the default
  headers: {
    Accept: 'application/json',
    'Content-Type': 'application/json',
  },
  timeout: 10000,
});

export default {
  postRecipe(recipe) {
    return apiClient.post('/addRecipe', recipe);
  },
};
