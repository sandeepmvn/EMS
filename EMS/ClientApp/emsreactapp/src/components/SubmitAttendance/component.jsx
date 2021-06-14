import React, { Component } from 'react';
import { authenticationService } from '../../_services/authenticationService';


export default class SubmitAttendanceComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { empId: 0
      };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }


    handleChange(event) {
        this.setState({ value: event.target.value });
    }

    handleSubmit(event) {
        alert('A name was submitted: ' + this.state.value);
        event.preventDefault();
    }

    componentDidMount() {
        var empId = authenticationService.getEmployeeId(authenticationService.token);
        this.setState({ empId });
    }

    render() {
        return (
            <>
                <div className="jumbotron">
                    <div className="container">
                        <div className="col-xs-12 card p-5">
                            <h4>Submit Attendance:</h4>
                            <form autocomplete="off">
                                <div className="form-group">
                                    <label for="EmpId">Employee Id:</label>
                                    <input type="text" id="EmpId" name="EmpId" value={this.state.empId} className="form-control" readOnly disabled />
                                </div>

                                <div className="form-group">
                                    <label for="dob">DOB</label>
                                    <input required type="date" id="dob" name="dob" value="" className="form-control" />
                                </div>

                                <div className="form-group">
                                    <label for="workhours">Work Hours</label>
                                    <input required type="text" id="workhours" name="workhours" placeholder="00:00" value="" className="form-control" maxLength="05" pattern="[6789][0-9]{9}" />
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