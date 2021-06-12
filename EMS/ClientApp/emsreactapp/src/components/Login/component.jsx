import React, { Component, useState } from 'react';
import axios from 'axios';
import { authenticationService } from '../../_services/authenticationService';
import Alert from 'react-bootstrap/Alert';
const LoginComponent = (props) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [errorMessage, seterrorMessage] = useState("");
    const handleClick = (event) => {
        if (!(username && password))
            return;
    }

    return (
        <div className="container">
            <form autocomplete="off">
            <div className="card offset-md-4 col-12 col-lg-4 login-card mt-2 hv-center p-5">
                <div class="text-center p-2">
                <i class="fa fa-users" aria-hidden="true" ></i>
                </div>
                {errorMessage && <Alert variant="danger">
                    Invalid Email or Password
                </Alert>}
                <label for="emsemail"><i class="fa fa-envelope-o" aria-hidden="true"></i> Email</label>
                <input type="email" value={username}
                    className="form-control"
                    id="emsemail"
                    name="emsemail"
                    aria-describedby="emailHelp"
                    placeholder="Enter EmailId" autoComplete="off"
                    onChange={(e) => setUsername(e.target.value)} required
                />
                <label for="emspassword"><i class="fa fa-key" aria-hidden="true"></i> Password</label>
                <input value={password} type="password"
                    className="form-control"
                    id="emspassword"
                    name="emspassword"
                    placeholder="Password" autoComplete="off"
                    onChange={(e) => setPassword(e.target.value)} required
                />
                <button class="btn btn-primary mt-3" onClick={handleClick}>Login</button>
            </div>
            </form>
        </div>
    );
}

export default LoginComponent;