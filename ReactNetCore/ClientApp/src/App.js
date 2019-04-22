import React, { Component } from 'react';
import { Home } from './components/Home';
import { loadProgressBar } from 'axios-progress-bar';
import '../node_modules/bootstrap/dist/css/bootstrap.css';

export default class App extends Component {
  componentDidMount () {
    loadProgressBar()
  }
  render() {
    return (
        <div>
            <Home />
        </div>
    );
  }
}
