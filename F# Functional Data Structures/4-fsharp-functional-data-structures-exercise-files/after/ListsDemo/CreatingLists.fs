module CreatingLists

// Creating a list from a Seq.unfold:
let myUnfoldList =
   Seq.unfold (fun state -> 
      if state > 100 then None
      else Some(state, state+1)
   ) 0 |> List.ofSeq

// Creating a list from a recursive List expression:
let rec myListRecursive n =
   [
      if n < 100 then
         yield n
         yield! (myListRecursive (n+1))
   ]

// SafeFileHierarchy using a List expression:
let rec SafeFileHierarchy startDir = 
   let TryEnumerateFiles dir = 
      try 
         System.IO.Directory.EnumerateFiles(startDir)
      with _ -> Seq.empty
   
   let TryEnumerateDirs dir = 
      try 
         System.IO.Directory.EnumerateDirectories(startDir)
      with _ -> Seq.empty
   
   [ 
      yield! TryEnumerateFiles startDir
      for dir in TryEnumerateDirs startDir do
         yield! (SafeFileHierarchy dir)
   ]
