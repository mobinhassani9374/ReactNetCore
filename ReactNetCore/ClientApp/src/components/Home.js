import React, { Component } from 'react';
import Request from '../Service/Request';

export class Home extends Component {

  render() {
    console.log(Request('https://jsonplaceholder.typicode.com/users'))
    return (
      <div>
        <h1>Hello, world!</h1>‌ 
      </div>
    );
  }
}
