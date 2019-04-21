import React, { Component } from 'react';
import UserList from './UserList';
import UserAdd from './UserAdd';

export class Home extends Component {

  render() {
    return (
      <div className="container">
        <div className="row">
          <div className="card">
            <div className="card-body p-3">
              <UserList />
              <hr />
              <UserAdd />
            </div>
          </div>
        </div>
      </div>
    );
  }
}
