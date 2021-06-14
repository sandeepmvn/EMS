import React, { Component } from 'react';
import axios from 'axios';

import { css } from "@emotion/react";
import {ClipLoader}from "react-spinners";

const override = css`
  display: block;
  margin: 0 auto;
  color: "#000000";
`;

export default class LoaderComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { isloading: false };
    }

    componentDidMount() {
        var self = this;
        // Add a request interceptor
        axios.interceptors.request.use(function (config) {
            // Do something before request is sent
            self.setState({ isloading: true });
            return config;
        }, function (error) {
            self.setState({ isloading: false });
            // Do something with request error
            return Promise.reject(error);
        });

        // Add a response interceptor
        axios.interceptors.response.use(function (response) {
            // Any status code that lie within the range of 2xx cause this function to trigger
            // Do something with response data
            self.setState({ isloading: false });
            return response;
        }, function (error) {
            self.setState({ isloading: false });
            // Any status codes that falls outside the range of 2xx cause this function to trigger
            // Do something with response error
            return Promise.reject(error);
        });
    }


    render() {
        return (
            <>
                <div style={{ position: 'fixed', zIndex: "9999999", margin: "auto", left: "49%", top: "40%" }}>
                    <ClipLoader loading={this.state.isloading} css={override} size={150} />
                   
                </div>
            </>
        );
    }
}