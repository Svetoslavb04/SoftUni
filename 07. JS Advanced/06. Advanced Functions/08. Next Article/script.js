function getArticleGenerator(articles) {
    let allArticles = articles;

    return function showArticle() {
        if (allArticles.length > 0) {
            let divElement = document.getElementById('content');
            let articleElement = document.createElement('article');
            articleElement.textContent = allArticles.shift();
            divElement.appendChild(articleElement);
        } else {
            
        }
    }
}
