import React, { useState } from 'react';

function PricingBlock() {
    const [callopsPrice, setCallopsPrice] = useState(false);
    return (
        <div className="price-range-block">
            <div className="filter-title">
                <a className="title" data-bs-toggle="collapse" href="#pricingTwo" role="button" onClick={() => { setCallopsPrice(!callopsPrice) }} aria-expanded={callopsPrice}>Pricing Range</a>
            </div>
            <div className={`collapse ${callopsPrice ? 'show' : ''}`} id="pricingTwo">
                <div className="price-range">
                    <div className="price-amount flex-wrap">
                        <div className="amount-input mt-1">
                            <label className="fw-bold">Minimum Price</label>
                            <input type="text" id="minAmount2" className="form-control" />
                        </div>
                        <div className="amount-input mt-1">
                            <label className="fw-bold">Maximum Price</label>
                            <input type="text" id="maxAmount2" className="form-control" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default PricingBlock;