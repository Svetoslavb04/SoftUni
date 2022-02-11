function solution() {
    class Employee {
        salary = 0;
        tasks = [];

        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        work() {
            let currentTask = this.tasks[0];

            console.log(currentTask.replace('{name}', this.name));

            this.tasks.push(this.tasks.shift());
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);

            this.tasks = ['{name} is working on a simple task.'];
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);

            this.tasks = ['{name} is working on a complicated task.'
                , '{name} is taking time off work.'
                , '{name} is supervising junior workers.'];
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);

            this.tasks = ['{name} scheduled a meeting.'
                , '{name} is preparing a quarterly report.'];
        }

        dividend = 0;

        collectSalary() {
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager
    };
}