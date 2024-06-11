import React, { useState } from 'react';
import { Modal } from 'react-bootstrap';
import PageHeader1 from '../../components/common/PageHeader1';
import Avatar1 from '../../assets/images/xs/avatar1.svg';
import Avatar2 from '../../assets/images/xs/avatar2.svg';
import Avatar3 from '../../assets/images/xs/avatar3.svg';
import Avatar4 from '../../assets/images/xs/avatar4.svg';

function Departments() {
    const [ismodal, setIsmodal] = useState(false);
    const [ismodaledit, setIsmodaledit] = useState(false);

    const deletbutton1 = () => {
        const Row1 = document.getElementById('row1')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
    const deletbutton2 = () => {
        const Row1 = document.getElementById('row2')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
    const deletbutton3 = () => {
        const Row1 = document.getElementById('row3')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
    const deletbutton4 = () => {
        const Row1 = document.getElementById('row4')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
    const deletbutton5 = () => {
        const Row1 = document.getElementById('row5')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
    const deletbutton6 = () => {
        const Row1 = document.getElementById('row6')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
    return (
        <div className="body d-flex py-lg-3 py-md-2">
            <div className="container-xxl">
                <PageHeader1 pagetitle='Departments' modalbutton={() => {
                    return <div className="col-auto d-flex w-sm-100">
                        <button type="button" onClick={() => { setIsmodal( true ) }} className="btn btn-primary btn-set-task w-sm-100" data-bs-toggle="modal" data-bs-target="#expadd"><i className="icofont-plus-circle me-2 fs-6"></i>Add Departments</button>
                    </div>
                }} />

                <div className="row clearfix g-3">
                    <div className="col-sm-12">
                        <div className="card mb-3">
                            <div className="card-body">
                                <div id="myProjectTable_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer">
                                    <div className="row">
                                        <div className="col-sm-12">
                                            <div className='table-responsive'>
                                                <table id="myProjectTable" className="table table-hover align-middle mb-0 nowrap dataTable no-footer dtr-inline collapsed" style={{ width: '100%' }} role="grid" aria-describedby="myProjectTable_info">
                                                    <thead>
                                                        <tr role="row">
                                                            <th className="sorting_asc" tabIndex="0" aria-controls="myProjectTable" rowSpan="1" colSpan="1" style={{ width: '8.2px' }} aria-label="#: activate to sort column descending" aria-sort="ascending">#</th>
                                                            <th className="sorting" tabIndex="0" aria-controls="myProjectTable" rowSpan="1" colSpan="1" style={{ width: '142.2px' }} aria-label="Department Head: activate to sort column ascending">Department Head</th>
                                                            <th className="dt-body-right sorting" tabIndex="0" aria-controls="myProjectTable" rowSpan="1" colSpan="1" style={{ width: '138.2px' }} aria-label="Department Name: activate to sort column ascending">Department Name</th>
                                                            <th className="sorting" tabIndex="0" aria-controls="myProjectTable" rowSpan="1" colSpan="1" style={{ width: '118.2px' }} aria-label="Staff UnderWork: activate to sort column ascending">Staff UnderWork</th>
                                                            <th className="dt-body-right sorting" tabIndex="0" aria-controls="myProjectTable" rowSpan="1" colSpan="1" style={{ width: '62.2px' }} aria-label="Actions: activate to sort column ascending">Actions</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr id='row1' role="row" className="odd">
                                                            <td tabIndex="0" className="sorting_1">
                                                                <span className="">1</span>
                                                            </td>
                                                            <td>
                                                                <img className="avatar rounded lg border" src={Avatar1} alt="" />
                                                                <span className="mx-1">Joan Dyer</span>
                                                            </td>
                                                            <td className=" dt-body-right">
                                                                Logistics
                                                            </td>
                                                            <td>
                                                                40
                                                            </td>
                                                            <td className=" dt-body-right" >
                                                                <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                    <button type="button" onClick={() => {setIsmodaledit(true ) }} className="btn btn-outline-secondary" data-bs-toggle="modal" data-bs-target="#depedit"><i className="icofont-edit text-success"></i></button>
                                                                    <button type="button" onClick={() => { deletbutton1() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id='row2' role="row" className="odd">
                                                            <td tabIndex="0" className="sorting_1">
                                                                <span className="">2</span>
                                                            </td>
                                                            <td>
                                                                <img className="avatar rounded lg border" src={Avatar2} alt="" />
                                                                <span className="mx-1">Ryan	Randall</span>
                                                            </td>
                                                            <td className=" dt-body-right">
                                                                Digital Marketing
                                                            </td>
                                                            <td>
                                                                48
                                                            </td>
                                                            <td className=" dt-body-right" >
                                                                <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                    <button type="button" onClick={() => { setIsmodaledit( true ) }} className="btn btn-outline-secondary" data-bs-toggle="modal" data-bs-target="#depedit"><i className="icofont-edit text-success"></i></button>
                                                                    <button type="button" onClick={() => { deletbutton2() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id='row3' role="row" className="even">
                                                            <td tabIndex="0" className="sorting_1">
                                                                <span className="">3</span>
                                                            </td>
                                                            <td>
                                                                <img className="avatar rounded lg border" src={Avatar3} alt="" />
                                                                <span className="mx-1">Phil	Glover</span>
                                                            </td>
                                                            <td className=" dt-body-right">
                                                                Customer Service
                                                            </td>
                                                            <td>
                                                                15
                                                            </td>
                                                            <td className=" dt-body-right" >
                                                                <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                    <button type="button" onClick={() => { setIsmodaledit(true ) }} className="btn btn-outline-secondary" data-bs-toggle="modal" data-bs-target="#depedit"><i className="icofont-edit text-success"></i></button>
                                                                    <button type="button" onClick={() => {deletbutton3() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id='row4' role="row" className="odd">
                                                            <td tabIndex="0" className="sorting_1">
                                                                <span className="">4</span>
                                                            </td>
                                                            <td>
                                                                <img className="avatar rounded lg border" src={Avatar4} alt="" />
                                                                <span className="mx-1">Victor Rampling</span>
                                                            </td>
                                                            <td className=" dt-body-right">
                                                                Inventory Associates
                                                            </td>
                                                            <td>
                                                                39
                                                            </td>
                                                            <td className=" dt-body-right" >
                                                                <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                    <button type="button" onClick={() => {setIsmodaledit(true ) }} className="btn btn-outline-secondary" data-bs-toggle="modal" data-bs-target="#depedit"><i className="icofont-edit text-success"></i></button>
                                                                    <button type="button" onClick={() => {deletbutton4() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id='row5' role="row" className="even">
                                                            <td tabIndex="0" className="sorting_1">
                                                                <span className="">5</span>
                                                            </td>
                                                            <td>
                                                                <img className="avatar rounded lg border" src={Avatar1} alt="" />
                                                                <span className="mx-1">Sally Graham</span>
                                                            </td>
                                                            <td className=" dt-body-right">
                                                                Finance and Accounting
                                                            </td>
                                                            <td>
                                                                12
                                                            </td>
                                                            <td className=" dt-body-right" >
                                                                <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                    <button type="button" onClick={() => { setIsmodaledit( true ) }} className="btn btn-outline-secondary" data-bs-toggle="modal" data-bs-target="#depedit"><i className="icofont-edit text-success"></i></button>
                                                                    <button type="button" onClick={() => { deletbutton5() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id='row6' role="row" className="odd">
                                                            <td tabIndex="0" className="sorting_1">
                                                                <span className="">6</span>
                                                            </td>
                                                            <td>
                                                                <img className="avatar rounded lg border" src={Avatar2} alt="" />
                                                                <span className="mx-1">Robert Anderson</span>
                                                            </td>
                                                            <td className=" dt-body-right">
                                                                Business Analyst
                                                            </td>
                                                            <td>
                                                                8
                                                            </td>
                                                            <td className=" dt-body-right" >
                                                                <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                    <button type="button" onClick={() => { setIsmodaledit(true ) }} className="btn btn-outline-secondary" data-bs-toggle="modal" data-bs-target="#depedit"><i className="icofont-edit text-success"></i></button>
                                                                    <button type="button" onClick={() => { deletbutton6() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <Modal show={ismodal} onHide={() => { setIsmodal( false ) }} style={{ display: 'block' }} >
                <Modal.Header className="modal-header" closeButton>
                    <h5 className="modal-title  fw-bold" id="depaddLabel"> Add Department </h5>
                </Modal.Header>
                <Modal.Body className="modal-body">
                    <div className="mb-3">
                        <label htmlFor="exampleFormControlInput1111" className="form-label">Department Name</label>
                        <input type="text" className="form-control" id="exampleFormControlInput1111" />
                    </div>
                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="depone" className="form-label">Department Head</label>
                                    <input type="text" className="form-control" id="depone" />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="deptwo" className="form-label">Staff UnderWork</label>
                                    <input type="text" className="form-control" id="deptwo" />
                                </div>
                            </div>
                        </form>
                    </div>
                </Modal.Body>
                <Modal.Footer className="modal-footer" onClick={() => { setIsmodal(false ) }}>
                    <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Done</button>
                    <button type="submit" className="btn btn-primary">Add</button>
                </Modal.Footer>
            </Modal>

            <Modal show={ismodaledit} onHide={() => {setIsmodaledit( false ) }} className="modal fade" id="depedit" tabIndex="-1" aria-modal="true" role="dialog">

                <Modal.Header className="modal-header" closeButton>
                    <h5 className="modal-title  fw-bold" id="depeditLabel"> Edit Department </h5>
                </Modal.Header>
                <Modal.Body className="modal-body">
                    <div className="mb-3">
                        <label htmlFor="exampleFormControlInput11111" className="form-label">Department Name</label>
                        <input type="text" className="form-control" id="exampleFormControlInput11111" value="Logistics" onChange={() => { }} />
                    </div>
                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label className="form-label">Department Head</label>
                                    <select className="form-select">
                                        <option >Joan Dyer</option>
                                        <option value="1">Ryan Randall</option>
                                        <option value="2">Phil Glover</option>
                                        <option value="3">Victor Rampling</option>
                                        <option value="4">Sally Graham</option>
                                    </select>
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="deptwo48" className="form-label">Staff UnderWork</label>
                                    <input type="text" className="form-control" id="deptwo48" value="40" onChange={() => { }} />
                                </div>
                            </div>
                        </form>
                    </div>
                </Modal.Body>
                <Modal.Footer className="modal-footer">
                    <button type="button" onClick={() => {setIsmodaledit(false ) }} className="btn btn-secondary" data-bs-dismiss="modal">Done</button>
                    <button type="submit" className="btn btn-primary">Save</button>
                </Modal.Footer>
            </Modal>
        </div>
    )
}
export default Departments;