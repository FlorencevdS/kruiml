export const namespaced = true;

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
};
