import React, { Component } from 'react';
import { authenticationService } from '../_services/authenticationService';


export default class WelcomeComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { empId: 0, empName: '' };

    }

    componentDidMount() {
        var token = authenticationService.gettoken();
        var empId = authenticationService.getEmployeeId(token);
        this.setState({ empId });
        var empName = authenticationService.getEmpName(token);
        this.setState({ empName });
    }


    render() {
        return (
            <>
                <div className="jumbotron" style={{
                    height: '100vh', backgroundImage: "url(/welcome.png)", backgroundPosition: 'center',
                    backgroundSize: 'cover',
                    backgroundRepeat: 'no-repeat'
                }}>
                    <div className="container">
                        <div className="col-xs-12 card p-5 text-center">
                            <h4><i className="fa fa-user"></i> Welcome {this.state.empName}!</h4>
                            <p>EmployeeId is {this.state.empId}</p>
                        </div>
                    </div>
                </div>

            </>
        )
    }

}