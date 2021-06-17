import RecipeReadService from '@/services/RecipeReadService.js';
import RecipeWriteService from '@/services/RecipeWriteService.js';

export const namespaced = true;

export const state = {
  recipes: [],
  cook: { image: require('@/assets/kok.jpg') },
  recipe: {},
  perPage: 9,
};

export const mutations = {
  ADD_RECIPE(state, recipe) {
    state.recipes.push(recipe);
  },
  SET_RECIPES(state, recipes) {
    Array.isArray(recipes)
      ? (state.recipes = recipes)
      : (state.recipes = [recipes]);
  },
  SET_RECIPE(state, recipe) {
    state.recipe = recipe;
  },
};

export const actions = {
  fetchRecipes({ commit, dispatch, state }) {
    return RecipeReadService.getRecipes()
      .then((response) => {
        commit('SET_RECIPES', response.data);
      })
      .catch((error) => {
        const notification = {
          type: 'error',
          message: 'There was a problem fetching recipes: ' + error.message,
        };
      });
  },
  fetchRecipesByUserId({ commit, dispatch, state }, id) {
    return RecipeReadService.getRecipesByUserId(id)
      .then((response) => {
        commit('SET_RECIPES', response.data);
      })
      .catch((error) => {
        const notification = {
          type: 'error',
          message: 'There was a problem fetching recipes: ' + error.message,
        };
      });
  },
  fetchRecipe({ commit, getters, state }, id) {
    var recipe = getters.getRecipeById(id);

    if (recipe) {
      commit('SET_RECIPE', recipe);
      return recipe;
    } else {
      return RecipeReadService.getRecipe(id).then((response) => {
        commit('SET_RECIPE', response.data);
        return response.data;
      });
    }
  },
  createRecipe({ commit }, recipe) {
    return RecipeWriteService.postRecipe(recipe)
      .then((response) => {
        commit('SET_RECIPE', recipe);
        return response.data;
      })
      .catch((error) => {
        return error.response;
      });
  },
};
export const getters = {
  getRecipeById: (state) => (id) => {
    return state.recipes.find((recipe) => recipe.recipeId === id);
  },
};
