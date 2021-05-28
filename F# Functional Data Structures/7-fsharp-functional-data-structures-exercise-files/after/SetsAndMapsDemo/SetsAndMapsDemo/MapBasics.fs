module MapBasics

// Create a map using a Map.of... function:
let elements = 
   [
      "Hydrogen", 1
      "Helium", 2
      "Lithium", 3
      "Beryllium", 4
      "Boron", 5
      "Carbon", 6
      "Nitrogen", 7
      "Oxygen", 8
      "Fluorine", 9
      "Neon", 10
   ] |> Map.ofList

// Create a map using the Map constructor:
let elements2 = 
   Map([
         "Hydrogen", 1
         "Helium", 2
         "Lithium", 3
         "Beryllium", 4
         "Boron", 5
         "Carbon", 6
         "Nitrogen", 7
         "Oxygen", 8
         "Fluorine", 9
         "Neon", 10
      ])

// Use array-like syntax to access an element by key:
elements.["Lithium"]

// Add a new key-value pair, returning a new Map:
let elements' = elements.Add("Ununoctium", 118)

// Use array-like syntax to access the new element by key:
elements'.["Ununoctium"]
