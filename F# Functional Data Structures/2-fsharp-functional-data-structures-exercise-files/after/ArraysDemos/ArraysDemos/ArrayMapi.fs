module ArrayMapi

// Array.mapi:
open System

let VowelPositions (str : string) =
   let vowels = "aeiouAEIOU"
   str.ToCharArray()
   |> Array.mapi (fun i c -> if vowels.Contains(c.ToString()) then
                                sprintf "Vowel at position %i: %c" i c
                             else
                                "Some other character")
