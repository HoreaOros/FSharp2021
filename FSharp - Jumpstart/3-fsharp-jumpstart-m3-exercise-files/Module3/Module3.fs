#if INTERACTIVE
#else
module Module3
#endif

// Array literals:
let arr = [|1; 2; 4|]

let fruits =
   [|
      "apple"
      "orange"
      "pear"
   |]

// Array from range:
let numbers = [|0..99|]

// Array from code:
let squares = [| for i in 0..99 do yield i * i |]

let RandomFruits count =
   let r = System.Random()
   let fruits = [| "apple"; "orange"; "pear" |]
   [|
      for i in 1..count do
         let index = r.Next(3)
         yield fruits.[index]
   |]

// Array.init:
let RandomFruits2 count =
   let r = System.Random()
   let fruits = [| "apple"; "orange"; "pear" |]
   Array.init count (fun _ ->
      let index = r.Next(3)
      fruits.[index]
   )

// Array element access:
let fruits2 = RandomFruits2 10
let first = fruits2.[0]
let last = fruits2.[9]  

// Iterating over an array:
let LikeSomeFruit fruits =
   for fruit in fruits do
      printfn "I like %s" fruit

// Array.filter:
let squares2 =  
   [|
      for i in 0..99 do
         yield i * i
   |]

let IsEven n = 
   n % 2 = 0

//let evenSquares = Array.filter (fun x -> IsEven x) squares2
let evenSquares = squares2 |> Array.filter IsEven

// Array.sort:

let sortedFruit = Array.sort [|"pear"; "orange"; "apple" |]

// Array.iter:
let LikeSomeFruit2 fruit = 
   Array.iter (fun fruit -> printfn "I like %s" fruit)

// Without forward pipe:
let PrintLongWords (words : string[]) =
   let longWords : string[] = Array.filter (fun w -> w.Length > 8) words
   let sortedLongWords = Array.sort longWords
   Array.iter (fun w -> printfn "%s" w) sortedLongWords

// With forward pipe:
let PrintLongWords2 (words : string[]) =
   words
   |> Array.filter (fun w -> w.Length > 8)
   |> Array.sort
   |> Array.iter (fun w -> printfn "%s" w)

// Array.map:
let PrintSquares min max =
    let square n =
        n*n
    [|min..max|]
    |> Array.map (fun i -> square i)
    |> Array.iter (fun i -> printfn "%i" i)

// Array.map (more concise):
let PrintSquares2 min max =
    let square n =
        n*n
    [|min..max|]
    |> Array.map square
    |> Array.iter (printfn "%i")

// Array element mutation:
let arr2 = [|0..9|]
arr2.[3] <- 99

// List creation and List.map:
let PrintSquaresUsingList min max =
    let square n =
        n*n
    [min..max]
    |> List.map square
    |> List.iter (printfn "%i")

// Sequence creation:

let smallNumbers = {0..99}

let smallNumbers2 = 
   Seq.init 100 (fun i -> i)

let smallNumbers3 = 
    seq {
        for i in 0..99 do
            yield i    
    }

// Sequences from external calls:

open System.IO

let bigFiles =
   Directory.EnumerateFiles(@"c:\windows")
   |> Seq.map (fun name -> FileInfo name)
   |> Seq.filter (fun fi -> fi.Length > 1000000L)
   |> Seq.map (fun fi -> fi.Name)





 
