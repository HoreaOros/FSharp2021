module dict

type LatLong = { Lat : double; Long : float }

let zipLocations =
   [
      11373, {Lat = 40.72; Long = -73.87}
      11374, {Lat = 40.72; Long = -73.86}
      11375, {Lat = 40.72; Long = -73.84}
      11377, {Lat = 40.74; Long = -73.9}
   ] |> dict

printfn "%A" zipLocations.[11374]