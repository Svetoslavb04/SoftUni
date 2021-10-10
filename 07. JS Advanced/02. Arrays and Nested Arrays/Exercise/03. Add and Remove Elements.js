function solve(arrStr) {

    let resultArr = [];
    let number = 1;

    for (let i = 0; i < arrStr.length; i++) {
        if (arrStr[i] == 'add') {
            resultArr.push(number);
        }
        else {
            resultArr.pop();
        }
        number++;

    }
    
    if (resultArr.length == 0) {
        console.log('Empty');
    }
    else {
        resultArr.forEach(element => {
            console.log(element);
        });
    }
}

solve(['add', 
'add', 
'remove', 
'add', 
'add']

)