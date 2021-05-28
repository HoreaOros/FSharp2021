module ArrayParallel

open System

let validationPrimes =
   [3; 5; 7; 13; 17; 19; 23; 29; 31; 37; 41; 43] // Misses 11 deliberately

let Valid (candidate : string) =
   let len = candidate.Length
   let body = candidate.ToString().Substring(0, len-1)
   let checkDigit = candidate.ToString().Substring(len-1, 1) |> Int32.Parse

   let total = 
      body
      |> Seq.zip validationPrimes
      |> Seq.sumBy (fun (p, c) ->
         let n = Int32.Parse(c.ToString()) 
         n * p)
   let checksumCalc = total % 11 % 10
   checksumCalc = checkDigit
