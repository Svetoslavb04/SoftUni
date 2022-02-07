class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (!name || !salary || !position || !department || Number(salary) < 0) {
            throw new Error('Invalid input!');
        }

        let employee = {
            name
            , salary
            , position
        }

        if (Object.keys(this.departments).includes(department)) {
            this.departments[department].push(employee);
        } else {
            this.departments[department] = [];
            this.departments[department].push(employee); 
        }

        this.departments[department].sort((a, b) => {
            if (b.salary === a.salary) {
                return a.name.localeCompare(b.name)
            } else {
                return b.salary - a.salary;
            }
        });

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let departmentsHighestAvgSalaries = Array.from(Object.keys(this.departments))
            .map(deptName => {
                let deptAvgSal = this.departments[deptName]
                .reduce((acc, currKvp) => {
                    return Number(acc) + Number(currKvp.salary)
                }, 0) / this.departments[deptName].length;

                return [deptName, deptAvgSal];
            });

        departmentsHighestAvgSalaries.sort((a, b) => b[1] - a[1]);

        let output = [];
        output.push(`Best Department is: ${departmentsHighestAvgSalaries[0][0]}`);
        output.push(`Average salary: ${departmentsHighestAvgSalaries[0][1].toFixed(2)}`);
        for (const employee of this.departments[departmentsHighestAvgSalaries[0][0]]) {
            output.push(`${employee.name} ${employee.salary} ${employee.position}`);
        }

        return output.join('\n');
    }
}