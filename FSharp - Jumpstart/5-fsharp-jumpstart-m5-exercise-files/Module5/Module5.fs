#if INTERACTIVE
#else
module Module5
#endif

// Immutability:
let ImmutabilityDemo() = 
   let x = 42
   // x <- 43 // "This value is not mutable"
   x

// Shadowing:
let ImmutabilityDemo2() = 
   let x = 42
   // Binds a *new* value called x:
   let x = 43
   x

// Shadowing in an inner scope:
let ImmutabilityDemo3() = 
   let x = 42
   printfn "x: %i" x
   if 1 = 1 then
      // Binds a *new* value called x:
      let x = x + 1
      printfn "x: %i" x
   // The original x is back in scope!:
   printfn "x: %i" x

// Prime (') notation:
let ImmutabilityDemo4() = 
   let x = 42
   printfn "x: %i" x
   if 1 = 1 then
      let x' = x + 1
      // We can still see the original x:
      printfn "x': %i x: %i" x' x
   printfn "x: %i" x

// Mutability:
let MutabilityDemo() = 
   let mutable x = 42
   printfn "x: %i" x
   x <- x + 1
   printfn "x: %i" x

// Reference cells: 
// (Very rarely necessary from F# 4.0 on.)
let RefCellDemo() =
   let x = ref 42
   x := 43
   printfn "x: %i" !x

// Using reference cells for mutation when 
// mutables are forbidden.
// (Very rarely necessary from F# 4.0 on.)
let PrintLines() =
    seq {
        let finished = ref false 
        while not !finished do   
            match System.Console.ReadLine() with
            | null -> finished := true
            | s -> yield s
        }
