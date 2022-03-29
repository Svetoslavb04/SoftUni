import { html } from "../../node_modules/lit-html/lit-html.js";
import { createGame } from "../services/gameService.js";
import page from '../../node_modules/page/page.mjs';

const createTemplate = () => html`
    <section id="create-page" class="auth">
        <form id="create" @submit=${createGameHandler}>
            <div class="container">

                <h1>Create Game</h1>
                <label for="leg-title">Legendary title:</label>
                <input type="text" id="title" name="title" placeholder="Enter game title..." required>

                <label for="category">Category:</label>
                <input type="text" id="category" name="category" placeholder="Enter game category..." required>

                <label for="levels">MaxLevel:</label>
                <input type="number" id="maxLevel" name="maxLevel" min="1" placeholder="1" required>

                <label for="game-img">Image:</label>
                <input type="text" id="imageUrl" name="imageUrl" placeholder="Upload a photo..." required>

                <label for="summary">Summary:</label>
                <textarea name="summary" id="summary" required></textarea>
                <input class="btn submit" type="submit" value="Create Game">
            </div>
        </form>
    </section>`;

export function renderCreateView(ctx) {
    ctx.render(createTemplate());
}

async function createGameHandler(e) {
    e.preventDefault();

    let formdata = new FormData(e.currentTarget);

    let game = {
        title: formdata.get('title'),
        category: formdata.get('category'),
        maxLevel: Number(formdata.get('maxLevel')),
        imageUrl: formdata.get('imageUrl'),
        summary: formdata.get('summary'),
    };

    const res = await createGame(game);
    
    page.redirect('/');
}