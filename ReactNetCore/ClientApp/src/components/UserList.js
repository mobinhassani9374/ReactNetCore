import React, { Component } from 'react'

export default class UserList extends Component {
    state = {
        userList :[
            {id:'1',name:'mahdi',family:'hassani'},
            {id:'2',name:'mobin',family:'hassani'},
            {id:'3',name:'mohammad',family:'bahrami'},
        ]
    }
  render() {
      let {userList} = this.state;
    return (
       <table>
           <thead>
               <tr>
                   <th>---</th>
                   <th>name</th>
                   <th>family</th>
               </tr>
           </thead>
           <tbody>
               {
                   userList.map((item,key)=><tr key={key}>
                       <td>{++key}</td>
                       <td>{item.name}</td>
                       <td>{item.family}</td>                       
                   </tr>)
               }
           </tbody>
       </table>     
    )
  }
}
