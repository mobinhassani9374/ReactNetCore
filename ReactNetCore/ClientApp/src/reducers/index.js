
const initialState = {authorization :false};

let reducer =(state = initialState , action) => {      
    switch(action.type) {
        case "authorization" : return {authorization: action.isAuth};
    } 
    return state
}

export default reducer;