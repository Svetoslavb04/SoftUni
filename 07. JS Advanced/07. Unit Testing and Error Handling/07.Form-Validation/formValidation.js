function validate() {
    let usernameInputElement = document.getElementById('username');
    let emailInputElement = document.getElementById('email');
    let passwordInputElement = document.getElementById('password');
    let confirmPasswordInputElement = document.getElementById('confirm-password');
    let companyElement = document.getElementById('company');
    let fieldsetElement = document.getElementById('companyInfo');
    let companyNumberElement = document.getElementById('companyNumber');

    companyElement.addEventListener("change", (e) => {
        if (companyElement.checked) {
            fieldsetElement.style.display = "block";
        } else {
            fieldsetElement.style.display = "none";
        }
    });

    function isValid(event) {
        event.preventDefault();

        let username = usernameInputElement.value;
        let email = emailInputElement.value;
        let password = passwordInputElement.value;
        let confirmPassword = confirmPasswordInputElement.value;
        let isCompany = companyElement.checked;

        let isValid = true;

        if (!username.match(/^[A-Za-z0-9]{3,20}$/)) {
            usernameInputElement.style.borderColor = 'red';
            isValid = false;
        } else {
            usernameInputElement.style.borderColor = "";
        }
        if (!email.match(/^[^@.]+@[^@]*\.[^@]*$/)) {
            emailInputElement.style.borderColor = 'red';
            isValid = false;
        } else {
            emailInputElement.style.borderColor = "";
        }
        if (!password.match(/^[\w]{5,15}$/)) {
            passwordInputElement.style.borderColor = 'red';
            isValid = false;
        } else {
            passwordInputElement.style.borderColor = "";
        }
        if (!confirmPassword.match(/^[\w]{5,15}$/)) {
            confirmPasswordInputElement.style.borderColor = 'red';
            isValid = false;
        } else {
            confirmPasswordInputElement.style.borderColor = "";
        }
        if (password != confirmPassword || password == '' || confirmPassword == '') {
            passwordInputElement.style.borderColor = 'red';
            confirmPasswordInputElement.style.borderColor = 'red';
            isValid = false;
        } else {
        }
        if (isCompany) {
            if (companyNumberElement.value < 1000 || companyNumberElement.value > 9999) {
                companyNumberElement.style.borderColor = 'red';
                isValid = false;
            }
            else {
                companyNumberElement.style.borderColor = "none";
            }
        }

        let validElement = document.getElementById('valid');
        
        if (isValid) {
            validElement.style.display = 'block';
        } else {
            validElement.style.display = 'none';
        }
    }

    let submitButtonElement = document.getElementById('submit');
    submitButtonElement.addEventListener('click', isValid);
}
