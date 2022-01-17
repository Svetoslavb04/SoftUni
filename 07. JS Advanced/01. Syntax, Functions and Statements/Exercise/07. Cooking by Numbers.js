function Cooking(number, operation1, operation2, operation3, operation4, operation5) {
    
    function doOperation(number, operation) {
        switch (operation) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number = number * 0.8;
                break;
            default:
                break;
        }

        console.log(number);
        return number;
    }

    let result = parseInt(number);
    result = doOperation(result, operation1);
    result = doOperation(result, operation2);
    result = doOperation(result, operation3);
    result = doOperation(result, operation4);
    result = doOperation(result, operation5); 
}