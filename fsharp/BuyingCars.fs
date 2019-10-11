namespace CodeWars

// https://www.codewars.com/kata/554a44516729e4d80b000012
module BuyingCars =

    //Percent of loss increases by {costDecay} percent at the end of every {costDecaysEvery} months.
    let costDecay = 0.5
    let costDecaysEvery = 2

    let getPriceAdjustment (monthNo: int) (percentLossByMonth: float) =
        let increasingDecay = costDecay * ((monthNo / costDecaysEvery) |> float)
        let adjustment = (
            + 1.0
            - (percentLossByMonth + increasingDecay) * 0.01
        )
        printfn "Price decreases by %f on month %i" (1.0 - adjustment) monthNo
        adjustment

    let nbMonths (startPriceOld: float) (startPriceNew: float) (savingsPerMonth: float) (percentLossByMonth: float): int*float =
        seq { 1 .. 100 }
            |> Seq.scan (fun (monthNo, lastMonthAdj) _ ->
                let result = (monthNo + 1, lastMonthAdj * (getPriceAdjustment monthNo percentLossByMonth))
                printfn "Total price adjustment is %f" (result |> snd)
                result
            ) (1, 1.0)
            |> Seq.map (fun (monthNo, totalPercentLoss) ->
                (
                    monthNo,
                    (
                        + savingsPerMonth * (monthNo |> float)
                        - (startPriceNew - startPriceOld) * totalPercentLoss
                    )
                )
            )
            |> Seq.find (fun (_, balance) -> balance >= 0.0)
            |> fun (monthNo, balance) -> (monthNo, round balance)


