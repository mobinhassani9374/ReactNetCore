import React, { Component } from 'react'

export default class UserItem extends Component {
    render() {
        let { user } = this.props;
        return (
            <tr >
                <td>{user.id}</td>
                <td>{user.fullName}</td>
                <td>{user.password}</td>
                <td>{user.userName}</td>
            </tr>
        )
    }
}
