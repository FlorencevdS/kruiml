import Vue from 'vue';
import Vuex from 'vuex';
import * as recipe from '@/store/modules/recipe';
import * as user from '@/store/modules/user';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {},
  mutations: {},
  actions: {},
  modules: {
    recipe,
    user,
  },
});
