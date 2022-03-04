function attachEvents() {
    let loadButtonElement = document.getElementById('btnLoadPosts');
    let viewButtonElement = document.getElementById('btnViewPost');

    loadButtonElement.addEventListener('click', loadPosts);
    viewButtonElement.addEventListener('click', viewComments);

    let allPostsData = [];

    async function loadPosts() {
        try {
            allPostsData = await fetch('http://localhost:3030/jsonstore/blog/posts')
            .then((res) => res.json())
            .then(function (data) {
                let postsArray = [];
                Array.from(Object.keys(data)).forEach(k => {
                    postsArray.push({
                       id: data[k]['id'],
                       title: data[k]['title'],
                       body: data[k]['body']
                    });
                });

                return postsArray;
            });

            let allPostsElement = document.getElementById('posts');

            allPostsData.forEach(p => {
                let optionElement = document.createElement('option');
                optionElement.value = p.id;
                optionElement.textContent = p.title;

                allPostsElement.appendChild(optionElement);
            });
        } catch (error) {
            console.log(error);
        }
    }

    async function viewComments() {
        try {
            let selectedOptionId = document.getElementById('posts')
                .value;

            let allCommentsForCurrentPost = await fetch('http://localhost:3030/jsonstore/blog/comments/')
                .then((res) => res.json())
                .then(function(data) {
                    let posts = [];

                    Array.from(Object.keys(data)).forEach(k => {
                        if (data[k].postId == selectedOptionId) {
                            posts.push(data[k].text);
                        }
                    });

                    return posts;
                });
            
            document.getElementById('post-title').textContent = allPostsData.find(p => p.id == selectedOptionId).title;
            document.getElementById('post-body').textContent = allPostsData.find(p => p.id == selectedOptionId).body;
            
            let commentsElement = document.getElementById('post-comments');
            while (commentsElement.firstChild) {
                commentsElement.removeChild(commentsElement.firstChild);
            }
        
            allCommentsForCurrentPost.forEach(c => {
                let liElement = document.createElement('li');
                liElement.textContent = c;

                commentsElement.appendChild(liElement);
            });
        } catch (error) {
            
        }
    }
}

attachEvents();