import React, {  useState } from 'react';
import axios from 'axios';
import { authenticationService } from '../../_services/authenticationService';
import Alert from 'react-bootstrap/Alert';
import {config} from '../../_config/config';
import { css } from "@emotion/react";
import ClipLoader from "react-spinners/ClipLoader";

const override = css`
  display: block;
  margin: 0 auto;
`;

const LoginComponent = (props) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [errorMessage, seterrorMessage] = useState(false);
    const [isSaving, setisSaving]=useState(false);
    const handleClick = (event) => {
        if (!(username && password))
            return;
       seterrorMessage(false);
       setisSaving(true)
       
        var payload = {
            "emailId": username,
            "password": password
        };
        axios.post(config.apiURL+`/authentication/login`, payload).then(function (response) {
            setisSaving(false);
            if(response.status===200){
               if(response.data.Token){
                authenticationService.login(response.data.Token);
                props.history.push('/viewinfo');
               }
           }
        }).catch(function (error) {
            setisSaving(false);
            seterrorMessage(true);
            console.log(error);
            //alert("Error occurred");
        })
        event.preventDefault();
    }

    return (
        <div className="container">
            <form autoComplete="off" onSubmit={handleClick}>
                <div className="card offset-md-4 col-12 col-lg-4 login-card mt-2 hv-center p-5">
                    <div className="text-center p-2">
                        <i className="fa fa-users" aria-hidden="true" ></i>
                    </div>
                    {errorMessage && <Alert variant="danger">
                        Invalid Email or Password
                </Alert>}
                    <label htmlFor="emsemail"><i className="fa fa-envelope-o" aria-hidden="true"></i> Email</label>
                    <input type="email" value={username}
                        className="form-control"
                        id="emsemail"
                        name="emsemail"
                        aria-describedby="emailHelp"
                        placeholder="Enter EmailId" autoComplete="off"
                        onChange={(e) => setUsername(e.target.value)} required
                    />
                    <label htmlFor="emspassword"><i className="fa fa-key" aria-hidden="true"></i> Password</label>
                    <input value={password} type="password"
                        className="form-control"
                        id="emspassword"
                        name="emspassword"
                        placeholder="Password" autoComplete="off"
                        onChange={(e) => setPassword(e.target.value)} required
                    />
                    <button type="submit" disabled={isSaving}  className="btn btn-primary mt-3" >Login</button>
                </div>
            </form>
            <ClipLoader  loading={isSaving} css={override} size={150} />
        </div>
    );
}

export default LoginComponent;