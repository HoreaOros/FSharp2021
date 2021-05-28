module CollectionsAsSequences

// Treating an array as a sequence:
let array = [|1..1000|]

let evens =
   array
   |> Seq.filter (fun i -> i%2 = 0)
