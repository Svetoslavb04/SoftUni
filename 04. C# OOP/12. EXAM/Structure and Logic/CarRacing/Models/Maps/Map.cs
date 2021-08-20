using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            else if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if(!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            else
            {
                double chanceOfWinningRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience;

                if (racerOne.RacingBehavior == "strict")
                {
                    chanceOfWinningRacerOne = chanceOfWinningRacerOne * 1.2;
                }
                else
                {
                    chanceOfWinningRacerOne = chanceOfWinningRacerOne * 1.1;
                }

                double chanceOfWinningRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;

                if (racerOne.RacingBehavior == "strict")
                {
                    chanceOfWinningRacerTwo = chanceOfWinningRacerTwo * 1.2;
                }
                else
                {
                    chanceOfWinningRacerTwo = chanceOfWinningRacerTwo * 1.1;
                }

                racerOne.Race();
                racerTwo.Race();

                if (chanceOfWinningRacerOne > chanceOfWinningRacerTwo)
                {
                    return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
                }
                else
                {
                    return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
                }
            }
        }
    }
}
