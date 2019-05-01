const initialState = {authorization :false};

let login =(state = initialState , action) => {     
    switch(action.type) {
        case "authorization" : return {authorization: action.isAuth}
    } 
    return state
}

export default login;