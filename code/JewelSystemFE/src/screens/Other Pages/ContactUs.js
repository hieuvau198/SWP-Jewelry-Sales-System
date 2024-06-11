import React from 'react';
import { Col, Row, Tab } from 'react-bootstrap';
import PageHeader1 from '../../components/common/PageHeader1';
import ContactAdd from '../../components/Other Pages/ContactUs/ContactAdd';
import ContactProfileView from '../../components/Other Pages/ContactUs/ContactProfileView';
import ContactTableListView from '../../components/Other Pages/ContactUs/ContactTableListView';

function ContactUs() {
    return (
        <div className='body d-flex py-3'>
            <div className='container-xxl'>
                <Tab.Container defaultActiveKey="first">
                    <Row>
                        <Col sm={12}>
                            <PageHeader1 pagetitle='Contact' cantactus={true} />

                        </Col>
                        <Col sm={12}>
                            <Tab.Content className='tab-content'>
                                <Tab.Pane eventKey="first" className='tab-pane fade show'>
                                    <div className='row clearfix g-3'>
                                        <div className="col-lg-4">
                                            <ContactAdd />
                                        </div>
                                        <div className="col-lg-8">
                                            <ContactProfileView />
                                        </div>
                                    </div>
                                </Tab.Pane>
                                <Tab.Pane eventKey="second" className='tab-pane fade show'>
                                    <div className='row clearfix g-3'>
                                        <div className="col-lg-4">
                                            <ContactAdd />
                                        </div>
                                        <div className="col-lg-8">
                                            <ContactTableListView />
                                        </div>
                                    </div>
                                </Tab.Pane>
                            </Tab.Content>
                        </Col>
                    </Row>
                </Tab.Container>
            </div>
        </div>
    )
}
export default ContactUs;