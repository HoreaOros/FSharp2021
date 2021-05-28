module SetsVocabulary

open System.IO

// Split a string into words.
let re = System.Text.RegularExpressions.Regex("\w+")
let ToWords str = 
   seq {for m in re.Matches(str) -> m.Value}

// Split a named file into words.
let FileWords fileName = 
   fileName
   |> File.ReadLines
   |> Seq.collect ToWords
   |> Seq.map (fun w -> w.ToLowerInvariant())
   |> Seq.filter (fun w -> w.IndexOfAny([|'a'..'z'|]) > -1)
   |> Seq.filter (fun w -> w.IndexOfAny([|'0'..'9'|]) = -1)
   |> Seq.filter (fun w -> w.IndexOfAny([|'_'|]) = -1)

// Get a set of all the words in all the files in a specified directory.
let DirUniqueWords dirName =
   dirName
   |> Directory.EnumerateFiles
   |> Seq.collect FileWords
   |> Set.ofSeq

// The set of words in each of three novels:

// http://www.gutenberg.org/ebooks/search/?query=clarissa
let clarissa = DirUniqueWords @"c:\data\gutenberg\clarissa"
// http://www.gutenberg.org/ebooks/4085
let roderick = DirUniqueWords @"c:\data\gutenberg\RoderickRandom"
// http://www.gutenberg.org/ebooks/6593
let tomJones = DirUniqueWords @"c:\data\gutenberg\TomJones"

// Words in 'Roderick Random' which aren't in 'Clarissa':
let rNotC = Set.difference roderick clarissa
let rNotC2 = roderick - clarissa

// Does a novel contain the word 'abaft'?
roderick.Contains "abaft"
clarissa.Contains "abaft"

// Combined vocabularies of two novels:
let words1748 = Set.union clarissa roderick
let words1748_2 = clarissa + roderick

// Combined vocabularies of a sequence of novels:
let wordsC18th = [clarissa; roderick; tomJones] |> Set.unionMany

// Which words in a common phrase appear in 'Clarissa'?
let fox = Set(["the";"quick";"brown";"fox";"jumps";"over";"a";"lazy";"dog"])
Set.isSubset fox clarissa

// Which word isn't that isn't in Clarissa?
fox - clarissa
