function RequiredMoney(foodType, weight, price) {

    let money = weight/1000 * price;
    console.log(`I need $${money.toFixed(2)} to buy ${(weight/1000).toFixed(2)} kilograms ${foodType}.`);
}