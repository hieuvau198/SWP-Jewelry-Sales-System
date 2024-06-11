import React from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import { SalaryslipAddressData, SalaryslipTable1Data, SalaryslipTable2Data } from '../../components/Data/AccountData/AccountData';

function Salaryslip (){
        return (
            <div className="body d-flex py-lg-3 py-md-2">
                <div className="container-xxl">
                <PageHeader1 pagetitle='Salaryslip' />
                    <div className="row justify-content-center">
                        <div className="col-lg-12 col-md-12">
                            <div className="card p-xl-5 p-lg-4 p-0">
                                <div className="card-body">
                                    <div className="mb-3 pb-3 border-bottom">
                                        SalarySlip
                                        <strong>01/Nov/2020</strong>
                                    </div>
                                    <div className="row mb-4">
                                        {
                                            SalaryslipAddressData.map((d, i) => {
                                                return <div key={'s'+i} className="col-sm-6">
                                                    <h6 className="mb-3">{d.title}</h6>
                                                    <div><strong>{d.name}</strong></div>
                                                    <div>{d.address}</div>
                                                    <div>{d.add}</div>
                                                    <div>{d.email}</div>
                                                    <div>{d.number}</div>
                                                </div>
                                            })
                                        }
                                    </div>
                                    <div className="row">
                                        <div className="col-lg-6">
                                            <div className="table-responsive-sm">
                                                <table className="table table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th className="text-center">#</th>
                                                            <th>Earnings</th>
                                                            <th className="text-end">Amount</th>
                                                        </tr>
                                                    </thead>
                                                    {
                                                        SalaryslipTable1Data.map((d, i) => {
                                                            return <tbody key={'s'+i}>
                                                                <tr>
                                                                    <td className="text-center">{d.number}</td>
                                                                    <td>{d.title}</td>
                                                                    <td className="text-end">{d.price}</td>
                                                                </tr>
                                                            </tbody>
                                                        })
                                                    }
                                                </table>
                                            </div>
                                            <div className="row">
                                                <div className="col-lg-4 col-sm-5"></div>
                                                <div className="col-lg-4 col-sm-5 ms-auto">
                                                    <table className="table table-clear">
                                                        <tbody>
                                                            <tr>
                                                                <td><strong>Subtotal</strong></td>
                                                                <td className="text-end">$8150,00</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="col-lg-6">
                                            <div className="table-responsive-sm">
                                                <table className="table table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th className="text-center">#</th>
                                                            <th>Deductions</th>
                                                            <th className="text-end">Amount</th>
                                                        </tr>
                                                    </thead>
                                                    {
                                                        SalaryslipTable2Data.map((d,i) => {
                                                            return <tbody key={'s'+i}>
                                                                <tr>
                                                                    <td className="text-center">{d.number}</td>
                                                                    <td>{d.title}</td>
                                                                    <td className="text-end">{d.price}</td>
                                                                </tr>
                                                            </tbody>
                                                        })
                                                    }
                                                   
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
                                                                <td className="text-end">$215,00</td>
                                                            </tr>
                                                            <tr>
                                                                <td><strong>(ER) - (DE)</strong></td>
                                                                <td className="text-end">$7935</td>
                                                            </tr>
                                                            <tr>
                                                                <td><strong>Total</strong></td>
                                                                <td className="text-end"><strong>$7935</strong></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
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
                </div>
            </div>
        )
    }
export default Salaryslip;