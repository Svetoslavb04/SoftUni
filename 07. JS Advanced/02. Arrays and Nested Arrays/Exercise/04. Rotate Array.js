function solve(arr, number) {
    
    for (let i = 0; i < number; i++) {
        arr.unshift(arr.pop());
    }

    console.log(arr.join(' '));
}