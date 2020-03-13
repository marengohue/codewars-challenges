namespace CodeWars

// https://www.codewars.com/kata/559b8e46fa060b2c6a0000bf
module BinomialSums =

    let binomial n p =
        let inline fact (x: int): bigint = [ 1I .. bigint x ] |> Seq.reduce ( * )
        let hiDenom = max (n - p) p
        let loDenom = min (n - p) p
        ([ bigint (hiDenom + 1) .. (bigint n) ] |> Seq.fold ( * ) (bigint 1))
            /
        (fact loDenom)

    let diagonal(n:int, p:int): bigint =
        binomial (n + 1) (p + 1)
