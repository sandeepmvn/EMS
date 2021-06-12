import logo from './logo.svg';
import './App.css';

// import { PrivateRoute } from './helpers/PrivateRoute';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import NavbarComponent  from './components/Navbar/component';
import LoginComponent  from './components/Login/component';
import  { history}  from './_helpers/history';
function App() {
  return (
    <Router history={history}>
      <NavbarComponent />
      <switch>
         <Route path='/' exact component={LoginComponent} />
         <Route path='/login' exact component={LoginComponent} />
      </switch>
    </Router>
  );
}

export default App;
