module MPAN

open System

let private ProfileClasses = 
   [
      00 // Half-hourly supply (import and export)
      01 // Domestic Unrestricted
      02 // Domestic Economy 7
      03 // Non-Domestic Unrestricted
      04 // Non-Domestic Economy 7
      05 // Non-domestic, with MD recording capability and with LF less than or equal to 20%
      06 // Non-domestic, with MD recording capability and with LF less than or equal to 30% and greater than 20%
      07 // Non-domestic, with MD recording capability and with LF less than or equal to 40% and greater than 30%
      08 // Non-domestic, with MD recording capability and with LF greater than 40% (also all NHH export MSIDs)
   ] |> Set.ofList

let private Distributors =    
   [
      10 // Eastern England
      11 // East Midlands
      12 // London
      13 // Merseyside
      14 // West Midlands
      15 // North Eastern England
      16 // North Western England
      17 // Northern Scotland
      18 // Southern Scotland
      19 // South Eastern England
      20 // Southern England
      21 // Southern Wales
      22 // South Western England
      23 // Yorkshire
      24 // Envoy
      25 // ESP Electricity
      26 // Energetics
      27 // GTC
      28 // EDF IDNO
   ] |> Set.ofList

let validationPrimes =
   [3; 5; 7; 13; 17; 19; 23; 29; 31; 37; 41; 43] // Misses 11 deliberately

type ProfileClass(value : int) =
   do 
      if ProfileClasses |> Set.contains value |> not then
         raise (Exception("Invalid ProfileClass"))
   override __.ToString() = sprintf "%02i" value

type MeterTimeswitchClass(value : int) =
   do
      if value < 1 || value > 999 then
         raise (Exception("Invalid MeterTimeswitchClass"))
   override __.ToString() = sprintf "%03i" value
   
type LineLossFactorClass(value : int) =
   do
      if value < 1 || value > 999 then
         raise (Exception("Invalid LineLossFactorClass"))
   override __.ToString() = sprintf "%03i" value
    
type DistributorId(value : int) =
   do 
      if Distributors |> Set.contains value |> not then
         raise (Exception("Invalid DistributorId"))
   override __.ToString() = sprintf "%02i" value

type UniqueIdentifier(value : int64) =
   do
      if value < 1L || value > 9999999999L then
         raise (Exception("Invalid UniqueIdentifier"))    
   override __.ToString() = sprintf "%010i" value
    
type CheckDigit(value : int) =
   do
      if value < 0 || value > 9 then
         raise (Exception("Invalid CheckSum"))    
   override __.ToString() = sprintf "%i" value
   member __.Value = value
       
type MPAN
   (
      profileClass : ProfileClass, 
      meterTimeswitchClass : MeterTimeswitchClass, 
      lineLossFactorClass : LineLossFactorClass, 
      distributorId : DistributorId, 
      uniqueIdentifier : UniqueIdentifier, 
      checkDigit : CheckDigit
   ) =
   let valid =
      let total = 
         distributorId.ToString() + uniqueIdentifier.ToString()
         |> Seq.zip validationPrimes
         |> Seq.sumBy (fun (p, c) ->
            let n = Int32.Parse(c.ToString()) 
            n * p)
      let checksumCalc = total % 11 % 10
      checksumCalc = checkDigit.Value
   do
      if not valid then
         raise (Exception("CheckSum error"))    
   member this.ProfileClass = profileClass.ToString()
   member this.MeterTimeSwitchClass = meterTimeswitchClass.ToString()
   member this.LineLossFactorClass = lineLossFactorClass.ToString()
   member this.DistributorId = distributorId.ToString()
   member this.UniqueIdentifier = uniqueIdentifier.ToString()
   member this.CheckDigit = checkDigit.ToString()      

let Test() =
   let badProfile = ProfileClass(99)

   let mpan = MPAN(ProfileClass(1), MeterTimeswitchClass(801), LineLossFactorClass(100), 
                  DistributorId(20), UniqueIdentifier(0001636844L), CheckDigit(1))
   mpan
      