import React, { Component } from 'react'
import {NavLink } from 'react-router-dom'

export default class NotFound extends Component {
  render() {
    return (
     <div className="container">
       <div className="row d-flex">
         <div className="col-md-12">
            <div className="error-template">
              <h1 className="mt-4 text-center">
                  Oops!</h1>
              <h2 className="mt-4 text-center">
                  404 Not Found</h2>
              <div className="error-details mt-4 text-center">
                  صفحه درخواستی را پیدا نکردم !!!!!
              </div>
              <div className="error-actions mt-4 text-center">
                  <NavLink to="/" className="btn btn-primary btn-lg"> <span className="glyphicon glyphicon-home"></span>
                      بازگشت به صفحه اصلی  </NavLink>
              </div>
            </div>
         </div>
       </div>
     </div>
    )
  }
}
