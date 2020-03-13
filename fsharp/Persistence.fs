namespace CodeWars

// https://www.codewars.com/kata/55bf01e5a717a0d57e0000ec
module Persistence =

    let productOfDigits =
        function
            | x when x >= 10 -> Some (x % 10, x / 10)
            | 0 -> None
            | x -> Some (x, 0)
        |> Seq.unfold
        >> Seq.reduce ( * )

    let persistence =
        function
            | x when x >= 10 -> Some (true, productOfDigits x)
            | _-> None
        |> Seq.unfold
        >> Seq.length
