function solve(arrInt) {
    arrInt.sort((a, b) => a-b).reverse();
 
    let result = [];
    
    while(arrInt.length > 0){
        result.push(arrInt.pop());
        arrInt.reverse();
    }
 
    return result;
}