import page from '../node_modules/page/page.mjs';
import { renderHomeView } from '../src/homeView.js';
import { renderDetailsView } from '../src/detailsView.js';

page('/', renderHomeView);
page('/furniture/:id', renderDetailsView);

page.start();