import page from '../node_modules/page/page.mjs';
import { authMiddleware } from './middlewares/authMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';
import { renderHomeView } from './views/homeView.js';
import { renderLoginView } from './views/loginView.js';
import { executeLogout } from './views/logout.js';
import { renderRegisterView } from './views/registerView.js';


page(authMiddleware);
page(renderMiddleware);

page('/', renderHomeView);
page('/login', renderLoginView);
page('/register', renderRegisterView);
page('/logout', executeLogout);

page.start();