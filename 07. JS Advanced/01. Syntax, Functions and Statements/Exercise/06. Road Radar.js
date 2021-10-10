function CameraForSpeedLimit(speed, area) {

    let speedlimit;

    switch(area) {
  case 'city':
    speedlimit = 50;
    break;
  case 'residential':
    speedlimit = 20;
    break;
  case 'interstate':
    speedlimit = 90;
    break;
  case 'motorway':
    speedlimit = 130;
    break;
  default:
    }

    let speedDifference = Math.abs(speed - speedlimit);
    
    if(speedlimit >= speed) {
        console.log(`Driving ${speed} km/h in a ${speedlimit} zone`);
    }
    else {
        if(speedDifference <= 20) {
            console.log(`The speed is ${speedDifference} km/h faster than the allowed speed of ${speedlimit} - speeding`);
        }
        else if(speedDifference <= 40) {
            console.log(`The speed is ${speedDifference} km/h faster than the allowed speed of ${speedlimit} - excessive speeding`);
        }
        else {
            console.log(`The speed is ${speedDifference} km/h faster than the allowed speed of ${speedlimit} - reckless driving`);
        }
    }
}