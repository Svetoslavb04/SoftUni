import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAllGames } from '../services/gameService.js';

const allGamesTemplate = (games) => html`
    <section id="catalog-page">
            <h1>All Games</h1>
            <!-- Display div: with information about every game (if any) -->
            ${
                games.length > 0 ? html`${games.map(g => html`
                <div class="allGames">
                    <div class="allGames-info">
                        <img src="${g.imageUrl}">
                        <h6>${g.category}</h6>
                        <h2>${g.title}</h2>
                        <a href="/games/${g._id}" class="details-button">Details</a>
                    </div>
                </div>`)}` 
                : html`<h3 class="no-articles">No articles yet</h3>`
            }
            
    </section>`;

export async function renderAllGamesView(ctx) {
    const games = await getAllGames();

    ctx.render(allGamesTemplate(games));
}