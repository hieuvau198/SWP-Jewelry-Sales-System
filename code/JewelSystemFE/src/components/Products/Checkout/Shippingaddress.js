import React from 'react';
import A1 from '../../../assets/images/product/shipping-3.png';
import A2 from '../../../assets/images/product/shipping-3.png';
import A3 from '../../../assets/images/product/shipping-2.png';
import A4 from '../../../assets/images/product/shipping-1.png';
import { Link } from 'react-router-dom';

function Shippingaddress() {
    return (
        <form className="mt-3">
            <div className="row g-3 align-items-center">
                <div className="col-md-6">
                    <label htmlFor="firstname" className="form-label">First Name</label>
                    <input type="text" className="form-control" id="firstname" />
                </div>
                <div className="col-md-6">
                    <label htmlFor="lastname" className="form-label">Last Name</label>
                    <input type="text" className="form-control" id="lastname" />
                </div>
                <div className="col-md-6">
                    <label htmlFor="phonenumber" className="form-label">Phone Number</label>
                    <input type="text" className="form-control" id="phonenumber" />
                </div>
                <div className="col-md-6">
                    <label htmlFor="emailaddress" className="form-label">Email Address</label>
                    <input type="email" className="form-control" id="emailaddress" />
                </div>
                <div className="col-md-12">
                    <label className="form-label">Shipping Address</label>
                    <input type="email" className="form-control" />
                </div>
                <div className="col-md-6">
                    <label htmlFor="cityblock" className="form-label">City</label>
                    <input type="text" className="form-control" id="cityblock" />
                </div>
                <div className="col-md-6">
                    <label htmlFor="postcode" className="form-label">Post Code</label>
                    <input type="text" className="form-control" id="postcode" />
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
            </div>

            <div className="col-md-12">
                <div className="checkout-payment-option mt-4">
                    <h6 className="form-label mb-0">Select Delivery Option</h6>
                    <div className="payment-option-wrapper">
                        <div className="single-payment-option">
                            <input type="radio" name="shipping" id="shipping-1" />
                            <label htmlFor="shipping-1">
                                <img src={A1} alt="Sipping" />
                                <span className="s-info">Standerd Shipping</span>
                                <span className="price">$12.00</span>
                            </label>
                        </div>
                        <div className="single-payment-option">
                            <input type="radio" name="shipping" id="shipping-2" />
                            <label htmlFor="shipping-2">
                                <img src={A2} alt="Sipping" />
                                <span className="s-info">Standerd Shipping</span>
                                <span className="price">$10.00</span>
                            </label>
                        </div>
                        <div className="single-payment-option">
                            <input type="radio" name="shipping" id="shipping-3" />
                            <label htmlFor="shipping-3">
                                <img src={A3} alt="Sipping" />
                                <span className="s-info">Standerd Shipping</span>
                                <span className="price">$11.00</span>
                            </label>
                        </div>
                        <div className="single-payment-option">
                            <input type="radio" name="shipping" id="shipping-4" />
                            <label htmlFor="shipping-4">
                                <img src={A4} alt="Sipping" />
                                <span className="s-info">Standerd Shipping</span>
                                <span className="price">$18.00</span>
                            </label>
                        </div>
                    </div>
                </div>
            </div>
            <div className="col-md-12">
                <div className="steps-form-btn">
                    <Link to="/invoice" className="btn btn-primary px-5 text-uppercase">Save</Link>
                </div>
            </div>
        </form>
    )
}
export default Shippingaddress;