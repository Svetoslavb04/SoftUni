import { getUser } from "../services/authService.js";

export function authMiddleware(ctx, next) {
    ctx.isAuthenticated = () => Boolean(getUser().accessToken);
    ctx.userEmail = () => getUser().email;
    
    next();
}