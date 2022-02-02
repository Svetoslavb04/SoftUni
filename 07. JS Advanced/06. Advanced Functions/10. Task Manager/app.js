function solve() {
    let addButtonElement = document.querySelector('#add');
    addButtonElement.addEventListener('click', addTaskHandler);


    function addTaskHandler(e) {
        e.preventDefault();
        let taskNameElement = document.querySelector('#task');
        let descriptionElement = document.querySelector('#description');
        let dueDateElement = document.querySelector('#date');

        let taskName = taskNameElement.value;
        let description = descriptionElement.value;
        let dueDate = dueDateElement.value;

        if (taskName == '' || description == '' || dueDate == '') {
            return;
        }

        let articleElement = document.createElement('article');

        let taskNameHeaderElement = document.createElement('h3');
        taskNameHeaderElement.textContent = taskName;

        let descriptionParagraphElement = document.createElement('p');
        descriptionParagraphElement.textContent = `Description: ${description}`;

        let dueDateParagraphElement = document.createElement('p');
        dueDateParagraphElement.textContent = `Due Date: ${dueDate}`;

        let divElement = document.createElement('div');
        divElement.classList.add('flex');

        let startButtonElement = document.createElement('button');
        startButtonElement.classList.add('green');
        startButtonElement.textContent = 'Start';

        let deleteButtonElement = document.createElement('button');
        deleteButtonElement.classList.add('red');
        deleteButtonElement.textContent = 'Delete';

        articleElement.appendChild(taskNameHeaderElement);
        articleElement.appendChild(descriptionParagraphElement);
        articleElement.appendChild(dueDateParagraphElement);
        divElement.appendChild(startButtonElement);
        divElement.appendChild(deleteButtonElement);
        articleElement.appendChild(divElement);

        let openTasks = document.querySelector('section:nth-child(2) div:nth-child(2)');
        openTasks.appendChild(articleElement);

        startButtonElement.addEventListener('click', startHandler);
        deleteButtonElement.addEventListener('click', () => {
            articleElement.remove();
        })

        function startHandler() {
            let finishButtonElement = startButtonElement.cloneNode(false);
            finishButtonElement.classList.remove('green');
            finishButtonElement.classList.add('orange');
            finishButtonElement.textContent = 'Finish';

            startButtonElement.remove();
            deleteButtonElement.remove();

            divElement.appendChild(deleteButtonElement);
            divElement.appendChild(finishButtonElement);

            articleElement.remove();

            let inProgressTasks = document.querySelector('section:nth-child(3) div:nth-child(2)');
            inProgressTasks.appendChild(articleElement);

            finishButtonElement.addEventListener('click', finishHandler);

            function finishHandler() {
                divElement.remove();
                articleElement.remove();
                let completedTasks = document.querySelector('section:nth-child(4) div:nth-child(2)');
                completedTasks.appendChild(articleElement);
            }
        }

        taskNameElement.value = '';
        descriptionElement.value = '';
        dueDateElement.value = '';
    }
}