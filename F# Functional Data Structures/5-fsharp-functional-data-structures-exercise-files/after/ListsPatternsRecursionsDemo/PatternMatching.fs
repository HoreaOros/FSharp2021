module PatternMatching

open System

// Match statement as a simple case statement:
let BingoName (x : int) =
   match x with
   | 1 -> "Kelly's Eye"
   | 2 -> "One little duck"
   | 3 -> "Cup of tea"
   // Etc
   | _ -> x.ToString()

// Matching on Option type:
let DescribeOption (x : int Option) =
   match x with 
   | Some n -> sprintf "%i" n
   | None -> "No value"

// Matching on array elements:
let DescribeArray arr =
   match arr with
   | [||] -> "Empty array"
   | [|x|] -> sprintf "One value: %A" x
   | [|x;y|] -> sprintf "Pair: %A and %A" x y
   | _ -> sprintf "A larger array"

// Matching on empty list and head+tail:
let DescribeList list =
   match list with
   | [] -> "Empty list"
   | head::tail -> sprintf "List beginning %A with %i more elements" head (tail.Length)
