import React, { Component } from 'react';
import UserList from './UserList';

export class Home extends Component {

  render() {
    return (
      <div className="container">
        <div className="card">
          <div className="card-body p-3">
            <UserList />
          </div>
        </div>
      </div>
    );
  }
}
