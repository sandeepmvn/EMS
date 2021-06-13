import React, { Component } from 'react';
import { authenticationService } from '../../_services/authenticationService';
import { Navbar, Nav } from 'react-bootstrap';

export default class DownloadPaySlipsComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { employeeInfo: {} };
    }

    componentDidMount(){
        //load the data
              }

    render() {
        return (
            <>
             <div className="jumbotron">
                    <div className="container">
                        <div className="col-xs-12 card p-5">
                            <h4>Pay Slips:</h4>
                                                    </div>
                    </div>
                </div>

            </>
        )
    }

}