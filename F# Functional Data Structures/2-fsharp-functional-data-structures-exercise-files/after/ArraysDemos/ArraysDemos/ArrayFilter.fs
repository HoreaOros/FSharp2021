module ArrayFilter

// Array.filter:
open System

let LastDays year =
   [|
      for i in 1..12 do
         let firstDay = DateTime(year, i, 1)
         let dayCount = float(DateTime.DaysInMonth(year, i))
         let lastDay = firstDay.AddDays(dayCount-1.)
         yield lastDay
   |]

let IsWeekend (day : DateTime) =
   day.DayOfWeek = DayOfWeek.Saturday 
   || day.DayOfWeek = DayOfWeek.Sunday

let WarningDays year =
   LastDays year
   |> Array.filter (fun d -> IsWeekend d)
   // or: Array.filter IsWeekend