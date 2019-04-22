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
                <td>
                    <button onClick={()=>this.props.deleteUser(user.id)} className="btn btn-outline-danger">delete <i className="fa fa-trash"></i></button>
                </td>
            </tr>
        )
    }
}
