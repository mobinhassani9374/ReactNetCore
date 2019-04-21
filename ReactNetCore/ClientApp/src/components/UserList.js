import React, { Component } from 'react'
import Request from '../Service/Request';
import UserItem from './UserItem';
import UserAdd from './UserAdd';

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
            }, 1000);
        })
    }
    render() {
        let { userList, isLoading } = this.state;
        return (
            <div>
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th>id</th>
                            <th>fullName</th>
                            <th>password</th>
                            <th>userName</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            isLoading ? <tr><td className="text-danger text-center" colSpan="4">در حال بارگزاری اطلاعات</td></tr>
                                : userList.map((item, key) => <UserItem user={item} key={key} />)
                        }
                    </tbody>
                </table>
                <hr />
                <UserAdd name="mahdi" loadData={this.loadData} />
            </div>
        )
    }
}
