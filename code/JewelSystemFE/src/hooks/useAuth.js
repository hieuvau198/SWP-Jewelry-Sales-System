import { useContext, useDebugValue } from "react";
import AuthContext from "../context/AuthProvider";
import { useCookies } from "react-cookie";

const useAuth = () => {
    const [cookies, setCookie] = useCookies();
    const auth = cookies.user;
    console.log(JSON.stringify(cookies?.user));
    useDebugValue(auth, auth => auth?.user ? "Logged In" : "Logged Out")
    return useContext(AuthContext);
}

export default useAuth;