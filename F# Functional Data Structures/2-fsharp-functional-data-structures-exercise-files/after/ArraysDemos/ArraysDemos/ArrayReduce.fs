module ArrayReduce

// Array.reduce:
//
// Call with 
//   ReduceDemo [|"aaa"; "bbb"; "ccc"|]
open System

let StringJoinWithCommas (arr : array<string>) =
   arr
   |> Array.reduce (fun acc elem -> sprintf "%s, %s" acc elem)

// Array.reduce - reducing with a single operator:
//
// Call with 
//    ReduceDemo [|"aaa"; "bbb"; "ccc"|]
open System

let StringJoinNoSeparator (arr : array<string>) =
   arr
   |> Array.reduce (+)

// Array.reduce - multiple up an array of floats:
//
// Call with
//    Multiply [|1.1; 2.2; 3.3|];;
let Multiply (arr : array<float>) =
   arr 
   |> Array.reduce (*)

// Array.reduce - version safe for empty array:
//
// Call with
//    Multiply [|1.1; 2.2; 3.3|];;
//    Multiply [||];;
let MultiplySafe (arr : array<float>) =
   match arr with
   | [||] -> 0.
   | _  -> arr |> Array.reduce (*)
