namespace codewars

module FindOdd =
    let inline findOdd numbers = 
        numbers
            |> (Seq.groupBy id)
            |> Seq.find (fun (_, vals) -> Seq.length vals % 2 = 1)
            |> fst
