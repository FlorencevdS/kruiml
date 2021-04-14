<template>
  <div>
    <b-container>
      <b-row>
        <b-col>
          <b-img v-if="previewUrl" :src="previewUrl" fluid></b-img>
          <b-form-file
            v-if="state == 'Edit'"
            v-model="recipe.image"
            placeholder="Choose an image for your recipe..."
            accept="image/*"
            @change="previewFile"
          ></b-form-file>
          <b-img v-else :src="recipe.image" fluid></b-img>
        </b-col>
        <b-col
          ><h1 v-if="state == 'Information'">{{ recipe.title }}</h1>
          <b-form-input
            v-else
            v-model="recipe.title"
            placeholder="Enter recipe title"
          ></b-form-input>
          <small v-if="state == 'Information'"
            >{{ recipe.likes }} likes | {{ recipe.prepTime }} minutes |
            {{ recipe.serves }} persons | {{ recipe.kcal }} kcal
          </small>
          <b-container fluid v-else>
            <b-row>
              <b-col sm="2"
                ><b-form-input
                  v-model="recipe.prepTime"
                  size="sm"
                ></b-form-input
              ></b-col>
              <b-col sm="8"><label>minutes</label></b-col>
            </b-row>
            <b-row>
              <b-col sm="2"
                ><b-form-input v-model="recipe.serves" size="sm"></b-form-input
              ></b-col>
              <b-col sm="8"><label>persons</label></b-col>
            </b-row>
            <b-row>
              <b-col sm="2"
                ><b-form-input v-model="recipe.kcal" size="sm"></b-form-input
              ></b-col>
              <b-col sm="8"><label>kcal</label></b-col>
            </b-row>
          </b-container>

          <p v-if="state == 'Information'">{{ recipe.description }}</p>
          <b-form-textarea
            v-else
            placeholder="Enter recipe description"
            v-model="recipe.description"
          ></b-form-textarea>
        </b-col>
      </b-row>
      <b-row>
        <b-col
          ><h4>Ingredients</h4>
          <hr />
          <b-form-group v-if="state == 'Information'">
            <b-form-checkbox
              v-for="(ingredient, index) in recipe.ingredients"
              :key="index"
              >{{ ingredient.quantity }} {{ ingredient.name }}</b-form-checkbox
            >
          </b-form-group>
          <div v-else>
            <b-container fluid>
              <b-row>
                <b-col sm="2"><b-form-input size="sm"></b-form-input></b-col>
                <b-col sm="8"><b-form-input size="sm"></b-form-input></b-col>
              </b-row>
            </b-container>
            <b-button @click="addIngredient">Add ingredient</b-button>
          </div>
        </b-col>
        <b-col
          ><h4>Method</h4>

          <hr />
          <b-form-group v-if="state == 'Information'">
            <b-form-checkbox
              v-for="(step, index) in recipe.method"
              :key="index"
              >{{ step }}</b-form-checkbox
            >
          </b-form-group>
          <div v-else>
            <b-container fluid>
              <b-row>
                <b-col sm="12"><b-form-textarea></b-form-textarea></b-col>
              </b-row>
            </b-container>
            <b-button @click="addMethodStep">Add step</b-button>
          </div>
        </b-col>
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
    state: {
      type: String,
      required: true,
    },
  },
  data() {
    return {
      dataRecipe:
        this.recipe !== undefined
          ? { ...this.recipe }
          : {
              image: '',
              title: '',
              description: '',
              likes: '',
              prepTime: '',
              serves: '',
              kcal: '',
              ingredients: [],
              method: [],
            },
      previewUrl: null,
    };
  },
  methods: {
    previewFile(e) {
      const file = e.target.files[0];
      this.previewUrl = URL.createObjectURL(file);
    },
    addIngredient: function() {
      this.recipe.ingredients.push({ quantity: '', name: '' });
    },
  },
};
</script>

<style>
p {
  margin-top: 2rem !important;
}

.container-fluid {
  padding: 1rem 0 1rem 0 !important;
}
</style>
