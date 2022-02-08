function cars(carArray) {
    let carBrands = new Map();

    for (const car of carArray) {
        let carBrand = car.split(' | ')[0];
        let model = car.split(' | ')[1];
        let quantity = Number(car.split(' | ')[2]);

        if (carBrands.has(carBrand)) {
            if (carBrands.get(carBrand).has(model)) {
                let currentQuantity = carBrands.get(carBrand).get(model);
                carBrands.get(carBrand).set(model, currentQuantity + quantity);
            } else {
                carBrands.get(carBrand).set(model, quantity);
            }
        } else {
            carBrands.set(carBrand, new Map());
            carBrands.get(carBrand).set(model, quantity);
        }
    }

    for (const [carBrand, models] of carBrands.entries()) {
        console.log(carBrand);
        for (const [model, quantity] of models.entries()) {
            console.log(`###${model} -> ${quantity}`);
        }
    }
}