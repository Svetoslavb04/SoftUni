function juices(juicesArr) {
    let littersJuices = new Map();
    let bottlesJuices = new Map();

    for (let juiceArr of juicesArr) {

        const juice = juiceArr.split(' => ')[0];
        const quantity = Number(juiceArr.split(' => ')[1]);

        if (littersJuices.has(juice)) {
            littersJuice = littersJuices.get(juice);
            littersJuices.set(juice, littersJuice + quantity);
        } else {
            littersJuices.set(juice, quantity);
        }
        if (littersJuices.get(juice) >= 1000) {
            if (bottlesJuices.has(juice)) {

                let bottleJuice = bottlesJuices.get(juice);
                bottlesJuices.set(juice, bottleJuice + Math.floor(littersJuices.get(juice) / 1000));

                littersJuice = littersJuices.get(juice);
                littersJuices.set(juice, littersJuice - Math.floor(littersJuices.get(juice) / 1000) * 1000);
            } else {
                bottlesJuices.set(juice, Math.floor(littersJuices.get(juice) / 1000));

                littersJuice = littersJuices.get(juice);
                littersJuices.set(juice, littersJuice - Math.floor(littersJuices.get(juice) / 1000) * 1000);
            }
        }
    }

    for(let [key, value] of bottlesJuices) {
        console.log(`${key} => ${value}`);
      }
      
}

juices(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']

);