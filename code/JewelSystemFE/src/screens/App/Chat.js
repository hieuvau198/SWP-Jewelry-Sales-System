import React from 'react';
import { Col, Nav, Row, Tab } from 'react-bootstrap';
import ChatTab from '../../components/App/chat/ChatTab';
import EcommerceTab from '../../components/App/chat/EcommerceTab';
import ContactTab from '../../components/App/chat/ContactTab';
import ChatBox from '../../components/App/ChatBox/ChatBox';

function Chat() {
    return (
        <div className="body d-flex">
            <div className="container-xxl p-0">
                <div className="row g-0">
                    <div className="col-12 d-flex">
                        <div id='tabboxes' className="card card-chat border-right border-top-0 border-bottom-0  w380" >
                            <Tab.Container defaultActiveKey="first">
                                <Row>
                                    <Col sm={12}>
                                        <div className="px-4 py-3 py-md-4">
                                            <div className="input-group mb-3">
                                                <input type="text" className="form-control mb-1" placeholder="Search..." />
                                            </div>
                                            <Nav className="nav nav-pills justify-content-between text-center" role="tablist">
                                                <Nav.Link className="flex-fill rounded border-0 nav-link " eventKey='first' href="#chat-recent">Chat</Nav.Link>
                                                <Nav.Link className="flex-fill rounded border-0 nav-link" eventKey='second' href="#chat-groups" >Ecommerce Groups</Nav.Link>
                                                <Nav.Link className="flex-fill rounded border-0 nav-link" eventKey='third' href="#chat-contact" >Contact</Nav.Link>
                                            </Nav>
                                        </div>
                                    </Col>
                                    <Col sm={12}>
                                        <Tab.Content className="tab-content border-top">
                                            <Tab.Pane className="tab-pane fade  show" eventKey='first' id="chat-recent" role="tabpanel">
                                                <ChatTab />
                                            </Tab.Pane>
                                            <Tab.Pane className="tab-pane fade  show" eventKey='second' id="chat-groups" role="tabpanel">
                                                <EcommerceTab />
                                            </Tab.Pane>
                                            <Tab.Pane className="tab-pane fade  show" eventKey='third' id="chat-contact" role="tabpanel">
                                                <ContactTab />
                                            </Tab.Pane>
                                        </Tab.Content>
                                    </Col>
                                </Row>
                            </Tab.Container>
                        </div>
                        <div className="card card-chat-body border-0  w-100 px-4 px-md-5 py-3 py-md-4">
                            <ChatBox />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default Chat;