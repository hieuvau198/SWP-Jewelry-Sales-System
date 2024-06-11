import React from 'react';
import { PricePlanExampleData } from '../../Data/OtherPagesData';

function PricePlan() {

    return (
        <div className="body d-flex py-lg-3 py-md-2">
            <div className="container-xxl">
                <div className="row mb-5 mt-4">
                    <div className="col-12 text-center">
                        <h2 className="fw-bold">Choose Your Plan</h2>
                        <p className="text-muted mt-4 mx-auto">Choose one of the plans that suits you. You will get a better service with the upgraded package.</p>
                    </div>
                    <div className="d-inline-flex justify-content-center mx-auto">
                        <ul className="nav nav-tabs tab-body-header rounded invoice-set" role="tablist">
                            <li className="nav-item"><a className="nav-link" href="#!" >Month Plan</a></li>
                            <li className="nav-item"><a className="nav-link active" href="#!">Yearly Plan</a></li>
                        </ul>
                    </div>
                </div>
                <div className="row g-2 justify-content-center align-items-center">
                    {
                        PricePlanExampleData.map((d, i) => {
                            return <div key={'s' + i} className="col-xxl-3 col-xl-4 col-lg-4 col-sm-12 lift">
                                <div className="card">
                                    <div className="card-body py-4 text-center">
                                        <h6 className="text-uppercase">{d.title}</h6>
                                        <div><span className="display-5 text-primary">{d.price}</span> <span className="text-muted">/Month</span></div>
                                    </div>
                                    <div className="border-top-0 px-5 card-footer">
                                        <p className="d-flex justify-content-between py-1"><span><i className="fa fa-check-circle"></i> Voice chat:</span> <span>{d.voicechat}</span></p>
                                        <p className="d-flex justify-content-between py-1"><span><i className="fa fa-check-circle"></i> Chat without limit:</span> <span>{d.chatwithout}</span></p>
                                        <p className="d-flex justify-content-between py-1"><span><i className="fa fa-check-circle"></i> Support:</span> <span>{d.support}</span></p>
                                        <p className="d-flex justify-content-between py-1"><span><i className="fa fa-check-circle"></i> Domain:</span> <span>{d.domain}</span></p>
                                        <p className="d-flex justify-content-between py-1"><span><i className="fa fa-check-circle"></i> Hidden Fees:</span> <span>{d.hiddenfees}</span></p>
                                    </div>
                                    <div className="card-body text-center">
                                        <a href="#!" className="btn btn-white border lift">Get Started</a>
                                    </div>
                                </div>
                            </div>
                        })
                    }
                </div>
            </div>
        </div>
    )
}
export default PricePlan;