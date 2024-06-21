import React, { useState, useEffect } from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import Bankdetail from '../../components/Products/Checkout/Bankdetail';
import Personaldetail from '../../components/Products/Checkout/Personaldetail';
import Pricing from '../../components/Products/Checkout/Pricing';
import Shippingaddress from '../../components/Products/Checkout/Shippingaddress';
import CustomerList from '../User/CustomerList';
import DataTable from 'react-data-table-component';
import { ShoppingCartData } from '../../components/Data/ShoppingCartData';
import ShoppingCart from './ShoppingCart';
import { useCart } from 'react-use-cart';


    

    




function CheckOut() {

    const [firstCollapse, setFirstCollapse] = useState(true);
    const [secondCollapse, setSecondCollapse] = useState(true);   
    const [ discount, setDiscount] = useState(10);
    const [ userId, setUserId] = useState();     
    const {items, updateItemQuantity, removeItem, getItem, emptyCart, cartTotal,updateCartMetadata, metadata } = useCart();


    return (
        <div className="container-xxl">
            <PageHeader1 pagetitle='Checkout Details' />
            <div className="row g-3 mb-3">
                <div className="col-lg-12 col-xl-8">
                    <div className="card">
                        <div className="card-body">
                            <div className="checkout-steps">
                                <ul id="accordionExample">
                                    <li>
                                        <section>
                                            <a href='#!' onClick={() => { setFirstCollapse( !firstCollapse ) }} aria-expanded={firstCollapse}>
                                                <h6 className="title collapsed fw-bold" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-controls="collapseOne">Your Personal Details </h6>
                                            </a>
                                            <div className={`checkout-steps-form-content collapse ${firstCollapse ? "show" : ''}`} id="collapseOne" aria-labelledby="headingOne" data-bs-parent="#accordionExample">
                                                
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
                                               
                                            </div>
                                        </section>
                                    </li>
                                    <li>
                                        <section>
                                            <a href='#!' onClick={() => { setSecondCollapse(!secondCollapse ) }} aria-expanded={secondCollapse}>
                                                <h6 className="title collapsed fw-bold" id="headingTwo" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-controls="collapseTwo">Shipping Address</h6>
                                            </a>
                                            <div className={`checkout-steps-form-content collapse ${secondCollapse ? "show" : ''}`} id="collapseTwo" aria-labelledby="headingTwo" data-bs-parent="#accordionExample">
                                                <CustomerList />
                                            </div>
                                        </section>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="col-lg-12 col-xl-4">
                    <div className="card  mb-3">
                        <Pricing metadata={metadata} />
                    </div>
                    <Bankdetail />
                </div>
            </div>
        </div>
        
    )
}
export default CheckOut;