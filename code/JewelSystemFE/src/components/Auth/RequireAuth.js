import { useLocation, Navigate, Outlet } from "react-router-dom";
import useAuth from "../../hooks/useAuth";

const RequireAuth = ({ allowedRoles }) => {
    const { auth } = useAuth();
    const location = useLocation();

    return (
        auth?.roles?.find(role => allowedRoles?.includes(role))
            ? <Outlet />
            : auth?.username
                ? <Navigate to={process.env.PUBLIC_URL+"/sign-in"} state={{ from: location }} replace />
                : <Navigate to={process.env.PUBLIC_URL+"/sign-in"} state={{ from: location }} replace />
    );
}

export default RequireAuth;