module SequenceExpressions

// Using mutable values in sequence expressions:
//let seqWithMutable = 
//   seq { 
//      let mutable i = 0
//      while i < 100 do // Error here
//         i <- i + 1
//         yield i
//   }

// Replacing a mutable with a reference value:
let seqWithRef = 
   seq { 
      let i = ref 0
      while !i < 100 do
         yield !i
         i := !i + 1
   }


// Using Directory.EnumerateFiles (fails if any dir has no permission):
open System
open System.IO

let SimpleFileHierarchy startDir = 
   System.IO.Directory.EnumerateFiles(startDir, @"*.*", SearchOption.AllDirectories)

// Permissions-safe file hierarchy traversal:
open System
open System.IO

let rec SafeFileHierarchy startDir =
   let TryEnumerateFiles dir = 
      try 
         System.IO.Directory.EnumerateFiles(startDir)
      with _ -> Seq.empty
   
   let TryEnumerateDirs dir = 
      try 
         System.IO.Directory.EnumerateDirectories(startDir)
      with _ -> Seq.empty

   seq { 
      yield! TryEnumerateFiles startDir
      for dir in TryEnumerateDirs startDir do
         yield! (SafeFileHierarchy dir)
   }

// Call with: SafeFileHierarchy @"c:\windows" |> Seq.truncate 100 |> Array.ofSeq;;