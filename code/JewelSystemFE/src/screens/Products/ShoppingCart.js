import React from 'react';
import DataTable from "react-data-table-component";
import { Link } from 'react-router-dom';
import PageHeader1 from '../../components/common/PageHeader1';
import {ShoppingCartData} from '../../components/Data/ShoppingCartData';
import { useState } from 'react';
import { useCart } from 'react-use-cart';



function ShoppingCart () {

    
    const {items, updateItemQuantity, removeItem, getItem, emptyCart, cartTotal,updateCartMetadata, metadata } = useCart();
    const [ discount, setDiscount] = useState(10);
    


        return (
            <div className="body d-flex py-3">
                <div className="container-xxl">
                <PageHeader1 pagetitle='Cart Detail' />
                    <div className="row g-3 mb-3 justify-content-center">
                        <div className="col-lg-12 col-xl-12 col-xxl-9">
                            <div className="card">
                                <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                                    <h6 className="m-0 fw-bold">Order Summary</h6>
                                </div>
                                <div className="card-body">
                                    <div className="product-cart">
                                        <div className="checkout-table">
                                            <div className="table-responsive">
                                                <div id="myCartTable_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer">
                                                    <div className="row">
                                                        <div className="col-sm-auto">
                                                            <DataTable
                                                                title={ShoppingCartData().title}
                                                                columns={ShoppingCartData().columns}
                                                                data={ShoppingCartData().rows}
                                                                defaultSortField="title"
                                                                pagination
                                                                selectableRows={false}
                                                                className="table myDataTable table-hover align-middle mb-0 d-row nowrap dataTable no-footer dtr-inline"
                                                                highlightOnHover={true}
                                                            />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="checkout-coupon-total checkout-coupon-total-2 d-flex flex-wrap mt-2">
                                            <div className="checkout-coupon">
                                                    <div className="single-form form-default d-inline-flex mt-3">
                                                        <div className="input-group mb-3">
                                                        <button type="button" className="btn btn-primary" onClick={emptyCart}>emptycart</button>
                                                        </div>
                                                    </div>
                                                    
                                            </div>
                                            <div className="checkout-coupon">
                                                <span>Apply Coupon to get discount!</span>
                                                    <div className="single-form form-default d-inline-flex mt-3">
                                                        <div className="input-group mb-3">
                                                            <input type="number" className="form-control" placeholder={discount} onChange={(e)=>{setDiscount(e.target.value)}}  />
                                                            <button className="btn btn-primary" onClick={()=>{updateCartMetadata({discount:discount})}}>Apply</button>
                                                        </div>
                                                    </div>
                                                    
                                            </div>
                                            <div className="checkout-total">
                                            
                                                <div className="single-total">
                                                    <p className="value">Subotal Price:</p>
                                                    <p className="price"> {new Intl.NumberFormat("de-DE").format(Math.round(cartTotal)) }d</p>
                                                </div>
                                                <div className="single-total">
                                                    <p className="value">Discount ({0-metadata.discount}%):</p>
                                                    <p className="price"> {new Intl.NumberFormat("de-DE").format(Math.round(cartTotal*metadata.discount/100)) }d</p>
                                                </div>
                                                <div className="single-total">
                                                    <p className="value">Tax(18%):</p>
                                                    <p className="price"> {new Intl.NumberFormat("de-DE").format(Math.round(cartTotal*18/100)) }d </p>
                                                </div>
                                                <div className="single-total total-payable">
                                                    <p className="value">Total Payable:</p>
                                                    <p className="price"> {new Intl.NumberFormat("de-DE").format(Math.round(cartTotal-cartTotal*metadata.discount/100+cartTotal*18/100)) }d</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="checkout-btn d-flex justify-content-between pt-3 flex-wrap mt-2">
                                            <div className="single-btn w-sm-100">
                                                <Link to={process.env.PUBLIC_URL+"/product-list"} className="btn btn-secondary w-sm-100">Continue Shopping</Link>
                                            </div>
                                            <div className="single-btn w-sm-100">
                                                <Link to={process.env.PUBLIC_URL+"/check-out"} className="btn btn-primary w-sm-100">Proceed to Checkout</Link>
                                            </div>
                                            <div className="single-btn w-sm-100">
                                                <Link onClick={()=>{console.log(metadata)}} className="btn btn-primary w-sm-100">check metadata</Link>
                                            </div>
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
export default ShoppingCart