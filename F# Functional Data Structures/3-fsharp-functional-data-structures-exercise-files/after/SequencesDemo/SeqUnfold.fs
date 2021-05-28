module SeqUnfold

open System

// Dates at working-day intervals:
let IsWorkingDay (day : DateTime) =
   day.DayOfWeek <> DayOfWeek.Saturday
   && day.DayOfWeek <> DayOfWeek.Sunday

let DaysFollowing (start : DateTime) = 
   Seq.initInfinite (fun i -> start.AddDays(float (i)))

let WorkingDaysFollowing start = 
   start
   |> DaysFollowing
   |> Seq.filter IsWorkingDay

let NextWorkingDayAfter interval start = 
   start
   |> WorkingDaysFollowing
   |> Seq.item interval

let ActionDays startDate endDate interval = 
   Seq.unfold (fun date -> 
      if date > endDate then None
      else 
         let next = date |> NextWorkingDayAfter interval
         let dateString = date.ToString("dd-MMM-yy dddd")
         Some(dateString, next)) startDate

// Run with: ActionDays (DateTime(2015, 6, 1)) (DateTime(2015, 7, 1)) 3 |> Array.ofSeq;;