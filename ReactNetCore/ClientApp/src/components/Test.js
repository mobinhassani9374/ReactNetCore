import React, { Component } from 'react';
import { MDBInput } from 'mdbreact';

class Test extends Component {
state = {
  modal: false
}

toggle = () => {
  this.setState({
    modal: !this.state.modal
  });
}

render() {
  return (
        <MDBInput
            label="Your name"
            icon="user"
            group
            type="text"
            validate
            error="wrong"
            success="right"
        />
    );
  }
}

export default Test;