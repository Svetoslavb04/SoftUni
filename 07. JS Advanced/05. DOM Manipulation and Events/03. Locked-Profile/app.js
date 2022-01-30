function lockedProfile() {
    function toggleInfo(e) {
        let unlocked = e.target.parentElement.children[4].checked;

        if (unlocked) {
            if (e.target.textContent == 'Show more') {
                e.target.parentElement.children[9].style.display = 'inline';
                e.target.textContent = 'Hide it';
            } else {
                e.target.parentElement.children[9].style.display = 'none';
                e.target.textContent = 'Show more';
            }
        }
    }

    let buttonsElements = Array.from(document.querySelectorAll('.profile button'));

    buttonsElements.forEach(b => {
        b.addEventListener('click', toggleInfo);
    });
}