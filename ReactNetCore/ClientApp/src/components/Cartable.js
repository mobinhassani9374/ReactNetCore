import React, { Component } from 'react'
import Layout from './Layout';
import Request from '../Service/Request';
import { connect } from 'react-redux';

class Cartable extends Component {
    state = {
        routine : {

        }
    }
    componentDidMount() {
        Request(`/api/routine/${this.props.match.params.id}`).then(response=> {
            console.log(response.data);
            this.setState({routine:response.data})
        }).catch(error=> {            
            alert(error.response.data)
            this.props.history.push('/')
        })
    }
    render() { 
        let {title , tableName , id} = this.state.routine;      
        return (
        <div>
            <Layout />
            <div className="section">
                <div className="container">
                    <div className="row flex-column">
                        <p>نام جدول : {tableName}</p>
                        <p>عنوان : {title}</p>
                        <p>آی دی : {id}</p>                       
                    </div>
                </div>
            </div>
        </div>
        )
    }
}
export default connect()(Cartable)
