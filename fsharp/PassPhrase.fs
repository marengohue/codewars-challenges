namespace CodeWars

open System
open System.Globalization

// https://www.codewars.com/kata/559536379512a64472000053
module PassPhrase =

    let zIndex = 'z' |> int

    let aIndex = 'a' |> int

    let shiftPositiveConverter = aIndex - zIndex - 1

    let shiftNegativeConverter = zIndex - aIndex - 1

    let numberConverter = ('9' |> int) + ('0' |> int)

    let reverseString s =
        seq {
            let tee = StringInfo.GetTextElementEnumerator(s)
            while tee.MoveNext() do
                yield tee.GetTextElement()
        }
        |> Array.ofSeq
        |> Array.rev
        |> String.concat ""


    let mapDigitChar c =
        c
            |> int
            |> (fun x -> numberConverter - x)
            |> char

    let shiftCharCode shift loweredCharCode =
        let shiftedChar = (loweredCharCode + shift % 26)
        if shiftedChar > zIndex then
            shiftedChar + shiftPositiveConverter
        elif shiftedChar < aIndex then
            shiftedChar + shiftNegativeConverter
        else
            shiftedChar

    let mapLetterChar pos shift c =
        c
            |> Char.ToLower
            |> int
            |> shiftCharCode shift
            |> char
            |> (fun x -> if pos % 2 = 1 then Char.ToLower(x) else Char.ToUpper(x))

    let mapCharacters shift index c =
        match c with
            | numChar when (Char.IsDigit(numChar)) -> mapDigitChar numChar
            | letterChar when (Char.IsLetter(letterChar)) -> mapLetterChar index shift letterChar
            | _ -> c

    let playPass (s: string) (shift: int) : string =
        s
            |> String.mapi (mapCharacters shift)
            |> reverseString

    [<EntryPoint>]
    let main args =
        let result = playPass "ABCDE" -1
        0
