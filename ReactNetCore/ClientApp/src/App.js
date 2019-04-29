import React, { Component } from 'react';
import { Home } from './components/Home';
import { loadProgressBar } from 'axios-progress-bar';
import '../node_modules/bootstrap/dist/css/bootstrap.css';
import {BrowserRouter as Router, Route , Switch } from 'react-router-dom'
import UserList from './components/UserList';
import UserAdd from './components/UserAdd';
import NotFound from './components/NotFound';
import Login from './components/Login';

export default class App extends Component {
  componentDidMount () {
    loadProgressBar()
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


