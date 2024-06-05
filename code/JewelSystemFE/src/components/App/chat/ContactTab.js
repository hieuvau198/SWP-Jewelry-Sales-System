import React from 'react';
import { ContactData } from '../../Data/chat/ContactData';

function ContactTab () {
        return (
            <>
                <ul className="list-unstyled list-group list-group-custom list-group-flush mb-0">
                    {
                        ContactData.map((d, i) => {
                            return <li key={'s'+i} className="list-group-item px-md-4 py-3 py-md-4">
                                <a href="#!" className="d-flex">
                                    <img className="avatar rounded" src={d.image} alt="" />
                                    <div className="flex-fill ms-3 text-truncate">
                                        <div className="d-flex justify-content-between mb-0">
                                            <h6 className="mb-0">{d.name}</h6>
                                            <div className="text-muted">
                                                <i className="fa fa-heart-o pl-2 text-danger active"></i>
                                                <i className="fa fa-trash pl-2 text-danger"></i>
                                            </div>
                                        </div>
                                        <span className="text-muted">{d.message}</span>
                                    </div>
                                </a>
                            </li>
                        })
                    }
                </ul>
            </>
        )
    }

export default ContactTab;