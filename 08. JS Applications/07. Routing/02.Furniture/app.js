import page from './node_modules/page/page.mjs';
import { renderHomeView } from './src/homeView.js';
import { renderDetailsView } from './src/detailsView.js';
import { renderLoginView } from './src/loginView.js';
import { renderRegisterView } from './src/registerView.js';
import { renderEditView } from './src/editView.js';

page('/', renderHomeView);
page('/login', renderLoginView);
page('/register', renderRegisterView);
page('/furniture/:_id', renderDetailsView);
page('/furniture/edit/:_id', renderEditView);

page.start();