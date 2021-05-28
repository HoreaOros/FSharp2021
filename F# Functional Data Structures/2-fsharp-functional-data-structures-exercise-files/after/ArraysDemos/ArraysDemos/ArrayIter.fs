module ArrayIter

// Array.iteri:
open System

let VowelPositions (str : string) =
   let vowels = "aeiouAEIOU"
   str.ToCharArray()
   |> Array.iteri (fun i c -> if vowels.Contains(c.ToString()) then
                                 printfn "Vowel at position %i: %c" i c)
