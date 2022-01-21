function modelACar(requirements) {
    let car = {};

    car['model'] = requirements['model'];

    if (requirements['power'] < 120) {
        car['engine'] = { power: 90, volume: 1800 };
    }
    else if (requirements['power'] < 200) {
        car['engine'] = { power: 120, volume: 2400 };
    }
    else {
        car['engine'] = { power: 200, volume: 3500 };
    }

    car['carriage'] = {
         type : `${requirements['carriage']}`,
         color : `${requirements['color']}` 
        };

    if (requirements['wheelsize'] % 2 == 0) {
        car['wheels'] = [requirements['wheelsize'] - 1, requirements['wheelsize'] - 1, requirements['wheelsize'] - 1, requirements['wheelsize'] - 1];
    } else {
        car['wheels'] = [requirements['wheelsize'], requirements['wheelsize'], requirements['wheelsize'], requirements['wheelsize']];
    }

    return car;
}