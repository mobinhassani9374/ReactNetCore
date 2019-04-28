import axios from 'axios';
export default Request = (url , method , data) => axios({
    url:url,
    method:method || 'get',
    data : data || '',
    headers : {
        Authorization:"Bearer "+ localStorage.getItem("token")
    }
});