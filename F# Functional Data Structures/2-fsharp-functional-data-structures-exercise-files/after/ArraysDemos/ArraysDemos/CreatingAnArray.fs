module ArraysDemos

// From a literal:
let primes = [|1; 3; 5; 7; 11|]

// From a literal on separate lines:
let animals =
   [|
      "cat"
      "dog"
      "zebra"
   |]

// From a range:
let someNumbers = [|1000..1020|]

// From a range with an interval:
let someNumbersThrees = [|1000..3..1020|]

// From a range (floating point):
let someNumbersFloats = [|1000.0 .. 3.3 .. 1020.0|]

// From a loop:
let smallEvens = [|for i in 1..100 do if i%2 = 0 then yield i|]

// More logic within the array clamps:
open System

let lastDays year =
   [|
      for i in 1..12 do
         let firstDay = DateTime(year, i, 1)
         let lastDay = firstDay.AddDays(float(DateTime.DaysInMonth(year, i)-1))
         yield lastDay
   |]

// With Array.create:
let notUseful = Array.create 100 3.3

// With Array.zeroCreate:
let emptyStrings : string[] = Array.zeroCreate 100

// With Array.init:
let lastDays2 year =
   Array.init 12 (fun i ->
      let month = i+1
      let firstDay = DateTime(year, month, 1)
      let lastDay = firstDay.AddDays(float(DateTime.DaysInMonth(year, month)-1))
      lastDay
   )

// From an IEnumerable:
let files = System.IO.Directory.EnumerateFiles(@"c:\Windows")
            |> Array.ofSeq
