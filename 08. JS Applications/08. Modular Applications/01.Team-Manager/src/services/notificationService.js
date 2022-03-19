let notification = document.querySelector('.overlay');
let notificationMessage = notification.querySelector('p');
let notificationButton = notification.querySelector('a');

export function popNotification(message, buttonHandler) {
    notification.style.display = 'block';

    notificationMessage.textContent = message
    notificationButton.textContent = 'Hide';
    notificationButton.addEventListener('click', buttonHandler);
}