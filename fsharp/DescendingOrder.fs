namespace codewars

module descendingOrder =
    let descendingOrder n =
        n.ToString()
            |> List.ofSeq
            |> Seq.sortDescending
            |> Seq.toArray
            |> System.String
            |> int

