<template>
  <div>
    <b-container>
      <b-row>
        <b-col>
          <b-img v-if="previewUrl" :src="previewUrl" fluid></b-img>
          <b-form-file
            v-if="state == 'Edit'"
            v-model="imageFile"
            placeholder="Choose an image for your recipe..."
            accept="image/*"
            @change="changeFile"
          ></b-form-file>
          <b-img v-else :src="recipe.imageUrl" fluid></b-img>
        </b-col>
        <b-col
          ><div
            v-if="state == 'Information'"
            class="form-inline justify-content-between"
          >
            <h1>{{ recipe.title }}</h1>
            <b-button
              v-if="this.$store.state.user.user.id == recipe.userId"
              variant="outline-danger"
              class="col-sm-3"
              size="sm"
              @click="deleteRecipe"
              >Delete recipe</b-button
            >
          </div>

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
            ><b-form-rating
              id="rating-inline"
              inline
              no-border
              size="sm"
              icon-empty="heart"
              icon-half="heart-half"
              icon-full="heart-fill"
              :value="ratingValue.averageRatingValue"
              disabled
            ></b-form-rating>
            {{ ratingValue.numberOfRatings }} ratings |
            {{ recipe.prepTime }} minutes | {{ recipe.serves }} persons |
            {{ recipe.kcal }} kcal
          </small>
          <b-container fluid v-else>
            <b-row>
              <b-col sm="2"
                ><b-form-input
                  v-model.number="dataRecipe.prepTime"
                  size="sm"
                  type="number"
                ></b-form-input
              ></b-col>
              <b-col sm="8"><label>minutes</label></b-col>
            </b-row>
            <b-row>
              <b-col sm="2"
                ><b-form-input
                  v-model.number="dataRecipe.serves"
                  size="sm"
                  type="number"
                ></b-form-input
              ></b-col>
              <b-col sm="8"><label>persons</label></b-col>
            </b-row>
            <b-row>
              <b-col sm="2"
                ><b-form-input
                  v-model.number="dataRecipe.kcal"
                  size="sm"
                  type="number"
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

          <label
            for="rating-lg-no-border"
            class="mt-3"
            v-if="state == 'Information'"
            >Rate this recipe:</label
          >
          <b-form-rating
            v-if="state == 'Information' && personalRating != null"
            disabled
            id="rating-lg-no-border"
            icon-empty="heart"
            icon-half="heart-half"
            icon-full="heart-fill"
            variant="danger"
            no-border
            size="lg"
            style="display: inherit !important; text-align: inherit !important"
            v-model="personalRating.value"
          ></b-form-rating>
          <b-form-rating
            v-if="state == 'Information' && personalRating == null"
            id="rating-lg-no-border"
            icon-empty="heart"
            icon-half="heart-half"
            icon-full="heart-fill"
            variant="danger"
            no-border
            size="lg"
            style="display: inherit !important; text-align: inherit !important"
            v-model="rating.value"
            @change="addRating"
          ></b-form-rating>
        </b-col>
      </b-row>
      <b-row>
        <b-col>
          <b-row
            ><b-col style="padding-top:0 !important"
              ><h4>Ingredients</h4></b-col
            >
            <b-col
              style="padding-top:0 !important"
              v-if="state == 'Information'"
              ><b-input-group>
                <template #append>
                  <b-button @click="addPerson">+</b-button>
                  <b-button
                    @click="subtractPerson"
                    :disabled="dataRecipe.serves == 1"
                    >-</b-button
                  >
                </template>
                <b-form-input
                  disabled
                  :placeholder="dataRecipe.serves + ' persons'"
                ></b-form-input> </b-input-group
            ></b-col>
          </b-row>
          <hr />
          <b-form-group>
            <b-form-checkbox
              v-for="(ingredient, index) in recipe.recipeIngredients"
              :key="index"
              >{{ ingredient.amount }} {{ ingredient.unit }}
              {{ ingredient.ingredient.name }}</b-form-checkbox
            >
          </b-form-group>
          <div v-if="state == 'Edit'">
            <b-container fluid class="no-padding">
              <b-row>
                <b-col sm="2" style="padding-right:5px"
                  ><b-form-input
                    size="sm"
                    v-model.number="ingredient.amount"
                    placeholder="Total"
                    type="number"
                    step="0.5"
                  ></b-form-input
                ></b-col>
                <b-col sm="2" style="padding-right:5px"
                  ><b-form-input
                    size="sm"
                    v-model="ingredient.unit"
                    placeholder="Unit"
                  ></b-form-input
                ></b-col>
                <b-col sm="8"
                  ><b-form-input
                    size="sm"
                    v-model="ingredient.ingredient.name"
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
              v-for="(step, index) in recipe.directions"
              :key="index"
              >{{ step.description }}</b-form-checkbox
            >
          </b-form-group>
          <div v-if="state == 'Edit'">
            <b-container fluid class="no-padding">
              <b-row>
                <b-col sm="12"
                  ><b-form-textarea
                    v-model="description"
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
    ratingValue: Object,
    personalRating: Object,
  },
  data() {
    return {
      dataRecipe: { ...this.recipe },
      originalQuantities: this.recipe.recipeIngredients.map((i) => i.amount),
      imageFile: null,
      previewUrl: '',
      ingredient: { amount: null, unit: '', ingredient: { name: '' } },
      description: '',
      rating: {
        recipeId: this.recipe.recipeId,
        userId: this.$store.state.user.user.id,
        value: '',
      },
    };
  },
  methods: {
    changeFile(e) {
      const file = e.target.files[0];
      this.previewUrl = URL.createObjectURL(file);
      this.getBase64EncodingOfImage(file).then((base64) => {
        this.dataRecipe.imageUrl = base64;
      });
    },
    addIngredient: function() {
      this.dataRecipe.recipeIngredients.push(this.ingredient);
      this.ingredient = { amount: null, unit: '', ingredient: { name: '' } };
    },
    addMethodStep: function() {
      this.dataRecipe.directions.push({ description: this.description });
      this.description = '';
    },
    addRecipe: function() {
      this.previewUrl = '';
      this.$store
        .dispatch('recipe/createRecipe', this.dataRecipe)
        .then((response) => {
          this.$router.push({
            name: 'RecipeInformation',
            params: { recipeId: response.recipeId },
          });
        });
    },
    getBase64EncodingOfImage(filename) {
      return new Promise((resolve, reject) => {
        var reader = new FileReader();
        reader.readAsDataURL(filename);
        reader.onload = () => {
          resolve(reader.result);
        };
        reader.onerror = reject;
      });
    },
    addRating() {
      this.$store.dispatch('rating/createRating', this.rating);
    },
    addPerson() {
      this.dataRecipe.serves = this.dataRecipe.serves + 1;
      this.getNewQuantities();
    },
    subtractPerson() {
      this.dataRecipe.serves = this.dataRecipe.serves - 1;
      this.getNewQuantities();
    },
    getNewQuantities() {
      const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', Accept: '*/*' },
        body: JSON.stringify({
          OldNumberOfServes: this.recipe.serves,
          NewNumberOfServes: this.dataRecipe.serves,
          Quantities: this.originalQuantities.map((q) =>
            q === null ? (q = 0) : (q = q)
          ),
        }),
      };

      fetch('http://localhost:7071/api/CalculateQuantities', requestOptions)
        .then((response) => response.json())
        .then((data) =>
          this.dataRecipe.recipeIngredients.forEach((i, index) =>
            data[index] === 0 ? (i.amount = null) : (i.amount = data[index])
          )
        );
    },
    deleteRecipe() {
      this.$store
        .dispatch('recipe/deleteRecipe', this.recipe.recipeId)
        .then(() => {
          this.$router.push({
            name: 'Home',
          });
        });
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

.no-padding {
  padding: 0 0 1rem 0 !important;
}

output#rating-lg-no-border {
  background-color: transparent;
}
</style>
