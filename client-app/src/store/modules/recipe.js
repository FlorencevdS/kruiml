import RecipeService from '@/services/RecipeService.js';

export const namespaced = true;

export const state = {
  recipes: [
    {
      id: 1,
      image: require('@/assets/andijviestamppot.jpg'),
      title: 'Endive stew',
    },
    {
      id: 2,
      image: require('@/assets/Champignonsoep.jpg'),
      title: 'Mushroomsoup',
    },
    { id: 3, image: require('@/assets/hummus.jpg'), title: 'Hummus' },
    { id: 4, image: require('@/assets/pesto.jpg'), title: 'Pesto' },
    { id: 5, image: require('@/assets/Soep.jpg'), title: 'Soup' },
  ],
  cook: { image: require('@/assets/kok.jpg'), name: 'Mr. Chef' },
  recipe: {},
  perPage: 9,
};

export const mutations = {
  ADD_RECIPE(state, recipe) {
    state.recipes.push(recipe);
  },
  SET_RECIPES(state, recipes) {
    state.recipes = recipes;
  },
  SET_RECIPE(state, recipe) {
    state.recipe = recipe;
  },
};

export const actions = {
  fetchRecipes({ commit, dispatch, state }) {
    return state.recipes;
    // return RecipeService.getRecipes(state.perPage, page)
    //   .then((response) => {
    //     commit('SET_RECIPES', response.data);
    //   })
    //   .catch((error) => {
    //     const notification = {
    //       type: 'error',
    //       message: 'There was a problem fetching recipes: ' + error.message,
    //     };
    //     dispatch('notification/add', notification, { root: true });
    //   });
  },
  fetchRecipe({ commit, getters, state }, id) {
    if (id == state.recipe.id) {
      return state.recipe;
    }

    var recipe = getters.getRecipeById(id);

    if (recipe) {
      commit('SET_RECIPE', recipe);
      return recipe;
    } else {
      return RecipeService.getRecipe(id).then((response) => {
        commit('SET_RECIPE', response.data);
        return response.data;
      });
    }
  },
};
export const getters = {
  getRecipeById: (state) => (id) => {
    return state.recipes.find((recipe) => recipe.id === id);
  },
};
