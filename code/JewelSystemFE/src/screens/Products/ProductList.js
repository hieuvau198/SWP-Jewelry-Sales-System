import React from 'react';
import CategoriesBlock from '../../components/Products/ProductList/CategoriesBlock';
import SizeBlock from '../../components/Products/ProductList/SizeBlock';
import ColorBlock from '../../components/Products/ProductList/ColorBlock';
import PricingBlock from '../../components/Products/ProductList/PricingBlock';
import RatingBlock from '../../components/Products/ProductList/RatingBlock';
import CardBlock from '../../components/Products/ProductList/CardBlock';
import PageHeader1 from '../../components/common/PageHeader1';

function ProductList() {
    return (
        <div className="container-xxl">
            <PageHeader1 pagetitle='Products' productlist={true} />
            <div className="row g-3 mb-3">
                <div className="col-md-12 col-lg-4 col-xl-4 col-xxl-3">
                    <div className="sticky-lg-top">
                        <div className="card mb-3">
                            <div className="reset-block">
                                <div className="filter-title">
                                    <h4 className="title">Filter</h4>
                                </div>
                                <div className="filter-btn">
                                    <a className="btn btn-primary" href="#!">Reset</a>
                                </div>
                            </div>
                        </div>
                        <div className="card mb-3">
                            <CategoriesBlock />
                        </div>
                        <div className="card mb-3">
                            <SizeBlock />
                        </div>
                        <div className="card mb-3">
                            <ColorBlock />
                        </div>
                        <div className="card mb-3">
                            <PricingBlock />
                        </div>
                        <div className="card">
                            <RatingBlock />
                        </div>
                    </div>
                </div>
                <div className="col-md-12 col-lg-8 col-xl-8 col-xxl-9">
                    <CardBlock />
                </div>
                <div className="row g-3 mb-3">
                    <div className="col-md-12">
                        <nav className="justify-content-end d-flex">
                            <ul className="pagination">
                                <li className="page-item disabled">
                                    <a className="page-link" href="#!">Previous</a>
                                </li>
                                <li className="page-item"><a className="page-link" href="#!">1</a></li>
                                <li className="page-item active" aria-current="page">
                                    <a className="page-link" href="#!">2</a>
                                </li>
                                <li className="page-item"><a className="page-link" href="#!">3</a></li>
                                <li className="page-item">
                                    <a className="page-link" href="#!">Next</a>
                                </li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default ProductList;