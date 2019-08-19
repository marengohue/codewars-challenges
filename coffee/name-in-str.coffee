# https://www.codewars.com/kata/whats-in-a-name/

nameInStr = (string, name) ->
    lastNameLetterIndex = -1
    Array
        .from name.toLowerCase()
        .every (letter) ->
            currentLetterIndex = string.indexOf(letter, lastNameLetterIndex + 1)
            if currentLetterIndex != -1
                lastNameLetterIndex = currentLetterIndex
                true
            else
                false
