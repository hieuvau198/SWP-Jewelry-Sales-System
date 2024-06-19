import React from 'react';

function SimpleInvoice () {
        return (
            <div className="row justify-content-center">
                <div className="col-lg-8 col-md-12">
                    <div className="card p-xl-5 p-lg-4 p-0">
                        <div className="card-body">
                            <div className="mb-3 pb-3 border-bottom">
                                Date
                                <strong className='px-1'>May 22, 2021</strong>
                                <span className="float-end"> <strong>transection id:</strong> #18414</span>
                            </div>

                            <div className="row mb-4">
                                <div className="col-sm-6">
                                    <h6 className="mb-3">From:</h6>
                                    <div><strong>eBazar Shop</strong></div>
                                    <div>111  Berkeley Rd</div>
                                    <div>STREET ON THE FOSSE, Poland</div>
                                    <div>Email: info@ebazar.com</div>
                                    <div>Phone: +44 888 666 3333</div>
                                </div>

                                <div className="col-sm-6">
                                    <h6 className="mb-3">To:</h6>
                                    <div><strong>Dianalove</strong></div>
                                    <div>45 Larissa Court</div>
                                    <div>Victoria, BIRDWOODTON</div>
                                    <div>Email: Dianalove@gmail.com</div>
                                    <div>Phone: +66 243 456 789</div>
                                </div>
                            </div>

                            <div>
                                <table className="table table-striped">
                                    <thead>
                                        <tr>
                                            <th className="text-center">#</th>
                                            <th>Item</th>
                                            <th>Description</th>
                                            <th className="text-end">Item Cost</th>
                                            <th className="text-center">Products Item</th>
                                            <th className="text-end">Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td className="text-center">1</td>
                                            <td>Rado Watch</td>
                                            <td>Men Watch for Gold Color</td>
                                            <td className="text-end">$330.00</td>
                                            <td className="text-center">1</td>
                                            <td className="text-end">$330.00</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                            <div className="row">
                                <div className="col-lg-4 col-sm-5">

                                </div>

                                <div className="col-lg-4 col-sm-5 ms-auto">
                                    <table className="table table-clear">
                                        <tbody>
                                            <tr>
                                                <td><strong>Subtotal</strong></td>
                                                <td className="text-end">$330.00</td>
                                            </tr>
                                            <tr>
                                                <td><strong>Tax(18%)</strong></td>
                                                <td className="text-end">$59.4</td>
                                            </tr>
                                            <tr>
                                                <td><strong>Total</strong></td>
                                                <td className="text-end"><strong>$389.00</strong></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                            <div className="row">
                                <div className="col-lg-12">
                                    <h6>Terms &amp; Condition</h6>
                                    <p className="text-muted">Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over</p>
                                </div>
                                <div className="col-lg-12 text-end">
                                    <button type="button" className="btn btn-outline-secondary btn-lg my-1"><i className="fa fa-print"></i> Print</button>
                                    <button type="button" className="btn btn-primary btn-lg my-1"><i className="fa fa-paper-plane-o"></i> Send Invoice</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }

export default SimpleInvoice;