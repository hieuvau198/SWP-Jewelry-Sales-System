import React from 'react';

function HelpBlock () {
    
        return (
            <div className="card border-0">
                <div className="card-header py-3">
                    <h4 className=" display-6 fw-bold">Help</h4>
                </div>
                <div className="card-body">
                    <div className="mb-4 overflow-hidden">
                        <div className="bg-primary py-5 px-4 text-light">
                            <h4>pixelwibes.com</h4>
                            <span>Quick Start Guides Help Center</span>
                        </div>
                        <div className="p-4">
                            <p className="fw-bold">eBazar guide</p>
                            <span>Get started witheBazar Business and learn about features for admins and users.</span>
                            <div className="mt-4 mb-2">
                                <a href="http://pixelwibes.com/" className="btn btn-primary" >Check out the guide</a>
                            </div>
                            <hr></hr>
                            <p className="fw-bold">Get answers</p>
                            <span>Visit the help centre for answers to common issues.</span>
                            <div className="mt-4 mb-2">
                                <a href="http://pixelwibes.com/" className="btn btn-primary" >Go to Help Centre</a>
                            </div>
                            <hr></hr>
                            <span className="text-muted">Thanks for choosing <strong className="text-warning">Pixel Wibes</strong> Admin.</span>
                        </div>
                    </div>
                </div>
            </div>
        )
    }

export default HelpBlock;