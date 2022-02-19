let expect = require('chai').expect;
let flowerShop = require('./flowerShop.js');

describe("FlowerShop Tests", function () {
    describe("Calculate price of flowers method tests", function () {
        it("Test for a proper behaviour with valid args", function () {
            expect(flowerShop.calcPriceOfFlowers('rose', 5, 5)).to.be.equal(`You need $${(5 * 5).toFixed(2)} to buy rose!`);
        });
        it("Throw error on invalid args", function () {
            expect(() => flowerShop.calcPriceOfFlowers(5, 5, 5)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('rose', '5', 5)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('rose', 5, '5')).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('rose', 5.5, 5)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('rose', 5, 5.5)).to.throw('Invalid input!');
        });
    });
    describe("Calculate check available flowers method tests", function () {
        it("Test for a proper behaviour with valid args", function () {
            expect(flowerShop.checkFlowersAvailable('rose', ['rose'])).to.be.equal(`The rose are available!`);
            expect(flowerShop.checkFlowersAvailable('ose', ['rose', 'orhid'])).to.be.equal(`The ose are sold! You need to purchase more!`);
        });
    });
    describe("Selling flowers method tests", function () {
        it("Test for a proper behaviour with valid args", function () {
            expect(flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 0)).not.to.include('Rose');
            expect(flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 1)).not.to.include('Lily');
            expect(flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 0)).to.equal('Lily / Orchid');
        });
        it("Throw error on invalid args", function () {
            expect(() => flowerShop.sellFlowers('hi', 1)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 'hi')).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], -5)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 6)).to.throw('Invalid input!');
        });
    });
});
