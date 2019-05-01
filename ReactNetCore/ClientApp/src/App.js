import React, { Component } from 'react';
import Home from './components/Home';
import { loadProgressBar } from 'axios-progress-bar';
import '../node_modules/bootstrap/dist/css/bootstrap.css';
import {BrowserRouter as Router, Route , Switch } from 'react-router-dom'
import UserList from './components/UserList';
import UserAdd from './components/UserAdd';
import NotFound from './components/NotFound';
import Login from './components/Login';
import Cartable from './components/Cartable';
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
    let {login,user ,loading} = this.props
    console.log('login',login)
    console.log('user',user)
    console.log('loading',loading)
    return (
      <div>
        {
          loading ? <div className="loading">
              <div className="loading-spin"></div>
          </div> : ''
        } 
        <Router>        
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/users/" component={UserList} />
            <Route path="/users-add" component={UserAdd} />
            <Route path="/login" component={Login} />
            <Route path="/cartable/:id" component={Cartable} />
            <Route component={NotFound} />
          </Switch>
        </Router> 
      </div>       
    );
  }
}

const mapStateToProp=(state)=> {
  return state
}

export default connect(mapStateToProp)(App)


