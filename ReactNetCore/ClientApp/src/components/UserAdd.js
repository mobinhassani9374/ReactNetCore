import React, { Component } from 'react';
import Request from '../Service/Request';
import Layout from './Layout';

export default class UserAdd extends Component {
    state = {
        password:'',
        userName:'',
        fullName:''
    }    

    handleChange = (event) => {              
        let {value , name} = event.target;       
        this.setState({
            [name] : value
        })
    }

    handleSubmit = (event) => {
        event.preventDefault();
        Request('/api/user','post',this.state).then(res=>alert('کاربر با موفقیت اضافه شد '))
        this.setState({
            password:'',
            userName:'',
            fullName:''
        }).catch(error => {                       
            if(error.response.status===401) {
                localStorage.removeItem("token")
            }            
        });                    
    }
  
    render() {
        let {userName , fullName , password} = this.state;        
        return (
            <div>
                <Layout />
                <div className="section">
                    <div className="container">
                        <div className="row">
                            <div className="card w-100">
                                <div class="card-header">اضافه نمودن کاربر جدید </div>
                                <div className="card-body">
                                    <div className="row">
                                        <div className="col-sm-6">
                                            <form onSubmit={this.handleSubmit}>
                                                <div className="form-group">
                                                    <label>نام و نام خانوادکی کاربر</label>
                                                    <input required onChange={this.handleChange} value={fullName} placeholder="نام و نام خانوادکی کاربر" type="text" className="form-control" name="fullName" />
                                                </div>
                                                <div className="form-group">
                                                    <label>نام کاربری کاربر</label>
                                                    <input required onChange={this.handleChange} value={userName} placeholder="نام کاربری کاربر" type="text" className="form-control" name="userName" />
                                                </div>
                                                <div className="form-group">
                                                    <label>رمز عبور کاربر</label>
                                                    <input required onChange={this.handleChange} value={password} placeholder="رمز عبور کاربر" type="password" className="form-control" name="password" />
                                                </div>
                                                <div className="form-group">
                                                    <button className="btn btn-outline btn-success btn-block">ثبت نام</button>
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
