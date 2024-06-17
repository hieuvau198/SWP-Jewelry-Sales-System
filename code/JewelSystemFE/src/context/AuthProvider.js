import { createContext} from "react";
import { useCookies } from 'react-cookie';

const AuthContext = createContext({});



export const AuthProvider = ({ children }) => {
    const [cookies, setCookie] = useCookies();
    const auth = cookies.user;
    const setAuth = setCookie.user;
    console.log(JSON.stringify(auth));
    return (
        <AuthContext.Provider value={{ auth, setAuth }}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthContext;
