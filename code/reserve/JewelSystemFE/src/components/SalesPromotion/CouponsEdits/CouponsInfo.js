import React, { useState } from 'react';
import { Link } from 'react-router-dom';

function CouponsOInfo () {
    const[supplyopen,setSupplyopen]=useState(false);
        return (
            <div className="card mb-3">
                <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                    <h6 className="m-0 fw-bold">Coupon Information</h6>
                </div>
                <div className="card-body">
                    <form>
                        <div className="row g-3 align-items-center">
                            <div className="col-md-6">
                                <label className="form-label">Coupons Code</label>
                                <input type="text" className="form-control" value="AXXQT-2547"/>
                            </div>
                            <div className="col-md-6">
                                <label className="form-label">Discount Products</label>
                                <select className="form-select">
                                    <option >Open this select category</option>
                                    <option value="1">Watch</option>
                                    <option value="2">Mobile</option>
                                    <option value="3">Laptop</option>
                                    <option value="4">Clothes</option>
                                    <option value="5">Shoes</option>
                                    <option value="6">Top</option>
                                    <option value="7">Watches</option>
                                </select>
                            </div>
                            <div className="col-md-6">
                                <label className="form-label">Discount Country</label>
                                <select className="form-select">
                                    <option >Open this select Country</option>
                                    <option value="1">India</option>
                                    <option value="2">Denmark</option>
                                    <option value="3">Oman</option>
                                    <option value="4">South Africa</option>
                                </select>
                            </div>
                            <div className="col-md-6">
                                <label className="form-label">Coupons Limits</label>
                                <input type="text" className="form-control" value="10"/>
                            </div>
                            <div className="col-md-12">
                                <label className="form-label">Coupons Types</label>
                                <div className="form-check">
                                    <input className="form-check-input" checked={supplyopen} type="radio" name="couponstype"
                                        onChange={(val) => {
                                            setSupplyopen( true )
                                        }}
                                    />
                                    <label className="form-check-label">
                                        Free Shipping
                                    </label>
                                </div>
                                <div className="form-check">
                                    <input className="form-check-input" checked={supplyopen} type="radio" name="couponstype"
                                        onChange={(val) => {
                                            setSupplyopen( true )
                                        }}
                                    />
                                    <label className="form-check-label">
                                        Percentage
                                    </label>
                                </div>
                                <div className="form-check">
                                    <input className="form-check-input" checked={!supplyopen} type="radio" name="couponstype"
                                        onChange={(val) => {
                                            setSupplyopen( false )
                                        }}
                                    />
                                    <label className="form-check-label">
                                        Fixed Amount
                                    </label>
                                </div>
                            </div>
                            <div className="col-md-12">
                                <label className="form-label">Discount value</label>
                                <input type="text" className="form-control" value="20%"/>
                            </div>
                        </div>
                        <Link to='#!' type="submit" className="btn btn-primary mt-4 text-uppercase px-5">Submit</Link>
                    </form>
                </div>
            </div>
        )
    }
export default CouponsOInfo;