module SeqPairwiseWindowedCollect

// Seq.pairwise:
let routeHeights = [| 552; 398; 402; 399; 481; 512; 392; 350 |]

let TotalClimb heights =   
   heights
   |> Seq.pairwise
   |> Seq.filter (fun (a, b) -> b > a)
   |> Seq.map (fun (a, b) -> b - a)
   |> Seq.sum

// Call with: TotalClimb routeHeights;;

// Seq.windowed:
let Peaks heights =
   heights
   |> Seq.windowed 3
   |> Seq.choose (fun triplet -> 
         match triplet with
         | [| a; b; c |] when b > a && b > c -> Some b
         | _ -> None)

// Call with:  Peaks routeHeights;;

// Seq.collect:
open System
open System.Text.RegularExpressions
open System.Net

let UniqueWords() = 
   let urls = 
      [| "http://www.google.com"
         "http://www.pluralsight.com"
         "http://www.amazon.com" |]

   let Words(s : string) = 
      let re = new Regex(@"\b[a-z]+\b")
      let words = re.Matches(s)
      words
      |> Seq.cast
      |> Seq.map (fun w -> w.ToString())

   use wc = new WebClient()
   urls
   |> Seq.choose (fun url -> 
         try 
            wc.DownloadString(url) |> Some
         with _ -> None)
   |> Seq.collect Words
   |> Seq.distinct
   |> Seq.sort
   |> Seq.iter (fun w -> printfn "%s" w)
