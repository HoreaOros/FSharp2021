module AccessingListElements

open System
open System.Diagnostics

// Performance of indexed access to List elements:
let randomList n = 
   let r = System.Random()
   List.init n (fun _ -> r.Next())
   
let TestList() =
   let bigList = randomList 1000000

   let DoTest i =
      let sw = new Stopwatch()
      sw.Start()
      let firstElement = bigList.[i]
      let ticks = sw.ElapsedTicks
      printfn "Accessing element %i took %i ticks"  i ticks

   [0; 500000; 999999] |> List.iter DoTest

// Performance of indexed access to Array elements:
let randomArray n = 
   let r = System.Random()
   Array.init n (fun _ -> r.Next())
   
let TestArray() =
   let bigArray = randomArray 1000000

   let DoTest i =
      let sw = new Stopwatch()
      sw.Start()
      let firstElement = bigArray.[i]
      let ticks = sw.ElapsedTicks
      printfn "Accessing element %i took %i ticks"  i ticks

   [0; 500000; 999999] |> List.iter DoTest