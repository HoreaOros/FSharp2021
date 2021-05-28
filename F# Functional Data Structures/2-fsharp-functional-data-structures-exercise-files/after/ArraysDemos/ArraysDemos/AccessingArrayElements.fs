module AccessingArrayElements

// Last days of month - bug-compatible with Excel, using mutation:
open System

let lastDaysExcelMutation year =
   let days =
      Array.init 12 (fun i ->
         let month = i+1
         let firstDay = DateTime(year, month, 1)
         let lastDay = firstDay.AddDays(float(DateTime.DaysInMonth(year, month)-1))
         lastDay.Day
      )
   if year = 1900 then
      days.[1] <- 29
   days

// Last days of month - bug-compatible with Excel, without mutation:
open System

let lastDaysExcel year =
   Array.init 12 (fun i ->
      let month = i+1
      let firstDay = DateTime(year, month, 1)
      let lastDay = firstDay.AddDays(float(DateTime.DaysInMonth(year, month)-1))
      let lastDayExcel = 
         if firstDay = DateTime(1900, 2, 1) then
            29
         else
            lastDay.Day
      lastDayExcel
   )
