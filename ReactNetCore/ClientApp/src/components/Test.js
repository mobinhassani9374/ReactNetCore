import React, { Component } from 'react'
import { MDBInput } from "mdbreact";

export default class Test extends Component {
  render() {
    return (
      <div>
        <div className="form-group">
            <label htmlFor="exampleInput">Your e-mail</label>
            <input type="email" id="exampleInput" className="form-control" />
        </div>
      </div>
    )
  }
}
