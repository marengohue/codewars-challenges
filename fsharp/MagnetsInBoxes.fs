namespace CodeWars

// https://www.codewars.com/kata/56c04261c3fcf33f2d000534
module MagnetsInBoxes =

    let doubles kMax nMax =
        ({ 1.0..(kMax |> float) }, { 1.0..(nMax |> float) })
            ||> Seq.allPairs
            |> Seq.sumBy (fun (k, n) -> 1.0 / (k * (n + 1.0)**(2.0*k)))
