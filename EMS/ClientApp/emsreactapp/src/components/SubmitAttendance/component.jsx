import React, { Component } from 'react';
import { authenticationService } from '../../_services/authenticationService';
import { config } from '../../_config/config';
import {authHeader} from '../../_helpers/auth-header';
import {handleResponse} from '../../_helpers/handle-response';
import axios from 'axios';
export default class SubmitAttendanceComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { empId: 0, attendenceVM:{},isloading:false
      };
        this.handleChange = this.handleChange.bind(this);
        //this.handleSubmit = this.handleSubmit.bind(this);
        this.formatDate=this.formatDate.bind(this);
    }


    handleChange(event) {
        this.setState({ value: event.target.value });
    }
    handleChangeEmp(prop,event){
        var attendenceVM=this.state.attendenceVM;
        attendenceVM[prop]=event.target.value;
        this.setState({attendenceVM});
    }


    componentDidMount() {
        var empId = authenticationService.getEmployeeId(authenticationService.gettoken());
        this.setState({ empId });
        
    }

    formatDate(datestring){
        var today = new Date(datestring);
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        var yyyy = today.getFullYear();
        return yyyy + '-' + mm + '-' +dd ;
      }

      handleSubmit(event) {
        
        var payload= {
            "employeeId":this.state.empId,
            "attendenceOn":this.state.attendenceVM.AttendenceOn,
            "workingHours":this.state.attendenceVM.WorkingHours
        }
        this.setState({isloading:true});
        axios({url:config.apiURL+"/Attendence/AddEmployeeAttendence",method:'post',headers:authHeader(), data:payload}).then(handleResponse)
        .then(employeeInfo=>{
            this.setState({isloading:false});
            var attendenceVM=this.state.attendenceVM;
            attendenceVM.AttendenceOn=new Date();
            attendenceVM.WorkingHours=0;
            this.setState({attendenceVM});

            alert("Submitted!!");
        });
        event.preventDefault();
      }

    render() {
        return (
            <>
                <div className="jumbotron">
                    <div className="container">
                        <div className="col-xs-12 card p-5">
                            <h4>Submit Attendance:</h4>
                            <form autoComplete="off" onSubmit={(e)=>this.handleSubmit(e)}>
                                <div className="form-group">
                                    <label htmlFor="EmpId">Employee Id:</label>
                                    <input type="text" id="EmpId" name="EmpId" value={this.state.empId} className="form-control" readOnly disabled />
                                </div>

                                <div className="form-group">
                                    <label htmlFor="dob">DOB</label>
                                    <input required type="date" id="dob" name="dob" value={this.formatDate(this.state.attendenceVM.AttendenceOn)} className="form-control" onChange={(e)=>this.handleChangeEmp('AttendenceOn',e)} />
                                </div>

                                <div className="form-group">
                                    <label htmlFor="workhours">Work Hours</label>
                                    <input required type="number" id="workhours" name="workhours" placeholder="00" value={this.state.attendenceVM.WorkingHours} className="form-control" min="0" max="12" onChange={(e)=>this.handleChangeEmp('WorkingHours',e)} />
                                </div>
                                <div className="pull-right">
                                <button type="submit" className="btn btn-primary" disabled={this.state.isloading}>Submit</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>

            </>
        )
    }

}