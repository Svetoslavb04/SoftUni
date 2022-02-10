(function solve() {

    String.prototype.ensureStart = function(str) {
        if (this.startsWith(str)) {
            return this.toString();
        } else {
            return str + this.toString();
        }
    }

    String.prototype.ensureEnd = function(str) {
        if (this.endsWith(str)) {
            return this.toString();
        } else {
            return this.toString() + str;
        }
    }

    String.prototype.isEmpty = function() {
        if (this.length == 0) {
            return true;
        } else {
            return false;
        }
    }

    String.prototype.truncate = function(n) {

        if(Number(n) < 4) {

            return ".".repeat(Number(n));

        }

        if (Number(n) >= this.length) {
                
            return this.toString();

        }
        
        let lastWhitespace = this.toString().substring(0, n - 2).lastIndexOf(" ");

        return lastWhitespace !== -1 
            ? `${this.toString().substring(0, lastWhitespace)}...` 
            : `${this.toString().substring(0, n - 3)}...`;
        
    }

    String.format = function(string, ...params) {

        for (let i = 0; i < params.length; i++) {
            string = string.replace(`{${i}}`, params[i]);
        }

        return string;

    }
})();