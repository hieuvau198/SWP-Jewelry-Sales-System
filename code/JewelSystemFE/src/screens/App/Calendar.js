import React, { useState } from 'react';
import { Modal } from 'react-bootstrap';
import BigCalendar from '../../components/App/Calendar/BigCalendar';
import PageHeader1 from '../../components/common/PageHeader1';

function Calendar() {
    const [ismodal, setIsmodal] = useState(false);
    return (<div className='body d-flex py-lg-3 py-md-2'>
        <div className='container-xxl'>
            <PageHeader1 pagetitle='Calendar' modalbutton={() => {
                return <div className="col-auto d-flex w-sm-100">
                    <button type="button" onClick={() => { setIsmodal(true) }} className="btn btn-primary btn-set-task w-sm-100"><i className="icofont-plus-circle me-2 fs-6"></i>Add Event</button>
                </div>
            }} />

            <BigCalendar />
        </div>
        <Modal show={ismodal} onHide={() => { setIsmodal(false) }}>
            <Modal.Header className="modal-header" closeButton>
                <h5 className="modal-title  fw-bold" id="eventaddLabel">Add Event</h5>
            </Modal.Header>
            <Modal.Body className="modal-body">
                <div className="mb-3">
                    <label htmlFor="exampleFormControlInput99" className="form-label">Event Name</label>
                    <input type="text" className="form-control" id="exampleFormControlInput99" />
                </div>
                <div className="mb-3">
                    <label htmlFor="formFileMultipleone" className="form-label">Event Images</label>
                    <input className="form-control" type="file" id="formFileMultipleone" />
                </div>
                <div className="deadline-form">
                    <form>
                        <div className="row g-3 mb-3">
                            <div className="col">
                                <label htmlFor="datepickerded" className="form-label">Event Start Date</label>
                                <input type="date" className="form-control w-100" id="datepickerded" />
                            </div>
                            <div className="col">
                                <label htmlFor="datepickerdedone" className="form-label">Event End Date</label>
                                <input type="date" className="form-control w-100" id="datepickerdedone" />
                            </div>
                        </div>
                    </form>
                </div>
                <div className="mb-3">
                    <label htmlFor="exampleFormControlTextarea78" className="form-label">Event Description (optional)</label>
                    <textarea className="form-control" id="exampleFormControlTextarea78" rows="3" placeholder="Add any extra details about the request"></textarea>
                </div>
            </Modal.Body>
            <Modal.Footer className="modal-footer">
                <button type="button" className="btn btn-secondary" onClick={() => { setIsmodal(false) }} data-bs-dismiss="modal">Done</button>
                <button type="button" className="btn btn-primary">Create</button>
            </Modal.Footer>
        </Modal>
    </div>
    )
}
export default Calendar;