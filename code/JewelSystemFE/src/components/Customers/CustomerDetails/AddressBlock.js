import React from 'react';
import { CustomerDetailData } from '../../Data/CustomerDetailData';

function AddressBlock() {

    return (
        <div className="row g-3 mb-3 row-cols-1 row-cols-md-1 row-cols-lg-2 row-deck">
            {
                CustomerDetailData.map((d, i) => {
                    return <div key={'s' + i} className="col">
                        <div className="card auth-detailblock">
                            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                                <h6 className="mb-0 fw-bold ">{d.name}</h6>
                            </div>
                            <div className="card-body">
                                <div className="row g-3">
                                    <div className="col-12">
                                        <label className="form-label col-6 col-sm-5">Block Number:</label>
                                        <span><strong>{d.blokNum}</strong></span>
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
        </div>
    )
}
export default AddressBlock;