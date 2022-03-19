import page from '../node_modules/page/page.mjs';
import { authMiddleware } from './middlewares/authMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';
import { renderBrowseTeamsView } from './views/browseTeamsView.js';
import { renderHomeView } from './views/homeView.js';
import { renderRegisterView } from './views/registerView.js';
import { renderLoginView } from './views/loginView.js';
import { renderLogoutView } from './views/logoutView.js';
import { renderCreateView } from './views/createView.js';
import { renderTeamDetails } from './views/teamDetailsView.js';

page(authMiddleware);
page(renderMiddleware);

page('/', renderHomeView);
page('/browse', renderBrowseTeamsView);
page('/register', renderRegisterView);
page('/login', renderLoginView);
page('/logout', renderLogoutView);
page('/create', renderCreateView);
page('/team/:_id', renderTeamDetails);

page.start();

page.redirect('/');