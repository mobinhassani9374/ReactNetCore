let loading =(state = false , action) => {     
    switch(action.type) {
        case "loading" : return action.isLoading
    } 
    return state
}

export default loading;