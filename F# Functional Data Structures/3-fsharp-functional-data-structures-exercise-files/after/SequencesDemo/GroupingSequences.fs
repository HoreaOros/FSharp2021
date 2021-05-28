module GroupingSequences

// Seq.distinct:
open System
open System.IO

let Extensions (dir : string) =
   Directory.EnumerateFiles(dir)
   |> Seq.map (fun name -> Path.GetExtension(name))
   |> Seq.distinct

// Seq.distinctBy:
open System

type Vegetable = 
   { Name : string
     Color : string }

let availableVegetables = 
   [| { Name = "Carrot"
        Color = "orange" }
      { Name = "Peas"
        Color = "green" }
      { Name = "Lettuce"
        Color = "green" }
      { Name = "Beetroot"
        Color = "purple" }
      { Name = "Aubergine"
        Color = "purple" }
      { Name = "Potato"
        Color = "white" }
      { Name = "Swede"
        Color = "orange" }
      { Name = "Turnip"
        Color = "white" }
      { Name = "Cabbage"
        Color = "green" } |]

let Randomize s = 
   let r = new Random()
   s |> Seq.sortBy (fun _ -> r.Next())

let Menu() = 
   availableVegetables
   |> Randomize
   |> Seq.distinctBy (fun v -> v.Color)

// Seq.countBy:
let VegColorCounts() = 
   availableVegetables 
   |> Seq.countBy (fun veg -> veg.Color)
