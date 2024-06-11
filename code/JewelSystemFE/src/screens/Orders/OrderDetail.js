import React from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import AddressBlock from '../../components/Orders/OrdersDetail/AddressBlock';
import CardBlock from '../../components/Orders/OrdersDetail/CardBlock';
import OrderSummeryBlock from '../../components/Orders/OrdersDetail/OrderSummeryBlock';
import StatusOrderBlock from '../../components/Orders/OrdersDetail/StatusOrderBlock';

function OrderDetail (){
        return (
            <div className="body d-flex py-3">
                <div className="container-xxl">
                    <PageHeader1 pagetitle='Order Details: #Order-78414' Orderdetail={true}/>
                    <CardBlock />
                    <div className="row g-3 mb-3 row-cols-1 row-cols-md-1 row-cols-lg-3 row-cols-xl-3 row-cols-xxl-3 row-deck">
                        <AddressBlock />
                        <div className="col">
                            <div className="card">
                                <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                                    <h6 className="mb-0 fw-bold ">Invoice Deatil</h6>
                                    <a href="#!" className="text-muted">Download</a>
                                </div>
                                <div className="card-body">
                                    <div className="row g-3">
                                        <div className="col-12">
                                            <label className="form-label col-6 col-sm-5">Number:</label>
                                            <span><strong>#78414</strong></span>
                                        </div>
                                        <div className="col-12">
                                            <label className="form-label col-6 col-sm-5">Seller GST :</label>
                                            <span><strong>AFQWEPX17390VJ</strong></span>
                                        </div>
                                        <div className="col-12">
                                            <label className="form-label col-6 col-sm-5">Purchase GST :</label>
                                            <span><strong>NVFQWEPX1730VJ</strong></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="row g-3 mb-3">
                        <div className="col-xl-12 col-xxl-8">
                            <div className="card">
                                <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                                    <h6 className="mb-0 fw-bold ">Order Summary</h6>
                                </div>
                                <div className="card-body">
                                    <div className="product-cart">
                                        <div className="checkout-table table-responsive">
                                            <div id="myCartTable_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer">
                                                <div className="row">
                                                    <OrderSummeryBlock />
                                                </div>
                                            </div>
                                        </div>
                                        <div className="checkout-coupon-total checkout-coupon-total-2 d-flex flex-wrap justify-content-end">
                                            <div className="checkout-total">
                                                <div className="single-total">
                                                    <p className="value">Subotal Price:</p>
                                                    <p className="price">$1096.00</p>
                                                </div>
                                                <div className="single-total">
                                                    <p className="value">Shipping Cost (+):</p>
                                                    <p className="price">$12.00</p>
                                                </div>
                                                <div className="single-total">
                                                    <p className="value">Discount (-):</p>
                                                    <p className="price">$10.00</p>
                                                </div>
                                                <div className="single-total">
                                                    <p className="value">Tax(18%):</p>
                                                    <p className="price">$198.00</p>
                                                </div>
                                                <div className="single-total total-payable">
                                                    <p className="value">Total Payable:</p>
                                                    <p className="price">$1296.00</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-xl-12 col-xxl-4">
                            <StatusOrderBlock />
                        </div>
                    </div>
                </div>
            </div>
        )
    }
export default OrderDetail;