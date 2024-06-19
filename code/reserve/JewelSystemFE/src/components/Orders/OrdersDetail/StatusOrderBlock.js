import React from 'react';

function StatusOrderBlock() {
    return (
        <div className="card mb-3">
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                <h6 className="mb-0 fw-bold ">Status Orders</h6>
            </div>
            <div className="card-body">
                <form>
                    <div className="row g-3 align-items-center">
                        <div className="col-md-12">
                            <label className="form-label">Order ID</label>
                            <input type="text" className="form-control" value="78414" onChange={() => { }} />
                        </div>
                        <div className="col-md-12">
                            <label className="form-label">Order Status</label>
                            <select className="form-select" >
                                <option value="1">Progress</option>
                                <option value="2">Completed</option>
                                <option value="3">Pending</option>
                            </select>
                        </div>
                        <div className="col-md-12">
                            <label className="form-label">Quantity</label>
                            <input type="text" className="form-control" value="4" onChange={() => { }} />
                        </div>
                        <div className="col-md-12">
                            <label className="form-label">Order Transection</label>
                            <select className="form-select">
                                <option value="1">Completed</option>
                                <option value="2">Fail</option>
                            </select>
                        </div>
                        <div className="col-md-12">
                            <label htmlFor="comment" className="form-label">Comment</label>
                            <textarea className="form-control" id="comment" rows="4" value='' onChange={() => { }}>Lorem Ipsum is simply dummy text of the printing and typesetting industry.</textarea>
                        </div>
                    </div>
                    <button type="button" className="btn btn-primary mt-4 text-uppercase">Submit</button>
                </form>
            </div>
        </div>
    )
}
export default StatusOrderBlock;