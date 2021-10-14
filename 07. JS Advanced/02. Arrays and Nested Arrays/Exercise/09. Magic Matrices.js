function solve(matrix) {
    let sumRows = 0;
    let sumCols = 0;

    let isMagical = true;

    for (let i = 0; i < matrix.length; i++) {
        let sumCurrRow = 0;
        for (let j = 0; j < matrix[i].length; j++) {
            sumRows += matrix[i][j];
            sumCurrRow += matrix[i][j];
        }
        
        if ((sumRows / (i + 1)) != sumCurrRow) {
            isMagical = false;
        }
    }

    for (let i = 0; i < matrix.length; i++) {
        let sumCurrCol = 0;
        for (let j = 0; j < matrix[i].length; j++) {
            sumCols += matrix[j][i];
            sumCurrCol += matrix[j][i];
        }

        if ((sumCols / (i + 1)) !== sumCurrCol) {
            isMagical = false;
        }
    }

    if (isMagical) {
        console.log(true);
    }
    else {
        console.log(false);
    }
}

solve([[1, 0, 0],
    [0, 0, 1]]
   )