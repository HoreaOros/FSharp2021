module AccessingSequenceElements

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

// Run with:
//
//      SafeFileHierarchy @"c:\windows" |> Seq.nth 10000;;
// ...slow
//      SafeFileHierarchy @"c:\windows" |> Seq.nth 10000;;
// ...slow again
//
// Cached vesion:
//      let files = SafeFileHierarchy @"c:\windows" |> Seq.cache;;
//      files |> Seq.nth 10000;;
// ...slow
//      files |> Seq.nth 10000;;
// ...fast

// Seq.head:
let firstFile = SafeFileHierarchy @"c:\windows" |> Seq.head

// Seq.last:
let lastFile = SafeFileHierarchy @"c:\windows" |> Seq.last