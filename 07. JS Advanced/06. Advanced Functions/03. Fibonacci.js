function fibonacciBuilder() {
    let fn1 = 0;
    let fn2 = 1;

    return function getFibonator() {
        let output = fn1 + fn2;
        fn1 = fn2;
        fn2 = output;

        return fn1;
    }
}

