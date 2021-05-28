module FileExistsChecker

open System.Security.Cryptography
open System.IO

let FileMD5 filePath =
   use md5 = MD5.Create()
   use stream = File.OpenRead(filePath)
   md5.ComputeHash(stream)

type FileExistsChecker(dirPath : string) =
   let md5dict =
      dirPath
      |> Directory.EnumerateFiles
      |> Seq.map (fun filePath -> FileMD5 filePath, filePath)
      |> dict
   /// If there is a duplicate (by content) of the specified file already in the
   /// path specified on construction, returns the path of that duplicate, otherwise
   /// returns None.
   member this.ExistingFilePath newFilePath =
      let newMD5 = FileMD5 newFilePath
      let ok, value = md5dict.TryGetValue(newMD5)
      if ok then
         value |> Some
      else
         None
