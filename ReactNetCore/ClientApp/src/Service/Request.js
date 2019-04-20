import axios from 'axios';
export default Request=(url)=>{
    axios.get(url)
    .then(res => {
      return res;
    })
}