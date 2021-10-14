function solve(arr) {
    arr.sort(
        (a, b) => {
            if(a.length === b.length) {
                return a.localeCompare(b);
            }
            else {
                return a.length - b.length;
            }
        }
    );

    console.log(arr.join('\n'));
}