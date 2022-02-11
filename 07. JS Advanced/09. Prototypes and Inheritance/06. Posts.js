function solution() {
    class Post {

        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            let result = [];
            result.push(`Post: ${this.title}`);
            result.push(`Content: ${this.content}`);

            return result.join('\n');
        }
    }

    class SocialMediaPost extends Post {
        constructor(name, age, likes, dislikes) {
            super(name, age);

            this.likes = Number(likes);
            this.dislikes = Number(dislikes);
        }

        comments = [];
        
        addComment(comment) { this.comments.push(comment); }

        toString() {
            let result = super.toString().split('\n');

            result.push(`Rating: ${this.likes - this.dislikes}`);

            if (this.comments.length != 0) {
                result.push('Comments:')
                for (const comment of this.comments) {
                    result.push(` * ${comment}`)
                }
            }

            return result.join('\n');
        }
    }

    class BlogPost extends Post {
        constructor(name, age, views) {
            super(name, age);

            this.views = views;
        }

        view() {
            this.views++;

            return this;
        }

        toString() {
            let result = super.toString().split('\n');

            result.push(`Views: ${this.views}`);

            return result.join('\n');
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost,
    };
}
