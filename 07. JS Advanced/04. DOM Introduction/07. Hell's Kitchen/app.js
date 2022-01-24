function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);

    function onClick() {
        let textAreaElement = document.querySelector('#inputs textarea');

        let restaurants = [];

        let rawRestaurantsInformation = JSON.parse(textAreaElement.value);

        for (let restaurant of rawRestaurantsInformation) {
            let restaurantName = restaurant.split(' - ')[0];

            let workers = restaurant.split(' - ')[1].split(', ').reduce((workersArr, currWorker) => {
                let workerName = currWorker.split(' ')[0];
                let workerSalary = Number(currWorker.split(' ')[1]);

                if (workerName == '' && isNaN(workerSalary)) {
                    return [];
                }

                let worker = {
                    name: workerName
                    , salary: workerSalary
                };

                workersArr.push(worker);

                return workersArr;
            }, []).sort((a, b) => b.salary - a.salary);

            if (!(restaurants.some(restaurant => restaurant.name == restaurantName))) {
                restaurants.push({
                    name: restaurantName
                    , workers
                    , averageSalary: workers.length ? (workers.reduce((sumOfSalaries, worker) => sumOfSalaries + worker.salary, 0) / workers.length).toFixed(2) : 0.00
                    , bestSalary: workers.length ? workers[0].salary.toFixed(2) : 0.00
                });
            } else {
                let indexOfRestaurant = restaurants.findIndex(r => r.name == restaurantName);
                restaurants[indexOfRestaurant].workers.push(...workers);
                restaurants[indexOfRestaurant].workers.sort((a, b) => b.salary - a.salary);
                restaurants[indexOfRestaurant].averageSalary = restaurants[indexOfRestaurant].workers.length ? (restaurants[indexOfRestaurant].workers.reduce((sumOfSalaries, worker) => sumOfSalaries + worker.salary, 0) / restaurants[indexOfRestaurant].workers.length).toFixed(2) : 0.00;
                restaurants[indexOfRestaurant].bestSalary = restaurants[indexOfRestaurant].workers.length ? restaurants[indexOfRestaurant].workers[0].salary.toFixed(2) : 0.00;
            }
        }

        restaurants.sort((a, b) => b.averageSalary - a.averageSalary);

        let outputStringRestaurantsInfo = `Name: ${restaurants[0].name} Average Salary: ${restaurants[0].averageSalary} Best Salary: ${restaurants[0].bestSalary}`;

        let formatedWorkers = restaurants[0].workers.map(worker => `Name: ${worker.name} With Salary: ${worker.salary}`);
        let outputStringWorkersInfo = formatedWorkers.join(' ');

        let bestRestaurantParagraphElement = document.querySelector('#bestRestaurant p');
        bestRestaurantParagraphElement.textContent = outputStringRestaurantsInfo;

        let bestRestaurantsWorkersParagraphElement = document.querySelector('#workers p');
        bestRestaurantsWorkersParagraphElement.textContent = outputStringWorkersInfo;
    }
}