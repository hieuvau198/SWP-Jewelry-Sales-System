import React from "react";

function InventoryInfo() {
    return (
        <>
            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Inventory Info</h6>
            </div>
            <div className="card-body">
                <div className="row g-3 align-items-center">
                    <div className="col-md-12">
                        <label className="form-label">SKU</label>
                        <input type="text" className="form-control" value="SKUN111" onChange={() => { }} />
                    </div>
                    <div className="col-md-12">
                        <label className="form-label">Total Stock Quantity</label>
                        <input type="text" className="form-control" value="1455" onChange={() => { }} />
                    </div>
                </div>
            </div>
        </>
    )
}
export default InventoryInfo;