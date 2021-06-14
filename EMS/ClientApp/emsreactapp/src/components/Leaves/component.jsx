import React, { Component } from 'react';
import { authenticationService } from '../../_services/authenticationService';
import axios from 'axios';
import { config } from '../../_config/config';
import { authHeader } from '../../_helpers/auth-header';
import { handleResponse } from '../../_helpers/handle-response';

export default class LeaveComponent extends Component {

    constructor(props) {
        super(props);
        this.state = {
            empId: 0, leaveVM: [], isloading: false
        };
    }
    
    componentDidMount() {
        var empId = authenticationService.getEmployeeId(authenticationService.gettoken());
        this.setState({ empId });
         axios({ url: config.apiURL + "/Leave/GetEmployeeLeavesByEmpId/"+ empId, method: 'get', headers: authHeader()}).then(handleResponse)
            .then(leaveVM => {
                this.setState({ leaveVM });
            });
    }

    render() {
        return (
            <>
                <div className="jumbotron">
                    <div className="container">
                        <div className="col-xs-12 card p-5">
                            <div className="p-2">
                            <a href="/applyleave" className="btn btn-primary">Apply For Leave</a>
                            </div>
                            <table className="table table-bordered table-hovered">
                                <thead>
                                    <tr>
                                        <td>No Of Days</td>
                                        <td>Reason</td>
                                        <td>Status</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    {this.state.leaveVM.map((item, index) => {
                                        return (
                                            <tr key={index}>
                                                <td>{item.NoOfDays}</td>
                                                <td>{item.Reason}</td>
                                                <td> <button className={(item.Status ==="Rejected")?'btn btn-danger':(item.Status === "Accepted")?'btn btn-success':'btn btn-default border'}>{item.Status}</button></td>
                                            </tr>
                                        )
                                    })}
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </>
        )
    }

}