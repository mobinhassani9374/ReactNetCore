import React, { Component } from 'react'
import Layout from './Layout';
import Request from '../Service/Request';
import { connect } from 'react-redux';
import loading from '../actions/loading';
import { toast } from 'react-toastify';
import {NavLink } from 'react-router-dom'

class Cartable extends Component {
    state = {
        routine : {
            title:'' ,
            tableName:'' , 
            id:'' ,
        },

        routineItems:[]
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
            this.setState({routine:response.data})
            Request(`/api/routine/getrolesWithdashboardcreation/${this.props.match.params.id}`).then(response=>{             
                this.setState({
                    routineItems:response.data
                })
                this.props.dispatch(loading(false))
            })
            .catch(error=>{
                this.props.history.push('/')
                setTimeout(() => {
                    toast.error('برنامه با خطا مواجه شد ');
                    this.props.dispatch(loading(false))
                }, 100);
            })  
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
        let {title , tableName , id } = this.state.routine;   
        let {routineItems} = this.state
        return (            
            <div >
                <Layout />
                <div className="container">
                    <div className="section">
                        <div className="card">
                            <div className="card-header">
                                مدیریت کارتابل ها 
                            </div>
                            <div className="card-body">
                                <p className="text-right">نام جدول : {tableName}</p>
                                <p className="text-right">عنوان : {title}</p>
                                <p className="text-right">آی دی : {id}</p>    
                                <hr className="mt-4 mb-4"/>

                                <div className="alert alert-success">
                                    <strong>کارتابل!</strong> نمایش کارتابلهای موجود 
                                </div>
                                <ul className="list-group p-0">
                                {
                                    routineItems.map((item,index)=><li key={index} className="list-group-item text-right"><NavLink to={`/routine/${id}/${tableName}/${item.dashboardEnum}/Draft/10/1`}>{item.title}</NavLink></li>)
                                } 
                                </ul> 
                            </div>             
                        </div>
                    </div>                    
                </div>
            </div>
        )
    }
}
export default connect()(Cartable)
