import { authMiddleware } from './middlewares/authMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';
import page from './node_modules/page/page.mjs';
import { renderCreateView } from './views/createView.js';
import { renderDashboardView } from './views/dashboardView.js';
import { executeDelete } from './views/deleteView.js';
import { renderDetailsView } from './views/detailsView.js';
import { renderEditView } from './views/editView.js';
import { renderLoginView } from './views/loginView.js';
import { executeLogout } from './views/logoutView.js';
import { renderMineView } from './views/mineView.js';
import { renderRegisterView } from './views/registerView.js';

page(authMiddleware);
page(renderMiddleware);

page('/', renderDashboardView);
page('/login', renderLoginView);
page('/register', renderRegisterView);
page('/logout', executeLogout);
page('/books/add', renderCreateView);
page('/books/mine', renderMineView);
page('/books/:_id/edit', renderEditView);
page('/books/:_id/delete', executeDelete);
page('/books/:_id', renderDetailsView);

page.start();