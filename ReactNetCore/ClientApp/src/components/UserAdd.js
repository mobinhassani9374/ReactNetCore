import React, { Component } from 'react';
import Request from '../Service/Request';

export default class UserAdd extends Component {
    state = {
        password:'',
        userName:'',
        fullName:''
    }

    loadData = () => {
        this.props.loadData()
    }

    handleChange = (event) => {              
        let {value , name} = event.target;       
        this.setState({
            [name] : value
        })
    }

    handleSubmit = (event) => {
        event.preventDefault();
        Request('/api/user','post',this.state).then(res=>this.loadData())
        this.setState({
            password:'',
            userName:'',
            fullName:''
        })                       
    }
  
    render() {
        let {userName , fullName , password} = this.state;        
        return (
            <div className="container">
                <div className="row">
                    <div className="card">
                        <div className="card-body">
                            <div className="row">
                                <div className="col-sm-12">
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
        )
    }
}
