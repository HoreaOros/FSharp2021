module ListModule

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
   
// Using List.filter:
let TempFiles startDir =
   startDir
   |> SafeFileHierarchy
   |> List.filter (fun path ->
      System.IO.Path.GetExtension(path) = ".tmp")
