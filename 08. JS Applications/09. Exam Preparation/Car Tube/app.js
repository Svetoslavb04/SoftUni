import page from './node_modules/page/page.mjs';
import { authMiddleware } from './src/middlewares/authMiddleware.js';
import { renderMiddleware } from './src/middlewares/renderMiddleware.js';
import { renderHomeView } from './src/views/homeView.js';
import { renderLoginView } from './src/views/loginView.js';

page(authMiddleware);
page(renderMiddleware);

page('/', renderHomeView);
page('/login', renderLoginView);

page.start();