import React from 'react';
import { Link } from 'react-router-dom';

function Personaldetail() {
    return (
        <form className="mt-3">
            <div className="row g-3 align-items-center">
                <div className="col-md-6">
                    <label htmlFor="firstname1" className="form-label">First Name</label>
                    <input type="text" className="form-control" id="firstname1" />
                </div>
                <div className="col-md-6">
                    <label htmlFor="lastname1" className="form-label">Last Name</label>
                    <input type="text" className="form-control" id="lastname1" />
                </div>
                <div className="col-md-6">
                    <label htmlFor="phonenumber1" className="form-label">Phone Number</label>
                    <input type="text" className="form-control" id="phonenumber1" />
                </div>
                <div className="col-md-6">
                    <label htmlFor="emailaddress1" className="form-label">Email Address</label>
                    <input type="email" className="form-control" id="emailaddress1" />
                </div>
                <div className="col-md-12">
                    <label className="form-label">Shipping Address</label>
                    <input type="email" className="form-control" />
                </div>
                <div className="col-md-6">
                    <label htmlFor="cityblock1" className="form-label">City</label>
                    <input type="text" className="form-control" id="cityblock1" />
                </div>
                <div className="col-md-6">
                    <label htmlFor="postcode1" className="form-label">Post Code</label>
                    <input type="text" className="form-control" id="postcode1" />
                </div>
                <div className="col-md-6">
                    <label className="form-label">Country</label>
                    <select className="form-select">
                        <option >Country Option</option>
                        <option value="1">India</option>
                        <option value="2">Australia</option>
                        <option value="3">Italy</option>
                    </select>
                </div>
                <div className="col-md-6">
                    <label className="form-label">State</label>
                    <select className="form-select">
                        <option >State Option</option>
                        <option value="1">Gujrat</option>
                        <option value="2">Kerela</option>
                        <option value="3">Rajesthan</option>
                    </select>
                </div>
                <div className="col-md-12">
                    <div className="form-check">
                        <input className="form-check-input" type="checkbox" id="flexCheckChecked1" />
                        <label className="form-check-label" htmlFor="flexCheckChecked1">
                            My delivery and Shipping addresses are the same.
                        </label>
                    </div>
                </div>
            </div>

            <Link to="#!" type="submit" className="btn btn-primary mt-4 px-5 text-uppercase">Save</Link>
        </form>
    )
}
export default Personaldetail;