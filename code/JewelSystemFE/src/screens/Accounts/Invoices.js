import React from 'react';
import { Col, Row, Tab } from 'react-bootstrap';
import EmailInvoice from '../../components/Accounts/Invoice/EmailInvoice';
import InvoiceList from '../../components/Accounts/Invoice/InvoiceList';
import SimpleInvoice from '../../components/Accounts/Invoice/SimpleInvoice';
import PageHeader1 from '../../components/common/PageHeader1';

function Invoices () {
           return (
            <div className="body d-flex py-lg-3 py-md-2">
                <div className="container-xxl">
                    <Tab.Container defaultActiveKey="second">
                        <Row>
                            <Col sm={12}>
                                <PageHeader1 pagetitle='Invoices' invoicetab={true}  />
                            </Col>
                            <Col sm={12}>
                                <div className="row justify-content-center">
                                    <div className="col-lg-12 col-md-12">
                                        <Tab.Content className="tab-content">
                                            <Tab.Pane className="tab-pane fade  show" eventKey="first" id="Invoice-list">
                                            {/* <SimpleInvoice/> */}
                                                <InvoiceList />
                                            </Tab.Pane>
                                            <Tab.Pane className="tab-pane fade  show" eventKey="second" id="Invoice-Simpl">
                                                <SimpleInvoice/>
                                                {/* <InvoiceList /> */}
                                            </Tab.Pane>
                                            <Tab.Pane className="tab-pane fade show" eventKey="third" id="Invoice-Email">
                                                <EmailInvoice />
                                            </Tab.Pane>
                                        </Tab.Content>
                                    </div>

                                </div>
                            </Col>
                        </Row>
                    </Tab.Container>
                </div>
            </div>
        )
    }
export default Invoices