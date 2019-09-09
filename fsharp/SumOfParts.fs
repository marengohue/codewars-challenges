namespace CodeWars

// https://www.codewars.com/kata/5ce399e0047a45001c853c2b
module SumOfParts =
    let nThSum (value: int) (acc: int list) =
        match acc with
            | hd::_ -> (hd + value)::acc
            | _ -> [ 0 ]

    let partsSums(ls: int array): int array =
        // Thanks, F# for switching arguments around in the foldBack function
        // Thus not allowing me to pipe values around in a pretty manner!
        List.foldBack nThSum (Array.toList ls) [0] |> Array.ofList
