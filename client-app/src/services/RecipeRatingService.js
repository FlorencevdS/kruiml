import axios from 'axios';
import store from '../store';

const apiClient = axios.create({
  baseURL: `https://localhost:8085`,
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
  getRatings(perPage, page) {
    // ?_limit=' + perPage + '&_page=' + page
    return apiClient.get('/rating');
  },
  getRating(id) {
    return apiClient.get('/rating/' + id);
  },
  postRating(rating) {
    return apiClient.post('/rating', rating);
  },
};
