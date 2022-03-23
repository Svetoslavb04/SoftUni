import { html } from '../../node_modules/lit-html/lit-html.js';

export const homeTemplate = () => html`
    <div id="welcome-container">
        <h1>Welcome To Car Tube</h1>
        <img class="hero" src="/images/car-png.webp" alt="carIntro">
        <h2>To see all the listings click the link below:</h2>
        <div>
            <a href="/listings/all" class="button">Listings</a>
        </div>
    </div>`;

export function renderHomeView(ctx) {
    ctx.render(homeTemplate());
}