module SetsBasics

// Create a set using the Set constructor:
let animals = Set(["Aardvark"; "Bushbaby"; "Opossum"])

// Create a set using a Set.of... function:
let animals2 = ["Aardvark"; "Bushbaby"; "Opossum"] |> Set.ofList

// Adding an element to a set:
let animals' = animals.Add("Brown Bear")

// Adding a duplicate element to a set (ignored):
let animals'' = animals'.Add("Bushbaby")