import React, { Component } from 'react'
import Layout from './Layout';

export default class Cartable extends Component {
  render() {
      console.log(this.props.match.params.id);
    return (
      <div>
        <Layout />
        <div className="section">
            <div className="container">
                <div className="row">
                    cartable Id is : {
                        this.props.match.params.id
                    }
                </div>
            </div>
        </div>
      </div>
    )
  }
}
