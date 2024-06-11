import React from 'react';
import { EmailinvoiceData } from '../../Data/AccountData/AccountData';

function EmailInvoice (){
   
        return (
            <div className="row justify-content-center">
                <div className="col-lg-8 col-md-12">
                    <div className="d-flex justify-content-center">
                        <table className="card p-5">
                            <tbody><tr>
                                <td></td>
                                <td className="text-center">
                                    <table>
                                        <tbody><tr>
                                            <td className="text-center">
                                                <h2>$389.00 Paid</h2>
                                            </td>
                                        </tr>
                                            <tr>
                                                <td className="text-center py-2">
                                                    <h4 className="mb-0">Thanks for usingeBazar.</h4>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td className="pt-2 pb-4">
                                                    <table>
                                                        <tbody>
                                                            <tr>
                                                                <td>Attn: <strong>Dianalove</strong> Winston Salem FL 27107 Email: Dianalove@gmail.com<br></br>Phone: +88 123 456 789<br></br> </td>
                                                            </tr>
                                                            <tr>
                                                                <td className="pt-2">
                                                                    <table className="table table-bordered">
                                                                        <tbody>
                                                                            {
                                                                                EmailinvoiceData.map((d, i) => {
                                                                                    return <tr key={'s'+i}>
                                                                                        <td className="text-start">{d.name}</td>
                                                                                        <td className="text-end">{d.price}</td>
                                                                                    </tr>
                                                                                })
                                                                            }
                                                                            <tr>
                                                                                <td className="text-start w-80"><strong>Total</strong></td>
                                                                                <td className="text-end fw-bold">$389.00</td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td className="pt-2 pb-2 text-center">
                                                    <a href="#!">View in browser</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td className="p-0 text-center">
                                                    PXL Inc. 47 Aurora St. South West, CT 06074
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table className="mt-3 text-center w-100">
                                        <tbody>
                                            <tr>
                                                <td className="aligncenter content-block">Questions? Email <a href="mailto:">info@pixelwibes.com</a></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td>

                                </td>
                            </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        )
    }

export default EmailInvoice;