namespace CodeWars

// https://www.codewars.com/kata/54da5a58ea159efa38000836
module FindOdd =
    let inline findOdd numbers =
        numbers
            |> (Seq.groupBy id)
            |> Seq.find (fun (_, vals) -> Seq.length vals % 2 = 1)
            |> fst
