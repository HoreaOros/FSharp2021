module Dedupe

open System.Collections.Generic

type LineRec = { Number : int; Key : string; Line : string }

let DedupeKeepLast (lines : seq<string>) =
   let lineDict = new Dictionary<string, int>()

   let records = 
      lines
      |> Seq.mapi (fun i line -> 
         { Number = i; Key = line.Split([|','|]).[0]; Line = line })

   records
   |> Seq.iter (fun record -> 
         lineDict.[record.Key] <- record.Number)

   records
   |> Seq.choose (fun record -> 
      if record.Number = lineDict.[record.Key] then 
         Some(record.Line) 
      else None)

let TestDedupeKeepLast() =
   [
      "49452,79.4,80.0"
      "49446,72.3,74.4"
      "49448,74.5,77.3"
      "49452,79.5,80.1"
      "49449,71.8,73.4"
      "49450,69.3,71.0"
      "49451,71.2,74.3"
      "49452,79.4,80.2"
      "49453,77.1,79.7"
      "49448,73.2,76.9"
      "49452,79.3,80.1"
   ]
   |> DedupeKeepLast 
   |> Seq.iter (fun lineRec -> printfn "%A" lineRec)
