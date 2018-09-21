
Insert into ItemTypes
(ItemTypeName)
values
('Salad'),
('Sandwich');

Insert into IngredientTypes
(IngredientTypeName)
values
('Bread'),
('Cheese'),
('Condiment'),
('Dressing'),
('Extras'),
('Lettuce'),
('Meat'),
('Veggies');

insert into Ingredients
(IngredientTypeId, IngredientName, SaladIngredient, SandwichIngredient, Selected)
values
(1,'Ciabatta',0,1,0),
(1,'Flatbread',0,1,0),
(1,'French',0,1,0),
(1,'Rye',0,1,0),
(1,'Sourdough',0,1,0),
(1,'Wheat',0,1,0),
(2,'Provolone',0,1,0),
(2,'GoatCheese',1,1,0),
(2,'Havarti',1,1,0),
(2,'Swiss',0,1,0),
(2,'SharpCheddar',1,1,0),
(2,'PepperaJack',1,1,0),
(3,'AvocadoMayo',0,1,0),
(3,'DijonMustard',0,1,0),
(3,'HoneyMustard',0,1,0),
(3,'Mayo',0,1,0),
(4,'Asian',1,0,0),
(4,'AvocadoRanch',1,0,0),
(4,'BlueCheese',1,0,0),
(4,'French',1,0,0),
(4,'HoneyMustard',1,0,0),
(4,'Itilian',1,0,0),
(4,'Ranch',1,0,0),
(5,'Croutons',1,0,0),
(5,'Walnuts',1,0,0),
(6,'Butterhead',1,0,0),
(6,'Iceburg',1,0,0),
(6,'PowerGreens',1,0,0),
(6,'Romaine',1,0,0),
(7,'Bacon',1,1,0),
(7,'Chicken',1,1,0),
(7,'Ham',1,1,0),
(7,'Pancetta',0,1,0),
(7,'Pepperoni',0,1,0),
(7,'Prosuitto',0,1,0),
(7,'RoastBeef',0,1,0),
(7,'Salami',0,1,0),
(7,'Turkey',1,1,0),
(8,'Avocado',1,1,0),
(8,'Cucumbers',1,0,0),
(8,'Onions',1,1,0),
(8,'Peppers',1,1,0),
(8,'Tomatoes',1,1,0),
(8,'Lettuce',0,1,0);






