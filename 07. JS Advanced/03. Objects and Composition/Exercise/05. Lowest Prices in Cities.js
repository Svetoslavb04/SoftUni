function solve(input) {
    let bestProducts = {};

    for (const tpp of input) {

        let town = tpp.split(' | ')[0];
        let product = tpp.split(' | ')[1];
        let price = Number(tpp.split(' | ')[2]);

        if (Object.keys(bestProducts).includes(product)) {
            if (bestProducts[product]['price'] > price) {
                bestProducts[product] = { price, town };
            }
        } else {
            bestProducts[product] = { price, town };
        }
    }

    for (const key in bestProducts) {
        console.log(`${key} -> ${bestProducts[key]['price']} (${bestProducts[key]['town']})`);
    }
}