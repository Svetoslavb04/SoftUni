async function solution() {
    var articles = await getArticles();

    async function getArticles() {
        try {
            let articles = await fetch('http://localhost:3030/jsonstore/advanced/articles/list')
                .then((res) => res.json())
                .then((data) => data);

                return articles;
        } catch (error) {
            
        }
    }
    console.log(articles);
    articles.forEach(article => {
        let accordionDiv = document.createElement('div');
        accordionDiv.classList.add('accordion');

        accordionDiv.innerHTML = `<div class="head">
            <span>${article['title']}</span>
            <button class="button" id="${article['_id']}">More</button>
        </div>
        <div class="extra">
            <p></p>
        </div>`;

    document.getElementById('main')
        .appendChild(accordionDiv);

    accordionDiv.children[1].style.display = 'none';

    async function showInfo() {
        try {
            if (accordionDiv.children[0].children[1].textContent == 'More') {
                let extra = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${article['_id']}`)
                .then((res) => res.json())
                .then((data) => data);

                accordionDiv.children[1].children[0].textContent = extra['content'];

                accordionDiv.children[0].children[1].textContent = 'Less';
                accordionDiv.children[1].style.display = 'inline';
            } else {
                accordionDiv.children[1].style.display = 'none';
                accordionDiv.children[0].children[1].textContent = 'More';
            }
                
        } catch (error) {
            
        }
    }

    accordionDiv
        .children[0]
        .children[1]
        .addEventListener('click', showInfo);
    });
}

solution();