import React from 'react';
import ImageSrc from "../../assets/images/login-img.svg";

function AuthLeft() {
    return (
        <div className="col-lg-6 d-none d-lg-flex justify-content-center align-items-center rounded-lg auth-h100">
            <div style={{ maxWidth: '25rem' }}>
                <div className="text-center mb-5">
                    <i className="bi bi-bag-check-fill  text-primary" style={{ fontSize: 90 }}></i>
                </div>
                <div className="mb-5">
                    <h2 className="color-900 text-center">A few clicks is all it takes.</h2>
                </div>
                <div className="">
                    <img src={ImageSrc} alt="login-img" />
                </div>
            </div>
        </div>
    );
}
export default AuthLeft;