// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

let SayHello() =
    printfn "Hello"

[<EntryPoint>]
let main argv = 
    SayHello()
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
