namespace CodeWars

// https://www.codewars.com/kata/5539fecef69c483c5a000015
module ReversePrimes =
    let strRev a =
        let rator = System.Globalization.StringInfo.GetTextElementEnumerator(a)
        List.unfold(fun n->if n then Some(rator.GetTextElement(), rator.MoveNext()) else None)(rator.MoveNext())|>List.rev|>String.concat ""

    let reverseNum (n: int64) =
        n
            |> string
            |> strRev
            |> int64

    let isPrime (n : int64) =
        let rec loop iterator =
            if iterator = n/2L then true
            elif n % iterator = 0L then false
            else loop (iterator + 1L)
        loop 2L

    let isBrp n =
        let reversed = n |> reverseNum
        reversed <> n && isPrime n && isPrime reversed

    let backwardsPrime (m: int64) (n: int64) =
        [m .. n]
            |> List.filter isBrp

    // for debugging purposes
    [<EntryPoint>]
    let main args =
        let result = backwardsPrime 70000L 70245L
        0
