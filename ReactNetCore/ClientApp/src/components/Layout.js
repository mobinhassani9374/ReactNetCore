import React, { Component } from 'react'
import {NavLink } from 'react-router-dom'
import authorization from '../actions/login'
import {connect} from 'react-redux'
import { stat } from 'fs';

class Layout extends Component {

  logout=()=> {
    localStorage.removeItem("token");
    let {history, dispatch} = this.props
    dispatch(authorization(false))
    window.location='/login'     
  }
  render() {  
    let {authorization} = this.props.login;      
    return (      
      <div>
        <nav className="navbar navbar-expand-sm bg-dark navbar-dark sticky-top">
          <ul className="navbar-nav">
            <li className="nav-item">
              <NavLink className="nav-link" exact={true} to="/">صفحه اصلی</NavLink>
            </li>
            {
              authorization ? 
                <li className="nav-item">
                  <NavLink className="nav-link" to="/users">لیست کاربران</NavLink>
                </li> : ''
            }           
            {
              authorization ? 
                <li className="nav-item">
                  <NavLink className="nav-link" to="/users-add">اضافه نمودن کاربر جدید </NavLink>
                </li>  : ''
            }   
            {
              authorization ? 
                <li className="nav-item">
                  <NavLink className="nav-link" to="/cartable/1">روال اول</NavLink>
                </li> : ''
            }                                                                  
            {
              authorization ? 
                <li className="nav-item">
                  <NavLink className="nav-link" to="/cartable/2">روال دوم</NavLink>
                </li> : ''
            }                                                                  
            {
              authorization ? 
                <li className="nav-item">
                  <NavLink className="nav-link" to="/cartable/3">روال سوم</NavLink>
                </li> : ''
            }                                                                  
            {
              authorization ? 
                <li className="nav-item">
                  <NavLink className="nav-link" to="/cartable/4">روال چهارم</NavLink>
                </li> : ''
            }                                                                  
            {
              authorization ? 
                <li className="nav-item">
                    <a onClick={this.logout} className="nav-link" >خروج</a>
                </li>  : ''
            }
            {
              !authorization ? 
                <li className="nav-item">
                  <NavLink className="nav-link" to="/login">ورود</NavLink>
              </li> : ''              
            }                                                                      
          </ul>
        </nav>            
      </div>
    )
  }
}

const mapStateToProp=(state)=> {
  return state
}

export default connect(mapStateToProp)(Layout);
