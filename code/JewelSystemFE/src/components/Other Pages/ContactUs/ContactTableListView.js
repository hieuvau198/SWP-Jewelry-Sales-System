import React, { useState } from 'react';
import DataTable from 'react-data-table-component';
import { Modal } from 'react-bootstrap'
import { ContactTableListViewTable } from '../../Data/OtherPagesData';


function ContactTableListView() {
    const [table_row, settable_row] = useState([...ContactTableListViewTable.rows]);
    const [iseditmodal, setiseditmodal] = useState(false);

    const columns = () => {
        return [
            {
                name: "PERSON NAME",
                selector: (row) => row.name,
                cell: row => <><img className="avatar rounded lg" src={row.image} alt="" /> <span className="px-2">{row.name}</span></>,
                sortable: true, minWidth: "250px"
            },
            {
                name: "BIRTHDATE",
                selector: (row) => row.date,
                sortable: true
            },
            {
                name: "EMAIL",
                selector: (row) => row.mail,
                sortable: true
            },
            {
                name: "PHONENUMBER",
                selector: (row) => row.phonenumber,
                sortable: true
            },
            {
                name: "ACTION",
                selector: (row) => { },
                sortable: true,
                cell: (row) => <div className="btn-group" role="group" aria-label="Basic outlined example">
                    <button onClick={() => { setiseditmodal(true) }} type="button" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></button>
                    <button type="button" onClick={() => { onDeleteRow(row) }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                </div>
            }
        ]
    }

    async function onDeleteRow(row) {
        //eslint-disable-next-line
        var result = await table_row.filter((d) => { if (d !== row) { return d } });
        settable_row([...result])
    }
    return (
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
                                highlightOnHover={true}
                            />
                        </div>
                    </div>
                </div>
            </div>
            <Modal className="modal fade show" show={iseditmodal} onHide={() => { setiseditmodal(false) }} style={{ display: 'block' }}>

                <Modal.Header className="modal-header" closeButton>
                    <h5 className="modal-title  fw-bold" id="expeditLabel"> Edit Contact</h5>
                </Modal.Header>
                <Modal.Body className="modal-body">
                    <div className="mb-3">
                        <label htmlFor="item1" className="form-label">Person Name</label>
                        <input type="text" className="form-control" id="item1" value="Phil Glover" onChange={() => { }} />
                    </div>
                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label className="form-label">Contact Image</label>
                                    <input type="file" className="form-control" onChange={() => { }} />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="abc1" className="form-label">Birthdate</label>
                                    <input type="date" className="form-control" id="abc1" value="2021-03-12" onChange={() => { }} />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="deptwo1" className="form-label">Email</label>
                                    <input type="email" className="form-control" id="deptwo1" value="PhilGlover@gmail.com" onChange={() => { }} />
                                </div>
                                <div className="col-sm-6">
                                    <label className="form-label">Phone</label>
                                    <input type="text" className="form-control" value="775-555-0117" onChange={() => { }} />
                                </div>
                            </div>
                        </form>
                    </div>

                </Modal.Body>
                <Modal.Footer className="modal-footer">
                    <button type="button" onClick={() => { setiseditmodal(false) }} className="btn btn-secondary" data-bs-dismiss="modal">Done</button>
                    <button type="submit" className="btn btn-primary">Save</button>
                </Modal.Footer>
            </Modal>
        </div>
    )
}
export default ContactTableListView;