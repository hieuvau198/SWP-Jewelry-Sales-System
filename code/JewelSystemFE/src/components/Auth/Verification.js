import React from 'react';
import { Link } from 'react-router-dom';
import Images from '../../assets/images/verify.svg';

function Verification(){

    return (
        <div className="w-100 p-3 p-md-5 card border-0 shadow-sm" style={{ maxWidth: '32rem' }}>
            <form className="row g-1 p-3 p-md-4">
                <div className="col-12 text-center mb-5">
                    <img src={Images} className="w240 mb-4" alt="" />
                    <h1>Verification</h1>
                    <span>We sent a verification code to your email. Enter the code from the email in the field below.</span>
                </div>
                <div className="col">
                    <div className="mb-2">
                        <input type="email" className="form-control form-control-lg text-center" placeholder="-" />
                    </div>
                </div>
                <div className="col">
                    <div className="mb-2">
                        <input type="email" className="form-control form-control-lg text-center" placeholder="-" />
                    </div>
                </div>
                <div className="col">
                    <div className="mb-2">
                        <input type="email" className="form-control form-control-lg text-center" placeholder="-" />
                    </div>
                </div>
                <div className="col">
                    <div className="mb-2">
                        <input type="email" className="form-control form-control-lg text-center" placeholder="-" />
                    </div>
                </div>
                <div className="col-12 text-center mt-4">
                    <Link to={process.env.PUBLIC_URL + "/"} title="" className="btn btn-lg btn-block btn-light lift text-uppercase">Verify my account</Link>
                </div>
                <div className="col-12 text-center mt-4">
                    <span>Haven't received it? <Link to="#!" className="text-secondary">Resend a new code.</Link></span>
                </div>
            </form>
        </div>
    )
}
export default Verification;