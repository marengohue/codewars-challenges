namespace CodeWars

// https://www.codewars.com/kata/5539fecef69c483c5a000015
module ReversePrimes =

    let initSieve topCandidate =
        let result = Array.zeroCreate<bool> (topCandidate + 1)
        Array.set result 2 true
        Array.set result 3 true
        Array.set result 5 true
        result

    let removeSquares sieve topCandidate =
        let squares =
            seq { 7 .. topCandidate}
                |> Seq.filter (fun n -> Array.get sieve n)
                |> Seq.map (fun n -> n * n)
                |> Seq.takeWhile (fun n -> n <= topCandidate)
        for n2 in squares do
            n2
                |> Seq.unfold (fun state -> Some(state, state + n2))
                |> Seq.takeWhile (fun x -> x <= topCandidate)
                |> Seq.iter (fun x -> Array.set sieve x false)
        sieve

    let pickPrimes sieve =
        sieve
            |> Array.mapi (fun i t -> if t then Some i else None)
            |> Array.choose id

    let doFirst sieve topCandidate =
        let set1 = Set.ofList [1; 13; 17; 29; 37; 41; 49; 53]
        let mutable x = 1
        let mutable y = 1
        let mutable go = true
        let mutable x2 = 4 * x * x
        while go do
            let n = x2 + y*y
            if n <= topCandidate then
                if Set.contains (n % 60) set1 then
                    Array.get sieve n |> not |> Array.set sieve n

                y <- y + 2
            else
                y <- 1
                x <- x + 1
                x2 <- 4 * x * x
                if topCandidate < x2 + 1 then
                    go <- false

    let doSecond sieve topCandidate =
        let set2 = Set.ofList [7; 19; 31; 43]
        let mutable x = 1
        let mutable y = 2
        let mutable go = true
        let mutable x2 = 3 * x * x
        while go do
            let n = x2 + y*y
            if n <= topCandidate then
                if Set.contains (n % 60) set2 then
                    Array.get sieve n |> not |> Array.set sieve n

                y <- y + 2
            else
                y <- 2
                x <- x + 2
                x2 <- 3 * x * x
                if topCandidate < x2 + 4 then
                    go <- false

    let doThird sieve topCandidate =
        let set3 = Set.ofList [11; 23; 47; 59]
        let mutable x = 2
        let mutable y = x - 1
        let mutable go = true
        let mutable x2 = 3 * x * x
        while go do
            let n = x2 - y*y
            if n <= topCandidate && 0 < y then
                if Set.contains (n % 60) set3 then
                    Array.get sieve n |> not |> Array.set sieve n

                y <- y - 2
            else
                x <- x + 1
                y <- x - 1
                x2 <- 3 * x * x
                if topCandidate < x2 - y*y then
                    go <- false

    let atkinSieve (topCandidate : int) =
        let sieve = initSieve topCandidate

        [async { doFirst sieve topCandidate }
         async { doSecond sieve topCandidate }
         async { doThird sieve topCandidate }]
            |> Async.Parallel
            |> Async.RunSynchronously
            |> ignore

        removeSquares sieve topCandidate |> pickPrimes

    let reverseNum (n: int) =
        let rec reverse rest reversed =
            if rest = 0 then reversed
            else reverse (rest / 10) (10 * reversed + rest % 10)
        reverse n 0

    let rec sieve list =
        let rec loop list acc =
            match list with
                | [] -> List.rev acc
                | hd::tl -> loop (List.filter (fun x -> x % hd <> 0L) tl) (hd::acc)
        loop list []

    let isBrp n primes nMax =
        let reversed = reverseNum n
        reversed <> n && Set.contains n primes && Set.contains reversed primes

    let backwardsPrime (m: int64) (n: int64) =
        let primeUpperBound = n |> double |> log10 |> ceil |> int |> pown 10
        let primes = primeUpperBound |> atkinSieve |> Set.ofSeq
        primes |> Set.filter (fun x -> (x >= (m |> int)) && (x <= (n |> int)) && isBrp x primes (n |> int)) |> Set.map int64 |> Set.toList

