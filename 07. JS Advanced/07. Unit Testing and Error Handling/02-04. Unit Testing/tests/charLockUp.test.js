let expect = require('chai').expect;
let lookupChar = require('../charLookUp.js');

describe('Char look up test group', () => {
    it('Return undefined if first arg isn`t string or second arg isn`t number or second arg is floating-point number', () => {

        let resultWithInvalidFirstAefResult = lookupChar(23, 3);
        let resultWithInvalidSecondArgResult = lookupChar('hello', 'NaN');
        let resultWithFloatingPointIndex = lookupChar('firstArg', 3.2);

        expect(resultWithInvalidFirstAefResult).to.be.equal(undefined);
        expect(resultWithInvalidSecondArgResult).to.be.equal(undefined);
        expect(resultWithFloatingPointIndex).to.be.equal(undefined);
    });
    it('Returns Incorrect index if index is bigger or equal to the string length or a negative number', () => {
        let stringBeingLockedUp = 'JS beats C#';

        let resultWithNegativeIndex = lookupChar(stringBeingLockedUp, -1);
        let resultWithIndexEqualToStringsLength = lookupChar(stringBeingLockedUp, stringBeingLockedUp.length);
        let resultWithIndexGreaterThanStringsLength = lookupChar(stringBeingLockedUp, stringBeingLockedUp.length + 1);

        expect(resultWithNegativeIndex).to.be.equal('Incorrect index');
        expect(resultWithIndexEqualToStringsLength).to.be.equal('Incorrect index');
        expect(resultWithIndexGreaterThanStringsLength).to.be.equal('Incorrect index');
    });
    it('Returns char at given index when the arguments are valid', () => {
        let stringBeingLockedUp = 'JS beats C#';

        let resultWithValidArguments = lookupChar(stringBeingLockedUp, 1);

        expect(resultWithValidArguments).to.be.equal('S');
    });
})

