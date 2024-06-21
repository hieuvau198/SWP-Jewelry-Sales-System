import { useLocation, Navigate, Outlet } from "react-router-dom";
import { useCookies } from "react-cookie";

const RequireAuth = ({ allowedRoles }) => {
    const [cookies, setCookie] = useCookies();
    const auth = cookies.user;
    const setAuth = setCookie.user;
    const location = useLocation();
    console.log(JSON.stringify(auth));

    return (
        auth?.roles?.find(role => allowedRoles?.includes(role))
            ? <Outlet />
            : auth?.username
                ? <Navigate to={process.env.PUBLIC_URL+"/sign-in"} state={{ from: location }} replace />
                : <Navigate to={process.env.PUBLIC_URL+"/sign-in"} state={{ from: location }} replace />
    );
}

export default RequireAuth;