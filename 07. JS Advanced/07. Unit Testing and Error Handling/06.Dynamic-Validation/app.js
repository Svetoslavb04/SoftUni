function validate() {
    let emailInputElement = document.getElementById('email');

    function isValid() {
        let emailRegex = /[a-z]+@[a-z]+.[a-z]+/;
        
        let userInput = emailInputElement.value;

        if (!userInput.match(emailRegex)) {
            emailInputElement.classList.add('error');
        } else {
           emailInputElement.classList.remove('error');
        }
    }

    emailInputElement.addEventListener('change', isValid);
}