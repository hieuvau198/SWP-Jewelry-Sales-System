import React from 'react';
import Avatar from '../../../assets/images/lg/avatar4.svg';
import { ProfileBlockData } from '../../Data/CustomerData';

function ProfileBlock() {
    return (
        <div className="card profile-card">
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                <h6 className="mb-0 fw-bold ">Profile</h6>
            </div>
            <div className="card-body d-flex profile-fulldeatil flex-column">
                <div className="profile-block text-center w220 mx-auto">
                    <a href="#!">
                        <img src={Avatar} alt="" className="avatar xl rounded img-thumbnail shadow-sm" />
                    </a>
                    <div className="about-info d-flex align-items-center mt-3 justify-content-center flex-column">
                        <span className="text-muted small">ID : #CS-00002</span>
                    </div>
                </div>
                <div className="profile-info w-100">
                    <h6 className="mb-0 mt-2  fw-bold d-block fs-6 text-center"> Joan Dyer</h6>
                    <span className="py-1 fw-bold small-11 mb-0 mt-1 text-muted text-center mx-auto d-block">24 years, California</span>
                    <p className="mt-2">Duis felis ligula, pharetra at nisl sit amet, ullamcorper fringilla mi. Cras luctus metus non enim porttitor sagittis. Sed tristique scelerisque arcu id dignissim.</p>
                    <div className="row g-2 pt-2">
                        {
                            ProfileBlockData.map((d, i) => {
                                return <div key={'s' + i} className="col-xl-12">
                                    <div className="d-flex align-items-center">
                                        <i className={`${d.icon}`}></i>
                                        <span className="ms-2">{d.detail}</span>
                                    </div>
                                </div>
                            })
                        }
                    </div>
                </div>
            </div>
        </div>
    )
}
export default ProfileBlock;