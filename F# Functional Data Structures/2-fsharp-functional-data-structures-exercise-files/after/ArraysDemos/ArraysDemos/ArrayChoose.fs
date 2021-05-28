module ArrayChoose

// If your ISP uses a DNS which redirects invalid requests, set
// your DNS to 8.8.8.8.

// Version without using Array.choose:
open System
open System.Net

let GetRequests() = 
   let requests =
      [|
         "http://www.google.com"
         "http://www.pluralsight.com"
         "http://99.99.99.99/doesntexist"
      |]

   use wc = new WebClient()

   requests
   |> Array.map (fun url -> 
         try
            wc.DownloadString(url) |> Some
         with
         | _ -> None)
   |> Array.filter (fun s -> s.IsSome)
   |> Array.map (fun s -> s.Value)
   |> Array.iter (fun s -> printfn "Content: %s" (s.Trim().Substring(0, 100)))

// Version using Array.choose:
