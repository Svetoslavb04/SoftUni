function solve(tickets, orderCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let ticketsArray = tickets.map(t => {
        let destination = t.split('|')[0];
        let price = t.split('|')[1];
        let status = t.split('|')[2];

        t = new Ticket(destination, price, status);
        return t;
    });

    if (orderCriteria == 'destination') {
        ticketsArray.sort((a, b) => a.destination.localeCompare(b.destination));
    } else if (orderCriteria == 'price'){
        ticketsArray.sort((a, b) => a.price - b.price);
    }
    else {
        ticketsArray.sort((a, b) => a.status.localeCompare(b.status));
    }    

    return ticketsArray;
}

solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
)