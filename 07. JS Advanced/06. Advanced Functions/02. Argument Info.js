function argumentTypes(...params) {
    let argDictionary = {};

    params
        .forEach(arg => {
            if (argDictionary[typeof arg] == undefined) {
                argDictionary[typeof arg] = 1
            } else {
                argDictionary[typeof (arg)]++;
            }
            console.log(`${typeof (arg)}: ${arg}`)
        });

    Object.entries(argDictionary).sort(([, a], [, b]) => b - a)
    .forEach(t => console.log(`${t[0]} = ${t[1]}`));
}