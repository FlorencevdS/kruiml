<template>
  <div class="home">
    <b-container>
      <b-row class="row-avatar">
        <b-col cols="4">
          <b-avatar size="6rem" :src="recipes.cook.image"></b-avatar>
          <span class="span-name">{{ recipes.cook.name }}</span>
        </b-col>
        <b-col>
          <b-button
            variant="outline-secondary"
            class="float-right"
            :to="{ name: 'addRecipe' }"
            >Add recipe</b-button
          >
        </b-col>
      </b-row>
      <b-row cols="3">
        <b-col v-for="(recipe, index) in recipes.recipes" :key="index"
          ><RecipeCard :recipe="recipe"
        /></b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import RecipeCard from '@/components/RecipeCard';

export default {
  components: {
    RecipeCard,
  },
  props: {
    recipes: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style>
.home {
  padding-top: 2rem;
}

.col {
  padding-top: 2rem;
}

.row-avatar {
  padding-left: 15px;
}

.span-name {
  padding-left: 2rem;
  align-self: center;
  font-size: 20px;
}
</style>
