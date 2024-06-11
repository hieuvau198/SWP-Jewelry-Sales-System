import React from 'react';
import { Link } from 'react-router-dom';
import { ProductListdata } from '../../Data/ProductListdata';

function CardBlock() {
    return (
        <div className="card mb-3 bg-transparent p-2">
            {
                ProductListdata.map((d, i) => {
                    return <div key={'ffff' + i} className="card border-0 mb-1">
                        <div className="form-check form-switch position-absolute top-0 end-0 py-3 px-3 d-none d-md-block">
                            <input className="form-check-input" type="checkbox" id="Eaten-switch1" />
                            <label className="form-check-label" htmlFor="Eaten-switch1">Add to Cart</label>
                        </div>
                        <div className="card-body d-flex align-items-center flex-column flex-md-row">
                            <Link to={process.env.PUBLIC_URL + "/product-detail"}>
                                <img className="w120 rounded img-fluid" src={d.images} alt="" />
                            </Link>
                            <div className="ms-md-4 m-0 mt-4 mt-md-0 text-md-start text-center w-100">
                                <Link to={process.env.PUBLIC_URL + "/product-detail"}><h6 className="mb-3 fw-bold">{d.title}<span className="text-muted small fw-light d-block">{d.reference}</span></h6></Link>
                                <div className="d-flex flex-row flex-wrap align-items-center justify-content-center justify-content-md-start">
                                    <div className="pe-xl-5 pe-md-4 ps-md-0 px-3 mb-2">
                                        <div className="text-muted small">Special priceends</div>
                                        <strong>{d.time}</strong>
                                    </div>
                                    <div className="pe-xl-5 pe-md-4 ps-md-0 px-3 mb-2">
                                        <div className="text-muted small">Offer</div>
                                        <strong>Bank Offer</strong>
                                    </div>
                                    <div className="pe-xl-5 pe-md-4 ps-md-0 px-3 mb-2">
                                        <div className="text-muted small">Price</div>
                                        <strong>{d.price}</strong>
                                    </div>
                                    <div className="pe-xl-5 pe-md-4 ps-md-0 px-3 mb-2">
                                        <div className="text-muted small">Ratings</div>
                                        <strong><i className="icofont-star text-warning"></i>{d.rating} <span className="text-muted">{d.ratingnumber}</span></strong>
                                    </div>
                                </div>
                                <div className="pe-xl-5 pe-md-4 ps-md-0 px-3 mb-2 d-inline-flex d-md-none">
                                    <button type="button" className="btn btn-primary">Add Cart</button>
                                </div>
                            </div>
                        </div>
                    </div>
                })
            }
        </div>
    )
}
export default CardBlock;