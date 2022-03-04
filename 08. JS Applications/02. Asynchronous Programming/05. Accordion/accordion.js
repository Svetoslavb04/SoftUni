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

        accordionDiv.innerHTML = `<div class="accordion">
        <div class="head">
            <span>${article['title']}</span>
            <button class="button" id="${article['_id']}">More</button>
        </div>
        <div class="extra">
            <p></p>
        </div>
    </div>`;

    document.getElementById('main')
        .appendChild(accordionDiv);
    });

    async function showInfo() {
        
    }

    accordionDiv
        .children[1]
        .children[0]
        .addEventListener('click', )
}

solution();