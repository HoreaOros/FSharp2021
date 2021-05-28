module CreatingSequences

// From a range:
let integersRange = {1..1000}

// From a sequence expression:
let integersExpression = 
   seq { 
      for i in 1..1000 do
         yield i
   }

// From a sequence expression (short form):
let integersExpression2 = 
   seq { 
      for i in 1..1000 -> i
   }

// Using Seq.init:
let integers = Seq.init 1000 (fun i -> i + 1)

// Using Seq.initInfinite:
let integers2 = Seq.initInfinite (fun i -> i + 1)