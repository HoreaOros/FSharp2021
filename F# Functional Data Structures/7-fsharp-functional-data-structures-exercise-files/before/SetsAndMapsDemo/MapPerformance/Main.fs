module MapPerformance

open System
open System.Diagnostics
open System.Collections.Generic

// Time how long an operation takes in ticks:
let Time f =
   let sw = Stopwatch()
   sw.Start()
   f()
   sw.ElapsedTicks

// Test creation and population of an F# Map:
let TestMapCreate count =
   let ticks = Time (fun () -> 
      let map = {1..count} |> Seq.map (fun x -> x, x * 2) |> Map.ofSeq
      ()
   )
   printfn "         TestMapCreate: %i" ticks

// Test creation and population of an F# dictionary (dict):
let TestDictCreate count =
   let ticks = Time (fun () -> 
      let dictionary = {1..count} |> Seq.map (fun x -> x, x * 2) |> dict
      ()
   )
   printfn "        TestDictCreate: %i" ticks
   
// Test creation and population of a .NET Dictionary:
let TestDictionaryCreate count =
   let ticks = Time (fun () -> 
      let dictionary = Dictionary<int, int>()
      {1..count} 
      |> Seq.map (fun x -> x, x * 2)
      |> Seq.iter (fun kv -> dictionary.Add kv)
      ()
   )
   printfn "  TestDictionaryCreate: %i" ticks

// Test retrieval from an F# Map:
let TestMapRetrieve count =
   let map = {1..count} |> Seq.map (fun x -> x, x * 2) |> Map.ofSeq
   let rnd = System.Random()
   let ticks = Time (fun () -> 
      {1..count} |> Seq.iter (fun _ -> map.[rnd.Next(1, count)] |> ignore)
      ()
   )
   printfn "       TestMapRetrieve: %i" ticks

// Test retrieval from an F# dictionary (dict):
let TestDictRetrieve count =
   let dictionary = {1..count} |> Seq.map (fun x -> x, x * 2) |> dict
   let rnd = System.Random()
   let ticks = Time (fun () -> 
      {1..count} |> Seq.iter (fun _ -> dictionary.[rnd.Next(1, count)] |> ignore)
      ()
   )
   printfn "      TestDictRetrieve: %i" ticks

// Test retrieval from a .NET Dictionary:
let TestDictionaryRetrieve count =
   let dictionary = Dictionary<int, int>()
   {1..count} 
   |> Seq.map (fun x -> x, x * 2)
   |> Seq.iter (fun kv -> dictionary.Add kv)
   let rnd = System.Random()
   let ticks = Time (fun () -> 
      {1..count} |> Seq.iter (fun _ -> dictionary.[rnd.Next(1, count)] |> ignore)
      ()
   )
   printfn "TestDictionaryRetrieve: %i" ticks

[<EntryPoint>]
let main args =
   let n = 100000
   TestMapCreate n
   TestDictCreate n
   TestDictionaryCreate n
   printfn ""
   TestMapRetrieve n
   TestDictRetrieve n
   TestDictionaryRetrieve n

   Console.ReadKey(true) |> ignore
   0