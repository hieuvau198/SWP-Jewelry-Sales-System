import React from 'react';

function AddStore() {
    return (
        <div className="card">
            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Add Store</h6>
            </div>
            <div className="card-body">
                <div className="mb-3">
                    <label className="form-label">Name</label>
                    <input type="text" className="form-control" />
                </div>
                <div className="mb-3">
                    <label className="form-label">Geocoded</label>
                    <input type="text" className="form-control" />
                </div>
                <div className="mb-3">
                    <label className="form-label">Address</label>
                    <input type="text" className="form-control" />
                </div>
                <div className="mb-3">
                    <label className="form-label">Phone</label>
                    <input type="text" className="form-control" />
                </div>
                <div className="mb-3">
                    <label className="form-label">Email</label>
                    <input type="email" className="form-control" />
                </div>
                <div className="mb-3">
                    <label className="form-label">URL</label>
                    <div className="input-group mb-3">
                        <span className="input-group-text">https://eBazar.com/location/</span>
                        <input type="text" className="form-control" />
                    </div>
                </div>
                <div className="mb-3">
                    <button type="button" className="btn btn-primary text-uppercase px-5">Submit</button>
                </div>
            </div>
        </div>
    )
}
export default AddStore;