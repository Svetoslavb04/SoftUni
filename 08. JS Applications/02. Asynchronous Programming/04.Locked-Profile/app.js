async function lockedProfile() {

    let users = await getUsers();

    async function getUsers() {
        try {
            let usersObj = await fetch('http://localhost:3030/jsonstore/advanced/profiles')
                            .then((res) => res.json())
                            .then((data) => data);

            let usersArr = [];

            for (const userKey of Object.keys(usersObj)) {
                usersArr.push({
                username: usersObj[userKey].username,
                email: usersObj[userKey].email,
                age: usersObj[userKey].age
                });

            }

            return usersArr;
        } catch (error) {
            console.log(error);
        }
    }

    for (const user of users) {
        let cardDiv = document.createElement('div');
        cardDiv.classList.add('profile');

        cardDiv.innerHTML = `<img src="./iconProfile2.png" class="userIcon" />
        <label>Lock</label>
        <input type="radio" name="user1Locked" value="lock" checked>
        <label>Unlock</label>
        <input type="radio" name="user1Locked" value="unlock"><br>
        <hr>
        <label>Username</label>
        <input type="text" name="user1Username" value="${user.username}" disabled readonly />
        <div class="hiddenInfo">
            <hr>
            <label>Email:</label>
            <input type="email" name="user1Email" value="${user.email}" disabled readonly />
            <label>Age:</label>
            <input type="email" name="user1Age" value="${user.age}" disabled readonly />
        </div>
        
        <button>Show more</button>`;

        document.getElementById('main')
            .appendChild(cardDiv);

        cardDiv.children[2].checked = true;


        cardDiv.lastChild
            .addEventListener('click', (e) => {
                if(e.target.parentNode.children[2].checked) {

                    return;
        
                }
                
                if(e.target.textContent === 'Show more') {
                    
                    e.target.parentNode.children[9].style.display = 'block';
                    e.target.parentNode.children[9].classList.remove('hiddenInfo');
                    e.target.parentNode.children[9].children[2].style.display = 'block';
                    e.target.parentNode.children[9].children[3].style.display = 'block';
                    e.target.textContent = 'Hide it';
        
                } else {
        
                    e.target.parentNode.children[9].style.display = 'none';
                    e.target.parentNode.children[9].classList.add('hiddenInfo');
        
                    e.target.textContent = 'Show more'
        
                }
            })
    }
}