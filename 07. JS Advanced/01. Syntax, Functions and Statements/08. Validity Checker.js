function solve(x1, y1, x2, y2) {
    
    let distance;

    /*{x1, y1} to {0, 0}*/ distance =  Math.sqrt(x1 ** 2 + y1 ** 2);
    
    if (Number.isInteger(distance)) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`)
    }
    else { console.log(`{${x1}, ${y1}} to {0, 0} is invalid`) }
    /*{x2, y2} to {0, 0}*/ distance =  Math.sqrt(x2 ** 2 + y2 ** 2);
    
    if (Number.isInteger(distance)) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`)
    }
    else { console.log(`{${x2}, ${y2}} to {0, 0} is invalid`) }

    /*{x1, y1} to {x2, y2}*/ distance =  Math.sqrt(Math.abs(x1-x2) ** 2 + Math.abs(y1-y2) ** 2);
    
    if (Number.isInteger(distance)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
    }
    else { console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`) }
}

solve(2, 1, 1, 1)