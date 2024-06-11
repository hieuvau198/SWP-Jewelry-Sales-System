const initialState = {
    username: '',
    darkMode: '',
    highcontrast: '',
    openmodal: false,
    openhelp: false,
    rtlmode:false,
    gradient:'',
    addimage:'',
    imgvalidation:''
}

const Mainreducer = (state = initialState, action) => {
    switch (action.type) {
       
        case 'USER_NAME': {
           
            return {
                ...state,
                username: action.payload
            }
        }
        case 'OPEN_MODAL':{
           
            return{
                ...state,
                openmodal:action.payload
            }
        }
        case 'SECOND':{
          
            return{
                ...state,
                second:action.payload
            }
        }
      case 'DARK_MODE':{
          
          return{
              ...state,
              darkMode:action.payload
          }
      }
      case 'HIGH_CONTRAST':{
         
          return{
              ...state,
              highcontrast:action.payload
          }
      }
      case 'GRADIENT_COLOR':{
          return{
              ...state,
              gradient:action.payload
          }
      }
      case 'ADD_IMAGE':{
            return{
                ...state,
                addimage:action.payload
            }

        }
        case 'IMAGE_VALIDATION':{
              return{
                  ...state,
                  imgvalidation:'it is more then 10 mb'
              }
  
          }
        default: {
            return state
        }
    }

}

export default Mainreducer;