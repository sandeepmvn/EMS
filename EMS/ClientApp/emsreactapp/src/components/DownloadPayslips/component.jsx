import React, { Component } from 'react';
import { authenticationService } from '../../_services/authenticationService';
import axios from 'axios';
import { config } from '../../_config/config';
import { authHeader } from '../../_helpers/auth-header';
import { handleResponse } from '../../_helpers/handle-response';

export default class DownloadPaySlipsComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { empId: 0, paySlipsvm: null, isloading: false, payslipmonth: null };
        this.formatDate=this.formatDate.bind(this);
    }

    componentDidMount() {
        var empId = authenticationService.getEmployeeId(authenticationService.gettoken());
        this.setState({ empId });

    }

    search(e) {
        var payslipmonth = e.target.value;
        if (payslipmonth) {
            this.setState({isloading:true});
            axios({ url: config.apiURL + "/Payslip/GetPayslipByEmpAndMonth/" + this.state.empId + "/" + payslipmonth, method: 'get', headers: authHeader() }).then(handleResponse)
                .then(paySlipsvm => {
                    this.setState({ paySlipsvm });
                    this.setState({ payslipmonth });
                    this.setState({isloading:false});
                });
        }
    }
    formatDate(datestring){
        var today = new Date(datestring);
        // var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        var yyyy = today.getFullYear();
        return yyyy + '-' + mm ;
      }



    render() {
        return (
            <>
                <div className="jumbotron">
                    <div className="container">
                        <div className="col-xs-12 card p-5">
                            <h4>Search by :</h4>
                            <input type="month" format="mm-yyyy" className="form-control" onChange={(e) => this.search(e)} disabled={this.state.isloading}
                            max={this.formatDate(new Date())}
                            ></input>
                        </div>
                        {this.state.payslipmonth && !this.state.paySlipsvm &&
                            <div className="col-xs-12 card p-2">
                                <div class="alert alert-danger" role="alert">
                                    No data found, Please contact admin!!
                                </div>
                            </div>
                        }
                        {this.state.paySlipsvm &&
                            <div className="col-xs-12 card p-5">
                                <h4>PaySlip</h4>
                                <table className="table table-bordered table-hovered">
                                    <tr><td colSpan="2">
                                        <div>
                                            <p className="text-center"> <i className="fa fa-users" aria-hidden="true" ></i> Employee Mangement System</p>
                                            <div className="row">
                                                <div className="col-3">
                                                    <p style={{margin:'0px,2px'}} >PaySlip Created</p> 
                                                    <i className="fa fa-calendar" aria-hidden="true"></i> {new Date(this.state.paySlipsvm.MonthDate).toDateString()}
                                                </div>
                                                <div className="col-9 border">
                                                    <div className="pull-right">
                                                     <p><i className="fa fa-address-card-o" aria-hidden="true"></i> :xxxx.xxxx.xxxx</p>
                                                     <p><i className="fa fa-mobile" aria-hidden="true"></i> :+91 xxxxxxxxxx</p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td></tr>
                                    <tr>
                                        <td> Employee Id</td>
                                        <td><i className="fa fa-user" aria-hidden="true" ></i> {this.state.empId}</td>
                                    </tr>
                                    <tr>
                                        <td>Credited On</td>
                                        <td><i className="fa fa-calendar" aria-hidden="true"></i> {new Date(this.state.paySlipsvm.CreditedOn).toDateString()}</td>
                                    </tr>
                                    <tr>
                                        <td>Amount</td>
                                        <td><i className="fa fa-inr" aria-hidden="true"></i> {this.state.paySlipsvm.Amount}</td>
                                    </tr>
                                    <tr>
                                        <td colSpan="2">
                                            <div className="pull-right">
                                                <button className="btn btn-info" onClick={(e) => window.print()}> <i className="fa fa-download" aria-hidden="true"></i> Download PaySlip</button>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        }
                    </div>
                </div>
            </>
        )
    }

}