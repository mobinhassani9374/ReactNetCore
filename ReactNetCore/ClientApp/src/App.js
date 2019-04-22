import React, { Component } from 'react';
import { Home } from './components/Home';
import { loadProgressBar } from 'axios-progress-bar';
import 'axios-progress-bar/dist/nprogress.css'

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
