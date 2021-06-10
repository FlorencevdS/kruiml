import Vue from 'vue';
import * as Keycloak from 'keycloak-js';
import App from './App.vue';
import router from './router';
import store from './store';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

Vue.config.productionTip = false;

const initOptions = {
  realm: 'Kruiml',
  url: 'http://localhost:8087/auth',
  clientId: 'kruiml',
  onLoad: 'login-required',
};

let keycloak = new Keycloak(initOptions);

keycloak
  .init({ onLoad: initOptions.onLoad })
  .then((auth) => {
    new Vue({
      router,
      store,
      render: (h) => h(App),
    }).$mount('#app');

    store.dispatch('user/createAuth', keycloak);
    store.dispatch('user/setToken', keycloak.token);
    store.dispatch('user/setRefreshToken', keycloak.refreshToken);

    setInterval(() => {
      keycloak
        .updateToken()
        .then(function(refreshed) {
          if (refreshed) {
            store.dispatch('user/setToken', keycloak.token);
          }
        })
        .catch(() => {
          alert('Failed to refresh token');
        });
    }, 3000);
  })
  .catch(() => {
    alert(authenticated ? 'authenticated' : 'not authenticated');
  });
