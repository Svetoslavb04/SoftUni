function generateReport() {
    let checkboxElements = document.querySelectorAll('thead input');
    let checkboxes = Array.from(checkboxElements);
    
    let rows = [];

    let rowsCount = Array.from(document.querySelectorAll('tbody tr')).length;

    for (let i = 0; i < rowsCount; i++) {
        rows[i] = {};

        for (let j = 0; j < checkboxes.length; j++) {
            if (checkboxes[j].checked) {
                let contentElement = document.querySelector(`tbody tr:nth-child(${i+1}) td:nth-child(${j+1})`);
                let content = contentElement.textContent;
                rows[i][checkboxes[j].name] = content;
            }
        }
    }

    let textAreaElement = document.querySelector('textarea');
    textAreaElement.value = JSON.stringify(rows);
}