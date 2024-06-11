import React from 'react';
import { OrderDiv } from '../../Data/OrderDetailData';

function AddressBlock() {
    return (
        <>
            {
                OrderDiv.map((d, i) => {
                    return <div key={'s' + i} className="col">
                        <div className="card">
                            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                                <h6 className="mb-0 fw-bold ">{d.addressName}</h6>
                                <a href="#!" className="text-muted">Edit</a>
                            </div>
                            <div className="card-body">
                                <div className="row g-3">
                                    <div className="col-12">
                                        <label className="form-label col-6 col-sm-5">Block Number:</label>
                                        <span><strong>{d.blockNumber}</strong></span>
                                    </div>
                                    <div className="col-12">
                                        <label className="form-label col-6 col-sm-5">Address:</label>
                                        <span><strong>{d.address}</strong></span>
                                    </div>
                                    <div className="col-12">
                                        <label className="form-label col-6 col-sm-5">Pincode:</label>
                                        <span><strong>{d.pincode}</strong></span>
                                    </div>
                                    <div className="col-12">
                                        <label className="form-label col-6 col-sm-5">Phone:</label>
                                        <span><strong>{d.phone}</strong></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                })
            }
        </>
    )
}
export default AddressBlock;