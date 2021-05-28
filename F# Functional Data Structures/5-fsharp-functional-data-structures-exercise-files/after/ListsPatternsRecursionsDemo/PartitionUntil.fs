module PartitionUntil

// Partition a list into two; the first result
// contains the input elements up to the point
// where the predicate returned true; the second
// result contains subsequent elements. The
// element which returned true is at the start
// of the second list result.
let PartitionUntil predicate input =
   let rec loop acc list =
      match list with
      | head::tail when predicate head -> List.rev acc, head::tail
      | head::tail -> loop (head::acc) tail
      | [] -> input, []
   loop [] input
