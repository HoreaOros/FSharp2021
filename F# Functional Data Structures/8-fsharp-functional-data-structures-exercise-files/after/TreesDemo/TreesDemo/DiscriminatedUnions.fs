module DiscriminatedUnions

// A Discriminated Union modelling a few geometric shapes:
type Shape =
    | Rectangle of width : float * length : float
    | Circle of radius : float
    // This is the formal name of a 'running track' shape!
    | Stadium of straight : float * radius : float

// Creating Shape instances using DU case labels and named fields:
let tennisCourt = Rectangle(width=23.78, length=10.97)
let hammerThrowingArea = Circle(radius=2.135)
let althleticsTrack = Stadium(straight=84.39, radius=36.5)

// F# 3.0 and before - no field labels:
//type Shape30 =
//    | Rectangle of float * float
//    | Circle of float
//    | Stadium of float * float

// Creating Shape instances using DU case labels and tupled arguments for fields:
//let tennisCourt = Rectangle(23.78, 10.97)
//let hammerThrowingArea = Circle(2.135)
//let althleticsTrack = Stadium(84.39, 36.5)

// Creating a list of Shape instances:
let sportingEvent = [tennisCourt; hammerThrowingArea; althleticsTrack]

// Using pattern matching to identify DU cases and recover field values:
let PrintShapes event =
   event
   |> Seq.iter (fun item ->
         match item with
         | Rectangle(w, h) -> printfn "Rectangle: %f x %f" w h
         | Circle(r) -> printfn "Circle: radius %f" r
         | Stadium(s,r) -> printfn "Stadium: straights: %f radius: %f" s r)