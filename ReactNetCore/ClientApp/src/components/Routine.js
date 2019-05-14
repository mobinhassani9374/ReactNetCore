import React, { Component } from 'react'
import Layout from './Layout';
import { connect } from 'react-redux';
import loading from '../actions/loading';
import Request from '../Service/Request'
import {toast} from 'react-toastify'

 class Routine extends Component {

    state = {
        totalPage:50,
        header:[],
        body:[],
        action:[]
    }

    componentDidMount() {
        this.updateData()
    }

    handleBodyTable=(body,header)=> {
        this.setState({body:[],action:[]})
        body.forEach(item => {           
            var newBody = [];

            this.setState(prevState => ({
                action: [...prevState.action, item.Actions]
            }))
                   
            this.state.header.forEach(i=> {               
                //newBody[i.titleEn]=item[i.titleEn]
                newBody.push(item[i.titleEn])
            }) 
                   
            this.setState(prevState => ({
                body: [...prevState.body, newBody]
            }))            
        });  
        console.log('body',this.state.body)      
        console.log('Actions',this.state.action)      
    }

    updateData = ()=> {
        this.props.dispatch(loading(true))
        
        let { type , tableName , routineId , dashboardEnum } = this.props.match.params;
        
        let head=[]

        Request(`/${tableName}/manage`,'Post',{
            dashboardType:type,
            routineId:routineId,
            dashboardEnum:dashboardEnum
        }).then(res=>{
            Request(`/api/routine/fields/${routineId}`).then(respo=> {
                this.props.dispatch(loading(false))              
                this.setState({header:respo.data})               
                this.handleBodyTable(res.data)  
            })
            .catch(error=> {
                this.props.dispatch(loading(false))
            })
                    
        }).catch(error=> {
            this.props.dispatch(loading(false))
            this.props.history.push('/')
            toast.error('برنامه با خطا مواجه شد ')
        })
    }

    componentDidUpdate(prevProps) {
        if (this.props.match.params.type !== prevProps.match.params.type 
            || this.props.match.params.pageSize !== prevProps.match.params.pageSize 
            || this.props.match.params.pageNumber !== prevProps.match.params.pageNumber 
            || this.props.match.params.tableName !== prevProps.match.params.tableName  ) {
           this.updateData()
        }
    }

    pagination = (status)=> {
        let {pageNumber , type , pageSize , tableName , routineId , dashboardEnum} = this.props.match.params;             
        switch(status) {           
            case 'next':       
              if(this.state.totalPage>pageNumber) {
                this.props.history.push(`/routine/${routineId}/${tableName}/${dashboardEnum}/${type}/${pageSize}/${++pageNumber}`) 
              }
              break;
            case 'prev':                  
                if(this.state.totalPage>=pageNumber && pageNumber>1) {
                    this.props.history.push(`/routine/${routineId}/${tableName}/${dashboardEnum}/${type}/${pageSize}/${pageNumber-1}`) 
                }
                break;
            case 'prev-last': 
                if(pageNumber!==1) {
                    this.props.history.push(`/routine/${routineId}/${tableName}/${dashboardEnum}/${type}/${pageSize}/1`) 
                }
              break;
            case 'next-last': 
                if(pageNumber!==this.state.totalPage) {
                    this.props.history.push(`/routine/${routineId}/${tableName}/${dashboardEnum}/${type}/${pageSize}/${this.state.totalPage}`) 
                }
              break;
            default:              
        }
    }

    changeSelect =(event)=> {       
        let pageSize = event.target.value
        let {pageNumber , type ,  tableName , routineId , dashboardEnum} = this.props.match.params;
        this.props.history.push(`/routine/${routineId}/${tableName}/${dashboardEnum}/${type}/${pageSize}/${pageNumber}`) 
    }

    changeTab=(type)=> {
        if(type!==this.props.match.params.type) {
            let {pageSize , tableName , routineId , dashboardEnum} = this.props.match.params;
            this.props.history.push(`/routine/${routineId}/${tableName}/${dashboardEnum}/${type}/${pageSize}/1`)
        }      
    }

    render() {
        let { tableName , type , pageSize ,pageNumber , routineId , dashboardEnum} = this.props.match.params;     
        return (
            <div >
                <Layout />
                <div className="container">
                    <div className="section">
                        <div className="card">
                            <div className="card-header">
                                مدیریت روال ها 
                            </div>
                            <div className="card-body">
                                <p className="text-right">نام جدول : {tableName}</p>
                                <p className="text-right">نوع : {type}</p>
                                <p className="text-right"> تعداد رکورد نمایشی : {pageSize}</p>    
                                <p className="text-right">  صفحه نمایشی : {pageNumber}</p> 
                                <p className="text-right">تعداد صفحات موجود : {this.state.totalPage}</p>   
                                <p className="text-right">  روتین آی دی  : {routineId}</p>   
                                <p className="text-right">  dashboardEnum  : {dashboardEnum}</p>   
                                <hr className="mt-4 mb-4"/>

                                <ul className="nav nav-tabs">
                                    <li className="nav-item">
                                        <a onClick={()=>this.changeTab('Draft')} className={"nav-link  " + (type==='Draft' ? 'active' : '')} data-toggle="tab">پیش نویس ها </a>
                                    </li>
                                    <li className="nav-item">
                                        <a onClick={()=>this.changeTab('New')} className={"nav-link  " + (type==='New' ? 'active' : '')}  data-toggle="tab">تازه ها</a>
                                    </li>
                                    <li className="nav-item">
                                        <a onClick={()=>this.changeTab('Archived')} className={"nav-link  " + (type==='Archived' ? 'active' : '')} data-toggle="tab">آرشیوها</a>
                                    </li>
                                    <li className="nav-item">
                                        <a onClick={()=>this.changeTab('Done')} className={"nav-link  " + (type==='Done' ? 'active' : '')} data-toggle="tab">خاتمه یافته ها</a>
                                    </li>
                                </ul>

                                <div className="tab-content">
                                    <div className="tab-pane container active">
                                        <div className="table-responsive">                                                 
                                            <table className="table table-striped">
                                                <thead>
                                                    <tr>
                                                        {
                                                            this.state.header.map((item,index)=>
                                                                <th key={index}>{item.title}</th>
                                                            )
                                                        }
                                                        <th>اقدامات</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    {
                                                        this.state.body.map((item,index)=>
                                                            <tr key={index}>
                                                                {
                                                                    item.map((it,ind)=>
                                                                        <td key={ind}>{it}</td>
                                                                    )                                                                   
                                                                }
                                                                 <td>
                                                                    {
                                                                        this.state.action[index].map((i,inde)=>
                                                                            <a className={`${i.icon} ${i.color} pe-2x pe-va`}></a>
                                                                        )
                                                                    }
                                                                </td>
                                                            </tr>
                                                        )
                                                    }   

                                                    {
                                                        this.state.body.length==0 ? 
                                                            <tr>
                                                                <td className="text-center text-danger" colSpan={this.state.header.length+1}>اطلاعاتی وجود ندارد </td>
                                                            </tr>
                                                        :''
                                                    }                                                
                                                </tbody>
                                            </table>                                    
                                        </div>
                                        <div className="row">
                                           <div className="col-sm-2">
                                                <ul className="pagination">
                                                    <li className="page-item"><a onClick={()=>this.pagination('next-last')} className="page-link"><i className="fa fa-angle-double-right"></i></a></li>
                                                    <li className="page-item"><a onClick={()=>this.pagination('next')} className="page-link"><i className="fa fa-angle-right"></i></a></li>                                            
                                                    <li className="page-item"><a  className="page-link">{pageNumber}</a></li>                                            
                                                    <li className="page-item"><a onClick={()=>this.pagination('prev')} className="page-link"><i className="fa fa-angle-left"></i></a></li>    
                                                    <li className="page-item"><a onClick={()=>this.pagination('prev-last')} className="page-link"><i className="fa fa-angle-double-left"></i></a></li>                                                                                    
                                                </ul>
                                           </div>
                                           <div className="col-sm-3">
                                                <div className="form-group">
                                                    <select onChange={this.changeSelect} className="form-control" value={pageSize}>
                                                        <option value={10}>10</option>
                                                        <option value={20}>20</option>
                                                        <option value={30}>30</option>
                                                        <option value={40}>40</option>
                                                        <option value={50}>50</option>
                                                    </select>
                                                </div>
                                           </div>
                                        </div>
                                    </div>                                                                       
                                </div>
                            </div>             
                        </div>
                    </div>                    
                </div>
            </div>
        )
    }
}

const mapStateToProps =(state)=>{
    return state
}

export default connect(mapStateToProps)(Routine)
