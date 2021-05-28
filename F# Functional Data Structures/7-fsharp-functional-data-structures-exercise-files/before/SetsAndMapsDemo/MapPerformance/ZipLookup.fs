module ZipLookup

open System
open System.IO

type LatLong = { Lat : float; Long : float }

let ZipLookup filePath =
   filePath
   |> File.ReadLines
   |> Seq.map (fun line -> 
      let parts = line.Split([|','|])
      let zip = parts.[0] |> Int32.Parse
      let latLong = 
         { Lat = parts.[1] |> Double.Parse
           Long = parts.[2] |> Double.Parse }
      zip, latLong)
   |> Map.ofSeq