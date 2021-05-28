module XMLTypeProvider

open FSharp.Data
 
// Download data from http://tinyurl.com/bnbserials -- choose the link called 'BNB LOD Serials | 2014-06 | 33,769 KB | rdfxml'

open FSharp.Data
open System

type Serials = XmlProvider<"""c:\Data\BNBLODSerials_201405_rdf\BNBLODS_201405_f06.rdf""">

let serials = Serials.Load("""c:\Data\BNBLODSerials_201405_rdf\BNBLODS_201405_f03.rdf""")

let FindByTitle (searchTitle : string) =
   let searchTitle = searchTitle.ToUpper()
   serials.Descriptions
   |> Array.choose (fun desc -> desc.Title)
   |> Array.filter (fun title -> title.ToUpper().Contains searchTitle)

let Frequencies() =
   serials.Descriptions
   |> Array.choose (fun desc -> desc.P065) // Type provider bug - should be P1065!
   |> Array.map (fun freq -> freq.Value)
   |> Seq.distinct
   |> Array.ofSeq

[<EntryPoint>]
let main args =
   if args.Length = 1 then
      let hits = FindByTitle args.[0]
      hits |> Array.iter (printfn "%s")
   else
      printfn "Please specify a search term."
   Console.ReadKey(true) |> ignore
   0