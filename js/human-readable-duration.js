// https://www.codewars.com/kata/52742f58faf5485cae000b9a

const divisors = [
    { secs: 31536000, name: 'year' },
    { secs: 86400, name: 'day' },
    { secs: 3600, name: 'hour' },
    { secs: 60, name: 'minute' },
    { secs: 1, name: 'second' }
];

function quantize(word, count) {
    return count > 1 ? word + 's' : word;
}

function partition(seconds) {
    return divisors
        .reduce((data, divisor) => {
            const count = Math.floor(data.remaining / divisor.secs);
            if (count > 0) {
                return {
                    remaining: data.remaining - count * divisor.secs,
                    partitioned: [...data.partitioned, `${count} ${quantize(divisor.name, count)}`]
                };
            } else {
                return data;
            }
        }, { remaining: seconds, partitioned: [] })
        .partitioned;
}

function joinWords(parts) {
    return parts.reduce((phrase, part, index) =>
        index === parts.length - 1
            ? `${phrase} and ${part}`
            : `${phrase}, ${part}`
    );
}

function formatDuration(seconds) {
    if (seconds === 0) return 'now';
    const parts = partition(seconds);
    return parts.length > 1 ? joinWords(parts) : parts[0];
}