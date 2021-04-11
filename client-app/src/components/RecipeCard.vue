<template>
  <div>
    <b-card
      no-body
      style="max-width: 30rem"
      :img-src="recipe.image"
      :img-alt="recipe.title"
      img-top
    >
      <template #header>
        <h6 class="mb-0">
          <b-link
            :to="{ name: 'RecipeInformation', params: { recipeId: recipe.id } }"
            class="stretched-link"
            >{{ recipe.title }}</b-link
          >
        </h6>
      </template>
    </b-card>
  </div>
</template>

<script>
export default {
  props: {
    recipe: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style>
a.stretched-link {
  text-decoration: none !important;
  color: #212529;
}
</style>
