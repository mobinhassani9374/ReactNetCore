import React, { Component } from 'react';
import Layout from './Layout';
import { connect } from 'react-redux';
class Home extends Component {

  render() {   
    return (
      <div>
        <Layout />
      </div>
    );
  }
}


export default connect()(Home);
