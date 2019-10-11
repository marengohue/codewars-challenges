namespace CodeWars

module Main =
    [<EntryPoint>]
    let main argv =
        let result = BuyingCars.nbMonths 2000.0 8000.0 1000.0 1.5
        printfn "%i %f" (result |> fst) (result |> snd)
        0