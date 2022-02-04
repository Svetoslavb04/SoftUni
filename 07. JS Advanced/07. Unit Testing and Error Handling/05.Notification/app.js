function notify(message) {
  let notification = document.getElementById('notification');
  notification.textContent = message;
  notification.style.display = 'block';

  notification.addEventListener('click', (e) => {
    e.currentTarget.style.display ='none';
  })
}