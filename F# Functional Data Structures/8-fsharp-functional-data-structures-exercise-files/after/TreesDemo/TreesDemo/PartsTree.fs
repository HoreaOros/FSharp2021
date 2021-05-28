module PartsTree

open System

// A record type for describing a part:
type Description = 
   { Name : string; 
     PartNumber : string; 
     Cost : decimal option }

// A tree of parts, some individual, some repeated, and some made up
// of other parts:
type Part = 
   | Item of Description
   | Repeat of Part * int
   | Compound of Description * Part list

// Some individual parts:
let pad = Item { Name = "Brake Pad"; PartNumber = "B12345"; Cost = Some 15.90M }
let calliperBody = Item { Name = "calliper Body"; PartNumber = "C456780"; Cost = Some 40.95M }
let brakePiston = Item { Name = "Bake calliper piston"; PartNumber = "P99669"; Cost = Some 25.00M }
let disc = Item { Name = "Disc"; PartNumber = "D56789"; Cost = Some 45.48M }
let clip = Item { Name = "Clip"; PartNumber = "P89792"; Cost = Some 10.00M }
let pin = Item { Name = "Pin"; PartNumber = "N13452"; Cost = Some 2.50M }

// A compound part, containing an individual part and a repeated part:
let calliper = 
   Compound (
      {Name = "Calliper"; PartNumber = "R124C41"; Cost = None},
      [calliperBody; Repeat(brakePiston, 2)] )

// A compound part, including another compound part:
let brake = 
   Compound (
      {Name = "Brake"; PartNumber = "THX1138"; Cost = None},
      [disc; calliper; Repeat(pin, 2); Repeat(pad, 2); clip]
   )

// Take a part tree and turn it into a flat sequence with no hierarchy:
let Flatten (part : Part) = 
   let rec flatten p = 
      seq { 
         match p with
         | Item d -> 
            yield d
         | Repeat(rp, count) -> 
            for _ in 0..count-1 do 
               yield! flatten rp
         | Compound(d, children) -> 
            yield d
            for child in children do
               yield! flatten child
      }
   flatten part

// Calculate the total cost of the parts by flattening it then doing a SumBy:
// (Note weakness in modelling - what if a compound part's cost is not None?)
let TotalCost part  = 
   part
   |> Flatten
   |> Seq.sumBy (fun d -> 
      match d.Cost with
      | Some c -> c
      | None -> 0.0M
   )

// Take a parts tree and indent it by level:
let Indent (part : Part) = 
   let rec indent level count p =
      seq { 
         match p with
         | Item d -> 
            yield level, count, d
         | Repeat(pr, count) -> 
            yield! indent (level+1) count pr
         | Compound(d, children) -> 
            yield level, count, d
            for child in children do
               yield! indent (level+1) 1 child
      }
   indent 0 1 part

// Print a parts tree using indenting:
let Print(part : Part) =
   let printItem (indent : int, count : int, desc : Description) =
      let costStr = match desc.Cost with | Some c -> sprintf "%0.2f" c | None -> "N/A"
      printfn "%s %s %s %s x %i" (String(' ', indent*3)) desc.Name desc.PartNumber costStr count

   part
   |> Indent 
   |> Seq.iter printItem

// Trying out TotalCost:
do
   printfn "Total cost: %f" (TotalCost brake)

// Trying out Indent and printItem:
do
   brake
   |> Flatten
   |> Seq.iter (fun desc -> printfn "%A" desc)
