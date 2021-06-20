export const namespaced = true;
import RecipeWriteService from '@/services/RecipeWriteService.js';

export const state = {
  auth: {},
  user: {},
  token: '',
  refreshToken: '',
};

export const mutations = {
  SET_AUTH(state, auth) {
    state.auth = auth;
    auth.loadUserInfo().then((userInfo) => {
      state.user = {
        name: userInfo.name,
        email: userInfo.email,
        id: userInfo.sub,
        username: userInfo.preferred_username,
      };
    });
  },
  SET_TOKEN(state, token) {
    state.token = token;
  },
  SET_REFRESHTOKEN(state, refreshToken) {
    state.refreshToken = refreshToken;
  },
};

export const actions = {
  createAuth({ commit }, auth) {
    commit('SET_AUTH', auth);
  },
  setToken({ commit }, token) {
    commit('SET_TOKEN', token);
  },
  setRefreshToken({ commit }, refreshToken) {
    commit('SET_REFRESHTOKEN', refreshToken);
  },
  deleteAccount({ commit }, id) {
    return RecipeWriteService.deleteAccount(id)
      .then(() => {})
      .catch((error) => {
        return error.response;
      });
  },
};
