import React, { Component } from 'react';
import Home from './components/Home';
import { loadProgressBar } from 'axios-progress-bar';
import '../node_modules/bootstrap/dist/css/bootstrap.css';
import {BrowserRouter as Router, Route , Switch } from 'react-router-dom'
import UserList from './components/UserList';
import UserAdd from './components/UserAdd';
import NotFound from './components/NotFound';
import Login from './components/Login';
import {connect} from 'react-redux';
import authorization from './actions/login';

class App extends Component {
  componentDidMount () {
    loadProgressBar()

    let hasToken = localStorage.getItem("token");
    if(hasToken!=null) {
      this.props.dispatch(authorization(true))
    }
  }
  render() {
    return (
      <Router>        
        <Switch>
          <Route path="/" exact component={Home} />
          <Route path="/users/" component={UserList} />
          <Route path="/users-add" component={UserAdd} />
          <Route path="/login" component={Login} />
          <Route component={NotFound} />
        </Switch>
      </Router>        
    );
  }
}

export default connect()(App)


