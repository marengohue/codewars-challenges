namespace CodeWars

// https://www.codewars.com/kata/554a44516729e4d80b000012
module BuyingCars =

    //Percent of loss increases by {costDecay} percent at the end of every {costDecaysEvery} months.
    let costDecay = 0.5
    let costDecaysEvery = 2

    let adjustPrice (monthNo: int) (percentLossByMonth: float) (price: float) =
        let monthlyDecay =  (monthNo |> float) * percentLossByMonth
        let increasingDecay = ((monthNo / costDecaysEvery) |> float) * costDecay
        (1.0 - ((monthlyDecay + increasingDecay) * 0.01)) * price

    let nbMonths (startPriceOld: float) (startPriceNew: float) (savingsPerMonth: float) (percentLossByMonth: float): int*int =
        Seq.initInfinite (fun monthNo ->
            let adjust = adjustPrice monthNo percentLossByMonth
            let balance =
                (
                    + (adjust startPriceOld)
                    + savingsPerMonth * (float monthNo)
                    - (adjust startPriceNew)
                )
                |> round
                |> int
            (monthNo, balance)
        )
        |> Seq.find (fun (_, balance) -> balance >= 0)

    [<EntryPoint>]
    let main argv =
        let adjustedPrice = adjustPrice 3 5.0 100.0
        0
