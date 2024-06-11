import React from 'react';
import { Link } from 'react-router-dom';
import Notfound from '../../assets/images/not_found.svg';

function Page404() {
    return (
        <div className="col-lg-6 d-flex justify-content-center align-items-center border-0 rounded-lg auth-h100">
            <div className="w-100 p-3 p-md-5 card border-0 shadow-sm" style={{ maxWidth: '32rem' }}>
                <form className="row g-1 p-3 p-md-4">
                    <div className="col-12 text-center mb-4">
                        <img src={Notfound} className="w240 mb-4" alt="" />
                        <h5>OOP! PAGE NOT FOUND</h5>
                        <span className="">Sorry, the page you're looking for doesn;t exist. if you think something is brlken, report a problem.</span>
                    </div>
                    <div className="col-12 text-center">
                        <Link to={process.env.PUBLIC_URL + "/"} title="" className="btn btn-lg btn-block btn-light lift text-uppercase">Back to Home</Link>
                    </div>
                </form>
            </div>
        </div>
    )
}
export default Page404;