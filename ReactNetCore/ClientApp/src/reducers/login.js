const initialState = {authorization :false};

let login =(state = initialState , action) => {     
    switch(action.type) {
        case "authorization" : return {authorization: action.isAuth}
        default : break;
    } 
    return state
}

export default login;