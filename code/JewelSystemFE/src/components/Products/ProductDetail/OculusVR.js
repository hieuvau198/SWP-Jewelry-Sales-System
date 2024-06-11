import React, { useState } from 'react';
import { Link } from 'react-router-dom';  
import A1 from '../../../assets/images/product/thunb-1.jpg';
import A2 from '../../../assets/images/product/thunb-2.jpg';
import A3 from '../../../assets/images/product/thunb-3.jpg';
import A4 from '../../../assets/images/product/thunb-4.jpg';
import A5 from '../../../assets/images/product/thunb-5.jpg';
import P1 from '../../../assets/images/product/productslide-1.jpg';
import P2 from '../../../assets/images/product/productslide-2.jpg';
import P3 from '../../../assets/images/product/productslide-3.jpg';
import P4 from '../../../assets/images/product/productslide-4.jpg';
import P5 from '../../../assets/images/product/productslide-5.jpg';
import B1 from '../../../assets/images/product/product-items-1.jpg';
import B2 from '../../../assets/images/product/product-items-2.jpg';
import B3 from '../../../assets/images/product/product-items-3.jpg'

function OculusVR() {
    const [first_img, setFirst_img] = useState(3)

    return (
        <div className="col-md-12">
            <div className="card">
                <div className="card-body">
                    <div className="product-details">
                        <div className="row align-items-center">
                            <div className="col-lg-6">
                                <div className="product-details-image mt-50">
                                    <div className="product-thumb-image">
                                        <div className="product-thumb-image-active nav flex-column nav-pills me-3" id="v-pills-tab" >
                                            <a className=" single-thumb  lift" id="v-pills-one-tab" href="#v-pills-one" onClick={() => { setFirst_img(1) }}>
                                                <img src={A1} alt="" />
                                            </a>
                                            <a className="single-thumb lift" id="v-pills-two-tab" href="#v-pills-two" onClick={() => { setFirst_img(2) }}>
                                                <img src={A2} alt="" />
                                            </a>
                                            <a className={`${first_img === 3 ? "active" : ''} single-thumb  lift`} id="v-pills-three-tab" href="#v-pills-three" onClick={() => { setFirst_img(3) }}>
                                                <img src={A3} alt="" />
                                            </a>
                                            <a className="single-thumb lift" id="v-pills-four-tab" href="#v-pills-four" onClick={() => { setFirst_img(4) }}>
                                                <img src={A4} alt="" />
                                            </a>
                                            <a className="single-thumb lift" id="v-pills-five-tab" href="#v-pills-five" onClick={() => { setFirst_img(5) }}>
                                                <img src={A5} alt="" />
                                            </a>
                                        </div>
                                    </div>
                                    <div className="product-image">

                                        <div className="product-image-active tab-content" id="v-pills-tabContent">

                                            {
                                                first_img === 1 ? <a href='#!' className="single-image  lift" id="v-pills-one">
                                                    <img src={P1} alt="" />
                                                </a> : null
                                            }
                                            {
                                                first_img === 2 ?
                                                    <a href='#!' className="single-image  lift" id="v-pills-two">
                                                        <img src={P2} alt="" />
                                                    </a>
                                                    : null
                                            }
                                            {
                                                first_img === 3 ? <a href='#!' className="single-image lift" id="v-pills-three">
                                                    <img src={P3} alt="" />
                                                </a>
                                                    : null
                                            }

                                            {
                                                first_img === 4 ? <a href='#!' className="single-image  lift" id="v-pills-four" role="tabpanel">
                                                    <img src={P4} alt="" />
                                                </a>
                                                    : null
                                            }

                                            {
                                                first_img === 5 ? <a href='#!' className="single-image  lift" id="v-pills-five" role="tabpanel">
                                                    <img src={P5} alt="" />
                                                </a>
                                                    : null
                                            }


                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-lg-6">
                                <div className="product-details-content mt-45">
                                    <h2 className="fw-bold fs-4">Oculus VR</h2>
                                    <div className="my-3">
                                        <i className="fa fa-star text-warning"></i>
                                        <i className="fa fa-star text-warning"></i>
                                        <i className="fa fa-star text-warning"></i>
                                        <i className="fa fa-star text-warning"></i>
                                        <i className="fa fa-star text-warning"></i>
                                        <span className="text-muted ms-3">(449 customer review)</span>
                                    </div>
                                    <div className="product-items flex-wrap">
                                        <h6 className="item-title fw-bold">Select Your Oculus</h6>
                                        <div className="items-wrapper" id="select-item-1">
                                            <div className="single-item ">
                                                <div className="items-image lift">
                                                    <img src={B1} alt="product" />
                                                </div>
                                                <p className="text">Oculus Go</p>
                                            </div>
                                            <div className="single-item">
                                                <div className="items-image lift">
                                                    <img src={B2} alt="product" />
                                                </div>
                                                <p className="text">Oculus Quest</p>
                                            </div>
                                            <div className="single-item">
                                                <div className="items-image lift">
                                                    <img src={B3} alt="product" />
                                                </div>
                                                <p className="text">Oculus Rift S</p>
                                            </div>
                                        </div>
                                    </div>
                                    <div className="product-select-wrapper flex-wrap">
                                        <div className="select-item">
                                            <h6 className="select-title fw-bold">Select Color</h6>
                                            <ul className="color-select" id="select-color-1">
                                                <li style={{ backgroundColor: '#EFEFEF' }} className="active"></li>
                                                <li style={{ backgroundColor: '#FAE5EC' }}></li>
                                                <li style={{ backgroundColor: '#4C4C4C' }}></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div className="product-price">
                                        <h6 className="price-title fw-bold">Price</h6>
                                        <p className="sale-price">$ 149 USD</p>
                                        <p className="regular-price text-danger">$ 179 USD</p>
                                    </div>
                                    <p>Lorem Ipsum is simply dummy text of the printing and
                                        typesetting industry. Lorem Ipsum has been the industry's standard
                                        dummy text ever since the 1500s, when an unknown printer took a
                                        galley of type and scrambled it to make a type specimen book.</p>
                                    <div className="product-btn mb-5">
                                        <div className="d-flex flex-wrap">
                                            <div className="mt-2 mt-sm-0  me-1">
                                                <div className="input-group">
                                                    <input type="number" className="form-control" placeholder="1" min="1" max="5" />
                                                    <span className="input-group-text"><i className="fa fa-sort"></i></span>  
                                                </div>
                                            </div>
                                            <button className="btn btn-primary mx-1 mt-2  mt-sm-0"><i className="fa fa-heart me-1"></i> Addto Wishlist</button>
                                            <Link to={process.env.PUBLIC_URL + '/shopping-cart'} className="btn btn-primary mx-1 mt-2 mt-sm-0 w-sm-100"><i className="fa fa-shopping-cart me-1"></i> Add to Cart</Link>
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
export default OculusVR;
