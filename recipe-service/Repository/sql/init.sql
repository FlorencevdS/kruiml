CREATE TABLE recipe (
    id serial PRIMARY KEY NOT NULL,
    title varchar(255),
    description varchar(255),
    likes int,
    prepTime int,
    serves int, 
    kcal int
);

CREATE TABLE ingredient_recipe (
    ingredient_recipe_id serial PRIMARY KEY NOT NULL,
    ingredient_id int NOT NULL,
    recipe_id int NOT NULL,
    FOREIGN KEY (recipe_id) REFERENCES recipe(id)
);
