import { html } from "../node_modules/lit-html/lit-html.js";
import { getUser } from "../services/authService.js";
import { getOne, isAEntityLikedByUser, likeEntity, totalLikesOfEntity } from "../services/entityService.js";

const detailsTemplate = (ctx, book, totalLikes, isLiked) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}"></p>
        <div class="actions">
            ${getUser()._id == book._ownerId
        ? html`<a class="button" href="/books/${book._id}/edit">Edit</a>
                       <a class="button" href="/books/${book._id}/delete">Delete</a>`
        : html``
    }
            
            ${(ctx.isAuthenticated() && book._ownerId != getUser()._id && !isLiked)
        ? html`<a class="button" @click=${likeHandler.bind(null, ctx, totalLikes)}>Like</a>`
        : html``
    }
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${totalLikes}</span>
            </div>
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${book.description}</p>
    </div>
</section>`;

export async function renderDetailsView(ctx) {
    const book = await getOne(ctx.params._id);

    const totalLikes = await totalLikesOfEntity(ctx.params._id);
    
    if (ctx.isAuthenticated()) {
        const likesCount = await isAEntityLikedByUser(ctx.params._id, getUser()._id);

        let isLiked = false;
        if (likesCount > 0) {
            isLiked = true;
        }

        ctx.render(detailsTemplate(ctx, book, totalLikes, isLiked));

        return;
    }

    ctx.render(detailsTemplate(ctx, book, totalLikes, true));
}

function likeHandler(ctx, totalLikes, e) {
    e.preventDefault();

    likeEntity(ctx.params._id)
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            }
            else {
                let likesElement = document.getElementById('total-likes');
                likesElement.textContent = `Likes: ${totalLikes + 1}`;

                e.target.remove();
            }
        })
}