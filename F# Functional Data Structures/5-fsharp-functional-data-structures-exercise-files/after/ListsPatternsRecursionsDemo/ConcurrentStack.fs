module ConcurrentStack

/// A version of SimpleStack with thread safety
/// added using F# lock expressions.
type ConcurrentStack<'T>() =    
    let mutable _stack : List<'T> = []

    member this.Push value =
      lock _stack (fun () -> 
         _stack <- value :: _stack)

    member this.Pop() =
      lock _stack (fun () ->
         match _stack with
         | result :: remainder ->
            _stack <- remainder
            result
         | [] -> failwith "Empty stack"
      )

    member this.TryPop() =
      lock _stack (fun () ->
         match _stack with
         | result :: newStack ->
            _stack <- newStack
            result |> Some
         | [] -> None
      )

    member this.Swap() =
      lock _stack (fun () ->
         match _stack with
         | a::b::tail -> _stack <- b::a::tail
         | _ -> failwith "Stack does not have enough elements"
      )
