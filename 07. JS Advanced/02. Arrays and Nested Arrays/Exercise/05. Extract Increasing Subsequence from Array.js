function solve(arrInt) {

    let resultArr = [arrInt[0]];
    let biggest = resultArr[0]; 

    for (let i = 1; i < arrInt.length; i++) {
        if (biggest < arrInt[i]) {
            biggest = arrInt[i];
        }
        if (arrInt[i] >= biggest) {
            resultArr.push(arrInt[i]);
        }
    }
    return resultArr
}