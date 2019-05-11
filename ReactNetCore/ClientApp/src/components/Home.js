import React, { Component } from 'react';
import Layout from './Layout';
import { connect } from 'react-redux';

import SweetAlert from 'react-bootstrap-sweetalert'
class Home extends Component {
  state = {
    show:true
  }

  render() {   
    return (
      <div>
        <Layout />
        {
          this.state.show ? 
          <SweetAlert  success title="پنل ادمین " onConfirm={()=>{this.setState({show:false})}}>
            خوش آمدید !!!!
          </SweetAlert> : ''
        }
      </div>
    );
  }
}


export default connect()(Home);
