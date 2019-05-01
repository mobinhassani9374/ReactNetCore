import React, { Component } from 'react'
import Request from '../Service/Request';
import UserItem from './UserItem';
import Layout from './Layout';
import { connect } from 'react-redux';
import {getUser} from '../actions/user';
import loading from '../actions/loading';
class UserList extends Component {
    state = {
        isLoading: true
    }
    componentDidMount() {
        this.loadData();
    }

    loadData = () => {
        this.props.dispatch(loading(true))
        this.setState({
            userList: [

            ],
            isLoading: true
        })
        Request('/api/user').then(res => {
            this.props.dispatch(getUser(res.data))
            this.setState({ isLoading: false });
            setTimeout(() => {
                this.props.dispatch(loading(false))
            }, 100);
        }).catch(error => {                       
            if(error.response.status===401) {
                localStorage.removeItem("token");                
                this.props.history.push('/login'); 
            }            
        });
    }

    deleteUser = (id) => {        
        this.loadData();
    }
  
    render() {
        let { userList, isLoading } = this.state; 
        let {user} = this.props       
        return (
            <div >
                <Layout />
                <div className="section">
                    <div className="container">
                        <div className="row">
                            <div className="card w-100">
                                <div className="card-header">لیست کاربران</div>
                                <div className="card-body">
                                    <div className="table-responsive">
                                        <table className="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th>ردیف</th>
                                                    <th>نام ونام خانوادگی کاربر</th>
                                                    <th>رمز عبور</th>
                                                    <th>نام کاربری </th>
                                                    <th>حذف</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {
                                                    isLoading ? <tr><td className="text-danger text-center" colSpan="5">در حال بارگزاری اطلاعات</td></tr>
                                                        : user.map((item, index) => <UserItem user={item} index={index} key={index} deleteUser={this.deleteUser} />)
                                                }
                                            </tbody>
                                        </table>                                  
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

const mapStateToProp=(state)=> {
    return state
}

export default connect(mapStateToProp)(UserList)
