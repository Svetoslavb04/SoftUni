function solve(intArr) {
    
    for (let i = 0; i < intArr.length; i++) {

        if (intArr[i] < 0) {
            let num = intArr[i];
            
            intArr.splice(i,1)
            intArr.unshift(num);   
        }
        
    }

    intArr.forEach(element => {
        console.log(element)
    });
}