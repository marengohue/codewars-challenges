# https://www.codewars.com/kata/playing-with-passphrases

alphabetSize = 26

codeOf = (char) -> char.charCodeAt 0

charOf = (code) -> String.fromCharCode code

processLetter = (shiftBy, index, char) ->
    charCode = (shiftBy % alphabetSize) + codeOf char
    if charCode > codeOf 'z'
        charOf(charCode - alphabetSize)
    else if charCode < codeOf 'a'
        charOf(charCode + alphabetSize)
    else
        charOf charCode

processNum = (numChar) ->
    (9 - numChar).toString()

processChar = (shiftBy, char, index) ->
    loweredChar = char.toLowerCase()
    if loweredChar >= 'a' and loweredChar <= 'z'
        baseLetter = processLetter shiftBy, index, loweredChar
        if index % 2 is 0 then baseLetter.toUpperCase() else baseLetter.toLowerCase()

    else if loweredChar >= '0' and loweredChar <= '9'
        processNum char
    else
        char

playPass = (str, shiftBy) ->
    Array
        .from(str)
        .map(processChar.bind(this, shiftBy))
        .reverse()
        .join('')

