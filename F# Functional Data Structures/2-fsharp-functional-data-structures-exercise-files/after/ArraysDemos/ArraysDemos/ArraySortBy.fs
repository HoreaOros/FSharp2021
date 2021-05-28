module ArraySort

// If your ISP uses a DNS which redirects invalid requests, set
// your DNS to 8.8.8.8.

// Array.sortBy:
open System
open System.Net

let GetUrlsByLength() = 
   let requests =
      [|
         "http://www.google.com"
         "http://www.pluralsight.com"
         "http://99.99.99.99/doesntexist"
         "http://www.bbc.co.uk"
         "http://www.amazon.com"
         "http://www.bing.com"
      |]

   use wc = new WebClient()

   requests
   |> Array.choose (fun url -> 
         try
            (url, wc.DownloadString(url).Length) |> Some
         with
         | _ -> None)
   |> Array.sortBy (fun (url, length) -> -length)
