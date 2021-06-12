
import {BehaviorSubject} from 'rxjs';

const isLoggedInSubject = new BehaviorSubject(localStorage.getItem('authCookie')?true:false);

export const authenticationService = {
    login,
    logout,
    isLogged: isLoggedInSubject.asObservable(),
    get isLoggedIn() { return isLoggedInSubject.value },
    token: localStorage.getItem('authCookie'),
};

export function login(token) {
    localStorage.setItem('authCookie', token);
    isLoggedInSubject.next(true);
}

export function logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('authCookie');
    isLoggedInSubject.next(false);
}




