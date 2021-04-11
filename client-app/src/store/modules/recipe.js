import RecipeService from '@/services/RecipeService.js';

export const namespaced = true;

export const state = {
  recipes: [
    {
      id: 1,
      image: require('@/assets/andijviestamppot.jpg'),
      title: 'Endive stew',
      description: 'The best endive stew ever!',
      likes: '500',
      prepTime: '30',
      serves: '4',
      kcal: '410',
      ingredients: [
        { quantity: '1.25 kg', name: 'potatoes' },
        { quantity: '250 g', name: 'bacon strips' },
        { quantity: '500 g', name: 'endive' },
        { quantity: '1/2 tbsp', name: 'nutmeg' },
      ],
      method: [
        'Peel the potatoes and cut into equal pieces. Boil in water with salt for 20 minutes until tender. Drain and reserve a cup of the cooking water. Meanwhile, heat a pan without oil or butter and fry the bacon on medium heat for about 7 minutes until crispy. Drain on kitchen paper and keep the bacon fat.',
        'Mash the potatoes with a potato masher until smooth. Add the bacon fat and any cooking liquid. Add the endive. Season with the nutmeg, pepper and salt if desired. Divide the stamp over plates. Divide the bacon over it.',
      ],
    },
    {
      id: 2,
      image: require('@/assets/Champignonsoep.jpg'),
      title: 'Mushroomsoup',
      description:
        'Make the most of mushrooms with this comforting mushroom soup recipe made with cream, onions and garlic. Serve for lunch or as a starter with crusty bread.',
      likes: '147',
      prepTime: '35',
      serves: '4',
      kcal: '309',
      ingredients: [
        { quantity: '90 g', name: 'butter' },
        { quantity: '2', name: 'onions' },
        { quantity: '1', name: 'garlic clove' },
        { quantity: '500 g', name: 'mushrooms' },
        { quantity: '2 tbsp', name: 'plain flour' },
        { quantity: '1 l', name: 'chicken stock' },
        { quantity: '1', name: 'bay leaf' },
        { quantity: '4 tbsp', name: 'single cream' },
        { quantity: 'small handful', name: 'flat-leaf parsley' },
      ],
      method: [
        'Heat the butter in a large saucepan and cook the onions and garlic until soft but not browned, about 8-10 mins.',
        'Add the mushrooms and cook over a high heat for another 3 mins until softened. Sprinkle over the flour and stir to combine. Pour in the chicken stock, bring the mixture to the boil, then add the bay leaf and simmer for another 10 mins.',
        'Remove and discard the bay leaf, then remove the mushroom mixture from the heat and blitz using a hand blender until smooth. Gently reheat the soup and stir through the cream (or, you could freeze the soup at this stage – simply stir through the cream when heating). Scatter over the parsley, if you like, and serve.',
      ],
    },
    {
      id: 3,
      image: require('@/assets/hummus.jpg'),
      title: 'Hummus',
      description:
        'This creamy, rich hummus is made using just five ingredients and is ready in 10 minutes. Serve with crunchy seasonal veg or warm pitta breads.',
      likes: '71',
      prepTime: '10',
      serves: '4',
      kcal: '380',
      ingredients: [
        { quantity: '400 g', name: 'chickpeas' },
        { quantity: '80 ml', name: 'extra virgin olive oil' },
        { quantity: '1-2', name: 'garlic cloves' },
        { quantity: '1', name: 'lemon' },
        { quantity: '3 tbsp', name: 'tahini' },
        { quantity: '', name: 'mixed crudités and toasted pitta bread' },
      ],
      method: [
        'Thoroughly rinse the chickpeas in a colander under cold running water. Tip into the large bowl of a food processor along with 60ml of the oil and blitz until almost smooth. Add the garlic, lemon and tahini along with 30ml water. Blitz again for about 5 mins, or until the hummus is smooth and silky.',
        'Add 20ml more water, a little at a time, if it looks too thick. Season and transfer to a bowl. Swirl the top of the hummus with the back of a dessert spoon and drizzle over the remaining oil. Serve with crunchy crudités and toasted pitta bread, if you like.',
      ],
    },
    {
      id: 4,
      image: require('@/assets/pesto.jpg'),
      title: 'Pesto',
      description:
        'Make a vegan pesto to add to pasta, pizzas, salads and sandwiches. It will keep in the fridge for up to a week.',
      likes: '8',
      prepTime: '7',
      serves: '8',
      kcal: '574',
      ingredients: [
        { quantity: '50 g', name: 'pine nuts' },
        { quantity: 'large bunch', name: 'basil' },
        { quantity: '2 tbsp', name: 'yeast' },
        { quantity: '150 ml', name: 'olive oil' },
        { quantity: '2', name: 'garlic cloves' },
        { quantity: '1/2', name: 'lemon' },
      ],
      method: [
        'Toast the pine nuts in a small pan over a low heat for 3-4 mins until golden brown. Set aside to cool.',
        'Blitz the pine nuts with the remaining ingredients in a food processor until smooth. Season to taste.',
        'Spoon the pesto into a jar and top with a thick drizzle of olive oil. Will keep stored in the fridge for up to a week. ',
      ],
    },
    {
      id: 5,
      image: require('@/assets/Soep.jpg'),
      title: 'Soup',
      description:
        'Get three of your 5-a-day in one serving with this healthy, low-calorie tomato soup.',
      likes: '51',
      prepTime: '20',
      serves: '4',
      kcal: '330',
      ingredients: [
        { quantity: '1.5 tbsp', name: 'rapeseed oil' },
        { quantity: '1', name: 'onion' },
        { quantity: '2', name: 'red peppers' },
        { quantity: '1', name: 'garlic clove' },
        { quantity: '1/2 tsp', name: 'chilli flakes' },
        { quantity: '800 g', name: 'tomatoes' },
        { quantity: '100 g', name: 'couscous' },
        { quantity: '500 ml', name: 'vegetable stock' },
        { quantity: '12', name: 'pork meatballs' },
        { quantity: '150 g', name: 'baby spinach' },
        { quantity: '1/2 small bunch', name: 'basil' },
        { quantity: '', name: 'grated parmesan' },
      ],
      method: [
        'Heat the oil in a saucepan. Fry the onion and peppers for 7 mins, then stir through the garlic and chilli flakes and cook for 1 min. Add the tomatoes, giant couscous and veg stock and bring to a simmer.',
        'Season to taste, then add the meatballs and spinach. Simmer for 5-7 mins or until cooked through. Ladle into bowls and top with the basil and some parmesan, if you like.',
      ],
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
