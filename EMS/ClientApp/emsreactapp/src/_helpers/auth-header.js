import { authenticationService } from '../_services/authenticationService';

export function authHeader() {
    // return authorization header with jwt token
    if (authenticationService.token) {
        return { Authorization: `JWT ${authenticationService.token}` };
    } else {
        return {};
    }
}