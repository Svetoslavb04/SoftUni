function solve(array) {
    array.sort((a, b) => a.localeCompare(b));

    var array = array.reduce((acc, cv, i) => {
        if (cv[0] !== (acc.length ? acc[acc.length - 1][2] : '-')) {
            acc.push(cv[0]);
            let name = cv.split(' : ')[0];
            let price = cv.split(' : ')[1];
            acc.push(`  ${name}: ${price}`);
        } else {
            let name = cv.split(' : ')[0];
            let price = cv.split(' : ')[1];
            acc.push(`  ${name}: ${price}`);
        }
        return acc;
    }, []);

    array.forEach(element => {
        console.log(element);
    });
}