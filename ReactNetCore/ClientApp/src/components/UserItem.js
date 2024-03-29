import React, { Component } from 'react'

export default class UserItem extends Component {

    
    render() {
        let { user , index } = this.props;      
        return (
            <tr >
                <td>{++index}</td>
                <td>{user.fullName}</td>
                <td>{user.password}</td>
                <td>{user.userName}</td>
                <td>
                  <i onClick={()=>this.props.deleteUser(user.id)} className="pe-7s-close-circle text-danger pe-2x pe-va"></i>
                </td>
            </tr>
        )
    }
}
