function TimeToWalk(steps, stepLength, speed) {
 
    let distanceToWalk = steps * stepLength;    
    const speedInMetersToSeconds = speed * 1000 / 3600;    
    let timeToComplete = distanceToWalk / speedInMetersToSeconds;  
    timeToComplete += parseInt((distanceToWalk / 500)) * 60;
    
    let seconds = Math.round(timeToComplete % 60);
    let minutes = parseInt(timeToComplete / 60);
    let hours = (parseInt(minutes / 60));
    
    let strSeconds;
    let strMinutes;
    let strHours;
 
    if(seconds < 10) {
        strSeconds = '0' + seconds;
    }
    else {
        strSeconds = seconds;
    }
    if(minutes < 10) {
        strMinutes = '0' + minutes;
    }
    else {
        strMinutes = minutes;
    }
    if(hours < 10) {
        strHours = '0' + hours;
    }
    else {
        strHours = hours;
    }
  
    console.log(`${strHours}:${strMinutes}:${strSeconds}`);
}