import React from 'react';
import change from '../../assets/images/change-log.svg'
import PageHeader1 from '../../components/common/PageHeader1';

function Changelog () {
        return (
            <div className='body d-flex py-lg-3 py-md-2'>
                <div className="container-xxl">
                    <PageHeader1 pagetitle='Changelog' changelog={true} />
                    <div className="row">
                        <div className="col-12">
                            <div className="card">
                                <div className="card-body text-center p-5">
                                    <img src={change} className="img-fluid mx-size" alt="No Data" />
                                </div>
                            </div>
                        </div>
                        <div className="col-12 col-md-12 mt-5">
                            <div className="card">
                                <div className="card-body">
                                    <div className="pt-2">
                                        <h6 className="d-inline-block"><span className="badge bg-warning font-weight-light">v1.1.0</span></h6>
                                        <span className="text-muted">&nbsp;&nbsp;&nbsp;–-- Nov 27, 2023</span>
                                        <ul className="ms-5">
                                            <li>React Update latest version</li>
                                            <li>Bootstrap Update latest version</li>
                                            <li>Router Changes</li>
                                            <li>Dark Contrast Color Code Fixing</li>
                                            <li>High Contrast Color Code Fixing</li>
                                            <li>Node version Update</li>
                                            <li>Full Calander Update</li>
                                        </ul>
                                    </div>
                                    <div className="pt-2">
                                        <h6 className="d-inline-block"><span className="badge bg-warning font-weight-light">v1.0.0</span></h6>
                                        <span className="text-muted">&nbsp;&nbsp;&nbsp;–-- May 31, 2022</span>
                                        <ul className="ms-5">
                                            <li>Initial release of my-Task! Lots more coming soon though 😁</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>   
        )
    }
export default Changelog;