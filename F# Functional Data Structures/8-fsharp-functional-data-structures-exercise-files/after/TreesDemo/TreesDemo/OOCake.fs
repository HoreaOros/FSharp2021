module OOCake

// A recursive OO type to model a cake:
type FoodStuff(name : string, allergenic : bool, ingredients : FoodStuff list) =
   member this.Name = name
   member this.Allergenic = allergenic
   member this.Ingredients = ingredients
   
// Constructing a cake instance:
let cake =
   FoodStuff("cake", false,
      [
         FoodStuff("flour", false, []) // Arguably true: gluten
         FoodStuff("eggs", false, [])
         FoodStuff("mixed fruit", false, 
            [
               FoodStuff("raisins", false, [])
               FoodStuff("saltanas", false, [])
            ])
         FoodStuff("mixed nuts", false, 
            [
               FoodStuff("walnuts", false, [])
               FoodStuff("almonds", false, [])
               FoodStuff("peanuts", true, [])
            ])
      ])

// Return true if any constituent of the cake is flagged as allergenic:
let rec Allergenic (foodStuff : FoodStuff) =
   foodStuff.Allergenic
   || foodStuff.Ingredients |> List.exists Allergenic 