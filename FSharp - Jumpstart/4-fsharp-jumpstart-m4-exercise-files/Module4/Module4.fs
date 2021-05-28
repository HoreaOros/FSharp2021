#if INTERACTIVE
#else
module Module4
#endif

// Record types:

type Person =
   {
      FirstName : string
      LastName : string
   }

let person = { FirstName = "Kit"; LastName = "Eason" }

printfn "%s, %s" person.LastName person.FirstName

let person2 = { person with FirstName = "Christian" }
let person3 = { FirstName = "Kit"; LastName = "Eason" }

// "Structural" (content) equality:
printfn "%b" (person = person3) // true
printfn "%b" (person = person2 )// false

// Option types:
type Company = 
   {
      Name : string
      SalesTaxNumber : int option
   }

let company = { Name = "Kit Enterprises"; SalesTaxNumber = None }
let company2 = { Name = "Acme Systems"; SalesTaxNumber = Some 12345 }

// Pattern matching on option types:
let PrintCompany (company : Company) =

   let taxNumberString = 
      match company.SalesTaxNumber with
      | Some n -> sprintf " [%i]" n
      | None -> ""
   
   printfn "%s%s" company.Name taxNumberString

printfn "%i" company.SalesTaxNumber.Value // NullReferenceException

// Discriminated unions:
type Shape =
  | Square of float
  | Rectangle of float * float
  | Circle of float

let s = Square 3.4
let r = Rectangle(2.2, 1.9)
let c = Circle(1.0)

let drawing = [|s; r; c|]

// Pattern matching on Discriminated Unions:
let Area (shape : Shape) =
   match shape with
   | Square x -> x * x
   | Rectangle(h, w) -> h * w
   | Circle r -> System.Math.PI * r * r

let total = drawing |> Array.sumBy (fun s -> Area s) 
let total2 = drawing |> Array.sumBy Area

// Pattern matching on arrays:
let one = [|50|]
let two = [|60; 61|]
let many = [|0..99|]

let Describe arr = 
   match arr with
   | [|x|] -> sprintf "One element: %i" x
   | [|x; y|] -> sprintf "Two elements: %i, %i" x y
   | _ -> sprintf "A longer array"

printfn "%s" (Describe one)
printfn "%s" (Describe two)
printfn "%s" (Describe many)


printfn "%s" <| Describe one
printfn "%s" <| Describe two
printfn "%s" <| Describe many