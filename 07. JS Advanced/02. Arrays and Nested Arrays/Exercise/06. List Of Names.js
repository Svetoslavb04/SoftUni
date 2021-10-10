function solve(arrStr) {

    arrStr.sort((a, b) => a.localeCompare(b));

    for (let i = 1; i <= arrStr.length; i++) {
        console.log(`${i}.${arrStr[i-1]}`)
    }
}