import React, { useState } from 'react';
import { Modal } from 'react-bootstrap';
import DataTable from 'react-data-table-component';
import PageHeader1 from '../../components/common/PageHeader1';
import { supplierData } from '../../components/Data/SupplierData';

function Supplier() {
    const [ismodal, setIsmodal] = useState(false);
    const [table_row, setTable_row] = useState([...supplierData.rows]);
    const [iseditmodal, setIseditmodal] = useState(false);
    const columns = () => {
        return [
            {
                name: " ID",
                selector: (row) => row.id,
                sortable: true,
            },
            {
                name: "ITEMS",
                selector: (row) => row.item,
                sortable: true,

            },
            {
                name: "SUPPLIERS",
                selector: (row) => row.name,
                cell: row => <><img className="avatar rounded lg border" src={row.image} alt="" /> <span className="px-2">{row.name}</span></>,
                sortable: true, minWidth: "250px"
            },
            {
                name: "SUPPLIERS REGDATE",
                selector: (row) => row.date,
                sortable: true
            },
            {
                name: "MAIL",
                selector: (row) => row.mail,
                sortable: true
            },
            {
                name: "PHONE",
                selector: (row) => row.phone,
                sortable: true
            },
            {
                name: "ADDRESS",
                selector: (row) => row.address,
                sortable: true
            },
            {
                name: "TAX_NUM",
                selector: (row) => row.taxnum,
                sortable: true
            },
            {
                name: "ACTION",
                selector: (row) => { },
                sortable: true,
                cell: (row) => <div className="btn-group" role="group" aria-label="Basic outlined example">
                    <button onClick={() => { setIseditmodal(true) }} type="button" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></button>
                    <button type="button" onClick={() => { onDeleteRow(row) }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                </div>
            }

        ]
    }

    async function onDeleteRow(row) {
        //eslint-disable-next-line
        var result = await table_row.filter((d) => { if (d !== row) { return d } });
        
        setTable_row([...result])
    }
    return (
        <div className="body d-flex py-lg-3 py-md-2">
            <div className="container-xxl">
                <PageHeader1 pagetitle='Suppliers Information' modalbutton={() => {
                    return <div className="col-auto d-flex w-sm-100">
                        <button type="button" onClick={() => { setIsmodal(true) }} className="btn btn-primary btn-set-task w-sm-100" data-bs-toggle="modal" data-bs-target="#expadd"><i className="icofont-plus-circle me-2 fs-6"></i>Add Suppliers</button>
                    </div>
                }} />
                <div className="row clearfix g-3">
                    <div className="col-sm-12">
                        <div className="card mb-3">
                            <div className="card-body">
                                <div id="myProjectTable_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer">
                                    <div className="row">
                                        <div className="col-sm-12">
                                            <DataTable
                                                columns={columns()}
                                                data={table_row}
                                                defaultSortField="title"
                                                pagination
                                                selectableRows={false}
                                                className="table myDataTable table-hover align-middle mb-0 d-row nowrap dataTable no-footer dtr-inline"
                                                highlightOnHover={true}
                                            />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <Modal show={ismodal} onHide={() => { setIsmodal(false) }} style={{ display: 'block' }} >
                <Modal.Header className="modal-header" closeButton>
                    <Modal.Title className="modal-title  fw-bold" id="expaddLabel">Add Suppliers</Modal.Title>
                </Modal.Header>
                <Modal.Body className="modal-body">
                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="item" className="form-label">Item</label>
                                    <input type="text" className="form-control" id="item" />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="taxtno" className="form-label">Tax No</label>
                                    <input type="text" className="form-control" id="taxtno" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="depone" className="form-label">Suppliers</label>
                                    <input type="text" className="form-control" id="depone" />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="abc" className="form-label">Suppliers Register date</label>
                                    <input type="date" className="form-control w-100" id="abc" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="abc11" className="form-label">Mail</label>
                                    <input type="text" className="form-control" id="abc11" />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="abc111" className="form-label">Phone</label>
                                    <input type="text" className="form-control" id="abc111" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-12">
                                    <label className="form-label">Address</label>
                                    <textarea className="form-control" rows="3"></textarea>
                                </div>
                            </div>
                        </form>
                    </div>
                </Modal.Body>
                <div className="modal-footer">
                    <button type="button" className="btn btn-secondary" onClick={() => { setIsmodal(false) }} data-bs-dismiss="modal">Done</button>
                    <button type="submit" className="btn btn-primary">Add</button>
                </div>
            </Modal>
            <Modal className="modal fade show" id="expedit" show={iseditmodal} onHide={() => { setIseditmodal(false) }} style={{ display: 'block' }}>

                <Modal.Header className="modal-header" closeButton>
                    <h5 className="modal-title  fw-bold" id="expeditLabel"> Edit Suppliers</h5>
                </Modal.Header>
                <Modal.Body className="modal-body">

                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="item1" className="form-label">Item</label>
                                    <input type="text" className="form-control" id="item1" value="Cloth" onChange={() => { }} />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="taxtno1" className="form-label">Tax No</label>
                                    <input type="text" className="form-control" id="taxtno1" value="5869" onChange={() => { }} />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label className="form-label">Suppliers</label>
                                    <select className="form-select">
                                        <option >Joan Dyer</option>
                                        <option value="1">Ryan Randall</option>
                                        <option value="2">Phil Glover</option>
                                        <option value="3">Victor Rampling</option>
                                        <option value="4">Sally Graham</option>
                                    </select>
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="abc1" className="form-label">Suppliers Register date</label>
                                    <input type="date" className="form-control w-100" id="abc1" value="2021-03-12" onChange={() => { }} />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="mailid" className="form-label">Mail</label>
                                    <input type="text" className="form-control" id="mailid" value="PhilGlover@gmail.com" onChange={() => { }} />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="phoneid" className="form-label">Phone</label>
                                    <input type="text" className="form-control" id="phoneid" value="843-555-0175" onChange={() => { }} />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-12">
                                    <label className="form-label">Address</label>
                                    <textarea className="form-control" rows="3" value='' onChange={() => { }}>4 Shirley Ave. West Chicago, IL 60185</textarea>
                                </div>
                            </div>
                        </form>
                    </div>

                </Modal.Body>
                <Modal.Footer className="modal-footer">
                    <button type="button" className="btn btn-secondary" onClick={() => { setIseditmodal(false) }} data-bs-dismiss="modal">Done</button>
                    <button type="submit" className="btn btn-primary">Save</button>
                </Modal.Footer>
            </Modal>
        </div>
    )
}
export default Supplier