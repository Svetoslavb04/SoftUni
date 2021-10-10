function solve(nestedArr) {

    let reducer = (a, b) => {
        a = Math.max(...a);
        let bMax = Math.max(...b);
        if (bMax > a) {
            a = bMax
        }

        let f = [a];
        return f;
    }

    let biggestNumber = nestedArr.reduce(reducer);

    console.log(biggestNumber[0])
}

solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
   )