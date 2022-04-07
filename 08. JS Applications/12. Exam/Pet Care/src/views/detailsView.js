import { html } from "../../node_modules/lit-html/lit-html.js";
import { getUser } from "../services/authService.js";
import { getOne, isAUserDonatedToEntity, donateToEntity, totalDonationsOfEntity } from "../services/entityService.js";

const detailsTemplate = (ctx, pet, totalDonations, isDonated) => html`
    <section id="detailsPage">
        <div class="details">
            <div class="animalPic">
                <img src="${pet.image}">
            </div>
            <div>
                <div class="animalInfo">
                    <h1>Name: ${pet.name}</h1>
                    <h3>Breed: ${pet.breed}</h3>
                    <h4>Age: ${pet.age}</h4>
                    <h4>Weight: ${pet.weight}</h4>
                    <h4 class="donation">Donation: ${totalDonations * 100}$</h4>
                </div>
                ${
                    ctx.isAuthenticated() 
                    ? (pet._ownerId == getUser()._id 
                        ? html`
                            <div class="actionBtn">
                                <a href="/pets/${pet._id}/edit" class="edit">Edit</a>
                                <a href="/pets/${pet._id}/delete" class="remove">Delete</a>
                            </div>`
                        : (!isDonated 
                                ? html`<div class="actionBtn">
                                            <a class="donate" @click=${donateHandler.bind(null, ctx, totalDonations)}>Donate</a>
                                       </div>` 
                                : html``))
                    : html``
                }
            </div>
        </div>
    </section>`;

export async function renderDetailsView(ctx) {
    const pet = await getOne(ctx.params._id);

    const totalDonations = await totalDonationsOfEntity(ctx.params._id);
    
    if (ctx.isAuthenticated()) {
        const donationsPerUser = await isAUserDonatedToEntity(ctx.params._id, getUser()._id);

        let isDonated = false;
        if (donationsPerUser > 0) {
            isDonated = true;
        }

        ctx.render(detailsTemplate(ctx, pet, totalDonations, isDonated));

        return;
    }

    ctx.render(detailsTemplate(ctx, pet, totalDonations, true));
}

function donateHandler(ctx, totalDonations, e) {
    e.preventDefault();

    donateToEntity(ctx.params._id)
        .then(data => {
            if (data.message) {
                window.alert(data.message);
            }
            else {
                let likesElement = document.querySelector('.donation');
                likesElement.textContent = `Donation: ${Number(totalDonations * 100) + 100}$`;

                e.target.remove();
            }
        })
}