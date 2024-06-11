import React, { useState } from 'react';
import { ProfileData } from '../../Data/OtherPagesData';
import Avatar4 from '../../../assets/images/lg/avatar4.svg'
import { Modal } from 'react-bootstrap';

function Profile() {
    const [ismodal, setIsmodal] = useState(false)
    return (
        <div className="card profile-card flex-column mb-3">
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                <h6 className="mb-0 fw-bold ">Profile</h6>
            </div>
            <div className="card-body d-flex profile-fulldeatil flex-column">
                <div className="profile-block text-center w220 mx-auto">
                    <a href="#!">
                        <img src={Avatar4} alt="" className="avatar xl rounded img-thumbnail shadow-sm" />
                    </a>
                    <button className="btn btn-primary" onClick={() => { setIsmodal(true) }} style={{ position: 'absolute', top: '15px', right: '15px' }}><i className="icofont-edit"></i></button>
                    <div className="about-info d-flex align-items-center mt-3 justify-content-center flex-column">
                        <span className="text-muted small">Admin ID : PXL-0001</span>
                    </div>
                </div>
                <div className="profile-info w-100">
                    <h6 className="mb-0 mt-2  fw-bold d-block fs-6 text-center">Adrian	Allan</h6>
                    <span className="py-1 fw-bold small-11 mb-0 mt-1 text-muted text-center mx-auto d-block">24 years, California</span>
                    <p className="mt-2">Duis felis ligula, pharetra at nisl sit amet, ullamcorper fringilla mi. Cras luctus metus non enim porttitor sagittis. Sed tristique scelerisque arcu id dignissim.</p>
                    <div className="row g-2 pt-2">
                        {
                            ProfileData.map((d, i) => {
                                return <div key={'s' + i} className="col-xl-12">
                                    <div className="d-flex align-items-center">
                                        <i className={`${d.icon}`}></i>
                                        <span className="ms-2">{d.detail} </span>
                                    </div>
                                </div>
                            })
                        }
                    </div>
                </div>
            </div>
            <Modal show={ismodal} onHide={() => { setIsmodal(false) }} style={{ display: 'block' }}>
                <div className="modal-content">
                    <Modal.Header className="modal-header" closeButton>
                        <h5 className="modal-title  fw-bold" id="expeditLabel1111"> Edit Profile</h5>
                    </Modal.Header>
                    <Modal.Body className="modal-body">

                        <div className="deadline-form">
                            <form>
                                <div className="row g-3 mb-3">
                                    <div className="col-sm-12">
                                        <label htmlFor="item100" className="form-label">Name</label>
                                        <input type="text" className="form-control" id="item100" value="Adrian Allan" onChange={() => { }} />
                                    </div>
                                    <div className="col-sm-12">
                                        <label htmlFor="taxtno200" className="form-label">Profile</label>
                                        <input type="file" className="form-control" id="taxtno200" onChange={() => { }} />
                                    </div>
                                </div>
                                <div className="row g-3 mb-3">
                                    <div className="col-sm-12">
                                        <label className="form-label">Details</label>
                                        <textarea className="form-control" rows="3" value="Duis felis ligula, pharetra at nisl sit amet, ullamcorper fringilla mi. Cras luctus metus non enim porttitor sagittis. Sed tristique scelerisque arcu id dignissim. Aenean sed erat ut est commodo tristique ac a metus. Praesent efficitur congue orci. Fusce in mi condimentum mauris maximus sodales. Quisque dictum est augue, vitae cursus quam finibus in. Nulla at tempus enim. Fusce sed mi et nibh laoreet consectetur nec vitae lacus." onChange={() => { }} />
                                    </div>
                                </div>
                                <div className="row g-3 mb-3">
                                    <div className="col-sm-6">
                                        <label className="form-label">Country</label>
                                        <input type="text" className="form-control" value="California" onChange={() => { }} />
                                    </div>
                                    <div className="col-sm-6">
                                        <label htmlFor="abc1" className="form-label">Birthday date</label>
                                        <input type="date" className="form-control w-100" id="abc1" value="1980-03-19" onChange={() => { }} />
                                    </div>
                                </div>
                                <div className="row g-3 mb-3">
                                    <div className="col-sm-6">
                                        <label htmlFor="mailid" className="form-label">Mail</label>
                                        <input type="text" className="form-control" id="mailid" value="adrianallan@gmail.com" onChange={() => { }} />
                                    </div>
                                    <div className="col-sm-6">
                                        <label htmlFor="phoneid" className="form-label">Phone</label>
                                        <input type="text" className="form-control" id="phoneid" value="202-555-0174" onChange={() => { }} />
                                    </div>
                                </div>
                                <div className="row g-3 mb-3">
                                    <div className="col-sm-12">
                                        <label className="form-label">Address</label>
                                        <textarea className="form-control" rows="3" value="2734 West Fork Street,EASTON 02334." onChange={() => { }} />
                                    </div>
                                </div>
                            </form>
                        </div>

                    </Modal.Body>
                    <div className="modal-footer" onClick={() => { setIsmodal(false) }}>
                        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Done</button>
                        <button type="submit" className="btn btn-primary">Save</button>
                    </div>
                </div>
            </Modal>
        </div>
    )
}

export default Profile;