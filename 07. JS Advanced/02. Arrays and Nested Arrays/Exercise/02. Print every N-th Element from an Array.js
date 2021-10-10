function solve(arrStr, number) {

    let resultArr = [];

    for (let i = 0; i < arrStr.length; i+=number) {
        resultArr.push(arrStr[i])
    }

    return resultArr;
}