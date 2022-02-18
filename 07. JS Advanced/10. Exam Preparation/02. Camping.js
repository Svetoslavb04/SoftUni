class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location
        this.priceForTheCamp = { "child": 150, "student": 300, "collegian": 500 };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        let participants = this.listOfParticipants
            .reduce((acc, v) => {
                acc.push(v.name);

                return acc;
            }, [])

        let keys = Array.from(Object.keys(this.priceForTheCamp));
        if (!keys.includes(condition)) {
            throw new Error("Unsuccessful registration at the camp.");
        }
        if (participants.includes(name)) {
            return `The ${name} is already registered at the camp.`;
        }
        if (money < this.priceForTheCamp[condition]) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push({
            name,
            condition,
            power: 100,
            wins: 0
        });

        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {
        let indexOfParticipant = this.listOfParticipants.findIndex(p => p.name == name);

        if (indexOfParticipant == -1) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        this.listOfParticipants.splice(indexOfParticipant, 1);

        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, participant1, participant2 = null) {

        if (typeOfGame == 'WaterBalloonFights') {
            let indexOfParticipant1 = this.listOfParticipants.findIndex(p => p.name == participant1);
            let indexOfParticipant2 = this.listOfParticipants.findIndex(p => p.name == participant2);

            if (indexOfParticipant1 == -1 || indexOfParticipant2 == -1) {
                throw new Error(`Invalid entered name/s.`);
            }

            let participant1Obj = this.listOfParticipants[indexOfParticipant1];
            let participant2Obj = this.listOfParticipants[indexOfParticipant2];

            if (participant1Obj.condition != participant2Obj.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            if (participant1Obj.power > participant2Obj.power) {

                participant1Obj.wins++;
                return `The ${participant1Obj.name} is winner in the game ${typeOfGame}.`;

            } else if (participant1Obj.power < participant2Obj.power) {

                participant2Obj.wins++;
                return `The ${participant2Obj.name} is winner in the game ${typeOfGame}.`;

            } else { return `There is no winner.`; }

        } else if (typeOfGame == 'Battleship') {
            let indexOfParticipant1 = this.listOfParticipants.findIndex(p => p.name == participant1);

            if (indexOfParticipant1 == -1) {
                throw new Error(`Invalid entered name/s.`);
            }

            let participant1Obj = this.listOfParticipants[indexOfParticipant1];

            participant1Obj.power += 20;

            return `The ${participant1Obj.name} successfully completed the game ${typeOfGame}.`;
        }
    }

    toString() {
        let result = [];

        result.push(`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`);

        for (const player of this.listOfParticipants.sort((a,b) => b.wins - a.wins)) {
            result.push(`${player.name} - ${player.condition} - ${player.power} - ${player.wins}`);
        }

        return result.join('\n');
    }
}

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
try {
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
    
} catch (error) {
    console.log(error);
}
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());



