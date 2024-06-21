export const OnchangeAddimage=(e)=>(dispatch)=>{
    
    if(e[0].size < (1 * 1024 * 1024)){
        dispatch({
            type:'ADD_IMAGE',
            payload:e
        })
    }
    else{
        dispatch({
            type:'IMAGE_VALIDATION'
        })
        
    }
}

export const Onchangeusername = (e) => (dispatch) => {
    dispatch({
        type: 'USER_NAME',
        payload: e
    })
}

export const onChangeDarkMode = (val) => (dispatch) => {
    
    if (val === 'dark') {
        window.document.children[0].setAttribute('data-theme', 'dark');
    } else if (val === 'high-contrast') {
        //window.document.children[0].setAttribute('data-theme', 'light')
    } else {
        window.document.children[0].setAttribute('data-theme', 'light')
    }
    dispatch({
        type: 'DARK_MODE',
        payload: val
    })
    dispatch({
        type: 'HIGH_CONTRAST',
        payload: val
    })
}
export const onChangeHighcontrast = (val) => (dispatch) => {
    
    if (val === 'high-contrast') {
        window.document.children[0].setAttribute('data-theme', 'high-contrast');
    } else if (val === 'dark') {
        window.document.children[0].setAttribute('data-theme', 'light')
    }
    else {
        window.document.children[0].setAttribute('data-theme', 'light')
    }
    dispatch({
        type: 'HIGH_CONTRAST',
        payload: val
    })
    dispatch({
        type: 'DARK_MODE',
        payload: val
    })
}
export const OnchangeRTLmode = (val) => (dispatch) => {

    if (document.body.classList.contains("rtl_mode")) {
        document.body.classList.remove("rtl_mode")
    } else {
        document.body.classList.add("rtl_mode");
    }

    dispatch({
        type: 'rtl_mode',
        payload: val
    })
}
export const Onopenmodalsetting = (val) => (dispatch) => {

    dispatch({
        type: 'OPEN_MODAL',
        payload: val
    })
}
export const OnGradientColor = (val) => (dispatch) => {
    var theme = document.getElementById("mainsidemenu");
    if (theme) {
        if(!theme.classList.contains('gradient')){
            theme.classList.add('gradient');
            dispatch({
                type: 'GRADIENT_COLOR',
                payload: true
            })
        }
        else
        {
            theme.classList.remove('gradient');
            dispatch({
                type: 'GRADIENT_COLOR',
                payload: false
            })
        }
    }
    
}