namespace Module6

// Simple OO type (immutable):
type Person(forename : string, surname : string) =
   member __.Forename = forename
   member __.Surname = surname

// OO type with mutable members:
type MutablePerson(forename : string, surname : string) = 
   let mutable _forename = forename
   let mutable _surname = surname
   
   member this.Forename 
      with get () = _forename
      and set value = _forename <- value
   
   member this.Surname 
      with get () = _surname
      and set value = _surname <- value


// Mutable type using member val:
type MutablePerson2(forename : string, surname : string) = 
   member val Forename = forename with get, set
   member val Surname = surname with get, set


open System

// Mutable type with validation on creation (but not on mutation):
type SafePerson(forename : string, surname : string) = 
   let validateString str =
      if String.IsNullOrWhiteSpace str then
         raise (ArgumentException())
   do
      validateString forename
      validateString surname
   member val Forename = forename with get, set
   member val Surname = surname with get, set

// Mutable type with validation on creation and mutation:
type SafePerson2 (forename : string, surname : string) =
   let mutable _forename = forename
   let mutable _surname = surname

   let validateString str =
      if String.IsNullOrWhiteSpace str then
         raise (ArgumentException())
   do
      validateString forename
      validateString surname

   member this.Forename 
      with get () = _forename
      and set value = 
         validateString value
         _forename <- value
   member this.surname 
      with get () = _surname
      and set value = 
         validateString value
         _surname <- value

open System

// Interfaces:
type IPerson =
   abstract member Forename : string
   abstract member Surname : string
   abstract member Fullname : string

// Implementing an interface:
type PersonFromInterface(forename : string, surname : string) =
   let validateString str =
      if String.IsNullOrWhiteSpace str then
         raise (ArgumentException())
   do
      validateString forename
      validateString surname

   interface IPerson with
      member __.Forename = forename
      member __.Surname = surname
      member __.Fullname = sprintf "%s %s" forename surname

module InterfaceAccessDemo = 
   // Accessing interface members:
   let person = PersonFromInterface("Kit", "Eason")
   printfn "%s" (person :> IPerson).Fullname

// For demonstrating access to Discriminated Union members from C# (See PersonTests.cs)
type Contact =
   | PhoneNumber of AreaCode:string * Number:string
   | EmailAddress of string

type ContactPerson(forename : string, surname : string, preferredContact : Contact) =
   let validateString str =
      if String.IsNullOrWhiteSpace str then
         raise (ArgumentException())
   do
      validateString forename
      validateString surname

   member __.PreferredContact = preferredContact

   interface IPerson with
      member __.Forename = forename
      member __.Surname = surname
      member __.Fullname = sprintf "%s %s" forename surname