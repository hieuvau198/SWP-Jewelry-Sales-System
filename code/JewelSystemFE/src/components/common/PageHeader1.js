import React from 'react';
import { Nav } from 'react-bootstrap';
import { Link } from 'react-router-dom';

function PageHeader1 (props) {
        const { pagetitle, righttitle, link, routebutton, modalbutton, button, invoicetab, changelog, Orderdetail, productgrid, productlist,documentation,cantactus } = props
        return (
            <div className="row align-items-center">
                <div className="border-0 mb-4">
                    <div className="card-header py-3 no-bg bg-transparent d-flex align-items-center px-0 justify-content-between border-bottom flex-wrap">
                        <h3 className="fw-bold mb-0">{pagetitle}</h3>
                        {
                            routebutton ? <div className="col-auto d-flex w-sm-100">
                                <Link to={process.env.PUBLIC_URL+link} className="btn btn-primary btn-set-task w-sm-100"><i className="icofont-plus-circle me-2 fs-6"></i>{righttitle}</Link>
                            </div> : null
                        }
                        {
                            modalbutton ? modalbutton() : null
                        }
                        {
                            button ? <button type="submit" className="btn btn-primary btn-set-task w-sm-100 text-uppercase px-5">Save</button> : null

                        }
                        {
                            invoicetab ? <div className="col-auto py-2 w-sm-100">
                                <Nav className="nav nav-tabs tab-body-header rounded invoice-set" role="tablist">
                                    <Nav.Item className="nav-item"><Nav.Link className="nav-link" eventKey="first" href="#Invoice-list">Invoice List</Nav.Link></Nav.Item>
                                    <Nav.Item className="nav-item"><Nav.Link className="nav-link " eventKey="second" href="#Invoice-Simple" >Simple invoice</Nav.Link></Nav.Item>
                                    <Nav.Item className="nav-item"><Nav.Link className="nav-link" eventKey="third" href="#Invoice-Email" >Email invoice</Nav.Link></Nav.Item>
                                </Nav>
                            </div> : null
                        }
                        
                        {
                            changelog ? <div className="col-auto mb-3 " style={{ display: 'flex', justifyContent: 'flex-end' }}>

                                <Link to="#!" title="" className="btn btn-white border lift me-1">Get Support</Link>
                                <Link to="#!" title="" className="btn btn-primary border lift">Our Portfolio</Link>
                            </div> : null
                        }
                        {
                            documentation ? <div className="row align-items-center">
                        <div className="col"></div>
                        <div className="col-auto">
                            <a href="https://themeforest.net/user/pixelwibes" title="Download"  className="btn btn-white border lift">Download</a>
                            <Link to={process.env.PUBLIC_URL+"/dashboard"} className="btn btn-dark lift">Go to Dashboard</Link>
                        </div>
                    </div> : null
                        }
                        {
                            Orderdetail ? <div className="col-auto d-flex btn-set-task w-sm-100 align-items-center">
                                <select className="form-select" aria-label="Default select example">
                                    <option>Select Order Id</option>
                                    <option value="1">Order-78414</option>
                                    <option value="2">Order-78415</option>
                                    <option value="3">Order-78416</option>
                                    <option value="4">Order-78417</option>
                                    <option value="5">Order-78418</option>
                                    <option value="6">Order-78419</option>
                                    <option value="7">Order-78420</option>
                                </select>
                            </div> : null
                        }
                        {
                            productgrid ? <div className="btn-group group-link btn-set-task w-sm-100">
                                <Link to={process.env.PUBLIC_URL+"/product-grid"} className="btn active d-inline-flex align-items-center" aria-current="page"><i className="icofont-wall px-2 fs-5"></i>Grid View</Link>
                                <Link to={process.env.PUBLIC_URL+"/product-list"} className="btn d-inline-flex align-items-center"><i className="icofont-listing-box px-2 fs-5"></i> List View</Link>
                            </div> : null
                        }
                        {
                            productlist ? <div className="btn-group group-link btn-set-task w-sm-100">
                                <Link to={process.env.PUBLIC_URL+"/product-grid"} className="btn  d-inline-flex align-items-center" aria-current="page"><i className="icofont-wall px-2 fs-5"></i>Grid View</Link>
                                <Link to={process.env.PUBLIC_URL+"/product-list"} className="btn active d-inline-flex align-items-center"><i className="icofont-listing-box px-2 fs-5"></i> List View</Link>
                            </div> : null
                        }
                        {
                            cantactus ?
                                    <div className=" py-2 project-tab  w-sm-100" style={{display:'flex',justifyContent:'right',alignItems:'right'}}>
                                        <Nav className="nav nav-tabs tab-body-header rounded ms-3 prtab-set w-sm-100" role="tablist">
                                            <Nav.Item className="nav-item"><Nav.Link eventKey="first" className="nav-link" data-bs-toggle="tab" href="#list-view" role="tab" aria-selected="true">List View</Nav.Link></Nav.Item>
                                            <Nav.Item className="nav-item"><Nav.Link eventKey="second" className="nav-link" data-bs-toggle="tab" href="#grid-view" role="tab" aria-selected="false">Grid View</Nav.Link></Nav.Item>
                                        </Nav>
                                    </div>
                               : null
                        }
                    </div>
                </div>
            </div>
        )
    }

export default PageHeader1;