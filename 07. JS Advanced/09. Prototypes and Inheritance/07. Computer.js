/*function createComputerHierarchy() {

    function Keyboard(manufacturer, responseTime) {
        this.manufacturer = manufacturer;
        this.responseTime = Number(responseTime);
    }

    function Monitor(manufacturer, width, height) {
        this.manufacturer = manufacturer;
        this.width = Number(width);
        this.height = Number(height);
    }

    function Battery(manufacturer, expectedLife) {
        this.manufacturer = manufacturer;
        this.expectedLife = Number(expectedLife);
    }

    function Computer(manufacturer, processorSpeed, ram, hardDiskSpace) {

        if (this.constructor == Computer) {
            throw new Error("Abstract classes cannot be initialized");
        }

        this.manufacturer = manufacturer;
        this.processorSpeed = Number(processorSpeed);
        this.ram = Number(ram);
        this.hardDiskSpace = Number(hardDiskSpace);
    }

    function Laptop(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
        Computer.call(this, manufacturer, processorSpeed, ram, hardDiskSpace);

        this.weight = Number(weight);
        this.color = color;

        if (battery instanceof Battery) {
            this._battery = battery
        } else {
            throw new TypeError("I should receive a real battery");
        }
    }

    Laptop.prototype = Object.create(Computer.prototype);
    Laptop.prototype.constructor = Laptop;

    function Desktop(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
        Computer.call(this, manufacturer, processorSpeed, ram, hardDiskSpace);

        if (keyboard instanceof Keyboard) {
            this._keyboard = keyboard
        } else {
            throw new TypeError("I should receive a real keyboard");
        }

        if (monitor instanceof Monitor) {
            this._monitor = monitor
        } else {
            throw new TypeError("I should receive a real monitor");
        }
    }

    Desktop.prototype = Object.create(Computer.prototype);
    Desktop.prototype.constructor = Desktop;


    return {
        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop
    }
}*/ //That was the older way

function solve() {
    class Keyboard{

        constructor(manufacturer, responseTime) {

            this.manufacturer = manufacturer;
            this.responseTime = Number(responseTime);

        }

    }

    class Monitor{

        constructor(manufacturer, width, height) {

            this.manufacturer = manufacturer;
            this.width = Number(width);
            this.height = Number(height);

        }

    }

    class Battery{

        constructor(manufacturer, expectedLife) {

            this.manufacturer = manufacturer;
            this.expectedLife = Number(expectedLife);

        }

    }

    class Computer {

        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {

            if (new.target === Computer) {

                throw new Error("Can't initialize an instance of Computer");

            }

            this.manufacturer = manufacturer;
            this.processorSpeed = Number(processorSpeed);
            this.ram = Number(ram);
            this.hardDiskSpace = Number(hardDiskSpace);

        }

    }

    class Laptop extends Computer {

        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {

            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = Number(weight);
            this.color = color;
            this.battery = battery;

        }

        get battery() {

            return this._battery;

        }

        set battery(value) {

            if (!(value instanceof Battery)) {

                throw new TypeError('Invalid argument passed for battery');

            }

            this._battery = value;
        }
    }

    class Desktop extends Computer {

        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {

            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.keyboard = keyboard;
            this.monitor = monitor;

        }

        get keyboard() {

            return this._keyboard;

        }

        set keyboard(value) {

            if (!(value instanceof Keyboard)) {

                throw new TypeError('Invalid argument passed for keyboard');

            }

            this._keyboard = value;
        }

        get monitor() {

            return this._monitor;

        }

        set monitor(value) {

            if (!(value instanceof Monitor)) {

                throw new TypeError('Invalid argument passed for monitor');

            }

            this._monitor = value;

        }

    }

    return {

        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop

    }
}