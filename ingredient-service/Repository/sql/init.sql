CREATE TABLE ingredient (
    id serial PRIMARY KEY NOT NULL,
    name varchar(255)
);

CREATE TABLE recipe_ingredient (
    recipe_ingredient_id serial PRIMARY KEY NOT NULL,
    ingredient_id int NOT NULL,
    recipe_id int NOT NULL,
    FOREIGN KEY (ingredient_id) REFERENCES ingredient(id)
);
