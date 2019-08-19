# https://www.codewars.com/kata/55466989aeecab5aac00003e

sqInRectRec = (length, width) ->
    if !length or !width
        []
    else
        max = Math.max(length, width)
        min = Math.min(length, width)
        [ min ].concat(sqInRectRec(max - min, min))

sqInRect = (length, width) ->
    if (length == width)
        null
    else
        sqInRectRec(length, width)
