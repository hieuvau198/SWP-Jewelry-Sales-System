import React, { useState } from 'react';
import { Modal } from 'react-bootstrap';
import DataTable from 'react-data-table-component';
import PageHeader1 from '../../components/common/PageHeader1';
import { PurchaseData } from '../../components/Data/PurchaseData';

function Purchase() {
    const [ismodal, setIsmodal] = useState(false);
    const [table_row, setTable_row] = useState([...PurchaseData.rows]);
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
                name: "PURCHASE STATUS",
                selector: (row) => row.status,
                sortable: true,
                cell: row => <span className='badge bg-success'>{row.status}</span>
            },
            {
                name: "ORDER BY",
                selector: (row) => row.name,
                cell: row => <><img className="avatar rounded lg border" src={row.image} alt="" /> <span className="px-2">{row.name}</span></>,
                sortable: true, minWidth: "250px"
            },
            {
                name: "DATE",
                selector: (row) => row.date,
                sortable: true
            },
            {
                name: "SUPPLIER",
                selector: (row) => row.supplier,
                sortable: true
            },
            {
                name: "TOTAL",
                selector: (row) => row.total,
                sortable: true
            },
            {
                name: "PAID",
                selector: (row) => row.paid,
                sortable: true
            },
            {
                name: "BALANCE",
                selector: (row) => row.balance,
                sortable: true
            },
            {
                name: "CREDIT",
                selector: (row) => row.credit,
                sortable: true
            },
            {
                name: "Payment Status",
                selector: (row) => row.paymentstatus,
                sortable: true,
                cell: row => <span className={`badge ${row.paymentstatus === "pending" ? "bg-warning" : 'bg-success'}`}>{row.paymentstatus}</span>
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
        // eslint-disable-next-line
        var result = await table_row.filter((d) => {  if (d !== row) { return d } });
        setTable_row([...result])
    }
    return (
        <div className="body d-flex py-lg-3 py-md-2">
            <div className="container-xxl">
                <PageHeader1 pagetitle='Purchase Items' modalbutton={() => {
                    return <div className="col-auto d-flex w-sm-100">
                        <button type="button" onClick={() => { setIsmodal(true) }} className="btn btn-primary btn-set-task w-sm-100" data-bs-toggle="modal" data-bs-target="#expadd"><i className="icofont-plus-circle me-2 fs-6"></i>Add Purchase Items</button>
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
            <Modal show={ismodal} onHide={() => { setIsmodal(false) }} style={{ display: 'block' }}>
                <Modal.Header className="modal-header" closeButton>
                    <Modal.Title className="modal-title  fw-bold" id="expaddLabel" > Add Purchase</Modal.Title>
                </Modal.Header>
                <Modal.Body className="modal-body" >
                    <div className="mb-3">
                        <label htmlhtmlFor="item" className="form-label">Item</label>
                        <input type="text" className="form-control" id="item" />
                    </div>
                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="depone" className="form-label">Order By</label>
                                    <input type="text" className="form-control" id="depone" />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="abc" className="form-label">Date</label>
                                    <input type="date" className="form-control w-100" id="abc" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="depone11" className="form-label">Credit</label>
                                    <input type="text" className="form-control" id="depone11" />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="abc11" className="form-label">Total</label>
                                    <input type="text" className="form-control" id="abc11" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="depone22" className="form-label">Paid</label>
                                    <input type="text" className="form-control" id="depone22" />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="abc22" className="form-label">Balance</label>
                                    <input type="text" className="form-control" id="abc22" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="deptwo" className="form-label">Supplier</label>
                                    <input type="text" className="form-control" id="deptwo" />
                                </div>
                                <div className="col-sm-6">
                                    <label className="form-label">Payment Status</label>
                                    <select className="form-select">
                                        <option >Pending</option>
                                        <option value="1">Completed</option>
                                        <option value="2">Wating</option>
                                        <option value="3">Decline</option>
                                    </select>
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-12">
                                    <label className="form-label">Purchase Status</label>
                                    <select className="form-select">
                                        <option >Item Recived</option>
                                        <option value="1">Not Recived</option>
                                    </select>
                                </div>
                            </div>
                        </form>
                    </div>
                </Modal.Body>
                <Modal.Footer className="modal-footer">
                    <button type="button" className="btn btn-secondary" onClick={() => { setIsmodal(false) }} data-bs-dismiss="modal">Done</button>
                    <button type="submit" className="btn btn-primary">Add</button>
                </Modal.Footer>
            </Modal>
            <Modal show={iseditmodal} onHide={() => { setIseditmodal(false) }} className="modal fade show" style={{ display: 'block' }}>

                <Modal.Header className="modal-header" closeButton>
                    <h5 className="modal-title  fw-bold" id="expeditLabel"> Edit Purchase</h5>
                </Modal.Header>
                <Modal.Body className="modal-body">
                    <div className="mb-3">
                        <label htmlFor="item1" className="form-label">Item</label>
                        <input type="text" className="form-control" id="item1" value="Cloth" onChange={() => { }} />
                    </div>
                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label className="form-label">Order By</label>
                                    <select className="form-select">
                                        <option >Joan Dyer</option>
                                        <option value="1">Ryan Randall</option>
                                        <option value="2">Phil Glover</option>
                                        <option value="3">Victor Rampling</option>
                                        <option value="4">Sally Graham</option>
                                    </select>
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="abc1" className="form-label">Date</label>
                                    <input type="date" className="form-control w-100" id="abc1" value="2021-03-12" onChange={() => { }} />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="depone11edit" className="form-label">Credit</label>
                                    <input type="text" className="form-control" id="depone11edit" value="3 Month" onChange={() => { }} />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="abc11edit" className="form-label">Total</label>
                                    <input type="text" className="form-control" id="abc11edit" value="$1551" onChange={() => { }} />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="depone22edit" className="form-label">Paid</label>
                                    <input type="text" className="form-control" id="depone22edit" value="$1500" onChange={() => { }} />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="abc22edit" className="form-label">Balance</label>
                                    <input type="text" className="form-control" id="abc22edit" value="$51" onChange={() => { }} />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="deptwo1" className="form-label">Supplier</label>
                                    <input type="text" className="form-control" id="deptwo1" value="Cloth Supplier" onChange={() => { }} />
                                </div>
                                <div className="col-sm-6">
                                    <label className="form-label">Status</label>
                                    <select className="form-select">
                                        <option >Pending</option>
                                        <option value="1">Completed</option>
                                        <option value="2">Wating</option>
                                        <option value="3">Decline</option>
                                    </select>
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-12">
                                    <label className="form-label">Purchase Status</label>
                                    <select className="form-select">
                                        <option >Item Recived</option>
                                        <option value="1">Not Recived</option>
                                    </select>
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

export default Purchase;