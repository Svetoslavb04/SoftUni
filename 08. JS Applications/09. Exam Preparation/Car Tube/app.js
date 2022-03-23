import page from './node_modules/page/page.mjs';
import { authMiddleware } from './src/middlewares/authMiddleware.js';
import { renderMiddleware } from './src/middlewares/renderMiddleware.js';
import { renderAllListings } from './src/views/allListingsView.js';
import { renderCreateCarView } from './src/views/createCarView.js';
import { renderDetailsView } from './src/views/detailsView.js';
import { renderEditView } from './src/views/editView.js';
import { renderHomeView } from './src/views/homeView.js';
import { renderLoginView } from './src/views/loginView.js';
import { executeLogout } from './src/views/logout.js';
import { renderMyListingsView } from './src/views/myListingsView.js';
import { renderRegisterView } from './src/views/registerView.js';
import { renderSearchView } from './src/views/searchView.js';

page(authMiddleware);
page(renderMiddleware);

page('/', renderHomeView);
page('/login', renderLoginView);
page('/register', renderRegisterView);
page('/logout', executeLogout);
page('/listings/all', renderAllListings);
page('/listings/:_id', renderDetailsView);
page('/listings/edit/:_id', renderEditView);
page('/listing', renderCreateCarView);
page('/user/listings', renderMyListingsView);
page('/search', renderSearchView);

page.start();