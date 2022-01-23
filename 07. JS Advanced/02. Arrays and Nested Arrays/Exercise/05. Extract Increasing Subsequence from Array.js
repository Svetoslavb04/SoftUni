function solve(array) {
    let reducer = (finalArray, currentValue) => {
        if (currentValue >= (finalArray[finalArray.length - 1] || array[0])) {
            finalArray.push(currentValue);
        }
        return finalArray;
    };

    return array.reduce(reducer, []);
}