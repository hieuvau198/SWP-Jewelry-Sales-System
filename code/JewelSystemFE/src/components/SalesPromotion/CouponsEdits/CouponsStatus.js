import React, { useState } from 'react';

function CouponsStatus() {
    const [supplyopen, setSupplyopen] = useState(false);
    return (

        <div className="card mb-3">
            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Coupon Status</h6>
            </div>
            <div className="card-body">
                <div className="form-check">
                    <input className="form-check-input" checked={supplyopen} type="radio" name="couponsstatus"
                        onChange={(val) => {
                            setSupplyopen(true)
                        }} />
                    <label className="form-check-label">
                        Active
                    </label>
                </div>
                <div className="form-check">
                    <input className="form-check-input active" checked={!supplyopen} type="radio" name="couponsstatus"
                        onChange={(val) => {
                            setSupplyopen(false)
                        }}
                    />
                    <label className="form-check-label">
                        In Active
                    </label>
                </div>
                <div className="form-check">
                    <input className="form-check-input" checked={supplyopen} type="radio" name="couponsstatus"
                        onChange={(val) => {
                            setSupplyopen(true)
                        }}
                    />
                    <label className="form-check-label">
                        Future Plan
                    </label>
                </div>
            </div>
        </div>

    )
}
export default CouponsStatus