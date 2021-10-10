function GCD (numberOne, numberTwo) {

    let divisor;
    let divider;
    let leftover = 1;

    if(numberOne > numberTwo) {
        divisor = numberOne;
        divider = numberTwo;
    }
    else {
        divisor = numberTwo;
        divider = numberOne;
    }

    while(leftover > 0) {
        leftover = divisor % divider;
        divisor = divider;
        divider = leftover
        gcd = divisor;
    }

    console.log(gcd)
}