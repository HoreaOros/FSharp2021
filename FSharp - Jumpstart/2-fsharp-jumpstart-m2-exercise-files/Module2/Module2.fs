#if INTERACTIVE
#else
module Module2
#endif

// Simple binding:
let x = 42
let hi = "Hello"

// Binding a function:
let SayHiTo me =
   printfn "Hi, %s" me
   
let Square x = x * x
   
let Area (height : float) width =
   height * width

// If expressions:
let Greeting name = 
   if System.String.IsNullOrWhiteSpace(name) then
      "whoever you are"
   else
      name

let SayHiTo2 me =
   printfn "Hi, %s" (Greeting me)
   
// For loops:
let PrintNumbers min max =
   for x in min..max do
      printfn "%i" x

let PrintNumbers2 min max =
   let square x =
      x * x
   for x in min..max do
      printfn "%i %i" x (square x)

// Returning tuples:
let RandomPosition() =
   let r = new System.Random()
   r.NextDouble(), r.NextDouble()

let latitude, longitude = RandomPosition()
let treasure = RandomPosition()

// Tupled arguments in external functions:
open System.IO

let files = Directory.EnumerateFiles(@"c:\windows", "*.exe")
//files |> Seq.iter (fun item -> printfn "%s" item)

// Partial application:
let a = Area 5.

// 'a' at this point is a function which takes one argument.
let b = a 6.






