import React, { Component } from 'react'

export default class UserItem extends Component {
  render() {
      let {user , key} = this.props;
    return (
        <tr key={key}>
            <td>{user.id}</td>
            <td>{user.fullName}</td>
            <td>{user.password}</td>
            <td>{user.userName}</td>           
        </tr>
    )
  }
}
