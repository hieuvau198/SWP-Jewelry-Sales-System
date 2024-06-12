import React from 'react';
import { Dropdown } from 'react-bootstrap';
import Avatar1 from '../../assets/images/xs/avatar1.svg';
import Avatar3 from '../../assets/images/xs/avatar3.svg';
import Avatar5 from '../../assets/images/xs/avatar5.svg';
import Avatar6 from '../../assets/images/xs/avatar6.svg';
import Avatar7 from '../../assets/images/xs/avatar7.svg';
import Profile from '../../assets/images/profile_av.svg';
import { Link } from 'react-router-dom';

function Header () {
        return (
            <div className="header">
                <nav className="navbar py-4">
                    <div className="container-xxl">
                        <div className="h-right d-flex align-items-center order-1">  
                            <Dropdown className="notifications zindex-popover">
                                <Dropdown.Toggle as="a" className="nav-link dropdown-toggle pulse">
                                    <i className="icofont-alarm fs-5"></i>
                                </Dropdown.Toggle>
                                <Dropdown.Menu className="rounded-lg shadow border-0 dropdown-animation dropdown-menu-sm-end p-0 m-0">
                                    <div className="card border-0 w380">
                                        <div className="card-header border-0 p-3">
                                            <h5 className="mb-0 font-weight-light d-flex justify-content-between">
                                                <span>Notifications</span>
                                                <span className="badge text-white">06</span>
                                            </h5>
                                        </div>
                                        <div className=" card-body">
                                            <div className="">
                                                <ul className="list-unstyled list mb-0">
                                                    <li className="py-2 mb-1 border-bottom">
                                                        <a href="#!" className="d-flex">
                                                            <img className="avatar rounded-circle" src={Avatar1} alt="" />
                                                            <div className="flex-fill ms-2">
                                                                <p className="d-flex justify-content-between mb-0 "><span className="font-weight-bold">Dylan Hunter</span> <small>2MIN</small></p>
                                                                <span className="">Added  2021-02-19 my-Task ui/ux Design <span className="badge bg-success">Review</span></span>
                                                            </div>
                                                        </a>
                                                    </li>
                                                    <li className="py-2 mb-1 border-bottom">
                                                        <a href="#!" className="d-flex">
                                                            <div className="avatar rounded-circle no-thumbnail">DF</div>
                                                            <div className="flex-fill ms-2">
                                                                <p className="d-flex justify-content-between mb-0 "><span className="font-weight-bold">Diane Fisher</span> <small>13MIN</small></p>
                                                                <span className="">Task added Get Started with Fast Cad project</span>
                                                            </div>
                                                        </a>
                                                    </li>
                                                    <li className="py-2 mb-1 border-bottom">
                                                        <a href="#!" className="d-flex">
                                                            <img className="avatar rounded-circle" src={Avatar3} alt="" />
                                                            <div className="flex-fill ms-2">
                                                                <p className="d-flex justify-content-between mb-0 "><span className="font-weight-bold">Andrea Gill</span> <small>1HR</small></p>
                                                                <span className="">Quality Assurance Task Completed</span>
                                                            </div>
                                                        </a>
                                                    </li>
                                                    <li className="py-2 mb-1 border-bottom">
                                                        <a href="#!" className="d-flex">
                                                            <img className="avatar rounded-circle" src={Avatar5} alt="" />
                                                            <div className="flex-fill ms-2">
                                                                <p className="d-flex justify-content-between mb-0 "><span className="font-weight-bold">Diane Fisher</span> <small>13MIN</small></p>
                                                                <span className="">Add New Project for App Developemnt</span>
                                                            </div>
                                                        </a>
                                                    </li>
                                                    <li className="py-2 mb-1 border-bottom">
                                                        <a href="#!" className="d-flex">
                                                            <img className="avatar rounded-circle" src={Avatar6} alt="" />
                                                            <div className="flex-fill ms-2">
                                                                <p className="d-flex justify-content-between mb-0 "><span className="font-weight-bold">Andrea Gill</span> <small>1HR</small></p>
                                                                <span className="">Add Timesheet For Rhinestone project</span>
                                                            </div>
                                                        </a>
                                                    </li>
                                                    <li className="py-2">
                                                        <a href="#!" className="d-flex">
                                                            <img className="avatar rounded-circle" src={Avatar7} alt="" />
                                                            <div className="flex-fill ms-2">
                                                                <p className="d-flex justify-content-between mb-0 "><span className="font-weight-bold">Zoe Wright</span> <small className="">1DAY</small></p>
                                                                <span className="">Add Calander Event</span>
                                                            </div>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <a className="card-footer text-center border-top-0" href="#!"> View all notifications</a>
                                    </div>
                                </Dropdown.Menu>
                            </Dropdown>
                            <Dropdown className="dropdown user-profilem ms-2 ms-sm-3 d-flex align-items-center zindex-popover">
                                <div className="u-info me-2">
                                    <p className="mb-0 text-end line-height-sm "><span className="font-weight-bold">User1</span></p>
                                    <small>Admin</small>
                                </div>
                                <Dropdown.Toggle as='a' className="nav-link dropdown-toggle pulse p-0 mb-3" href="#!" role="button">
                                    <img className="avatar lg rounded-circle img-thumbnail" src={Profile} alt="profile" />
                                </Dropdown.Toggle>
                                <Dropdown.Menu className="dropdown-menu rounded-lg shadow border-0 dropdown-animation dropdown-menu-end p-0 m-0 mt-5 ">
                                    <div className="card border-0   w280">
                                        <div className="card-body pb-0 ">
                                            <div className="d-flex py-1">
                                                <img className="avatar rounded-circle" src={Profile} alt="" />
                                                <div className="flex-fill ms-3">
                                                    <p className="mb-0"><span className="font-weight-bold">John	Quinn</span></p>
                                                    <small>Johnquinn@gmail.com</small>
                                                </div>
                                            </div>
                                            <div><hr className="dropdown-divider border-dark " /></div>
                                        </div>
                                        <div className="list-group m-2 ">
                                            <Link to={process.env.PUBLIC_URL+"/profile-pages"} className="list-group-item list-group-item-action border-0 "><i className="icofont-ui-user fs-5 me-3"></i>Profile Page</Link>
                                            <Link to={process.env.PUBLIC_URL+"/order-invoice"} className="list-group-item list-group-item-action border-0 "><i className="icofont-file-text fs-5 me-3"></i>Order Invoices</Link>
                                            <Link to={process.env.PUBLIC_URL+"/sign-in"} className="list-group-item list-group-item-action border-0 "><i className="icofont-logout fs-5 me-3"></i>Signout</Link>
                                        </div>
                                    </div>
                                </Dropdown.Menu>
                            </Dropdown>
                        </div>
                        <button className="navbar-toggler p-0 border-0 menu-toggle order-3" type="button" onClick={() => {
                            var sidebar = document.getElementById('mainsidemenu')
                            if (sidebar) {
                                if (sidebar.classList.contains('open')) {
                                    sidebar.classList.remove('open')
                                } else {
                                    sidebar.classList.add('open')
                                }
                            }
                        }}>
                            <span className="fa fa-bars"></span>
                        </button>
                        <div className="order-0 col-lg-4 col-md-4 col-sm-12 col-12 mb-4  ">
                            <div className="input-group flex-nowrap input-group-lg">
                                <input type="search" className="form-control" placeholder="Search" />
                                <button type="button" className="input-group-text" id="addon-wrapping"><i className="fa fa-search"></i></button>
                            </div>
                        </div>
                    </div>
                </nav>
            </div>
        )
    }




export default Header;