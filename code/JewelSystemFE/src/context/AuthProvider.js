import { createContext, useState } from "react";

const AuthContext = createContext({});

export const AuthProvider = ({ children }) => {
    const [auth, setAuth] = useState({});
    return (
        <AuthContext.Provider value={{ auth, setAuth }}>
            <h1>{JSON.stringify(auth)}</h1>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthContext;