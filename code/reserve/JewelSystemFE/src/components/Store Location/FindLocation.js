import React from 'react';

function FindLocation() {
    return (
        <div className="card">
            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Find Location</h6>
            </div>
            <div className="card-body">
                <div className="mb-3">
                    <label className="form-label">Name</label>
                    <input type="text" className="form-control" />
                </div>
                <div className="mb-3">
                    <label className="form-label">Address</label>
                    <input type="text" className="form-control" />
                </div>
                <div className="mb-3">
                    <label className="form-label">Country</label>
                    <select className="form-select" aria-label="Default select example">
                        <option >Select Country</option>
                        <option value="1">India</option>
                        <option value="2">Usa</option>
                        <option value="3">Italy</option>
                    </select>
                </div>
                <div className="mb-3">
                    <label className="form-label">City</label>
                    <select className="form-select" aria-label="Default select example">
                        <option >Select City</option>
                        <option value="1"> Albany </option>
                        <option value="2"> Allen </option>
                        <option value="3"> Burbank </option>
                    </select>
                </div>
                <div className="mb-3">
                    <label className="form-label">Zipcode</label>
                    <input type="text" className="form-control" />
                </div>
                <div className="mb-3">
                    <label className="form-label">Geocoded</label>
                    <input type="text" className="form-control" />
                </div>
                <div className="mb-3">
                    <button type="button" className="btn btn-primary text-uppercase px-4">Search Loaction</button>
                </div>
            </div>
        </div>
    )
}
export default FindLocation;