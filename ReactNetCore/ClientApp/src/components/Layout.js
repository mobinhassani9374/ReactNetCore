import React, { Component } from 'react'
import {NavLink } from 'react-router-dom'

export default class Layout extends Component {
  render() {
    return (
      <div>
            <nav className="navbar navbar-expand-sm bg-light navbar-light">
                <ul className="navbar-nav">
                    <li className="nav-item">
                        <NavLink className="nav-link" exact={true} to="/">صفحه اصلی</NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink className="nav-link" to="/users">لیست کاربران</NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink className="nav-link" to="/users-add">اضافه نمودن کاربر جدید </NavLink>
                    </li>                                     
                </ul>
            </nav>
      </div>
    )
  }
}
