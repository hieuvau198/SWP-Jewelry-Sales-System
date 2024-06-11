import React from 'react';
import Avatar2 from '../../../assets/images/xs/avatar2.svg'
import { Dropdown } from 'react-bootstrap';
import { ChatBoxData } from '../../Data/chat/ChatBoxData';

function ChatBox() {
    return (
        <>
            <div className="chat-header d-flex justify-content-between align-items-center border-bottom pb-3">
                <div className="d-flex align-items-center">
                    <a href="/dashboard" title="Home" className="d-block d-xxl-none"><i className="icofont-arrow-left fs-4"></i></a>
                    <a href="#!" title="">
                        <img className="avatar rounded" src={Avatar2} alt="avatar" />
                    </a>
                    <div className="ms-3">
                        <h6 className="mb-0">Grace Smith</h6>
                        <small className="text-muted">Last seen: 3 hours ago</small>
                    </div>
                </div>
                <div className="d-flex">
                    <a className="nav-link py-2 px-3 text-muted d-none d-lg-block" href="#!"><i className="fa fa-camera"></i></a>
                    <a className="nav-link py-2 px-3 text-muted d-none d-lg-block" href="#!"><i className="fa fa-video-camera"></i></a>
                    <a className="nav-link py-2 px-3 text-muted d-none d-lg-block" href="#!"><i className="fa fa-gear"></i></a>
                    <a className="nav-link py-2 px-3 text-muted d-none d-lg-block" href="#!"><i className="fa fa-info-circle"></i></a>
                    <a className="nav-link py-2 px-3 d-block d-lg-none chatlist-toggle" href="#!" onClick={() => {
                        var Tabbox = document.getElementById('tabboxes')
                        if (Tabbox) {
                            if (Tabbox.classList.contains('open')) {
                                Tabbox.classList.remove('open')
                            } else {
                                Tabbox.classList.add('open')
                            }
                        }
                    }}><i className="fa fa-bars"></i></a>
                    <div className="nav-item list-inline-item d-block d-xl-none">
                        <Dropdown>
                            <Dropdown.Toggle as='a' className="nav-link text-muted px-0 pulse" href="#!">
                                <i className="fa fa-ellipsis-v"></i>
                            </Dropdown.Toggle>
                            <Dropdown.Menu>
                                <li><Dropdown.Item href="/"><i className="fa fa-camera"></i> Share Images</Dropdown.Item></li>
                                <li><Dropdown.Item href="/"><i className="fa fa-video-camera"></i> Video Call</Dropdown.Item></li>
                                <li><Dropdown.Item href="/"><i className="fa fa-gear"></i> Settings</Dropdown.Item></li>
                                <li><Dropdown.Item href="/"><i className="fa fa-info-circle"></i> Info</Dropdown.Item></li>
                            </Dropdown.Menu>
                        </Dropdown>
                    </div>
                </div>
            </div>
            <ul className="chat-history list-unstyled mb-0 py-lg-5 py-md-4 py-3 flex-grow-1">
                {
                    ChatBoxData.map((d, i) => {
                        return <li key={'s' + i} className={d.type === 'received' ? "mb-3 d-flex flex-row align-items-end" : "mb-3 d-flex flex-row-reverse align-items-end"}>
                            <div className={`max-width-70 ${d.type === 'received' ? '' : 'text-right'}`}>
                                <div className="user-info mb-1">

                                    {d.type === 'received' ? <img className="avatar sm rounded-circle me-1" src={d.image} alt="avatar" /> : null}
                                    <span className="text-muted small">{d.time}</span>
                                </div>
                                <div className={`card border-0 p-3 ${d.type === 'received' ? '' : 'bg-primary text-light'}`}>
                                    <div className="message">{d.message}</div>
                                </div>
                            </div>
                            <Dropdown>
                                <Dropdown.Toggle as='a' href="#!" className="nav-link py-2 px-3 text-muted pulse" data-bs-toggle="dropdown" aria-expanded="false"><i className="fa fa-ellipsis-v"></i></Dropdown.Toggle>
                                <Dropdown.Menu className="dropdown-menu border-0 shadow">
                                    <li><Dropdown.Item href="#!">Edit</Dropdown.Item></li>
                                    <li><Dropdown.Item href="#!">Share</Dropdown.Item></li>
                                    <li><Dropdown.Item href="#!">Delete</Dropdown.Item></li>
                                </Dropdown.Menu>
                            </Dropdown>
                        </li>
                    })
                }
            </ul>
            <div>
                <textarea className="form-control" placeholder="Enter text here..."></textarea>
            </div>
        </>
    )
}
export default ChatBox;