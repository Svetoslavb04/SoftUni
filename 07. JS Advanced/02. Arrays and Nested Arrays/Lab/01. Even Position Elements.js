function solve(arrOfString) {
    let evenPositionedElements = [];

    for (let i = 0; i < arrOfString.length; i+=2) {
        evenPositionedElements.push(arrOfString[i]);
    }

    console.log(evenPositionedElements.join(' '))
}