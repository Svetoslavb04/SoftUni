function attachEvents() {
    document.querySelector('#submit')
        .addEventListener('click', getWeather);
}

async function getWeather() {
        let allLocations = await fetch('http://localhost:3030/jsonstore/forecaster/locations')
            .then((res) => res.json())
            .then((data) => data);

        let location = allLocations.find(l => l.name == document.querySelector('#location').value);

        let pElementToRemove = document.querySelector('#forecast p');
        if (pElementToRemove) {
            pElementToRemove.remove();
        }

        if (document.querySelector('#location').value) {
            try {
                let todaysWeather = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${location.code}`)
            .then((res) => res.json())
            .then((data) => data);

        let upcomingWeather = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`)
            .then((res) => res.json())
            .then((data) => data);

        let todaysWeatherDiv = document.createElement('div');
        todaysWeatherDiv.classList.add('forecasts');

        let conditionSymbolElement = document.createElement('span');
        conditionSymbolElement.classList.add('condition');
        conditionSymbolElement.classList.add('symbol');

        switch (todaysWeather.forecast.condition) {
            case 'Sunny':
                conditionSymbolElement.innerHTML = `&#x2600`;
                break;
            case 'Partly sunny':
                conditionSymbolElement.innerHTML = `&#x26C5`;
                break;
            case 'Overcast':
                conditionSymbolElement.innerHTML = `&#x2601`;
                break;
            case 'Rain':
                conditionSymbolElement.innerHTML = `&#x2614`;
                break;
            case 'Degrees':
                conditionSymbolElement.innerHTML = `&#176`;
                break;
        }

        todaysWeatherDiv.appendChild(conditionSymbolElement);

        let conditionElement = document.createElement('span');
        conditionElement.classList.add('condition');

        let conditionLocationElement = document.createElement('span');
        conditionLocationElement.classList.add('forecast-data');

        conditionLocationElement.textContent = todaysWeather.name;

        let conditionTempElement = document.createElement('span');
        conditionTempElement.classList.add('forecast-data');

        conditionTempElement.innerHTML = `${todaysWeather.forecast.low}&deg;/${todaysWeather.forecast.high}&deg;`;

        let conditionWeatherElement = document.createElement('span');
        conditionWeatherElement.classList.add('forecast-data');

        conditionWeatherElement.textContent = `${todaysWeather.forecast.condition}`;

        conditionElement.appendChild(conditionLocationElement);
        conditionElement.appendChild(conditionTempElement);
        conditionElement.appendChild(conditionWeatherElement);

        todaysWeatherDiv.appendChild(conditionElement);

        document.querySelector('#current').appendChild(todaysWeatherDiv);

        let forecastsInfoDiv = document.createElement('div');
        forecastsInfoDiv.classList.add('forecast-info');


        upcomingWeather.forecast.forEach(w => {
            let upcomingElement = document.createElement('span');
            upcomingElement.classList.add('upcoming');

            let upcomingSymbolElement = document.createElement('span');
            upcomingSymbolElement.classList.add('symbol');

            switch (w.condition) {
                case 'Sunny':
                    upcomingSymbolElement.innerHTML = `&#x2600`;
                    break;
                case 'Partly sunny':
                    upcomingSymbolElement.innerHTML = `&#x26C5`;
                    break;
                case 'Overcast':
                    upcomingSymbolElement.innerHTML = `&#x2601`;
                    break;
                case 'Rain':
                    upcomingSymbolElement.innerHTML = `&#x2614`;
                    break;
                case 'Degrees':
                    upcomingSymbolElement.innerHTML = `&#176`;
                    break;
            }

            let upcomingConditionTempElement = document.createElement('span');
            upcomingConditionTempElement.classList.add('forecast-data');

            upcomingConditionTempElement.innerHTML = `${w.low}&deg;/${w.high}&deg;`;

            let upcomingConditionWeatherElement = document.createElement('span');
            upcomingConditionTempElement.classList.add('forecast-data');

                upcomingConditionWeatherElement.textContent = `${w.condition}`;

                upcomingElement.appendChild(upcomingSymbolElement);
                upcomingElement.appendChild(upcomingConditionTempElement);
                upcomingElement.appendChild(upcomingConditionWeatherElement);

            forecastsInfoDiv.appendChild(upcomingElement);
        })

        document.querySelector('#current').appendChild(todaysWeatherDiv)
        document.querySelector('#upcoming').appendChild(forecastsInfoDiv);
        document.querySelector('#forecast').style.display = "inline";
            } catch {
                document.querySelector('#forecast').style.display = 'inline';
                let labels = Array.from(document.querySelectorAll('.label'));
                labels.forEach(label => {

                    label.style.display = 'none';

                })

                let paElement = document.createElement('p');
                paElement.textContent = `Error`;
                document.querySelector('#forecast').appendChild(paElement);
            }
        }
}

attachEvents();