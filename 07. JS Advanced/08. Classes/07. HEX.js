class Hex {
    constructor(number) {
        this.value = number;
    }

    valueOf() { return this.value; }

    toString() { return '0x' + this.value.toString(16).toUpperCase()}

    plus(number) {
        if (number instanceof Hex) {
            return new Hex(this.value + number.valueOf());
        } else {
            return new Hex(this.value + number);
        }
    }

    minus(number) {
        if (number instanceof Hex) {
            return new Hex(this.value - number.valueOf());
        } else {
            return new Hex(this.value - number);
        }
    }
    
    parse(string) {
        return parseInt(string, 16);
    }
}