import React from "react";
import { Col, Nav, Row, Tab } from "react-bootstrap";
import SyntaxHighlighter from 'react-syntax-highlighter';
import { a11yLight } from 'react-syntax-highlighter/dist/esm/styles/hljs';

function PillsNavs() {
    return (
        <div className="border-top mt-5 pt-3">
            <h3 id="Pills">Pills</h3>
            <p>Take that same HTML, but use <code>.nav-pills</code> instead:</p>
            <div className="card mb-3">
                <div className="card-body">
                    <Tab.Container id="left-tabs-example" defaultActiveKey="Preview8">
                        <Col>
                            <Nav variant="pills" className="mb-3">
                                <Nav.Item>
                                    <Nav.Link eventKey="Preview8">Preview</Nav.Link>
                                </Nav.Item>
                                <Nav.Item>
                                    <Nav.Link eventKey="HTML8">HTML</Nav.Link>
                                </Nav.Item>
                                <Nav.Item>
                                    <Nav.Link >LINK</Nav.Link>
                                </Nav.Item>
                                <Nav.Item>
                                    <Nav.Link disabled>Disabled</Nav.Link>
                                </Nav.Item>
                            </Nav>
                            <Tab.Content>
                                <Tab.Pane eventKey="Preview8" className="Pnavs-tab-pane-1">
                                    Eiusmod consequat eu adipisicing minim anim aliquip cupidatat culpa excepteur quis. Occaecat sit eu exercitation irure Lorem incididunt nostrud.
                                </Tab.Pane>
                                <Tab.Pane eventKey="HTML8" className="Pnavs-tab-pane-1">
                                    <SyntaxHighlighter language="javascript" className="mt-2 language-html py-2 px-2" style={a11yLight}>
                                        {`<Tab.Container id="left-tabs-example" defaultActiveKey="Preview8">
    <Nav variant="pills" className="mb-3">
            <Nav.Item>
                <Nav.Link eventKey="Preview8">Preview</Nav.Link>
            </Nav.Item>
            <Nav.Item>
                <Nav.Link eventKey="HTML8">HTML</Nav.Link>
            </Nav.Item>
            <Nav.Item>
                <Nav.Link >LINK</Nav.Link>
            </Nav.Item>
            <Nav.Item>
                <Nav.Link disabled>Disabled</Nav.Link>
            </Nav.Item>
    </Nav>
    <Tab.Content>
        <Tab.Pane eventKey="Preview8" className="Pnavs-tab-pane-1">
            ...
        </Tab.Pane>
        <Tab.Pane eventKey="HTML8" className="Pnavs-tab-pane-1">
            ...
        </Tab.Pane>
    </Tab.Content>
</Tab.Container>`}
                                    </SyntaxHighlighter>
                                </Tab.Pane>
                            </Tab.Content>
                        </Col>
                    </Tab.Container>

                </div>
            </div>
            <div className="card mb-3">
                <div className="card-body">
                    <Tab.Container id="left-tabs-example" defaultActiveKey="Preview8">
                        <Row>
                            <Col sm={3}>
                                <Nav variant="pills" className="flex-column">
                                    <Nav.Item>
                                        <Nav.Link eventKey="Preview8">Preview</Nav.Link>
                                    </Nav.Item>
                                    <Nav.Item>
                                        <Nav.Link eventKey="HTML8">HTML</Nav.Link>
                                    </Nav.Item>
                                    <Nav.Item>
                                        <Nav.Link >LINK</Nav.Link>
                                    </Nav.Item>
                                    <Nav.Item>
                                        <Nav.Link disabled>Disabled</Nav.Link>
                                    </Nav.Item>
                                </Nav>
                            </Col>
                            <Col>
                                <Tab.Content>
                                    <Tab.Pane eventKey="Preview8" className="Pnavs-tab-pane-1">
                                        Eiusmod consequat eu adipisicing minim anim aliquip cupidatat culpa excepteur quis. Occaecat sit eu exercitation irure Lorem incididunt nostrud.
                                    </Tab.Pane>
                                    <Tab.Pane eventKey="HTML8" className="Pnavs-tab-pane-1">
                                        <SyntaxHighlighter language="javascript" className="mt-2 language-html py-2 px-2" style={a11yLight}>
                                            {`<Tab.Container id="left-tabs-example" defaultActiveKey="Preview8">
    <Nav variant="pills" className="mb-3">
            <Nav.Item>
                <Nav.Link eventKey="Preview8">Preview</Nav.Link>
            </Nav.Item>
            <Nav.Item>
                <Nav.Link eventKey="HTML8">HTML</Nav.Link>
            </Nav.Item>
            <Nav.Item>
                <Nav.Link >LINK</Nav.Link>
            </Nav.Item>
            <Nav.Item>
                <Nav.Link disabled>Disabled</Nav.Link>
            </Nav.Item>
    </Nav>
    <Tab.Content>
        <Tab.Pane eventKey="Preview8" className="Pnavs-tab-pane-1">
            ...
        </Tab.Pane>
        <Tab.Pane eventKey="HTML8" className="Pnavs-tab-pane-1">
            ...
        </Tab.Pane>
    </Tab.Content>
</Tab.Container>`}
                                        </SyntaxHighlighter>
                                    </Tab.Pane>
                                </Tab.Content>
                            </Col>
                        </Row>
                    </Tab.Container>
                </div>
            </div>
        </div>
    );
}

export default PillsNavs;