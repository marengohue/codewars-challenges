namespace CodeWars

// https://www.codewars.com/kata/5539fecef69c483c5a000015
module ReversePrimes =

    let reverseNum (n: int64) =
        let rec reverse rest reversed =
            if rest = 0L then reversed
            else reverse (rest / 10L) (10L * reversed + rest % 10L)
        reverse n 0L

    let rec sieve list =
        let rec loop list acc = 
            match list with
                | [] -> List.rev acc
                | hd::tl -> loop (List.filter (fun x -> x % hd <> 0L) tl) (hd::acc)
        loop list []

    let isBrp n primes nMax =
        let reversed = reverseNum n
        reversed <> n && List.contains n primes && List.contains reversed primes

    let backwardsPrime (m: int64) (n: int64) =
        let primeUpperBound = n |> double |> log10 |> ceil |> int |> pown 10L
        let primes = [ 2L .. primeUpperBound ] |> sieve
        primes |> List.filter (fun x -> (x >= m) && (x <= n) && isBrp x primes n) 

    // for debugging purposes
    [<EntryPoint>]
    let main args =
        let result = backwardsPrime 70000L 70245L
        0
