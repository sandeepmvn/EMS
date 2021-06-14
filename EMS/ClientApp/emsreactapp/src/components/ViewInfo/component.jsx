import React, { Component } from 'react';
import { authenticationService } from '../../_services/authenticationService';
import axios from 'axios';
import { config } from '../../_config/config';
import {authHeader} from '../../_helpers/auth-header';
import {handleResponse} from '../../_helpers/handle-response';

export default class ViewInfoComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { employeeInfo: {},isloading:true };
        this.handleChange = this.handleChange.bind(this);
       // this.handleSubmit = this.handleSubmit.bind(this);
        this.formatDate=this.formatDate.bind(this);
        // this.handleChangeEmp=this.handleChangeEmp.bind(this);
    }

    handleChange(event) {
        this.setState({value: event.target.value});
      }

      handleChangeEmp(prop,event){
          var employeeInfo=this.state.employeeInfo;
          employeeInfo[prop]=event.target.value;
          this.setState({employeeInfo});
      }
    
      handleSubmit(event) {
        this.setState({isloading:true});
        axios({url:config.apiURL+"/UserProfile/UpdateEmployee",method:'put',headers:authHeader(), data:this.state.employeeInfo}).then(handleResponse)
        .then(employeeInfo=>{
            this.setState({isloading:false});
            alert("Updated!!");
        });
        event.preventDefault();
      }

      formatDate(datestring){
        var today = new Date(datestring);
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        var yyyy = today.getFullYear();
        
        return yyyy + '-' + mm + '-' +dd ;
      }

      componentDidMount(){
         var d= authenticationService.getEmployeeId(authenticationService.gettoken())
        axios({url:config.apiURL+"/UserProfile/GetEmployeerByEmpId/"+d,method:'get',headers:authHeader()}).then(handleResponse)
        .then(employeeInfo=>{
            this.setState({employeeInfo});
            this.setState({isloading:false});
        });
      }

    render() {
        return (
            <>
                <div className="jumbotron">
                    <div className="container">
                        <div className="col-xs-12 card p-5">
                            <h4>Employee Info:</h4>
                            <form autoComplete="off" onSubmit={(e)=>this.handleSubmit(e)}>
                                <div className="form-group">
                                    <label htmlFor="EmpId">Employee Id:</label>
                                    <input type="text" id="EmpId" name="EmpId" value={this.state.employeeInfo.EmployeeId} className="form-control" readOnly disabled />
                                </div>
                                <div className="form-group">
                                    <label htmlFor="fname">First Name</label>
                                    <input required type="text" id="fname" name="fname" value={this.state.employeeInfo.FirstName} className="form-control" maxLength="50" onChange={(e)=>this.handleChangeEmp('FirstName',e)}  />
                                </div>

                                <div className="form-group">
                                    <label htmlFor="lname">Last  Name</label>
                                    <input  type="text" id="lname" name="lname" value={this.state.employeeInfo.LastName} className="form-control" maxLength="50" onChange={(e)=>this.handleChangeEmp('LastName',e)} />
                                </div>

                                <fieldset className="form-group row">
                                    <legend className="col-form-label col-sm-2 float-sm-left pt-0">Gender:</legend>
                                    <div className="col-sm-10">
                                        <div className="form-check">
                                            <input className="form-check-input" type="radio" name="gridRadios" id="gridRadios1" value="Male" checked={this.state.employeeInfo.Gender==="Male"} onChange={(e)=>this.handleChangeEmp('Gender',e)} />
                                            <label className="form-check-label" htmlFor="gridRadios1">
                                                Male
                                             </label>
                                        </div>
                                        <div className="form-check">
                                            <input className="form-check-input" type="radio" name="gridRadios" id="gridRadios2" value="Female" checked={this.state.employeeInfo.Gender==="Female"} onChange={(e)=>this.handleChangeEmp('Gender',e)} />
                                            <label className="form-check-label" htmlFor="gridRadios2">
                                                Female </label>
                                        </div>
                                    </div>
                                </fieldset>

                                <div className="form-group">
                                    <label htmlFor="dob">DOB</label>
                                    <input required type="date" id="dob" name="dob" value={this.formatDate(this.state.employeeInfo.DateOfBirth)} className="form-control" onChange={(e)=>this.handleChangeEmp('DateOfBirth',e)} />
                                </div>
                               
                                <div className="form-group">
                                    <label htmlFor="phoneNo">Phone No</label>
                                    <input required type="tel" id="phoneNo" name="phoneNo" value={this.state.employeeInfo.PhoneNumber} className="form-control" maxLength="10" pattern="[6789][0-9]{9}" onChange={(e)=>this.handleChangeEmp('PhoneNumber',e)} />
                                </div>

                                <div className="form-group">
                                    <label htmlFor="Designation">Designation</label>
                                    <input type="text" id="Designation" name="Designation" value={this.state.employeeInfo.Designation} className="form-control" maxLength="50" required  onChange={(e)=>this.handleChangeEmp('Designation',e)}/>
                                </div>

                                <div className="form-group">
                                    <label htmlFor="Address">Address</label>
                                    <input type="text" id="Address" name="Address" value={this.state.employeeInfo.Address} className="form-control" maxLength="100" required onChange={(e)=>this.handleChangeEmp('Address',e)}  />
                                </div>
                                <div className="form-group">
                                    <label htmlFor="workplace">Work Place</label>
                                    <input type="text" id="workplace" name="workplace" value={this.state.employeeInfo.Workplace} className="form-control" maxLength="50" required onChange={(e)=>this.handleChangeEmp('Workplace',e)} />
                                </div>
                                <div className="pull-right">
                                <button type="submit" className="btn btn-primary" disabled={this.state.isloading}>Save</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </>);
    }


}