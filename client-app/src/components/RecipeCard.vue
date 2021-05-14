<template>
  <div>
    <b-card
      no-body
      style="max-width: 30rem"
      :img-src="recipe.imageUrl"
      :img-alt="recipe.title"
      img-top
    >
      <template #header>
        <div style="float:left">
          <h6 class="mb-0" style="padding: 0.2rem !important">
            <b-link
              :to="{
                name: 'RecipeInformation',
                params: { recipeId: recipe.recipeId },
              }"
              class="stretched-link"
              >{{ recipe.title }}</b-link
            >
          </h6>
        </div>
        <div style="float:right">
          <b-form-rating
            id="rating-inline"
            inline
            no-border
            size="sm"
            icon-empty="heart"
            icon-half="heart-half"
            icon-full="heart-fill"
            variant="danger"
            :value="rating ? rating.averageRatingValue : 0"
          ></b-form-rating>
        </div>
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
    rating: Object,
  },
};
</script>

<style>
a.stretched-link {
  text-decoration: none !important;
  color: #212529;
}

output#rating-inline {
  background-color: transparent !important;
}
</style>
