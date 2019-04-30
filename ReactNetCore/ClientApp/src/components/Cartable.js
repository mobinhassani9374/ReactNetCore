import React, { Component } from 'react'
import Layout from './Layout';
import Request from '../Service/Request';

export default class Cartable extends Component {
    componentDidMount() {
        Request(`/api/routin/${this.props.match.params.id}`).then(response=>{
            console.log(response);
        }).catch(error=> {
            console.log(error);
        })
    }
    render() {       
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
