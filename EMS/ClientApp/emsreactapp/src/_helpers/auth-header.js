import { authenticationService } from '../_services/authenticationService';

export function authHeader() {
    // return authorization header with jwt token
    if (authenticationService.gettoken()) {
        return { Authorization: `JWT ${authenticationService.gettoken()}` };
    } else {
        return {};
    }
}