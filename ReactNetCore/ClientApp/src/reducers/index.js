
const initialState = {authorization :false};

let reducer =(state = initialState , action) => {   
    console.log(state,action);    
    switch(action.type) {
        case "authorization" : return {authorization: action.isAuth};
    } 
    return state
}

export default reducer;