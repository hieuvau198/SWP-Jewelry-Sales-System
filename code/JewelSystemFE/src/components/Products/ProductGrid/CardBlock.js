import React from 'react';
import { Link } from 'react-router-dom';
import { ProductData } from '../../Data/ProductgridData';

function CardBlock() {
    return (
        <div className="row g-3 mb-3 row-cols-1 row-cols-sm-2 row-cols-md-2 row-cols-lg-2 row-cols-xl-2 row-cols-xxl-3">
            {
                ProductData.map((d, i) => {
                    return <div key={'product' + i} className="col">
                        <div className="card">
                            <div className="product">
                                <div className="product-image">
                                    <div className="product-item active">
                                        <img src={d.images} alt="product" className="img-fluid w-100" />
                                    </div>
                                    <a className="add-wishlist" href="#!">
                                        <i className={d.iconHeart}></i>
                                    </a>
                                </div>
                                <div className="product-content p-3">
                                    <span className="rating mb-2 d-block"><i className={d.iconStar}></i>{d.value} </span>
                                    <Link to={process.env.PUBLIC_URL + "/product-detail"} className="fw-bold">{d.title} </Link>
                                    <p className="text-muted">{d.referenceTitle}</p>
                                    <span className="d-block fw-bold fs-5 text-secondary">{d.doller}</span>
                                    <Link to={process.env.PUBLIC_URL + "/shopping-cart"} className="btn btn-primary mt-3">{d.button}</Link>
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