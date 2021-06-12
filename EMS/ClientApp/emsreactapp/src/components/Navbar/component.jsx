import React, { Component } from 'react';
import { authenticationService } from '../../_services/authenticationService';
import { Navbar,Nav } from 'react-bootstrap';

export default class NavbarComponent extends Component {

    constructor(props) {
        super(props);
        this.state = { isAuthenticated: authenticationService.isLoggedIn };
    }

    componentDidMount() {
        authenticationService.isLogged.subscribe(x => this.setState({ isAuthenticated: x }));
    }

    logout=()=> {
		authenticationService.logout();
        //this.props.history.push('/login');
		window.location.href='/login';
	}

    render() {
        return (
            <>
                <Navbar collapseOnSelect expand="lg" variant="light" bg="light">
                    <Navbar.Brand href="/"><i class="fa fa-users" aria-hidden="true"></i> Employee Management System</Navbar.Brand>
                    <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                    <Navbar.Collapse id="responsive-navbar-nav">
                        {this.state.isAuthenticated && <Nav className="mr-auto">
                            <Nav.Link href="#features">Features</Nav.Link>
                            <Nav.Link href="#pricing">Pricing</Nav.Link>
                        </Nav>}
                        {!this.state.isAuthenticated && <Nav className="mr-auto"></Nav>}
                        <Nav>
                            {!this.state.isAuthenticated && <Nav.Link href="/login"><i class="fa fa-sign-in" aria-hidden="true"></i> Login</Nav.Link>}
                            {this.state.isAuthenticated &&  <a onClick={this.logout} className="nav-item nav-link"><i class="fa fa-sign-out" aria-hidden="true"></i>Logout</a>}
                        </Nav>
                    </Navbar.Collapse>
                </Navbar>
            </>
        );
    }
}