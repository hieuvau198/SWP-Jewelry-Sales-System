import React from 'react'

function PaymentsMethod() {
    return (
        <>
            <div className="card mb-3">
                <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                    <h6 className="mb-0 fw-bold ">Payment Method</h6>
                </div>
                <div className="card-body">
                    <div className="payment-info">
                        <h5 className="payment-name text-muted"><i className="icofont-visa-alt fs-3"></i> Visa *******7548</h5>
                        <span>Next billing charged $48</span>
                        <br></br>
                        <em className="text-muted">Autopay on July 20, 2021</em>
                        <a href="#!" className="edit-payment-info text-secondary">Edit Payment Info</a>
                    </div>
                    <p className="mt-3"><a href="#!" className="btn btn-primary"> Add Payment Info</a></p>
                </div>
            </div>
            <div className="card">
                <div className="card-body">
                    <h5>Notification preferences</h5>
                    <span className="text-muted">Control all our newsletter and email related notifications to your email</span>
                    <div className="mt-4">
                        <div className="form-check form-switch mt-2">
                            <input className="form-check-input" type="checkbox" id="np-Newsletter" />
                            <label className="form-check-label" htmlFor="np-Newsletter">Activity Notifications</label>
                        </div>
                        <div className="form-check form-switch mt-2">
                            <input className="form-check-input" type="checkbox" id="np-Notifications" />
                            <label className="form-check-label" htmlFor="np-Notifications">Comment Notifications</label>
                        </div>
                        <div className="form-check form-switch mt-2">
                            <input className="form-check-input" type="checkbox" id="np-Preferences" />
                            <label className="form-check-label" htmlFor="np-Preferences">Email Preferences</label>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
export default PaymentsMethod;