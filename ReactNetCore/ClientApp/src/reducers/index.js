import { combineReducers } from 'redux'
import login from './login'
import user from './user'
import loading from './loading'

export default combineReducers({
    login,
    user,
    loading
})