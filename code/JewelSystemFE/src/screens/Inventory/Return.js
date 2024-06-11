import React, { useState } from 'react';
import { Modal } from 'react-bootstrap';
import PageHeader1 from '../../components/common/PageHeader1';
import Avatar1 from '../../assets/images/xs/avatar1.svg';
import Avatar2 from '../../assets/images/xs/avatar2.svg';
import Avatar3 from '../../assets/images/xs/avatar3.svg';
import Avatar4 from '../../assets/images/xs/avatar4.svg';

function Return(){
    const[ismodal,setIsmodal]=useState(false);
    const[iseditmodal,setIseditmodal]=useState(false);

   const deletbutton1=()=>{
        const Row1 = document.getElementById('row1')
        if (Row1) {
            Row1.setAttribute("style", "display:none"); 
        }
    }
   const deletbutton2=()=>{
        const Row1 = document.getElementById('row2')
        if (Row1) {
            Row1.setAttribute("style", "display:none"); 
        }
    }
   const deletbutton3=()=>{
        const Row1 = document.getElementById('row3')
        if (Row1) {
            Row1.setAttribute("style", "display:none"); 
        }
    }
  const deletbutton4=()=>{
        const Row1 = document.getElementById('row4')
        if (Row1) {
            Row1.setAttribute("style", "display:none"); 
        }
    }
   const deletbutton5=()=>{
        const Row1 = document.getElementById('row5')
        if (Row1) {
            Row1.setAttribute("style", "display:none"); 
        }
    }
        return (
            <div className="body d-flex py-lg-3 py-md-2">
                <div className="container-xxl">
                    <PageHeader1 pagetitle='Returns Items' modalbutton={() => {
                        return <div className="col-auto d-flex w-sm-100">
                            <button type="button" onClick={() => {setIsmodal(true) }} className="btn btn-primary btn-set-task w-sm-100" data-bs-toggle="modal" data-bs-target="#expadd"><i className="icofont-plus-circle me-2 fs-6"></i>Add Return Items</button>
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
                                                                <th className="sorting_asc" tabIndex="0" aria-controls="myProjectTable" rowSpan="1" colSpan="1" style={{ width: '54.2px' }} aria-label="Id: activate to sort column descending" aria-sort="ascending">Id</th>
                                                                <th className="sorting" tabIndex="0" aria-controls="myProjectTable" rowSpan="1" colSpan="1" style={{ width: '55.2px' }} aria-label="Items: activate to sort column ascending">Items</th>
                                                                <th className="sorting" tabIndex="0" aria-controls="myProjectTable" rowSpan="1" colSpan="1" style={{ width: '142.2px' }} aria-label="Customer: activate to sort column ascending">Customer</th>
                                                                <th className="dt-body-right sorting" tabIndex="0" aria-controls="myProjectTable" rowSpan="1" colSpan="1" style={{ width: '83.2px' }} aria-label="Return Date: activate to sort column ascending">Return Date</th>
                                                                <th className="sorting" tabIndex="0" aria-controls="myProjectTable" rowSpan="1" colSpan="1" style={{ width: '39.2px' }} aria-label="Total: activate to sort column ascending">Total</th>
                                                                <th className="dt-body-right sorting" tabIndex="0" aria-controls="myProjectTable" rowSpan="1" colSpan="1" style={{ width: '62.2px' }} aria-label="Actions: activate to sort column ascending">Actions</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr id='row1' role="row" className="removerow">
                                                                <td tabIndex="0" className="sorting_1">#RT-00004</td>
                                                                <td>Cycle</td>
                                                                <td>
                                                                    <img className="avatar rounded lg border" src={Avatar1} alt="" />
                                                                    <span className="mx-1">Phil	Glover</span>
                                                                </td>
                                                                <td className=" dt-body-right">
                                                                    16/03/2021
                                                                </td>
                                                                <td>$1551</td>
                                                                <td className=" dt-body-right" >
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <button type="button" className="btn btn-outline-secondary" onClick={() => {setIseditmodal( true ) }} data-bs-toggle="modal" data-bs-target="#expedit"><i className="icofont-edit text-success"></i></button>
                                                                        <button type="button" onClick={() => {deletbutton1() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id='row2' role="row" className="even">
                                                                <td tabIndex="0" className="sorting_1">#RT-00006</td>
                                                                <td>Shoes</td>
                                                                <td>
                                                                    <img className="avatar rounded lg border" src={Avatar2} alt="" />
                                                                    <span className="mx-1">Ryan	Randall</span>
                                                                </td>
                                                                <td className=" dt-body-right">
                                                                    12/03/2021
                                                                </td>
                                                                <td>$1551</td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <button type="button" onClick={() => {setIseditmodal( true ) }} className="btn btn-outline-secondary"  data-bs-toggle="modal" data-bs-target="#expedit"><i className="icofont-edit text-success"></i></button>
                                                                        <button type="button" onClick={() => { deletbutton2() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id='row3' role="row" className="odd">
                                                                <td tabIndex="0" className="sorting_1">#RT-00011</td>
                                                                <td>Oil</td>
                                                                <td>
                                                                    <img className="avatar rounded lg border" src={Avatar3} alt="" />
                                                                    <span className="mx-1">Victor Rampling</span>
                                                                </td>
                                                                <td className=" dt-body-right">
                                                                    25/02/2021
                                                                </td>
                                                                <td>$1551</td>
                                                                <td className=" dt-body-right" >
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <button type="button" onClick={() => { setIseditmodal( true ) }} className="btn btn-outline-secondary" data-bs-toggle="modal" data-bs-target="#expedit"><i className="icofont-edit text-success"></i></button>
                                                                        <button type="button" onClick={() => { deletbutton3() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id='row4' role="row" className="even">
                                                                <td tabIndex="0" className="sorting_1">#RT-00014</td>
                                                                <td>Sunglasses</td>
                                                                <td>
                                                                    <img className="avatar rounded lg border" src={Avatar4} alt="" />
                                                                    <span className="mx-1">Robert Anderson</span>
                                                                </td>
                                                                <td className=" dt-body-right">
                                                                    18/01/2021
                                                                </td>
                                                                <td>$1551</td>
                                                                <td className=" dt-body-right" >
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <button type="button" onClick={() => { setIseditmodal( true ) }} className="btn btn-outline-secondary" data-bs-toggle="modal" data-bs-target="#expedit"><i className="icofont-edit text-success"></i></button>
                                                                        <button type="button" onClick={() => { deletbutton4() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id='row5' role="row" className="odd">
                                                                <td tabIndex="0" className="sorting_1">#RT-00018</td>
                                                                <td>Watch</td>
                                                                <td>
                                                                    <img className="avatar rounded lg border" src={Avatar1} alt="" />
                                                                    <span className="mx-1">Sally Graham</span>
                                                                </td>
                                                                <td className=" dt-body-right">
                                                                    16/02/2021
                                                                </td>
                                                                <td>$1551</td>
                                                                <td className=" dt-body-right" >
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <button type="button" onClick={() => {setIseditmodal( true ) }} className="btn btn-outline-secondary" data-bs-toggle="modal" data-bs-target="#expedit"><i className="icofont-edit text-success"></i></button>
                                                                        <button type="button" onClick={() => { deletbutton5() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
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
                <Modal show={ismodal} onHide={() => { setIsmodal( false) }} style={{ display: 'block' }} >
                    <Modal.Header className="modal-header" closeButton>
                        <h5 className="modal-title  fw-bold" id="expaddLabel"> Add Return Item</h5>
                    </Modal.Header>
                    <Modal.Body className="modal-body">
                        <div className="mb-3">
                            <label htmlFor="item" className="form-label">Item</label>
                            <input type="text" className="form-control" id="item" />
                        </div>
                        <div className="deadline-form">
                            <form>
                                <div className="row g-3 mb-3">
                                    <div className="col-sm-6">
                                        <label htmlFor="depone" className="form-label">Customer</label>
                                        <input type="text" className="form-control" id="depone" />
                                    </div>
                                    <div className="col-sm-6">
                                        <label htmlFor="abc" className="form-label">Return Date</label>
                                        <input type="date" className="form-control w-100" id="abc" />
                                    </div>
                                </div>
                                <div className="row g-3 mb-3">
                                    <div className="col-sm-12">
                                        <label htmlFor="abc11" className="form-label">Total</label>
                                        <input type="text" className="form-control" id="abc11" />
                                    </div>
                                </div>

                            </form>
                        </div>
                    </Modal.Body>
                    <Modal.Footer className="modal-footer">
                        <button type="button" className="btn btn-secondary" onClick={() => { setIsmodal( false) }} data-bs-dismiss="modal">Done</button>
                        <button type="submit" className="btn btn-primary">Add</button>
                    </Modal.Footer>
                </Modal>
                <Modal className="modal fade " id="expedit" show={iseditmodal} onHide={() => { setIseditmodal( false ) }} tabIndex="-1" style={{ display: 'block' }} aria-modal="true" role="dialog">

                    <Modal.Header className="modal-header" closeButton>
                        <h5 className="modal-title  fw-bold" id="expeditLabel"> Edit Return Item</h5>
                    </Modal.Header>
                    <Modal.Body className="modal-body">
                        <div className="mb-3">
                            <label htmlFor="item1" className="form-label">Item</label>
                            <input type="text" className="form-control" id="item1" value="Cycle" onChange={()=>{}} />
                        </div>
                        <div className="deadline-form">
                            <form>
                                <div className="row g-3 mb-3">
                                    <div className="col-sm-6">
                                        <label className="form-label">Customer</label>
                                        <select className="form-select">
                                            <option>Phil Glover</option>
                                            <option value="1">Ryan Randall</option>
                                            <option value="2">Joan Dyer</option>
                                            <option value="3">Victor Rampling</option>
                                            <option value="4">Sally Graham</option>
                                        </select>
                                    </div>
                                    <div className="col-sm-6">
                                        <label htmlFor="abc1" className="form-label">Return Date</label>
                                        <input type="date" className="form-control w-100" id="abc1" value="2021-03-16" onChange={()=>{}}/>
                                    </div>
                                </div>
                                <div className="row g-3 mb-3">
                                    <div className="col-sm-12">
                                        <label htmlFor="abc11edit" className="form-label">Total</label>
                                        <input type="text" className="form-control" id="abc11edit" value="$1551" onChange={()=>{}}/>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </Modal.Body>
                    <Modal.Footer className="modal-footer">
                        <button type="button" className="btn btn-secondary" onClick={() => { setIseditmodal( false ) }} data-bs-dismiss="modal">Done</button>
                        <button type="submit" className="btn btn-primary">Save</button>
                    </Modal.Footer>

                </Modal>
            </div>
        )
    }
export default Return;