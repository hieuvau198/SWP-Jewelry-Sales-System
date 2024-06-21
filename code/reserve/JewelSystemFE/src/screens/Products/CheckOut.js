import React, { useState } from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import Bankdetail from '../../components/Products/Checkout/Bankdetail';
import Personaldetail from '../../components/Products/Checkout/Personaldetail';
import Pricing from '../../components/Products/Checkout/Pricing';
import Shippingaddress from '../../components/Products/Checkout/Shippingaddress';

function CheckOut() {
    const [firstCollapse, setFirstCollapse] = useState(true);
    const [secondCollapse, setSecondCollapse] = useState(true);
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
                                                <Personaldetail />
                                            </div>
                                        </section>
                                    </li>
                                    <li>
                                        <section>
                                            <a href='#!' onClick={() => { setSecondCollapse(!secondCollapse ) }} aria-expanded={secondCollapse}>
                                                <h6 className="title collapsed fw-bold" id="headingTwo" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-controls="collapseTwo">Shipping Address</h6>
                                            </a>
                                            <div className={`checkout-steps-form-content collapse ${secondCollapse ? "show" : ''}`} id="collapseTwo" aria-labelledby="headingTwo" data-bs-parent="#accordionExample">
                                                <Shippingaddress />
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
                        <Pricing />
                    </div>
                    <Bankdetail />
                </div>
            </div>
        </div>
    )
}
export default CheckOut;