namespace CodeWars

// https://www.codewars.com/kata/5467e4d82edf8bbf40000155
module descendingOrder =
    let descendingOrder n =
        n.ToString()
            |> List.ofSeq
            |> Seq.sortDescending
            |> Seq.toArray
            |> System.String
            |> int
