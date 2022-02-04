let expect = require('chai').expect;
let mathEnforcer = require('../mathEnforcer.js');

describe('Math enforcer test group', () => {
    describe('Add Five test group', () => {
        it('Return undefined when the input is not number', () => {
            let result = mathEnforcer.addFive('five');

            expect(result).to.be.equal(undefined);
        });
        it('Calculates correctly with positive integer', () => {
            let result = mathEnforcer.addFive(5);

            expect(result).to.be.equal(10);
        });
        it('Calculates correctly with negative integer', () => {
            let result = mathEnforcer.addFive(-5);

            expect(result).to.be.equal(0);
        });
        it('Calculates correctly with positive floating-point number', () => {
            let result = mathEnforcer.addFive(5.2);

            expect(result).to.be.closeTo(10.2, 0.01);
        });
        it('Calculates correctly with negative floating-point number', () => {
            let result = mathEnforcer.addFive(-5.2);

            expect(result).to.be.closeTo(-0.2, 0.01);
        });
    });
    describe('Substract ten test group', () => {
        it('Return undefined when the input is not number', () => {
            let result = mathEnforcer.subtractTen('five');

            expect(result).to.be.equal(undefined);
        });
        it('Calculates correctly with positive integer', () => {
            let result = mathEnforcer.subtractTen(5);

            expect(result).to.be.equal(-5);
        });
        it('Calculates correctly with negative integer', () => {
            let result = mathEnforcer.subtractTen(-5);

            expect(result).to.be.equal(-15);
        });
        it('Calculates correctly with positive floating-point number', () => {
            let result = mathEnforcer.subtractTen(5.2);

            expect(result).to.be.closeTo(-4.8, 0.01);
        });
        it('Calculates correctly with negative floating-point number', () => {
            let result = mathEnforcer.subtractTen(-5.2);

            expect(result).to.be.closeTo(-15.2, 0.01);
        });
    });
    describe('Sum test group', () => {
        it('Return undefined when one or both of the arguments aren`t numbers', () => {
            let resultWithInvalidFirstArg = mathEnforcer.sum('five', 5);
            let resultWithInvalidSecondArg = mathEnforcer.sum(5, '5');
            let resultWithInvalidBothArgs = mathEnforcer.sum(5, '5');

            expect(resultWithInvalidFirstArg).to.be.equal(undefined);
            expect(resultWithInvalidSecondArg).to.be.equal(undefined);
            expect(resultWithInvalidBothArgs).to.be.equal(undefined);
        });
        it('Sums correctly with two integers', () => {
            let resultWithPositive = mathEnforcer.sum(5, 8);
            expect(resultWithPositive).to.be.equal(13);

            let resultWithNegative = mathEnforcer.sum(-5, -8);
            expect(resultWithNegative).to.be.equal(-13);

            let resultWithFirstNegativeSecondPostitive = mathEnforcer.sum(-5, 8);
            expect(resultWithFirstNegativeSecondPostitive).to.be.equal(3);

            let resultWithSecondNegativeFirstPostitive = mathEnforcer.sum(5, -8);
            expect(resultWithSecondNegativeFirstPostitive).to.be.equal(-3);
        });
        it('Calculates correctly with two floating-point numbers', () => {
            let resultWithPositive = mathEnforcer.sum(5.5, 5.1);
            expect(resultWithPositive).to.be.closeTo(10.6, 0.01);

            let resultWithNegative = mathEnforcer.sum(-5.1, -8.3);
            expect(resultWithNegative).to.be.closeTo(-13.4, 0.01);

            let resultWithFirstNegativeSecondPostitive = mathEnforcer.sum(-5.4, 8.2);
            expect(resultWithFirstNegativeSecondPostitive).to.be.closeTo(2.8, 0.01);

            let resultWithSecondNegativeFirstPostitive = mathEnforcer.sum(5.4, -8.2);
            expect(resultWithSecondNegativeFirstPostitive).to.be.closeTo(-2.8, 0.01);
        });
    });
})

