namespace CodeWars

// https://www.codewars.com/kata/559ce00b70041bc7b600013d
module Finance =
    let savingsOnWeek daysInWeek weekNo =
        let firstDaySavings = 2 * weekNo
        let lastDaySavings = daysInWeek + weekNo - 1
        uint64 <| firstDaySavings + lastDaySavings * (daysInWeek - weekNo) / 2

    let finance m =
        seq { 0 .. m } |> Seq.sumBy (savingsOnWeek (m + 1))
