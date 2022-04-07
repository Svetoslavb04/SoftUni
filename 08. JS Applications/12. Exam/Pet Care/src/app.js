import { authMiddleware } from './middlewares/authMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';
import page from '../node_modules/page/page.mjs';
import { renderCreateView } from './views/createView.js';
import { renderDashboardView } from './views/dashobardView.js';
import { executeDelete } from './views/deleteView.js';
import { renderDetailsView } from './views/detailsView.js';
import { renderEditView } from './views/editView.js';
import { renderHomeView } from './views/homeView.js';
import { renderLoginView } from './views/loginView.js';
import { executeLogout } from './views/logoutView.js';
import { renderRegisterView } from './views/registerView.js';

page(authMiddleware);
page(renderMiddleware);

page('/', renderHomeView);
page('/login', renderLoginView);
page('/register', renderRegisterView);
page('/logout', executeLogout);
page('/dashboard', renderDashboardView);
page('/pets/create', renderCreateView);
page('/pets/:_id/edit', renderEditView);
page('/pets/:_id/delete', executeDelete);
page('/pets/:_id', renderDetailsView);

page.start();