import axios from 'axios';

const apiClient = axios.create({
  baseURL: `http://localhost:3000/api`,
  withCredentials: false, // This is the default
  headers: {
    Accept: 'application/json',
    'Content-Type': 'application/json',
  },
  timeout: 10000,
});

export default {
  getRecipes(perPage, page) {
    return apiClient.get('/recipes?_limit=' + perPage + '&_page=' + page);
  },
  getRecipe(id) {
    return apiClient.get('/recipes/' + id);
  },
  postRecipe(recipe) {
    return apiClient.post('/recipes', recipe);
  },
};
