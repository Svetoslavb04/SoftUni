function getInfo() {
    let busesListElement = document.getElementById('buses');
    let stopNameDivElement = document.getElementById('stopName');

    stopNameDivElement.textContent = '';
    busesListElement.textContent = '';

    let id = Number(document.getElementById('stopId').value);
    let baseUrl = 'http://localhost:3030/jsonstore/bus/businfo/';
    
    fetch(`${baseUrl}${id}`)
        .then((res) => res.json())
        .then((data) => {
            stopNameDivElement.textContent = data.name;

            for (const bus of Object.keys(data.buses)) {
                let liElement = document.createElement('li');
                liElement.textContent = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;

                busesListElement.appendChild(liElement);
            }
        })
        .catch(() => stopNameDivElement.textContent = 'Error');
}