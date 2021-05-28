module SimpleStack

/// A stack using an F# list for storage, and pattern 
/// matching for pushing/popping elements.
///
/// Not thread-safe!
///
type SimpleStack<'T>() =  
    let mutable _stack : List<'T> = []

    member this.Push value =
      _stack <- value :: _stack

    member this.PopWithWarning value =
      let result::remainder = _stack
      _stack <- remainder
      result

    member this.PopImperative value =
      if _stack.IsEmpty then
         failwith "Empty stack"
      else
         let result::remainder = _stack
         _stack <- remainder
         result

    member this.PopFunctional value =
      match _stack with
      | result :: remainder ->
         _stack <- remainder
         result
      | [] -> failwith "Empty stack"

    member this.TryPop() =
      match _stack with
      | result :: newStack ->
         _stack <- newStack
         result |> Some
      | [] -> None

    member this.SwapNaive() =
      let a, b = this.TryPop(), this.TryPop()
      if a.IsSome && b.IsSome then
         this.Push a.Value
         this.Push b.Value
      else
         failwith "Stack does not have enough elements"

    member this.SafeSwap() =
         match _stack with
         | a::b::tail -> _stack <- b::a::tail
         | _ -> failwith "Stack does not have enough elements"


