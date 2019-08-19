namespace CodeWars

// https://www.codewars.com/kata/55466989aeecab5aac00003e
module SquaresInRect =
    let rec placeSquaresRec (lng: int) (wdth: int) : int list =
        match (lng, wdth) with
            | (0, _)
            | (_, 0) -> []
            | _ -> min lng wdth :: (placeSquaresRec ((max lng wdth) - (min lng wdth)) (min lng wdth))

    let squaresInRect lng wdth =
        if lng = wdth then None else Some (placeSquaresRec lng wdth)
