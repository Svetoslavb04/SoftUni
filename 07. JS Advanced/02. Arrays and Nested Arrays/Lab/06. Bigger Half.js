function solve(intArr) {
    intArr = intArr.sort((x, y) => x-y).slice(intArr.length / 2, intArr.length)

    return intArr
}