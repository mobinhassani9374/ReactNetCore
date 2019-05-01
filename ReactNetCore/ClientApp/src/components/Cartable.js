import React, { Component } from 'react'
import Layout from './Layout';
import Request from '../Service/Request';
import { connect } from 'react-redux';
import loading from '../actions/loading';
import { toast } from 'react-toastify';

class Cartable extends Component {
    state = {
        routine : {

        }
    }

    componentDidMount() {
        this.updateData()
    }

    componentDidUpdate(prevProps) {
        if (this.props.match.params.id !== prevProps.match.params.id) {
           this.updateData()
        }
    }

    updateData = () => {
        this.props.dispatch(loading(true))
        Request(`/api/routine/${this.props.match.params.id}`).then(response=> {
            console.log(response.data);
            this.setState({routine:response.data})
            setTimeout(() => {
                this.props.dispatch(loading(false))
            }, 100);
        }).catch(error=> {  
            if(error.response.status===401) {
                localStorage.removeItem("token");                
                this.props.history.push('/login'); 
            } 
            else {                              
                this.props.history.push('/')
                setTimeout(() => {
                    toast.error(error.response.data)
                }, 100);
            }    
            this.props.dispatch(loading(false))                     
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
