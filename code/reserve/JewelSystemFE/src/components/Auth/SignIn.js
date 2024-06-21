import { useRef, useState, useEffect } from 'react';
import { Link, useNavigate, useLocation } from 'react-router-dom';
import { useCookies } from 'react-cookie';
import axios from '../../api/axios';
import ImageSrc from "../../assets/images/google.svg";
const LOGIN_URL = '/auth/login';

const Login = () => {
    const [cookies, setCookie] = useCookies()
    const navigate = useNavigate();
    const location = useLocation();
    const from = location.state?.from?.pathname || "/";

    const userRef = useRef();
    const errRef = useRef();

    const [username, setUsername] = useState('');
    const [password, setpassword] = useState('');
    const [errMsg, setErrMsg] = useState('');

    useEffect(() => {
        userRef.current.focus();
    }, [])

    useEffect(() => {
        setErrMsg('');
    }, [username, password])

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post(LOGIN_URL, {
                        "userId": "",
                        "username": username,
                        "password": password,
                        "fullname": "",
                        "email": "",
                        "role": ""
                      })
            // console.log(JSON.stringify(response?.data));
            //console.log(JSON.stringify(response));
            // const accessToken = response?.data?.accessToken;
            const roles = [response?.data?.role]; 
            setCookie('user', {username,roles});
            console.log(JSON.stringify(cookies?.user));
            setUsername('');
            setpassword('');
            navigate(process.env.PUBLIC_URL + "/dashboard", { replace: true });
        } catch (err) {
            if (!err?.response) {
                setErrMsg('No Server Response');
            } else if (err.response?.status === 400) {
                setErrMsg('Missing Username or Password');
            } else if (err.response?.status === 401) {
                setErrMsg('Unauthorized');
            } else {
                setErrMsg('Login Failed');
            }
            errRef.current.focus();
        }
    }

    return (

        <div className="col-lg-6 d-flex justify-content-center align-items-center border-0 rounded-lg auth-h100 " >
            <div className="w-100 p-3 p-md-5 card border-0 shadow-sm" style={{ maxwidth: "32rem" }}>
                <form className="row g-1 p-3 p-md-4 mt-5" onSubmit={handleSubmit}>
                    <div className="col-12 text-center mb-0">
                        <p ref={errRef} className={errMsg ? "errmsg" : "offscreen"} aria-live="assertive">{errMsg}</p>
                        <h1>Sign  in</h1>
                        <span>Free access to our dashboard.</span>
                    </div>
                    <div className="col-12 text-center mb-4">
                        <Link className="btn btn-lg btn-light btn-block" to="#!">
                            <span className="d-flex justify-content-center align-items-center">
                                <img className="avatar xs me-2" src={ImageSrc} alt="img Description" />
                                Sign in with Google
                            </span>
                        </Link>
                        <span className="dividers text-muted mt-4">OR</span>
                    </div>
                    <div className="col-12">
                        <div className="mb-2">
                            <label htmlFor="username" className="form-label">User name:</label>
                            <input  type="text" id="username" ref={userRef} autoComplete="off" onChange={(e) => setUsername(e.target.value)} value={username} required className="form-control form-control-lg lift"/>
                        </div>
                    </div>
                    <div className="col-12">
                        <div className="mb-2">
                            <div className="form-label">
                                <span className="d-flex justify-content-between align-items-center">
                                    Password
                                    <Link className="text-secondary" to={process.env.PUBLIC_URL + "/reset-password"}>Forgot Password?</Link>
                                </span>
                            </div>
                            <input type="password" id="password" onChange={(e) => setpassword(e.target.value)} value={password} required className="form-control form-control-lg lift" placeholder="***************" />
                        </div>
                    </div>
                    <div className="col-12">
                        <div className="form-check">
                            <input className="form-check-input" type="checkbox" value="" id="flexCheckDefault" />
                            <label className="form-check-label" htmlFor="flexCheckDefault">
                                Remember me
                            </label>
                        </div>
                    </div>
                    <div className="col-12 text-center mt-4">
                        <button className="btn btn-lg btn-block btn-light lift text-uppercase">Sign In</button>
                    </div>
                    <div className="col-12 text-center mt-4">
                        <span>Don't have an account yet? <Link to={process.env.PUBLIC_URL + "/sign-up"} className="text-secondary">Sign up here</Link></span>
                    </div>
                </form>
            </div>
        </div>

    )
}

export default Login
