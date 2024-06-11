import React from 'react';
import ProgressBar from 'react-bootstrap/ProgressBar'

function StatusReport() {

    return (
        <>
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                <h6 className="mb-0 fw-bold ">Status report</h6>
            </div>

            <div className="card-body" >
                <ul className="list-unstyled mb-0">
                    <li className="mb-4">
                        <div className="d-flex justify-content-between align-items-center mb-2">
                            <h6 className="mb-0">54</h6>
                            <span className="small text-muted">Product Visit</span>
                        </div>
                        <ProgressBar variant="success" style={{ height: '2px' }} now={90} />
                    </li>
                    <li className="mb-4">
                        <div className="d-flex justify-content-between align-items-center mb-2">
                            <h6 className="mb-0">27</h6>
                            <span className="small text-muted">Product Buy</span>
                        </div>
                        <ProgressBar variant="info" style={{ height: '2px' }} now={27} />
                    </li>
                    <li className="mb-4">
                        <div className="d-flex justify-content-between align-items-center mb-2">
                            <h6 className="mb-0">102</h6>
                            <span className="small text-muted">Comment on Product</span>
                        </div>
                        <ProgressBar variant="dark" style={{ height: '2px' }} now={10} />
                    </li>
                    <li className="mb-0">
                        <div className="d-flex justify-content-between align-items-center mb-2">
                            <h6 className="mb-0">1024 Hours</h6>
                            <span className="small text-muted">Total spent time</span>
                        </div>
                        <ProgressBar variant="danger" style={{ height: '2px' }} now={75} />
                    </li>
                </ul>
            </div>
        </>
    )
}

export default StatusReport;