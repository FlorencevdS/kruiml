<template>
  <div>
    <b-navbar toggleable="lg" type="light" variant="light">
      <b-navbar-brand :to="{ name: 'Home' }">Kruiml</b-navbar-brand>

      <b-collapse id="nav-collapse" is-nav>
        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <!-- <b-nav-form>
            <b-form-input
              size="sm"
              class="mr-sm-2"
              placeholder="Search"
            ></b-form-input>
            <b-button size="sm" class="my-2 my-sm-0" type="submit"
              >Search</b-button
            >
          </b-nav-form> -->

          <b-nav-item-dropdown right>
            <template #button-content>
              <em>{{ user.user.name }}</em>
            </template>
            <b-dropdown-item @click="account()">My account</b-dropdown-item>
            <b-dropdown-item @click="signOut()">Sign Out</b-dropdown-item>
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
  },
};
</script>
