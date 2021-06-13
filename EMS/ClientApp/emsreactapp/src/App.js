import logo from './logo.svg';
import './App.css';

import { PrivateRoute } from './_helpers/PrivateRoute';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import NavbarComponent  from './components/Navbar/component';
import LoginComponent  from './components/Login/component';
import  { history}  from './_helpers/history';
import ViewInfoComponent from './components/ViewInfo/component';
import SubmitAttendanceComponent from './components/SubmitAttendance/component';
import ApplyLeaveComponent from './components/ApplyLeave/component';
import DownloadPaySlipsComponent from './components/DownloadPayslips/component';

function App() {
  return (
    <Router history={history}>
      <NavbarComponent />
      <Switch>
         {/* <PrivateRoute exact path="/viewinfo" component={ViewInfoComponent} /> */}
         <PrivateRoute exact path="/viewinfo" component={ViewInfoComponent} />
         <PrivateRoute exact path="/attendance" component={SubmitAttendanceComponent} />
         <PrivateRoute exact path="/leave" component={ApplyLeaveComponent} />
         <PrivateRoute exact path="/payslips" component={DownloadPaySlipsComponent} />
         <Route path='/login' exact component={LoginComponent} />
         <Route path='/' exact component={LoginComponent} />
      </Switch>
    </Router>
  );
}

export default App;
