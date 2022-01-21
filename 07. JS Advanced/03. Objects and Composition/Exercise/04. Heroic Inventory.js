function solve(arr) {

    var heroes = [];

    for (const hero of arr) {
        heroes.push({
            name: hero.split(' / ')[0],
            level : Number(hero.split(' / ')[1]),
            items : hero ? hero.split(' / ')[2].split(', ') : []
        });
    }

    console.log(JSON.stringify(heroes));
}