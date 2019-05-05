const initialState = [];

let user =(state = initialState , action) => {   
    switch(action.type) {
        case "getUser" : return action.users
        default : break;
    } 
    return state
}

export default user;