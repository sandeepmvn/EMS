
import {BehaviorSubject} from 'rxjs';
import jwt_decode from 'jwt-decode';

const isLoggedInSubject = new BehaviorSubject(localStorage.getItem('authCookie')?true:false);

export const authenticationService = {
    login,
    logout,
    getEmployeeId,
    gettoken,
    isLogged: isLoggedInSubject.asObservable(),
    get isLoggedIn() { return isLoggedInSubject.value },
    
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

export function getEmployeeId(token){
    let decodedToken = jwt_decode(token);
    return decodedToken['UId'];
}

export function gettoken(){
    return localStorage.getItem('authCookie');
}




