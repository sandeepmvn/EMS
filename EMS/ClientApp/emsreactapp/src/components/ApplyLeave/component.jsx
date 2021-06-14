import React, { Component } from 'react';
import { authenticationService } from '../../_services/authenticationService';
import axios from 'axios';
import { config } from '../../_config/config';
import {authHeader} from '../../_helpers/auth-header';
import {handleResponse} from '../../_helpers/handle-response';

export default class ApplyLeaveComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { empId: 0, leaveVM:{},isloading:false
        };
        this.handleChange = this.handleChange.bind(this);
        //this.handleSubmit = this.handleSubmit.bind(this);
    }


    handleChange(event) {
        this.setState({value: event.target.value});
      }

      handleChangeEmp(prop,event){
        var leaveVM=this.state.leaveVM;
        leaveVM[prop]=event.target.value;
        this.setState({leaveVM});
    }
    
      handleSubmit(event) {
        var payload= {
            "employeeId":this.state.empId,
            "reason":this.state.leaveVM.Reason,
            "noOfDays":this.state.leaveVM.NoOfDays
        }
       
        axios({url:config.apiURL+"/Leave/AddEmployeeLeave",method:'post',headers:authHeader(), data:payload}).then(handleResponse)
        .then(employeeInfo=>{
            this.setState({isloading:false});
            var leaveVM=this.state.leaveVM;
            leaveVM.Reason='';
            leaveVM.NoOfDays=0;
            this.setState({leaveVM});
            alert("Submitted!!");
        });
        event.preventDefault();
      }

      componentDidMount(){
        var empId = authenticationService.getEmployeeId(authenticationService.gettoken());
        this.setState({ empId });
              }

    render() {
        return (
            <>
             <div className="jumbotron">
                    <div className="container">
                        <div className="col-xs-12 card p-5">
                            <h4>Apply Leave:</h4>
                            <form autoComplete="off" onSubmit={(e)=>{this.handleSubmit(e)}} >
                                <div className="form-group">
                                    <label htmlFor="EmpId">Employee Id:</label>
                                    <input type="text" id="EmpId" name="EmpId" value={this.state.empId} className="form-control" readOnly disabled />
                                </div>
 
                                <div className="form-group">
                                    <label htmlFor="noofdays">No Of Days</label>
                                    <input required type="int" id="noofdays" name="noofdays" value={this.state.leaveVM.NoOfDays} className="form-control" min="0" max="30" onChange={(e)=>this.handleChangeEmp('NoOfDays',e)} />
                                </div>
                               
                                <div className="form-group">
                                    <label htmlFor="Reason">Reason</label>
                                    <textarea required className="form-control" name="Reason" id="Reason" rows="3" maxLength="400" value={this.state.leaveVM.Reason}  onChange={(e)=>this.handleChangeEmp('Reason',e)} ></textarea>
                                </div>
                                <div className="pull-right">
                                <button type="submit" className="btn btn-primary">Apply</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>

            </>
        )
    }

}