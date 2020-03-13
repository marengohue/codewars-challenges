namespace CodeWars

// https://www.codewars.com/kata/5702e2f380b8c86df3000003
module TddAreas =

    open System

    type Shape =
        | Triangle of double * double
        | Square of double
        | Rectangle of double * double
        | Circle of double

    let areaOf shape =
        match shape with
            | Triangle (b, h) -> b * h / 2.0
            | Rectangle (a, b) -> a * b
            | Square a -> a * a
            | Circle r -> Math.PI * r ** 2.0

    let getTotalArea shapes =
        shapes
            |> Seq.sumBy areaOf
            |> fun area -> Math.Round(area, 2)
