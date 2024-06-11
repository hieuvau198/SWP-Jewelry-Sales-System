import React, { useState } from 'react';
import { Modal } from 'react-bootstrap';
import DataTable from 'react-data-table-component';
import PageHeader1 from '../../components/common/PageHeader1';
import { ExpenseData } from '../../components/Data/ExpenseData';

function Expense() {
    const[ismodal,setIsmodal]=useState(false);
    const[iseditmodal,seteditmodal]=useState(false);
    const[table_row,setTable_row]=useState([...ExpenseData.rows]);
    const columns = () => {
        return [
            {
                name: " ID",
                selector: (row) => row.id,
                sortable: true,
            },
            {
                name: "EXP ITEM",
                selector: (row) => row.item,
                sortable: true,

            },
            {
                name: "EXP ORDER BY",
                selector: (row) => row.name,
                cell: row => <><img className="avatar rounded lg border me-1" src={row.image} alt="" /> <span>{row.name}</span></>,
                sortable: true, minWidth: "250px"
            },
            {
                name: "DATE",
                selector: (row) => row.date,
                sortable: true
            },
            {
                name: "FROM",
                selector: (row) => row.from,
                sortable: true
            },
            {
                name: "AMOUNT",
                selector: (row) => row.amount,
                sortable: true
            },
            {
                name: "STATUS",
                selector: (row) => row.status,
                sortable: true,
                cell: row => <span className={`badge ${row.status === "Completed" ? 'bg-success' : "bg-warning"}`}>{row.status}</span>
            },
            {
                name: "ACTION",
                selector: (row) => { },
                sortable: true,
                cell: (row) => <div className="btn-group" role="group" aria-label="Basic outlined example">
                    <button type="button" onClick={() => { seteditmodal(true ) }} className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></button>
                    <button type="button" onClick={() => { onDeleteRow(row) }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                </div>
            }

        ]
    }

    async function onDeleteRow(row) {
        //eslint-disable-next-line
        var result = await table_row.filter((d) => { if (d !== row) { return d } });
        setTable_row( [...result] )
    }
    return (
        <div className="body d-flex py-lg-3 py-md-2">
            <div className="container-xxl">
                <PageHeader1 pagetitle='eBazar Expense' modalbutton={() => {
                    return <div className="col-auto d-flex w-sm-100">
                        <button type="button" onClick={() => { setIsmodal( true ) }} className="btn btn-primary btn-set-task w-sm-100"><i className="icofont-plus-circle me-2 fs-6"></i>Add Expenses</button>
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
            <Modal show={ismodal} onHide={() => { setIsmodal( false ) }} style={{ display: 'block' }}>

                <Modal.Header className="modal-header" closeButton>
                    <h5 className="modal-title  fw-bold" id="expaddLabel"> Add Expenses</h5>
                </Modal.Header>
                <Modal.Body className="modal-body">
                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="item" className="form-label">Exp Item</label>
                                    <input type="text" className="form-control" id="item" />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="amount" className="form-label">Amount</label>
                                    <input type="text" className="form-control" id="amount" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="depone" className="form-label">Exp Order By</label>
                                    <input type="text" className="form-control" id="depone" />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="abc" className="form-label">Date</label>
                                    <input type="date" className="form-control w-100" id="abc" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="deptwo" className="form-label">From</label>
                                    <input type="text" className="form-control" id="deptwo" />
                                </div>
                                <div className="col-sm-6">
                                    <label className="form-label">Status</label>
                                    <select className="form-select">
                                        <option>In Progress</option>
                                        <option value="1">Completed</option>
                                        <option value="2">Wating</option>
                                        <option value="3">Decline</option>
                                    </select>
                                </div>
                            </div>
                        </form>
                    </div>
                </Modal.Body>
                <Modal.Footer className="modal-footer" onClick={() => {setIsmodal( false ) }}>
                    <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Done</button>
                    <button type="submit" className="btn btn-primary">Add</button>
                </Modal.Footer>
            </Modal>

            <Modal show={iseditmodal} onHide={() => { seteditmodal( false ) }} style={{ display: 'block' }}>

                <Modal.Header className="modal-header" closeButton>
                    <h5 className="modal-title  fw-bold" id="expaddLabel"> Edit Expenses</h5>
                </Modal.Header>
                <Modal.Body className="modal-body">
                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="item" className="form-label">Exp Item</label>
                                    <input type="text" className="form-control" id="item" value="Mortgage Payments"/>
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="amount" className="form-label">Amount</label>
                                    <input type="text" className="form-control" id="amount" value="$5000"/>
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="depone" className="form-label">Exp Order By</label>
                                    <input type="text" className="form-control" id="depone" value="Joan Dyer"/>
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="abc" className="form-label">Date</label>
                                    <input type="date" className="form-control w-100" id="abc" value="2021-05-12" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="deptwo" className="form-label">From</label>
                                    <input type="text" className="form-control" id="deptwo" value="Office Owner" />
                                </div>
                                <div className="col-sm-6">
                                    <label className="form-label">Status</label>
                                    <select className="form-select">
                                        <option>In Progress</option>
                                        <option value="1">Completed</option>
                                        <option value="2">Wating</option>
                                        <option value="3">Decline</option>
                                    </select>
                                </div>
                            </div>
                        </form>
                    </div>
                </Modal.Body>
                <Modal.Footer className="modal-footer" onClick={() => {seteditmodal( false ) }}>
                    <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Done</button>
                    <button type="submit" className="btn btn-primary">Add</button>
                </Modal.Footer>
            </Modal>
        </div>
    )
}
export default Expense;