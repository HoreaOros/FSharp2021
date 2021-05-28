module ArrayFold

// Array.fold:
//
// Call with
//    PrintRow "|" [|"Value 1"; "Value 2"; "Value 3"|];;
open System

let PrintRow (separator: string) (arr: array<string>) =
   arr
   |> Array.fold (fun acc elem -> sprintf "%s%s%s" acc elem separator) separator
