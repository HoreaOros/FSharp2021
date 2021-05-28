module SearchingWithinSequences

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

// Seq.find:
let longFileName =
   SafeFileHierarchy @"c:\windows"
   |> Seq.find (fun name -> name.Length > 200)

// Seq.tryFind:
let longFileName2 =
   SafeFileHierarchy @"c:\temp"
   |> Seq.tryFind (fun name -> name.Length > 200)

// Seq.pick:
open System
open System.Net

let randomRealUrl() = 
   let rnd = System.Random()

   let RandomUrl len = 
      let RandAlpha() = rnd.Next(int('a'), int('z') + 1) |> char
      let randChars = Array.init len (fun _ -> RandAlpha())
      let randString = new String(randChars)
      sprintf "http://www.%s.com" randString

   let urls = Seq.initInfinite (fun _ -> RandomUrl 5)
   use wc = new WebClient()
   urls |> Seq.pick (fun url -> 
              try 
                 printfn "Trying %s" url
                 wc.DownloadString(url) |> ignore
                 url |> Some
              with _ -> None)

// Seq.findIndex:
let StepsToPrime() = 
   let rnd = new Random()
   let IsPrime n =
      let rec check i =
         i > n/2 || (n % i <> 0 && check (i + 1))
      check 2
   let numbers = Seq.initInfinite (fun _ -> rnd.Next())
   let steps = 
      numbers 
      |> Seq.findIndex (fun n -> 
         printfn "Trying %i" n
         IsPrime n)
   steps+1

// Seq.exists:
let ContainsPrime numbers = 
   let IsPrime n =
      let rec check i =
         i > n/2 || (n % i <> 0 && check (i + 1))
      check 2
   numbers
   |> Seq.exists (fun n -> IsPrime n) 
   // Seq.exists IsPrime

let TestContainsPrime() =
   let rnd = new Random()
   let numbers = [|8; 9; 12; 13|]
   ContainsPrime numbers

// Seq.choose:
open System
open System.IO

let LengthClass length = 
   if length < 1024L then "Small"
   else if length < 1024L * 1024L then "Medium"
   else "Large"

let FileSizeGroups dirName = 
   dirName
   |> System.IO.Directory.EnumerateFiles
   |> Seq.map (fun name -> 
         let info = new FileInfo(name)
         name, info.Length)
   |> Seq.groupBy (fun (name, length) -> LengthClass length)
