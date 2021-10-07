function SameDigits(number) {

    let AreSame = true;
    let strNumber = number.toString();
    let sumOfDigits = parseInt(strNumber[0]);

    for (let i = 0; i < strNumber.length - 1; i++) {

        sumOfDigits += parseInt(strNumber[i + 1]);

        if (strNumber[i] != strNumber[i+1]) {
            AreSame = false;
        }

    }

    console.log(AreSame);
    console.log(sumOfDigits);
}