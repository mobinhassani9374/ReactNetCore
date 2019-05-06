import React, { Component } from 'react';
import Request from '../Service/Request';
import Layout from './Layout';
import { connect } from 'react-redux';
import { toast } from 'react-toastify';
import loading from '../actions/loading';
import {MDBContainer , MDBRow , MDBInput , MDBBtn , MDBCol , MDBCard ,MDBCardBody , MDBCardHeader , MDBBreadcrumb , MDBBreadcrumbItem , Container  } from 'mdbreact'
 
class UserAdd extends Component {
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
        this.props.dispatch(loading(true))
        Request('/api/user','post',this.state).then(res=> {              
                toast.success('کاربر با موفقیت اضافه شد ')
                this.setState({
                    password:'',
                    userName:'',
                    fullName:''
                })
                this.props.history.push('/users')
            }
        )
        .catch(error => {                       
            if(error.response.status===401) {
                localStorage.removeItem("token")
                this.props.history.push('/login'); 
                this.props.dispatch(loading(false))
            }            
        });                    
    }
  
    render() {
        let {userName , fullName , password} = this.state;        
        return (
            <div>
                <Layout />
                <div className="section">
                    <MDBContainer>
                        <MDBRow >                           
                            <MDBCard className="w-100">
                                <MDBCardHeader>اضافه نمودن کاربر جدید </MDBCardHeader>
                                <MDBCardBody>
                                    <MDBRow>
                                        <MDBCol sm="6">
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
                                                    <MDBBtn className="btn-block" type="submit" gradient="aqua">ثبت نام</MDBBtn>                                                   
                                                </div>
                                            </form>
                                        </MDBCol>
                                    </MDBRow>
                                </MDBCardBody>
                            </MDBCard>
                        </MDBRow>
                    </MDBContainer>  
                </div>
            </div>                      
        )
    }
}

export default connect()(UserAdd)


