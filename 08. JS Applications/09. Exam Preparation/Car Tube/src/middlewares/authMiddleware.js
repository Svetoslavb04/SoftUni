import { isAuthenticated } from '../services/authService.js';

export function authMiddleware(ctx, next) {
    ctx.isAuthenticated = isAuthenticated;
    
    next();
}