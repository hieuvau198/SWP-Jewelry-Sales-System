import React from 'react';
import { InvoiceListData } from '../../Data/AccountData/AccountData';

function InvoiceList () {

        return (
            <div className="row justify-content-center">
                <div className="col-lg-8 col-md-12">
                    {
                        InvoiceListData.map((d,i) => {
                            return <div key={'s'+i} className="card mb-3" >
                                <div className="card-body d-sm-flex justify-content-between">
                                    <a href="#!" className="d-flex">
                                        <img className="avatar rounded" src={d.image} alt="" />
                                        <div className="flex-fill ms-3 ">
                                            <h6 className="d-flex justify-content-between mb-0"><span>{d.fname}</span></h6>
                                            <span className="">{d.name}</span>
                                        </div>
                                    </a>
                                    <div className="text-end d-none d-md-block">
                                        <p className="mb-1"><i className="icofont-location-pin ps-1"></i> {d.address}</p>
                                        <span className="text-muted"><i className="icofont-money ps-1"></i>{d.money}</span>
                                    </div>
                                </div>
                                <div className="card-footer justify-content-between d-flex align-items-center">
                                    <div className="d-none d-md-block">
                                        <strong>Date on:</strong>
                                        <span>{d.date}</span>
                                    </div>
                                    <div>
                                        <a className="btn btn-sm btn-white border lift" href="#!">Download</a>
                                        <a className="btn btn-sm btn-white border lift" href="#!">Send</a>
                                        <a className="btn btn-sm btn-white border lift" href="#!">Delete</a>
                                    </div>
                                </div>
                            </div>
                        })
                    }
                    <nav >
                        <ul className="pagination mt-4">
                            <li><a className="page-link" href="#!">Previous</a></li>
                            <li><a className="page-link" href="#!">1</a></li>
                            <li><a className="page-link" href="#!">2</a></li>
                            <li><a className="page-link" href="#!">3</a></li>
                            <li><a className="page-link" href="#!">Next</a></li>
                        </ul>
                    </nav>
                </div>
            </div>
        )
    }

export default InvoiceList;