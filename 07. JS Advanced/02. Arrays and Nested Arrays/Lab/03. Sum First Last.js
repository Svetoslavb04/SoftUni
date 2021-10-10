function solve(strArr) {

    let intArr = strArr.map((item) => { return parseInt(item) });

    let firstNumber = intArr.shift();
    let lastNumber = intArr.pop();
    
    return firstNumber + lastNumber
}