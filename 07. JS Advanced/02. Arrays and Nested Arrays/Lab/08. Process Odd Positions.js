function solve(strArr, firstFlavour, secondFlavour) {
    
    console.log(strArr.filter((elem, i) => i % 2 !== 0).map((x) => x*2).reverse().join(' '));

}