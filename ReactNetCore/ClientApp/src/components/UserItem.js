import React, { Component } from 'react'

export default class UserItem extends Component {

    deleteUser = (id) => {
        console.log('id =>>>>>>> ',id);
    }
    render() {
        let { user } = this.props;
        return (
            <tr >
                <td>{user.id}</td>
                <td>{user.fullName}</td>
                <td>{user.password}</td>
                <td>{user.userName}</td>
                <td>
                    <button onClick={this.deleteUser(user.id)} className="btn btn-danger">delete</button>
                </td>
            </tr>
        )
    }
}
