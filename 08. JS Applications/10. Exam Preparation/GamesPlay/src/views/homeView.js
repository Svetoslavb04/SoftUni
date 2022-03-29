import { html } from "../../node_modules/lit-html/lit-html.js";
import { getLatestGames } from "../services/gameService.js";

const homeTempate = (games) => html`
    <section id="welcome-world">
            <div class="welcome-message">
                <h2>ALL new games are</h2>
                <h3>Only in GamesPlay</h3>
            </div>
            <img src="./images/four_slider_img01.png" alt="hero">

            <div id="home-page">
                <h1>Latest Games</h1>
                ${
                    games.length > 0 ?
                        html`${games.map(g => html`<div class="game">
                                                        <div class="image-wrap">
                                                            <img src="${g.imageUrl}">
                                                        </div>
                                                        <h3>${g.title}</h3>
                                                        <div class="rating">
                                                            <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
                                                        </div>
                                                        <div class="data-buttons">
                                                            <a href="/games/${g._id}" class="btn details-btn">Details</a>
                                                        </div>
                                                    </div>`)}`
                        : html`<p class="no-articles">No games yet</p>`
                }
            </div>
    </section>`;

export async function renderHomeView(ctx) {
    const games = await getLatestGames();

    ctx.render(homeTempate(games.slice(0, 3)));
}