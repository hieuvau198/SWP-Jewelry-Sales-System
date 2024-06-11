import React, { useState } from 'react';
import { Modal } from 'react-bootstrap';
import { ContactProfileViewData } from '../../Data/OtherPagesData';

function ContactProfileView() {
    const [ismodal, setIsmodal] = useState(false)

    return (
        <div className="row row-cols-sm-1 row-cols-md-2 row-col-lg-3 row-cols-xl-2 row-cols-xxl-3">
            {
                ContactProfileViewData.map((d, i) => {
                    return <div key={'s' + i} className="col">
                        <div className="card teacher-card mb-3 flex-column">
                            <div className="card-body d-flex teacher-fulldeatil flex-column">
                                <div className="profile-teacher text-center w220 mx-auto">
                                    <a href="#!">
                                        <img src={d.image} alt="" className="avatar xl rounded-circle img-thumbnail shadow-sm" />
                                    </a>
                                    <button onClick={() => { setIsmodal({ ismodal: true }) }} className="btn btn-primary" style={{ position: 'absolute', top: '15px', right: '15px' }}><i className={`${d.icon}`}></i></button>
                                    <div className="about-info d-flex align-items-center mt-3 justify-content-center flex-column">
                                        <span className="text-muted small">{d.id}</span>
                                    </div>
                                </div>
                                <div className="teacher-info   w-100">
                                    <h6 className="mb-0 mt-2  fw-bold d-block fs-6 text-center">{d.title}</h6>
                                    <span className="py-1 fw-bold small-11 mb-0 mt-1 text-muted text-center mx-auto d-block">{d.year}</span>
                                    <div className="row g-2 pt-2">
                                        <div className="col-xl-12">
                                            <div className="d-flex align-items-center">
                                                <i className="icofont-ui-touch-phone"></i>
                                                <span className="ms-2">{d.number} </span>
                                            </div>
                                        </div>
                                        <div className="col-xl-12">
                                            <div className="d-flex align-items-center">
                                                <i className="icofont-email"></i>
                                                <span className="ms-2">{d.mail}</span>
                                            </div>
                                        </div>
                                        <div className="col-xl-12">
                                            <div className="d-flex align-items-center">
                                                <i className="icofont-birthday-cake"></i>
                                                <span className="ms-2">{d.date}</span>
                                            </div>
                                        </div>
                                        <div className="col-xl-12">
                                            <div className="d-flex align-items-center">
                                                <i className="icofont-address-book"></i>
                                                <span className="ms-2">{d.num}</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                })
            }
            <Modal show={ismodal} onHide={() => { setIsmodal(false) }}>

                <Modal.Header className="modal-header" closeButton>
                    <h5 className="modal-title  fw-bold" id="expeditLabel"> Edit Contact</h5>
                </Modal.Header>
                <Modal.Body className="modal-body">
                    <div className="mb-3">
                        <label htmlFor="item1" className="form-label">Person Name</label>
                        <input type="text" className="form-control" id="item1" value="Phil Glover" onChange={() => { }} />
                    </div>
                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label className="form-label">Contact Image</label>
                                    <input type="file" className="form-control" onChange={() => { }} />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="abc1" className="form-label">Birthdate</label>
                                    <input type="date" className="form-control" id="abc1" value="2021-03-12" onChange={() => { }} />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="deptwo1" className="form-label">Email</label>
                                    <input type="email" className="form-control" id="deptwo1" value="PhilGlover@gmail.com" onChange={() => { }} />
                                </div>
                                <div className="col-sm-6">
                                    <label className="form-label">Phone</label>
                                    <input type="text" className="form-control" value="775-555-0117" onChange={() => { }} />
                                </div>
                            </div>
                        </form>
                    </div>
                </Modal.Body>
                <Modal.Footer className="modal-footer">
                    <button type="button" className="btn btn-secondary" onClick={() => { setIsmodal(false) }}>Done</button>
                    <button type="submit" className="btn btn-primary">Save</button>
                </Modal.Footer>
            </Modal>

        </div>
    )

}
export default ContactProfileView