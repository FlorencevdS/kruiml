import RecipeRatingService from '@/services/RecipeRatingService.js';

export const namespaced = true;

export const state = {
  ratings: [],
  rating: {},
  perPage: 9,
};

export const mutations = {
  ADD_RATING(state, rating) {
    state.ratings.push(rating);
  },
  SET_RATINGS(state, ratings) {
    state.ratings = ratings;
  },
  SET_RATING(state, rating) {
    state.rating = rating;
  },
};

export const actions = {
  fetchRatings({ commit, dispatch, state }) {
    return RecipeRatingService.getRatings()
      .then((response) => {
        commit('SET_RATINGS', response.data);
      })
      .catch((error) => {
        const notification = {
          type: 'error',
          message: 'There was a problem fetching ratings: ' + error.message,
        };
      });
  },
  fetchRatingInformation({ commit, getters, state }, id) {
    return RecipeRatingService.getRating(id).then((response) => {
      commit('SET_RATING', response.data);
      return response.data;
    });
  },
  fetchPersonalRating({ commit, getters, state }, { recipeId, userId }) {
    return RecipeRatingService.getPersonalRating(recipeId, userId).then(
      (response) => {
        return response.data;
      }
    );
  },
  createRating({ commit }, rating) {
    return RecipeRatingService.postRating(rating)
      .then((response) => {
        commit('SET_RATING', rating);
        return response.data;
      })
      .catch((error) => {
        return error.response;
      });
  },
};
export const getters = {
  getRatingByRecipeId: (state) => (id) => {
    return state.ratings.find((rating) => rating.recipeId === id);
  },
};
