# https://www.codewars.com/kata/54f8693ea58bce689100065f

mod = (x, y) -> ((x % y) + y) % y

class Rational
    constructor: (@n, @d) ->
        gcd = (a, b) -> if b is 0 then a else gcd(b, a % b)
        fractionGcd = gcd(Math.max(@n, @d), Math.min(@n, @d))
        if fractionGcd isnt 1
            @n /= fractionGcd
            @d /= fractionGcd

    getIntegerPart: -> Math.floor(@n / @d)

    getFractionPart: -> new Rational(mod(@n, @d), @d)

    isEgyptian: -> @n is 1

    @parseFraction: (s) ->
        [ numenator, denominator ] = s
            .split '/'
            .map (num) -> parseInt(num, 10)
        new Rational(numenator, denominator)

    @parseNumber: (s) ->
        parseResult = Number.parseFloat s
        if not Number.isNaN(parseResult)
            denominator = 10 ** (s.length - 2)
            return new Rational(Math.floor(parseResult * denominator), denominator)
        else
            throw new Error("Argument is neither a fration, nor a number")

    @fromString: (s) ->
        if s.indexOf('/') isnt -1
            return Rational.parseFraction s
        else
            return Rational.parseNumber s

    toString: ->
        @n + '/' + @d

fibbonaciSplit = (x) ->
    fibbonaciStep = (fration) ->
        if fration.n is 0 then return []
        if fration.isEgyptian() then return [ fration ]
        stepDenominator = Math.ceil(fration.d / fration.n)
        [
            new Rational(1, stepDenominator)
        ].concat(fibbonaciStep(new Rational(mod(-fration.d, fration.n), fration.d * stepDenominator)))

    if x.getIntegerPart() > 0
        [
            x.getIntegerPart()
        ].concat(fibbonaciStep(x.getFractionPart()))
    else
        fibbonaciStep(x)

decompose = (n) ->
    rational = Rational.fromString(n)
    if (rational.n is 0)
        []
    else
        fibbonaciSplit(rational).map((f) -> f.toString())
