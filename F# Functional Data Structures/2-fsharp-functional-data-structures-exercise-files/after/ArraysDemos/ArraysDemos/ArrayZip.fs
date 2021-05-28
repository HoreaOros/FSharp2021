module ArrayZip

// Array.zip:
//
// Call with
//    ArrayMultiply [|1.1; 2.2; 3.3|] [|0.1; 0.2; 0.3|];;
let ArrayMultiply (arr1 : array<float>) (arr2 : array<float>) =
   Array.zip arr1 arr2
   |> Array.map (fun (x1, x2) -> x1 * x2)
