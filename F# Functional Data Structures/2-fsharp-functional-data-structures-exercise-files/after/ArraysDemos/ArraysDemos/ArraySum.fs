module ArraySum

// If your ISP uses a DNS which redirects invalid requests, set
// your DNS to 8.8.8.8.

// Array.sum:
open System
open System.Net

let GetTotalContentLength() = 
   let requests =
      [|
         "http://www.google.com"
         "http://www.pluralsight.com"
         "http://99.99.99.99/doesntexist"
      |]

   use wc = new WebClient()

   requests
   |> Array.choose (fun url -> 
         try
            wc.DownloadString(url) |> Some
         with
         | _ -> None)
   |> Array.map (fun str -> str.Length)
   |> Array.sum

// Array.sumBy:
open System
open System.Net

let GetTotalContentLength2() = 
   let requests =
      [|
         "http://www.google.com"
         "http://www.pluralsight.com"
         "http://99.99.99.99/doesntexist"
      |]

   use wc = new WebClient()

   requests
   |> Array.choose (fun url -> 
         try
            wc.DownloadString(url) |> Some
         with
         | _ -> None)
   |> Array.sumBy (fun str -> str.Length)
