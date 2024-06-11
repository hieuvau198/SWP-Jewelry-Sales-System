import React from 'react';
import { ProgressBar } from 'react-bootstrap';

function BranchLocation() {
    return (
        <div className="card">
            <div style={{ width: '100%', height: '100%' }}>
                <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                    <h6 className="m-0 fw-bold">Our Branch Location &amp; Revenue</h6>
                </div>
                <div id='map' style={{ margin: '15px' }}>
                    <iframe
                        src="https://maps.google.com/maps?hl=en&amp;coord=52.70967533219885, -8.020019531250002&amp;q=1%20Grafton%20Street%2C%20Dublin%2C%20Ireland&amp;ie=UTF8&amp;t=&amp;z=14&amp;iwloc=B&amp;output=embed"
                        width="100%"
                        height="365"
                        frameBorder="0"
                        title="f"
                        style={{ border: '0' }}
                        allowFullScreen
                    ></iframe>
                </div>
            </div>

            <div className="card-body">
                <div className="location-revenue  row g-3">
                    <span style={{ fontWeight: 'bold' }}>India</span>
                    <ProgressBar striped now={30} style={{ height: '9px' }} />
                    <span style={{ fontWeight: 'bold' }}>Mauritius</span>
                    <ProgressBar striped now={45} variant="success" style={{ height: '9px' }} />
                    <span style={{ fontWeight: 'bold' }}>Colombia</span>
                    <ProgressBar striped now={60} variant="info" style={{ height: '9px' }} />
                    <span style={{ fontWeight: 'bold' }}>Russia</span>
                    <ProgressBar striped now={75} variant="warning" style={{ height: '9px' }} />
                    <span style={{ fontWeight: 'bold' }}>France</span>
                    <ProgressBar striped now={98} variant="danger" style={{ height: '9px' }} />
                </div>
            </div>
        </div>
    )
}

export default BranchLocation;
