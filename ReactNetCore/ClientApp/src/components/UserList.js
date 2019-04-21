import React, { Component } from 'react'
import Request from '../Service/Request';
import UserItem from './UserItem';

export default class UserList extends Component {
    state = {
        userList: [

        ]
    }
    componentDidMount() {
        Request('/api/user').then(res => {
            setTimeout(() => {
                this.setState({ userList: res.data })
            }, 500);
        })
    }
    render() {
        let { userList } = this.state;
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
                            userList.map((item, key) => <UserItem user={item} key={key} />)
                        }
                    </tbody>
                </table>
            </div>
        )
    }
}
