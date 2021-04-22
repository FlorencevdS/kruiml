<template>
  <div>
    <b-container>
      <b-row>
        <b-col>
          <b-img v-if="previewUrl" :src="previewUrl" fluid></b-img>
          <b-form-file
            v-if="state == 'Edit'"
            v-model="dataRecipe.image"
            placeholder="Choose an image for your recipe..."
            accept="image/*"
            @change="previewFile"
          ></b-form-file>
          <b-img v-else :src="recipe.image" fluid></b-img>
        </b-col>
        <b-col
          ><h1 v-if="state == 'Information'">{{ recipe.title }}</h1>
          <div v-else class="form-inline justify-content-between">
            <b-form-input
              class="col-sm-8"
              v-model="dataRecipe.title"
              placeholder="Enter recipe title"
            ></b-form-input>
            <b-button
              variant="outline-success"
              class="col-sm-3"
              @click="addRecipe"
              >Add recipe</b-button
            >
          </div>
          <small v-if="state == 'Information'"
            >{{ recipe.likes }} likes | {{ recipe.prepTime }} minutes |
            {{ recipe.serves }} persons | {{ recipe.kcal }} kcal
          </small>
          <b-container fluid v-else>
            <b-row>
              <b-col sm="2"
                ><b-form-input
                  v-model="dataRecipe.prepTime"
                  size="sm"
                ></b-form-input
              ></b-col>
              <b-col sm="8"><label>minutes</label></b-col>
            </b-row>
            <b-row>
              <b-col sm="2"
                ><b-form-input
                  v-model="dataRecipe.serves"
                  size="sm"
                ></b-form-input
              ></b-col>
              <b-col sm="8"><label>persons</label></b-col>
            </b-row>
            <b-row>
              <b-col sm="2"
                ><b-form-input
                  v-model="dataRecipe.kcal"
                  size="sm"
                ></b-form-input
              ></b-col>
              <b-col sm="8"><label>kcal</label></b-col>
            </b-row>
          </b-container>

          <p v-if="state == 'Information'">{{ recipe.description }}</p>
          <b-form-textarea
            v-else
            placeholder="Enter recipe description"
            v-model="dataRecipe.description"
          ></b-form-textarea>
        </b-col>
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
          </b-form-group>
          <div v-if="state == 'Edit'">
            <b-container fluid class="no-padding">
              <b-row>
                <b-col sm="3"
                  ><b-form-input
                    size="sm"
                    v-model="ingredient.quantity"
                    placeholder="Quantity"
                  ></b-form-input
                ></b-col>
                <b-col sm="9"
                  ><b-form-input
                    size="sm"
                    v-model="ingredient.name"
                    placeholder="Name"
                  ></b-form-input
                ></b-col>
              </b-row>
            </b-container>
            <b-button @click="addIngredient">Add ingredient</b-button>
          </div>
        </b-col>
        <b-col
          ><h4>Method</h4>

          <hr />
          <b-form-group>
            <b-form-checkbox
              v-for="(step, index) in recipe.method"
              :key="index"
              >{{ step }}</b-form-checkbox
            >
          </b-form-group>
          <div v-if="state == 'Edit'">
            <b-container fluid class="no-padding">
              <b-row>
                <b-col sm="12"
                  ><b-form-textarea
                    v-model="method"
                    placeholder="Add method step"
                  ></b-form-textarea
                ></b-col>
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
    recipe: Object,
    state: String,
  },
  data() {
    return {
      dataRecipe: { ...this.recipe },
      previewUrl: null,
      ingredient: { quantity: '', name: '' },
      method: '',
    };
  },
  methods: {
    previewFile(e) {
      const file = e.target.files[0];
      this.previewUrl = URL.createObjectURL(file);
    },
    addIngredient: function() {
      this.dataRecipe.ingredients.push(this.ingredient);
      this.ingredient = { quantity: '', name: '' };
    },
    addMethodStep: function() {
      this.dataRecipe.method.push(this.method);
      this.method = '';
    },
    addRecipe: function() {},
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

.no-padding {
  padding: 0 0 1rem 0 !important;
}
</style>
