function solve(argArr) {
    let menu = {};

    for (let i = 0; i < argArr.length; i++) {
        if (i % 2 == 0) {
            menu[argArr[i]] = Number(argArr[i + 1]);
        }
    }

    console.log(menu);
}