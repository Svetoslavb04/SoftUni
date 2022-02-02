function solution(command) {
    let proteins = 0;
    let carbohydrates = 0;
    let fats = 0;
    let flavours = 0;

    let meals = {
        apple: 0,
        lemonade: 0,
        burgers: 0,
        eggs: 0,
        turkey: 0
    };

    return function (command) {
        let commandType = command.split(' ')[0];
        switch (commandType) {
            case 'restock':
                let element = command.split(' ')[1];
                let quantity = Number(command.split(' ')[2]);

                if (element == 'protein') proteins += quantity;
                if (element == 'carbohydrate') carbohydrates += quantity;
                if (element == 'fat') fats += quantity;
                if (element == 'flavour') flavours += quantity;

                return 'Success';
                break;
            case 'prepare':
                let recipe = command.split(' ')[1];
                let quantityMeals = Number(command.split(' ')[2]);

                let totalRequiredProteins = 0;
                let totalRequiredCarbs = 0;
                let totalRequiredFats = 0;
                let totalRequiredFlavours = 0;

                switch (recipe) {
                    case 'apple':
                        totalRequiredCarbs = quantityMeals;
                        totalRequiredFlavours = 2 * quantityMeals;
                        break;
                    case 'lemonade':
                        totalRequiredCarbs = 10 * quantityMeals;
                        totalRequiredFlavours = 20 * quantityMeals;
                        break;
                    case 'burger':
                        totalRequiredCarbs = 5 * quantityMeals;
                        totalRequiredFats = 7 * quantityMeals;
                        totalRequiredFlavours = 3 * quantityMeals;
                        break;
                    case 'eggs':
                        totalRequiredProteins = 5 * quantityMeals;
                        totalRequiredFats = quantityMeals;
                        totalRequiredFlavours = quantityMeals;
                        break;
                    case 'turkey':
                        totalRequiredProteins = 10 * quantityMeals;
                        totalRequiredCarbs = 10 * quantityMeals;
                        totalRequiredFats = 10 * quantityMeals;
                        totalRequiredFlavours = 10 * quantityMeals;
                        break;
                    default:
                        break;
                }

                if (totalRequiredProteins <= proteins && totalRequiredCarbs <= carbohydrates && totalRequiredFats <= fats && totalRequiredFlavours <= flavours) {
                    proteins -= totalRequiredProteins;
                    carbohydrates -= totalRequiredCarbs;
                    fats -= totalRequiredFats;
                    flavours -= totalRequiredFlavours;
                    meals[recipe]++;
                    return 'Success';
                } else {
                    if (totalRequiredProteins > proteins) return `Error: not enough protein in stock`;
                    else if (totalRequiredCarbs > carbohydrates) return `Error: not enough carbohydrate in stock`;
                    else if (totalRequiredFats > fats) return `Error: not enough fat in stock`;
                    else if (totalRequiredFlavours > flavours) return `Error: not enough flavour in stock`;
                }
                break;
            case 'report':
                return `protein=${proteins} carbohydrate=${carbohydrates} fat=${fats} flavour=${flavours}`;
                break;
            default:
                break;
        }
    }
}