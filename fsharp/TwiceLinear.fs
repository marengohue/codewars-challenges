namespace CodeWars

// https://www.codewars.com/kata/5672682212c8ecf83e000050
module TwiceLinear =

    let y x = 2 * x + 1
    let z x = 3 * x + 1

    let step set _ =
        let minElement = Set.minElement set
        set |> (
            Set.remove minElement
            >> Set.add (y minElement)
            >> Set.add (z minElement)
        )

    let dblLinear (n: int) =
        seq { 1..n }
            |> Seq.fold step (Set.ofList [1])
            |> Set.minElement
