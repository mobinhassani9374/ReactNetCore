import React, { Component } from 'react'
import Layout from './Layout';

export default class Routine extends Component {

    state = {
        totalPage:50,
        pageNumber:this.props.match.params.pageNumber,
        pageSize:this.props.match.params.pageSize,
        type:this.props.match.params.type,
        tableName: this.props.match.params.tableName
    }
    pagination=(status)=> {
        console.log(status);
    }

    changeSelect =(event)=> {
        this.setState({
            pageSize:event.target.value
        })
    }
    render() {
        let {tableName , type , pageSize ,pageNumber} = this.props.match.params;
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
                                <p>نام جدول : {tableName}</p>
                                <p>نوع : {type}</p>
                                <p> تعداد رکورد نمایشی : {pageSize}</p>    
                                <p>  صفحه نمایشی : {pageNumber}</p>    
                                <hr className="mt-4 mb-4"/>

                                <ul className="nav nav-tabs">
                                    <li className="nav-item">
                                        <a className={"nav-link  " + (type=='Draft' ? 'active' : '')} data-toggle="tab">پیش نویس ها </a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={"nav-link  " + (type=='New' ? 'active' : '')}  data-toggle="tab">تازه ها</a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={"nav-link  " + (type=='Archive' ? 'active' : '')} data-toggle="tab">آرشیوها</a>
                                    </li>
                                    <li className="nav-item">
                                        <a className={"nav-link  " + (type=='Done' ? 'active' : '')} data-toggle="tab">خاتمه یافته ها</a>
                                    </li>
                                </ul>

                                <div className="tab-content">
                                    <div className={"tab-pane container " + (type=='Draft' ? 'active' : '')}>
                                        <div className="table-responsive">                                                 
                                            <table className="table table-striped">
                                                <thead>
                                                    <tr>
                                                        <th>Firstname</th>
                                                        <th>Lastname</th>
                                                        <th>Email</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>John</td>
                                                        <td>Doe</td>
                                                        <td>john@example.com</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Mary</td>
                                                        <td>Moe</td>
                                                        <td>mary@example.com</td>
                                                    </tr>
                                                    <tr>
                                                        <td>July</td>
                                                        <td>Dooley</td>
                                                        <td>july@example.com</td>
                                                    </tr>
                                                </tbody>
                                            </table>                                    
                                        </div>
                                        <div className="row">
                                           <div className="col-sm-2">
                                                <ul className="pagination">
                                                    <li className="page-item"><a onClick={this.pagination('next')} className="page-link"><i className="fa fa-angle-double-right"></i></a></li>
                                                    <li className="page-item"><a onClick={this.pagination('next-last')} className="page-link"><i className="fa fa-angle-right"></i></a></li>                                            
                                                    <li className="page-item"><a  className="page-link">{pageNumber}</a></li>                                            
                                                    <li className="page-item"><a onClick={this.pagination('prev')} className="page-link"><i className="fa fa-angle-left"></i></a></li>    
                                                    <li className="page-item"><a onClick={this.pagination('prev-last')} className="page-link"><i className="fa fa-angle-double-left"></i></a></li>                                                                                    
                                                </ul>
                                           </div>
                                           <div className="col-sm-3">
                                                <div className="form-group">
                                                    <select onChange={this.changeSelect} className="form-control" value={this.state.pageSize}>
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
                                    <div className={"tab-pane container " + (type=='New' ? 'active' : '')}>
                                        .... New
                                    </div> 
                                    <div className={"tab-pane container " + (type=='Archive' ? 'active' : '')}>
                                        .... Archive
                                    </div> 
                                    <div className={"tab-pane container " + (type=='Done' ? 'active' : '')}>
                                        .... Done
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
