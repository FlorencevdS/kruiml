<template>
  <div>
    <b-container>
      <b-row>
        <b-col
          ><b-img :src="recipe.image" fluid alt="Responsive image"></b-img
        ></b-col>
        <b-col
          ><h1>{{ recipe.title }}</h1>
          <small
            >{{ recipe.likes }} likes | {{ recipe.prepTime }} minutes |
            {{ recipe.serves }} persons | {{ recipe.kcal }} kcal
          </small>
          <p>{{ recipe.description }}</p></b-col
        >
      </b-row>
      <b-row>
        <b-col
          ><h4>Ingredients</h4>
          <hr />
          <b-form-group>
            <b-form-checkbox
              v-for="(ingredient, index) in recipe.ingredients"
              :key="index"
              >{{ ingredient.quantity }} {{ ingredient.name }}</b-form-checkbox
            >
          </b-form-group></b-col
        >
        <b-col
          ><h4>Method</h4>

          <hr />
          <b-form-group>
            <b-form-checkbox
              v-for="(step, index) in recipe.method"
              :key="index"
              >{{ step }}</b-form-checkbox
            >
          </b-form-group></b-col
        >
      </b-row>
    </b-container>
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
p {
  margin-top: 2rem !important;
}
</style>
