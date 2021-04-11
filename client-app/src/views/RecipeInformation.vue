<template>
  <div>
    <b-container>
      <b-row>
        <b-col
          ><b-img :src="recipe.image" fluid alt="Responsive image"></b-img
        ></b-col>
        <b-col
          ><h1 class="h1-title">{{ recipe.title }}</h1>
          <p>{{ recipe.description }}</p></b-col
        >
      </b-row>
      <b-row>
        <b-col><h4>Ingredients</h4></b-col>
        <b-col><h4>Method</h4></b-col>
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
.h1-title {
  padding-bottom: 2rem !important;
}
</style>
