import React, { Component } from 'react';
import { authenticationService } from '../../_services/authenticationService';


export default class ApplyLeaveComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { empId: 0
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }


    handleChange(event) {
        this.setState({value: event.target.value});
      }
    
      handleSubmit(event) {
        alert('A name was submitted: ' + this.state.value);
        event.preventDefault();
      }

      componentDidMount(){
        var empId = authenticationService.getEmployeeId(authenticationService.token);
        this.setState({ empId });
              }

    render() {
        return (
            <>
             <div className="jumbotron">
                    <div className="container">
                        <div className="col-xs-12 card p-5">
                            <h4>Apply Leave:</h4>
                            <form autocomplete="off">
                                <div className="form-group">
                                    <label for="EmpId">Employee Id:</label>
                                    <input type="text" id="EmpId" name="EmpId" value="" className="form-control" readOnly disabled />
                                </div>
 
                                <div className="form-group">
                                    <label for="noofdays">No Of Days</label>
                                    <input required type="int" id="noofdays" name="noofdays" value="0" className="form-control" />
                                </div>
                               
                                <div className="form-group">
                                    <label for="Reason">Reason</label>
                                    <textarea required className="form-control" name="Reason" id="Reason" rows="3" maxLength="400"></textarea>
                                </div>
                             
                                <button type="Save" class="btn btn-primary">Submit</button>
                            </form>
                        </div>
                    </div>
                </div>

            </>
        )
    }

}