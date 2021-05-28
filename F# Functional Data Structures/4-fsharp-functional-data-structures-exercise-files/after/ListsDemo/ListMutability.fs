module ListMutability

let list = [0..10]
// Can't do this:
// list <- [1..11]
// Can't do this:
// list.[3] <- 999

let mutable mutableList = [0..10]
mutableList <- [1..11]
// Still can't do this:
// mutableList.[3] <- 999

// Mutation of List element properties:
type MutableThing = { mutable Name : string }

let thingList = 
   [{Name="Thing 0"}; {Name="Thing 1"}]

printfn "%A" thingList.[1]
thingList.[1].Name <- "Thing 1 was changed"
printfn "%A" thingList.[1]
