class List {
    #list = [];
    constructor() {

    }

    add(value) {
        this.#list.push(value);
        this.size = this.#list.length;
        return this.#list.sort((a, b) => a - b);
    }

    remove(index) {
        if (index > -1) {
            this.#list.splice(index, 1);
            this.size = this.#list.length;
            return this.size;
        } else {
            throw new Error(`Invalid index: ${value}`)
        }
    }

    get(index) {
        if (index >= 0 && index <= this.#list.length - 1) {
            return this.#list[index];
        } else {
            throw new Error(`Invalid index: ${value}`)
        }
    }

    size = this.#list.length;
}