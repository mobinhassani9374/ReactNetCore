import axios from 'axios';
export default Request=(url)=>{
  return axios.get(url);
}