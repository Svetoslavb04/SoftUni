function solve(nestedArr) {

    let leftDiagSum = 0;
    let rightDiagSum = 0;

    for (let i = 0; i < nestedArr.length; i++) {
        leftDiagSum += nestedArr[i][i];
        rightDiagSum += nestedArr[i][nestedArr.length - 1 - i]
    }

    console.log(leftDiagSum + ' ' + rightDiagSum)
}