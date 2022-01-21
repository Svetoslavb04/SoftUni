function solve(array) {
    let towns = [];

    for (let i = 1; i < array.length; i++) {
        let args = array[i].split('|');
        let Town = args[1].trim();
        let Latitude = Number(args[2].trim()).toFixed(2);
        let Longitude = Number(args[3].trim()).toFixed(2);

        towns.push({
            Town,
            Latitude : Number(Latitude),
            Longitude : Number(Longitude)
        })
    }

    console.log(JSON.stringify(towns));
}