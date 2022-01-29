function attachEventsListeners() {

    function DaysConvert(e) {
        let days = e.target.parentElement.children[1].value;
    
        let hours = days * 24;
        let minutes = hours * 60;
        let seconds = minutes * 60;
    
        let hoursElement = document.getElementById('hours');
        let minutesElement = document.getElementById('minutes');
        let secondsElement = document.getElementById('seconds');
    
        hoursElement.value = hours;
        minutesElement.value = minutes;
        secondsElement.value = seconds;
    }
    
    function HoursConvert(e) {
        let hours = e.target.parentElement.children[1].value;
    
        let days = (hours / 24).toFixed(1);
        let minutes = hours * 60;
        let seconds = minutes * 60;
    
        let daysElement = document.getElementById('days');
        let minutesElement = document.getElementById('minutes');
        let secondsElement = document.getElementById('seconds');
    
        daysElement.value = days;
        minutesElement.value = minutes;
        secondsElement.value = seconds;
    }
    
    function MinutesConvert(e) {
        let minutes = e.target.parentElement.children[1].value;
    
        let hours = (minutes / 60).toFixed(1);
        let days = (minutes / 1440).toFixed(1);
        let seconds = minutes * 60;
    
        let daysElement = document.getElementById('days');
        let hoursElement = document.getElementById('hours');
        let secondsElement = document.getElementById('seconds');
    
        daysElement.value = days;
        hoursElement.value = hours;
        secondsElement.value = seconds;
    }
    
    function SecondsConvert(e) {
        let seconds = e.target.parentElement.children[1].value;
    
        let hours = (seconds / 3600).toFixed(1);
        let days = (seconds / 86400).toFixed(1);
        let minutes = (seconds / 60).toFixed(1);
    
        let daysElement = document.getElementById('days');
        let hoursElement = document.getElementById('hours');
        let minutesElement = document.getElementById('minutes');
    
        daysElement.value = days;
        hoursElement.value = hours;
        minutesElement.value = minutes;
    }

    let daysButtonElement = document.getElementById('daysBtn');
    daysButtonElement.addEventListener('click', DaysConvert);

    let hoursButtonElement = document.getElementById('hoursBtn', HoursConvert);
    hoursButtonElement.addEventListener('click', HoursConvert);

    let minutesButtonElement = document.getElementById('minutesBtn', MinutesConvert);
    minutesButtonElement.addEventListener('click', MinutesConvert);

    let secondsButtonElement = document.getElementById('secondsBtn', SecondsConvert);
    secondsButtonElement.addEventListener('click', SecondsConvert);
}