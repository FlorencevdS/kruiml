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
