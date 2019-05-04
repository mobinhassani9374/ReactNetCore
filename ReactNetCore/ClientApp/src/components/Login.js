import React, { Component } from 'react'
import Layout from './Layout';
import Request from '../Service/Request';
import authorization from '../actions/login';
import { connect } from 'react-redux';
import { toast } from 'react-toastify';
import loading from '../actions/loading';
class Login extends Component {

    componentDidMount() {         
        let hasToken = localStorage.getItem("token");
        if(hasToken!=null) {
            this.props.dispatch(authorization(true))
            this.props.history.push('/'); 
        }
        else {
            this.props.dispatch(authorization(false))
            //this.props.dispatch(loading(false))
        }
    }
    state = {
        userName :'',
        password :''
    }

    handleChange =(event)=> {
        let {name , value} = event.target; 
        this.setState({
            [name]:value
        })
    }
    handleSubmit=(e)=> {
        e.preventDefault();
        let {userName , password} = this.state;     
        Request('/login','Post',{password,userName}).then(response=>{          
          if(response.data.isSuccess) {
            localStorage.setItem("token",response.data.token);
            this.props.dispatch(authorization(true))
            this.props.history.push('/'); 
            toast.success('کاربر گرامی خوش آمدید ')  
          }
          else {
            toast.error(response.data.message)                        
          }
        })
    }
    render() {
        let {userName , password} = this.state;       
        return (
            <div>
                <Layout />
                <div className="section">
                    <div className="container">
                        <div className="row">
                            <div className="card col-md-6 col-12 m-auto p-0">
                                <div className="card-header">ورود به سامانه </div>
                                <div className="card-body">
                                    <div className="row">
                                        <div className="col-sm-12">
                                            <form onSubmit={this.handleSubmit}>
                                                <div className="form-group">
                                                    <label>نام  کاربری</label>
                                                    <input onChange={this.handleChange} value={userName} required  placeholder="نام کاربری" type="text" className="form-control" name="userName" />
                                                </div>                                           
                                                <div className="form-group">
                                                    <label>رمز عبور کاربر</label>
                                                    <input onChange={this.handleChange} value={password} required placeholder="رمز عبور کاربر" type="password" className="form-control" name="password" />
                                                </div>
                                                <div className="form-group">
                                                    <button className="btn btn-outline btn-success btn-block">ورود</button>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>  
                </div>
            </div> 
        )
    }
}

const mapStateToProp=(state)=>{ 
    return state;
}

export default connect(mapStateToProp)(Login);
