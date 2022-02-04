let expect = require('chai').expect;

let isOddOrEven = require('../isOddOrEven.js');

describe('Tests for odd or even length of string', () => {
    it('Should return undefined when the input is not string', () => {
        let input = 24;
    
        let result = isOddOrEven(input);
    
        expect(result).to.be.undefined;
    });
    it('Should return even when the string`s length is even', () => {
        let input = '24';
    
        let result = isOddOrEven(input);
    
        expect(result).to.be.equal('even');
    });
    it('Should return even when the string`s length is odd', () => {
        let input = 'odd';
    
        let result = isOddOrEven(input);
    
        expect(result).to.be.equal('odd');
    });
})
