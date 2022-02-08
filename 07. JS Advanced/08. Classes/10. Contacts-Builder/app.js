class Contact {
    #firstName;
    #lastName;
    #phone;
    #email;
    #button;
    #component;

    constructor(firstName, lastName, phone, email) {
        this.#firstName = firstName;
        this.#lastName = lastName;
        this.#phone = phone;
        this.#email = email;

        this.#component = document.createElement('article');
        this.#component.innerHTML = `<div class="title">${firstName} ${lastName}<button>&#8505;</button></div>
        <div class="info">
            <span>&phone; ${phone}</span>
            <span>&#9993; ${email}</span>
        </div>`;
        
        this.#button = this.#component.querySelector('button');
        this.#button.addEventListener('click', showMore);

        this.#component.querySelector('.info').style.display = 'none';

        function showMore(e) {
            let info = e.currentTarget.parentElement.parentElement.querySelector('.info');

            if (info.style.display == 'none') {
                info.style.display = 'block';
            } else {
                info.style.display = 'none';
            }
        }

        this.online = false;
    }

    set online(value) {
        if (value) {
            this.#component.querySelector('.title').classList.add('online');
        } else {
            this.#component.querySelector('.title').classList.remove('online');
        }
    }

    render(id) {
        let item = document.querySelector(`#${id}`);
        item.appendChild(this.#component);
    }
}

let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
  ];
  contacts.forEach(c => c.render('main'));
  
  setTimeout(() => contacts[1].online = true, 2000);