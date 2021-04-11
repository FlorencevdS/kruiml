import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';
import Home from '../views/Home.vue';
import RecipeInformation from '../views/RecipeInformation.vue';
import store from '@/store/index';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    props: true,
    beforeEnter(routeTo, routeFrom, next) {
      store.dispatch('recipe/fetchRecipes').then(() => {
        routeTo.params.recipes = store.state.recipe;
        next();
      });
    },
  },
  {
    path: '/recipeInformation',
    name: 'RecipeInformation',
    component: RecipeInformation,
    props: true,
    beforeEnter(routeTo, routeFrom, next) {
      store
        .dispatch('recipe/fetchRecipe', routeTo.params.recipeId)
        .then((recipe) => {
          routeTo.params.recipe = recipe;
          next();
        });
    },
  },
];

const router = new VueRouter({
  mode: 'history',
  routes,
});

export default router;
