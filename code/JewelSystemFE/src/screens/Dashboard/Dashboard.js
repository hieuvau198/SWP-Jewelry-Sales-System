import React from 'react';
import { Tab, Nav, Row, Col } from 'react-bootstrap';
import ShoppingStatuschart from '../../components/dashboard/ShoppingStatuschart';
import TopShellingProductChart from '../../components/dashboard/TopShellingProductChart';
import AvgexpenceChart from '../../components/dashboard/AvgexpenceChart';
import BranchLocation from '../../components/dashboard/BranchLocation';
import ActiveUsersStatus from '../../components/dashboard/ActiveUsersStatus';
import RecentTransaction from '../../components/dashboard/RecentTransaction';
import SalesStatus from '../../components/dashboard/SalesStatus';
import { DashboardStatusData, MonthData, TodayData, WeekData, YearData } from '../../components/Data/Data';

function Dashboard() {
    return (
        <div className="body d-flex py-3">
            <div className="container-xxl">
                <div className="row g-3 mb-3 row-cols-1 row-cols-sm-2 row-cols-md-2 row-cols-lg-2 row-cols-xl-4">
                    {
                        DashboardStatusData.map((d, i) => {
                            return <div key={'statuscard' + i} className="col">
                                <div className={`${d.bgClass} alert mb-0`}>
                                    <div className="d-flex align-items-center">
                                        <div className={`avatar rounded no-thumbnail ${d.iconBgClass} text-light`}><i className={d.iconClass}></i></div>
                                        <div className="flex-fill ms-3 text-truncate">
                                            <div className="h6 mb-0">{d.title}</div>
                                            <span className="small">{d.value}</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        })
                    }
                </div>
                <div className="mt-1">
                    <Tab.Container id="left-tabs-example" defaultActiveKey="first" className="col-lg-12 col-md-12">
                        <Row>
                            <Col sm={12}>
                                <div className="tab-filter d-flex align-items-center justify-content-between mb-3 flex-wrap">
                                    <Nav variant="pills" className="nav nav-tabs tab-card tab-body-header rounded  d-inline-flex w-sm-100">
                                        <Nav.Item className="nav-item"><Nav.Link className="nav-link " eventKey="first" href="#summery-today">Today</Nav.Link></Nav.Item>
                                        <Nav.Item className="nav-item"><Nav.Link className="nav-link" eventKey="second" href="#summery-week">Week</Nav.Link></Nav.Item>
                                        <Nav.Item className="nav-item"><Nav.Link className="nav-link" eventKey="third" href="#summery-month">Month</Nav.Link></Nav.Item>
                                        <Nav.Item className="nav-item"><Nav.Link className="nav-link" eventKey="fourth" href="#summery-year">Year</Nav.Link></Nav.Item>
                                    </Nav>
                                    <div className="date-filter d-flex align-items-center mt-2 mt-sm-0 w-sm-100">
                                        <div className="input-group">
                                            <input type="date" className="form-control" />
                                            <button className="btn btn-primary" type="button"><i className="icofont-filter fs-5"></i></button>
                                        </div>
                                    </div>
                                </div>
                            </Col>
                            <Col sm={12}>
                                <Tab.Content className="tab-content mt-1">
                                    <Tab.Pane eventKey="first" className="tab-pane fade show" id="summery-today">
                                        <div className="row g-1 g-sm-3 mb-3 row-deck">
                                            {
                                                TodayData.map((d, i) => {
                                                    return <div key={'todaydata' + i} className="col-xl-4 col-lg-4 col-md-4 col-sm-6">
                                                        <div className="card">
                                                            <div className="card-body py-xl-4 py-3 d-flex flex-wrap align-items-center justify-content-between">
                                                                <div className="left-info">
                                                                    <span className="text-muted">{d.title}</span>
                                                                    <div><span className="fs-6 fw-bold me-2">{d.value}</span></div>
                                                                </div>
                                                                <div className="right-icon">
                                                                    <i className={`${d.iconClass}`}></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                })
                                            }
                                        </div>
                                    </Tab.Pane>
                                    <Tab.Pane eventKey="second" className="tab-pane fade show" id="summery-week">
                                        <div className="row g-3 mb-4 row-deck">
                                            {
                                                WeekData.map((d, i) => {
                                                    return <div key={'weekdata' + i} className="col-xl-4 col-lg-4 col-md-4 col-sm-6">
                                                        <div className="card">
                                                            <div className="card-body py-xl-4 py-3 d-flex flex-wrap align-items-center justify-content-between">
                                                                <div className="left-info">
                                                                    <span className="text-muted">{d.title}</span>
                                                                    <div><span className="fs-6 fw-bold me-2">{d.value}</span></div>
                                                                </div>
                                                                <div className="right-icon">
                                                                    <i className={`${d.iconClass}`}></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                })
                                            }

                                        </div>
                                    </Tab.Pane>
                                    <Tab.Pane eventKey="third" className="tab-pane fade show" id="summery-month">
                                        <div className="row g-3 mb-4 row-deck">
                                            {
                                                MonthData.map((d, i) => {
                                                    return <div key={'monthdata' + i} className="col-xl-4 col-lg-4 col-md-4 col-sm-6">
                                                        <div className="card">
                                                            <div className="card-body py-xl-4 py-3 d-flex flex-wrap align-items-center justify-content-between">
                                                                <div className="left-info">
                                                                    <span className="text-muted">{d.title}</span>
                                                                    <div><span className="fs-6 fw-bold me-2">{d.value}</span></div>
                                                                </div>
                                                                <div className="right-icon">
                                                                    <i className={`${d.iconClass}`}></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                })
                                            }
                                        </div>
                                    </Tab.Pane>
                                    <Tab.Pane eventKey="fourth" className="tab-pane fade show" id="summery-year">
                                        <div className="row g-3 mb-4 row-deck">
                                            {
                                                YearData.map((d, i) => {
                                                    return <div key={'yeardata' + i} className="col-xl-4 col-lg-4 col-md-4 col-sm-6">
                                                        <div className="card">
                                                            <div className="card-body py-xl-4 py-3 d-flex flex-wrap align-items-center justify-content-between">
                                                                <div className="left-info">
                                                                    <span className="text-muted">{d.title}</span>
                                                                    <div><span className="fs-6 fw-bold me-2">{d.value}</span></div>
                                                                </div>
                                                                <div className="right-icon">
                                                                    <i className={`${d.iconClass}`}></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                })
                                            }
                                        </div>
                                    </Tab.Pane>
                                </Tab.Content>
                            </Col>
                        </Row>
                    </Tab.Container>
                </div>
                <div className='row g-3 mb-3'>
                    <div className='col-xl-12'>
                        <SalesStatus />
                    </div>
                </div>
                <div className="row g-3 mb-3">
                    <div className="col-xxl-8 col-xl-8">
                        <ShoppingStatuschart />
                        <TopShellingProductChart />
                    </div>
                    <div className='col-xxl-4 col-xl-4'>
                        <BranchLocation />
                    </div>
                </div>
                <div className="row g-3 mb-3">
                    <div className="col-lg-4 col-md-12">
                        <ActiveUsersStatus />
                    </div>
                    <div className='col-lg-8 col-md-12'>
                        <AvgexpenceChart />
                    </div>
                </div>
                <div className="row g-3 mb-3">
                    <div className="col-md-12">
                        <RecentTransaction />
                    </div>
                </div>
            </div>
        </div>

    )
}
export default Dashboard;