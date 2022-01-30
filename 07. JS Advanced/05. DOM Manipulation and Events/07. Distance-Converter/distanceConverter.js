function attachEventsListeners() {
    let convertButtonElement = document.querySelector('#convert');

    function convertHandler() {
        let inputUnit = document.querySelector('#inputUnits').value;
        let outputUnit = document.querySelector('#outputUnits').value;

        let inputDistance = Number(document.querySelector('#inputDistance').value);
        let outputDistanceElement = document.querySelector('#outputDistance');

        let inputInMeters = inputDistance;

        switch (inputUnit) {
            case 'km':
                inputInMeters *= 1000;
                break;
            case 'm':
                break;
                
            case 'cm':
                inputInMeters /= 100;
                break;
            case 'mm':
                inputInMeters = inputInMeters / 100 / 10;
                break;
            case 'mi':
                inputInMeters *= 1609.34;
                break;
            case 'yrd':
                inputInMeters *= 0.9144;
                break;
            case 'ft':
                inputInMeters *= 0.3048;
                break;
            case 'in':
                inputInMeters *= 0.0254;
                break;
            default:
                break;
        }

        switch (outputUnit) {
            case 'km':
                inputInMeters /= 1000;
                break;
            case 'm':
                break;
            case 'cm':
                inputInMeters *= 100;
                break;
            case 'mm':
                inputInMeters = inputInMeters * 100 * 10;
                break;
            case 'mi':
                inputInMeters /= 1609.34;
                break;
            case 'yrd':
                inputInMeters /= 0.9144;
                break;
            case 'ft':
                inputInMeters /= 0.3048;
                break;
            case 'in':
                inputInMeters /= 0.0254;
                break;
            default:
                break;
        }

        outputDistanceElement.value = inputInMeters;
    }

    convertButtonElement.addEventListener('click', convertHandler)
}