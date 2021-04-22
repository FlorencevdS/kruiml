CREATE TABLE recipe (
    id serial PRIMARY KEY NOT NULL,
    title varchar(255),
    description varchar(255),
    likes int,
    prepTime int,
    serves int, 
    kcal int
);
