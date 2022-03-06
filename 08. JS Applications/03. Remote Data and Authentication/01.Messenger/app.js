function attachEvents() {
    let sendButton = document.getElementById('submit');
    let refreshButton = document.getElementById('refresh');

    sendButton.addEventListener('click', sendMessage);
    refreshButton.addEventListener('click', refreshMessages);
}

function sendMessage() {
    let name = document.querySelector('#controls > input:nth-child(2)')
        .value;
    let message = document.querySelector('#controls > input:nth-child(5)')
        .value;

    fetch(`http://localhost:3030/jsonstore/messenger`, {
        method: 'POST',
        body: JSON.stringify({
            author: name,
            content: message,
        })
    })
}

function refreshMessages() {
    let textAreaElement = document.getElementById('messages');
    textAreaElement.textContent = '';
    
    fetch(`http://localhost:3030/jsonstore/messenger`)
        .then((res) => res.json())
        .then((data) => {
            Object.values(data).forEach(m => {
                textAreaElement.textContent += `${m.author}: ${m.content} \n` 
            });
        })
}

attachEvents();