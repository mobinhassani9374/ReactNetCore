import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import { ConnectedRouter } from 'react-router-redux';
import { createBrowserHistory } from 'history';
import reducer from './reducers'
import App from './App';
import registerServiceWorker from './registerServiceWorker';

import 'bootstrap-4.1.3-rtl/css/bootstrap.css';
import 'axios-progress-bar/dist/nprogress.css'
import '../node_modules/font-awesome/css/font-awesome.css';
import './docs/fonts/font-fa.css'
import './docs/css/animate.css'
import './docs/css/styles.css?v=0.0.1'
import './docs/lib/pe-icon-7-stroke/css/helper.css'
import './docs/lib/pe-icon-7-stroke/css/pe-icon-7-stroke.css'

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const history = createBrowserHistory({ basename: baseUrl });

// Get the application-wide store instance, prepopulating with state from the server where available.
const initialState = window.initialReduxState;

const store = createStore(reducer)

const rootElement = document.getElementById('root');

ReactDOM.render(
  <Provider store={store}>
    <ConnectedRouter history={history}>
      <App />
    </ConnectedRouter>
  </Provider>,
  rootElement);

registerServiceWorker();

