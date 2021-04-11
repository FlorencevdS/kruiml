import RecipeService from '@/services/RecipeService.js';

export const namespaced = true;

export const state = {
  recipes: [
    {
      id: 1,
      image: require('@/assets/andijviestamppot.jpg'),
      title: 'Endive stew',
      description: 'The best endive stew ever!',
    },
    {
      id: 2,
      image: require('@/assets/Champignonsoep.jpg'),
      title: 'Mushroomsoup',
      description:
        'Make the most of mushrooms with this comforting mushroom soup recipe made with cream, onions and garlic. Serve for lunch or as a starter with crusty bread',
    },
    {
      id: 3,
      image: require('@/assets/hummus.jpg'),
      title: 'Hummus',
      description:
        'This creamy, rich hummus is made using just five ingredients and is ready in 10 minutes. Serve with crunchy seasonal veg or warm pitta breads',
    },
    {
      id: 4,
      image: require('@/assets/pesto.jpg'),
      title: 'Pesto',
      description:
        'Make a vegan pesto to add to pasta, pizzas, salads and sandwiches. It will keep in the fridge for up to a week',
    },
    {
      id: 5,
      image: require('@/assets/Soep.jpg'),
      title: 'Soup',
      description:
        'Get three of your 5-a-day in one serving with this healthy, low-calorie tomato soup.',
    },
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
