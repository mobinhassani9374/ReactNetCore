import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import 'bootstrap/dist/css/bootstrap.css';
import 'axios-progress-bar/dist/nprogress.css'
import '../node_modules/font-awesome/css/font-awesome.css';
import './docs/fonts/font-fa.css'
import './docs/css/animate.css'
import './docs/css/styles.css?v=0.0.1'
import './docs/lib/pe-icon-7-stroke/css/helper.css'
import './docs/lib/pe-icon-7-stroke/css/pe-icon-7-stroke.css'

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>,
  rootElement);

registerServiceWorker();
