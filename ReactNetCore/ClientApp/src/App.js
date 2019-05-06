import React, { Component } from 'react';
import Home from './components/Home';
import { loadProgressBar } from 'axios-progress-bar';
import 'react-toastify/dist/ReactToastify.css';
import {BrowserRouter as Router, Route , Switch } from 'react-router-dom'
import UserList from './components/UserList';
import UserAdd from './components/UserAdd';
import NotFound from './components/NotFound';
import Login from './components/Login';
import Cartable from './components/Cartable';
import Routine from './components/Routine';
import {connect} from 'react-redux';
import authorization from './actions/login';
import { ToastContainer } from 'react-toastify';
import Test from './components/Test';

class App extends Component {
  componentDidMount () {
    loadProgressBar()
    let hasToken = localStorage.getItem("token");
    if(hasToken!=null) {
      this.props.dispatch(authorization(true))
    }
  }
  render() {
    let {loading} = this.props    
    return (
      <div>
        {
          loading ? <div className="loading">
              <div className="loading-spin"></div>
          </div> : ''
        } 
        <ToastContainer position={'bottom-left'} autoClose={4000} rtl={true}/>        
        <Router>        
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/users/" component={UserList} />
            <Route path="/users-add" component={UserAdd} />
            <Route path="/login" component={Login} />
            <Route path="/cartable/:id" component={Cartable} />
            <Route path="/test" component={Test} />
            <Route path="/routine/:tableName/:type/:pageSize/:pageNumber" component={Routine} />
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


