const initialState = [];

let user =(state = initialState , action) => {   
    switch(action.type) {
        case "getUser" : return action.users
    } 
    return state
}

export default user;