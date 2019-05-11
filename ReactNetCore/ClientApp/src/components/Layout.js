import React, { Component } from 'react'
import {NavLink } from 'react-router-dom'
import authorization from '../actions/login'
import {connect} from 'react-redux'
import { Redirect } from 'react-router-dom'
import { toast } from 'react-toastify';

class Layout extends Component {

  state = {
    redirect:false
  }

  logout=()=> {
    localStorage.removeItem("token");
    let {dispatch} = this.props
    dispatch(authorization(false))
    this.setState({redirect:true}) 
    toast.info('خدافظ حسن قلی خان')
  }
  render() {  
    let {authorization} = this.props.login;   
    let {redirect} = this.state;
    console.log(this.props)
    if(redirect) {
      return <Redirect  to='/login'/>
    }
    return (      
      <div>
        <nav className="navbar navbar-expand-sm bg-dark navbar-dark sticky-top">
          {/* <NavLink to="/" class="navbar-brand" href="#">React.NteCore</NavLink> */}
          <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="collapsibleNavbar">
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
          </div>          
        </nav>                    
      </div>
    )
  }
}

const mapStateToProp=(state)=> { 
  return state
}

export default connect(mapStateToProp)(Layout);
