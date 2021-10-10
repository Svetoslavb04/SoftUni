function solve(intArr) {
    console.log(intArr.sort((x, y) => x - y).slice(0,2).join(' '));
}