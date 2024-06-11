import React from 'react';
import OculusVR from '../../components/Products/ProductDetail/OculusVR'
import ProgressBar from '../../components/Products/ProductDetail/ProgressBar';
import { Col, Nav, Row, Tab } from 'react-bootstrap';
import ReviewDiscription from '../../components/Products/ProductDetail/ReviewDiscription';
import Discription from '../../components/Products/ProductDetail/Discription';
import About from '../../components/Products/ProductDetail/About';
import PageHeader1 from '../../components/common/PageHeader1';

function ProductDetail (){
        return (
            <div className="container-xxl">
              <PageHeader1 pagetitle='Products Detail' />
                <div className="row g-3 mb-3">
                    <OculusVR />
                </div>
                <div className="row g-3 mb-3">
                    <div className="col-md-12">
                        <Tab.Container defaultActiveKey="first" className="card">
                            <Row>
                                <Col sm={12}>
                                    <Nav className="nav nav-tabs tab-body-header rounded  d-inline-flex mb-3" role="tablist">
                                        <Nav.Item className="nav-item"><Nav.Link eventKey="first" className="nav-link " data-bs-toggle="tab" href="#review" role="tab">Reviews</Nav.Link></Nav.Item>
                                        <Nav.Item className="nav-item"><Nav.Link eventKey="second" className="nav-link" data-bs-toggle="tab" href="#descriptions" role="tab">Descriptions</Nav.Link></Nav.Item>
                                        <Nav.Item className="nav-item"><Nav.Link eventKey="third" className="nav-link" data-bs-toggle="tab" href="#about" role="tab">About</Nav.Link></Nav.Item>
                                    </Nav>
                                </Col>
                                <Col sm={12}>
                                    <Tab.Content className="tab-content">
                                        <Tab.Pane eventKey="first" className="tab-pane fade show" id="review">
                                            <div className="row clearfix g-3">
                                                    <div className="col-lg-4 col-md-12">
                                                        <div className="feedback-info sticky-top">
                                                            <div className="card">
                                                                <div className="card-body">
                                                                    <ProgressBar />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div className="col-lg-8 col-md-12">
                                                        <ReviewDiscription />
                                                        <nav aria-label="...">
                                                            <ul className="pagination justify-content-end">
                                                                <li className="page-item disabled">
                                                                    <span className="page-link">Previous</span>
                                                                </li>
                                                                <li className="page-item"><a className="page-link" href='#!'>1</a></li>
                                                                <li className="page-item active" aria-current="page">
                                                                    <span className="page-link">2</span>
                                                                </li>
                                                                <li className="page-item"><a className="page-link" href='#!'>3</a></li>
                                                                <li className="page-item">
                                                                    <a className="page-link" href='#!'>Next</a>
                                                                </li>
                                                            </ul>
                                                        </nav>
                                                    </div>
                                            </div>
                                        </Tab.Pane>
                                        <Tab.Pane eventKey="second" className="tab-pane fade show" id="descriptions">
                                            <div className='card'>
                                                <div className="card-body">
                                                    <Discription />
                                                </div>
                                            </div>
                                        </Tab.Pane>
                                        <Tab.Pane eventKey="third" className="tab-pane fade show" id="about">
                                            <div className='card'>
                                                <div className="card-body">
                                                    <About />
                                                </div>
                                            </div>
                                        </Tab.Pane>
                                    </Tab.Content>
                                </Col>
                            </Row>
                        </Tab.Container>
                    </div>
                </div>
            </div>
        )
    }
export default ProductDetail;