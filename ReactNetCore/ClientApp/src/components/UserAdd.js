import React, { Component } from 'react'

export default class UserAdd extends Component {
    render() {
        return (
            <div className="card">
                <div className="card-body">
                    <div className="row">
                        <div className="col-xs-4">
                            <form>
                                <div className="form-group">
                                    <label>fullName</label>
                                    <input placeholder="fullname" type="text" className="form-control" name="fullName" />
                                </div>
                                <div className="form-group">
                                    <label>username</label>
                                    <input placeholder="username" type="text" className="form-control" name="username" />
                                </div>
                                <div className="form-group">
                                    <label>password</label>
                                    <input placeholder="password" type="password" className="form-control" name="password" />
                                </div>
                                <div className="form-group">
                                    <button className="btn btn-outline btn-success btn-block">register</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
