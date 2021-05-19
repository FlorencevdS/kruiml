import Vue from 'vue';
import Vuex from 'vuex';
import * as recipe from '@/store/modules/recipe';
import * as user from '@/store/modules/user';
import * as rating from '@/store/modules/rating';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {},
  mutations: {},
  actions: {},
  modules: {
    recipe,
    user,
    rating,
  },
});
