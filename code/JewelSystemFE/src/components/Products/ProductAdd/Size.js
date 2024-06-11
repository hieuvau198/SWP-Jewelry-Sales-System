import React from "react";

function Size() {
    return (
        <>
            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Size</h6>
            </div>
            <div className="card-body">
                <div className="form-check">
                    <input className="form-check-input" type="checkbox" value="" id="sizechek1" onChange={() => { }} />
                    <label className="form-check-label" htmlFor="sizechek1">
                        XS
                    </label>
                </div>
                <div className="form-check">
                    <input className="form-check-input" type="checkbox" value="" id="sizechek2" onChange={() => { }} />
                    <label className="form-check-label" htmlFor="sizechek2">
                        S
                    </label>
                </div>
                <div className="form-check">
                    <input className="form-check-input" type="checkbox" value="" id="sizechek3" onChange={() => { }} />
                    <label className="form-check-label" htmlFor="sizechek3">
                        M
                    </label>
                </div>
                <div className="form-check">
                    <input className="form-check-input" type="checkbox" value="" id="sizechek4" onChange={() => { }} />
                    <label className="form-check-label" htmlFor="sizechek4">
                        L
                    </label>
                </div>
                <div className="form-check">
                    <input className="form-check-input" type="checkbox" value="" id="sizechek5" onChange={() => { }} />
                    <label className="form-check-label" htmlFor="sizechek5">
                        XL
                    </label>
                </div>
            </div>
        </>
    )
}
export default Size;