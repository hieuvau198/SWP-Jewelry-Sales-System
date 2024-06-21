import React from 'react';
import { Link } from 'react-router-dom';

function Bankdetail() {
    return (
        <div className="card">
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0 align-items-center">
                <div className="form-check d-flex align-items-center">
                    <input className="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1" value='' onChange={() => { }} />
                    <label className="form-check-label fw-bold d-flex align-items-center" htmlFor="flexRadioDefault1">
                        <i className="icofont-mastercard-alt fs-3 mx-2"></i> Debit/Credit Card
                    </label>
                </div>
            </div>
            <div className="card-body">
                <form>
                    <div className="row g-3 align-items-center">
                        <div className="col-md-12">
                            <label className="form-label">Enter Card Number</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-6">
                            <label className="form-label">Valid Date</label>
                            <input type="date" className="form-control w-100" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-6">
                            <label className="form-label">CVV</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                    </div>
                    <div className="row g-3 align-items-center">
                        <div className="col-md-12">
                            <label className="form-label">valid date</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-6">
                            <label className="form-label">production</label>
                            <input type="date" className="form-control w-100" value='' onChange={() => { }} />

                        </div>
                    </div>
                </form>
            </div>
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0 align-items-center">
                <div className="form-check d-flex align-items-center">
                    <input className="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" value='' onChange={() => { }} />
                    <label className="form-check-label fw-bold d-flex align-items-center" htmlFor="flexRadioDefault2">
                        <i className="icofont-world fs-3 mx-2"></i> Net Banking
                    </label>
                </div>
            </div>
            <div className="card-body">
                <form>
                    <div className="row g-3 align-items-center">
                        <div className="col-md-12">
                            <label className="form-label">Enter Your Name</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-12">
                            <label className="form-label">Account Number</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-6">
                            <label className="form-label">Bank Name</label>
                            <input type="text" className="form-control" value='' onChange={() => { }} />
                        </div>
                        <div className="col-md-6">
                            <label htmlFor="admittime1" className="form-label">IFC Code</label>
                            <input type="text" className="form-control" id="admittime1" value='' onChange={() => { }} />
                        </div>
                    </div>

                    <Link to={process.env.PUBLIC_URL + "/invoices"} className="btn btn-primary mt-4 text-uppercase">Pay Now</Link>

                </form>
            </div>
        </div>
    )
}
export default Bankdetail;