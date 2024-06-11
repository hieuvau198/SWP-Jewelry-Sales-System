import React from 'react';
import { Modal } from 'react-bootstrap';

function Returnmodal(props) {

    const { onclose, show } = props
    return (
        <Modal show={show} onHide={onclose} className="modal fade show" id="expedit" tabIndex="-1" style={{ display: 'block' }} aria-modal="true" role="dialog">

            <Modal.Header className="modal-header" closeButton>
                <h5 className="modal-title  fw-bold" id="expeditLabel"> Edit Return Item</h5>
            </Modal.Header>
            <Modal.Body className="modal-body">
                <div className="mb-3">
                    <label htmlFor="item1" className="form-label">Item</label>
                    <input type="text" className="form-control" id="item1" placeholder="Cloth" />
                </div>
                <div className="deadline-form">
                    <form>
                        <div className="row g-3 mb-3">
                            <div className="col-sm-6">
                                <label className="form-label">Customer</label>
                                <select className="form-select">
                                    <option >Joan Dyer</option>
                                    <option value="1">Ryan Randall</option>
                                    <option value="2">Phil Glover</option>
                                    <option value="3">Victor Rampling</option>
                                    <option value="4">Sally Graham</option>
                                </select>
                            </div>
                            <div className="col-sm-6">
                                <label htmlFor="abc1" className="form-label">Return Date</label>
                                <input type="date" className="form-control w-100" id="abc1" placeholder="2021-03-12" />
                            </div>
                        </div>
                        <div className="row g-3 mb-3">
                            <div className="col-sm-12">
                                <label htmlFor="abc11edit" className="form-label">Total</label>
                                <input type="text" className="form-control" id="abc11edit" placeholder="$1551" />
                            </div>
                        </div>
                    </form>
                </div>

            </Modal.Body>
            <Modal.Footer className="modal-footer">
                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Done</button>
                <button type="submit" className="btn btn-primary">Save</button>
            </Modal.Footer>
        </Modal>
    )
}
export default Returnmodal;