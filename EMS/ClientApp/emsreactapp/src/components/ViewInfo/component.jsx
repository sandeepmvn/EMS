import React, { Component } from 'react';
import { authenticationService } from '../../_services/authenticationService';
import { Navbar, Nav } from 'react-bootstrap';

export default class ViewInfoComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { employeeInfo: {} };
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
//load the data
      }

    render() {
        return (
            <>
                <div className="jumbotron">
                    <div className="container">
                        <div className="col-xs-12 card p-5">
                            <h4>Employee Info:</h4>
                            <form autocomplete="off">
                                <div className="form-group">
                                    <label for="EmpId">Employee Id:</label>
                                    <input type="text" id="EmpId" name="EmpId" value="" className="form-control" readOnly disabled />
                                </div>
                                <div className="form-group">
                                    <label for="fname">First Name</label>
                                    <input required type="text" id="fname" name="fname" value="" className="form-control" maxLength="50" />
                                </div>

                                <div className="form-group">
                                    <label for="lname">Last  Name</label>
                                    <input  type="text" id="lname" name="lname" value="" className="form-control" maxLength="50" />
                                </div>

                                <fieldset className="form-group row">
                                    <legend className="col-form-label col-sm-2 float-sm-left pt-0">Gender:</legend>
                                    <div className="col-sm-10">
                                        <div className="form-check">
                                            <input className="form-check-input" type="radio" name="gridRadios" id="gridRadios1" value="option1" checked />
                                            <label className="form-check-label" for="gridRadios1">
                                                Male
                                             </label>
                                        </div>
                                        <div className="form-check">
                                            <input className="form-check-input" type="radio" name="gridRadios" id="gridRadios2" value="option2" />
                                            <label className="form-check-label" for="gridRadios2">
                                                Female </label>
                                        </div>
                                    </div>
                                </fieldset>

                                <div className="form-group">
                                    <label for="dob">DOB</label>
                                    <input required type="date" id="dob" name="dob" value="" className="form-control" />
                                </div>
                               
                                <div className="form-group">
                                    <label for="phoneNo">Phone No</label>
                                    <input required type="tel" id="phoneNo" name="phoneNo" value="" className="form-control" maxLength="10" pattern="[6789][0-9]{9}" />
                                </div>

                                <div className="form-group">
                                    <label for="Designation">Designation</label>
                                    <input type="text" id="Designation" name="Designation" value="" className="form-control" maxLength="50" required />
                                </div>

                                <div className="form-group">
                                    <label for="Address">Address</label>
                                    <input type="text" id="Address" name="Address" value="" className="form-control" maxLength="100" required/>
                                </div>
                                <div className="form-group">
                                    <label for="workplace">Work Place</label>
                                    <input type="text" id="workplace" name="workplace" value="" className="form-control" maxLength="50" required />
                                </div>
                                <button type="Save" class="btn btn-primary">Submit</button>
                            </form>
                        </div>
                    </div>
                </div>
            </>);
    }


}