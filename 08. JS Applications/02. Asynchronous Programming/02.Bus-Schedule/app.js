function solve() {
    let baseUrl = 'http://localhost:3030/jsonstore/bus/schedule/';

    let currentStop;
    let nextStop = 'depot';

    let infoElement = document.querySelector('.info');

    async function depart() {
        try {
            await fetch(`${baseUrl}${nextStop}`)
            .then((res) => res.json())
            .then(function(data) 
            {
                infoElement.textContent = `Next stop ${data.name}`;

                currentStop = data.name;   
                nextStop = data.next;
            });

        } catch (error) {
            infoElement.textContent = 'Error';

            document.getElementById('depart').disabled = true;
            document.getElementById('arrive').disabled = true;
        }

        document.getElementById('depart').disabled = true;
        document.getElementById('arrive').disabled = false;
    }

    function arrive() {

        infoElement.textContent = `Arriving at ${currentStop}`; 

        document.getElementById('depart').disabled = false;;
        document.getElementById('arrive').disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();