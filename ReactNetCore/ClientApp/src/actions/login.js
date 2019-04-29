const authorization =(isAuth)=> {
    return {
        type:'authorization',
        isAuth
    }
}

export default authorization;