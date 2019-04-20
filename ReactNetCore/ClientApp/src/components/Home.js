import React, { Component } from 'react';
import Request from '../Service/Request';
import UserList from './UserList';

export class Home extends Component {

  render() {
    console.log(Request('https://jsonplaceholder.typicode.com/users'))
    return (
      <div>        
        <UserList />
      </div>
    );
  }
}
