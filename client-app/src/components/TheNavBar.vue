<template>
  <div>
    <b-navbar toggleable="lg" type="light" variant="light">
      <b-navbar-brand :to="{ name: 'Home' }">Kruiml</b-navbar-brand>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav class="ml-auto">
          <b-nav-item-dropdown right>
            <template #button-content>
              <em>{{ user.user.name }}</em>
            </template>
            <b-dropdown-item @click="account()">My account</b-dropdown-item>
            <b-dropdown-item @click="signOut()">Sign Out</b-dropdown-item>
            <b-dropdown-item @click="deleteAccount()"
              >Delete account</b-dropdown-item
            >
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script>
import { mapState } from 'vuex';

export default {
  computed: {
    ...mapState(['user']),
  },
  methods: {
    account() {
      this.$store
        .dispatch('recipe/fetchRecipesByUserId', this.user.user.id)
        .then((response) => {
          this.$router.push({
            name: 'Account',
            params: {
              UserId: this.user.user.id,
              userName: this.user.user.username,
            },
          });
        });
    },
    signOut() {
      this.user.auth.logout();
    },
    deleteAccount() {
      this.$store
        .dispatch('user/deleteAccount', this.user.user.id)
        .then((response) => {
          window.location.href =
            'http://localhost:8087/auth/realms/Kruiml/account';
        });
    },
  },
};
</script>
