import React, { Component } from 'react'
import Request from '../Service/Request';
import UserItem from './UserItem';
import Layout from './Layout';

export default class UserList extends Component {
    state = {
        userList: [

        ],
        isLoading: true
    }
    componentDidMount() {
        this.loadData();
    }

    loadData = () => {
        this.setState({
            userList: [

            ],
            isLoading: true
        })
        Request('/api/user').then(res => {
            setTimeout(() => {
                this.setState({ userList: res.data })
                this.setState({ isLoading: false })
            }, 100);
        })
    }

    deleteUser = (id) => {
        console.log('id =>>>>>>> ',id);
        this.loadData();
    }
  
    render() {
        let { userList, isLoading } = this.state;
        return (
            <div >
                <Layout />
                <div className="section">
                    <div className="container">
                        <div className="row">
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
                                                : userList.map((item, key) => <UserItem user={item} key={key} deleteUser={this.deleteUser} />)
                                        }
                                    </tbody>
                                </table>                                  
                            </div>
                        </div>
                    </div>  
                </div>                        
            </div>
           
        )
    }
}
