module Dictionaries

open System.Collections.Generic

// Basic dictionary operations

type LatLong = { Lat : double; Long : float }

// Creating a dictionary:
let zipLocations = Dictionary<int, LatLong>()

// Adding items using add:
zipLocations.Add(11373, {Lat = 40.72; Long = -73.87})
zipLocations.Add(11374, {Lat = 40.72; Long = -73.86})

// Adding items using indexed assignment:
zipLocations.[11375] <- {Lat = 40.72; Long = -73.84}
zipLocations.[11377] <- {Lat = 40.74; Long = -73.9}

// Retrieving items:
printfn "%A" zipLocations.[11377]

// Updating items using assignment:
zipLocations.[11377] <- {Lat = 40.75; Long = -74.2}
printfn "%A" zipLocations.[11377]

// Adding a duplicate key/value (causes an exception):
zipLocations.Add(11374, {Lat = 40.72; Long = -73.86})

// Iterating over the dictionary by treating it as a sequence:
zipLocations
|> Seq.iter (fun kvp -> 
   printfn "%i %f %f" kvp.Key kvp.Value.Lat kvp.Value.Long)

// Iterating over the keys as a sequence:
zipLocations.Keys
|> Seq.iter (fun key -> printfn "%i" key)

// Iterating over the values as a sequence:
zipLocations.Values
|> Seq.iter (fun value -> printfn "%f %f" value.Lat value.Long)



