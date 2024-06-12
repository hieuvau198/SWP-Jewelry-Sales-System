import React, { useState, useEffect, userRef } from 'react';
import { Modal } from 'react-bootstrap';
import DataTable from 'react-data-table-component';
import PageHeader1 from '../../components/common/PageHeader1';
import axios from '../../api/axios';

function UserList() {
    const [table_row, setTable_row] = useState();
    const [ismodal, setIsmodal] = useState(false);
    const [iseditmodal, setIseditmodal] = useState(false);
    const [userID, setUserId] = useState('');
    const [username, setUsername] = useState('');
    const [password, setpassword] = useState('');
    const [fullname, setFullname] = useState('');
    const [email, setEmail] = useState('');
    const [role, setRole] = useState('');



    
    useEffect(() => {
        let isMounted = true;
        const controller = new AbortController();

        const getUsers = async () => {
            try {
                const response = await axios.get('/user');
                isMounted && setTable_row(response.data);
            } catch (err) {
                console.error(err);
            }
        }

        getUsers();
        return () => {
            isMounted = false;
            controller.abort();
        }
    }, []);

    const handleSubmitAdd = async (e) => {
        e.preventDefault();

        try {
            console.log( {
                username,
                password,
                fullname,
                email,
                role
              });
            const response = await axios.put('/user', {
                username,
                password,
                fullname,
                email,
                role
              });
            console.log(response);
        } catch (err) {
            console.log(err);
        }
    }

    const columns = () => {
        return [
            {
                name: " ID",
                selector: (row) => row.userId,
                sortable: true,
            },
            {
                name: "USER NAME",
                selector: (row) => row.username,
                sortable: true,
            },
            {
                name: "FULL NAME",
                selector: (row) => row.fullname,
                sortable: true,

            },
            {
                name: "MAIL",
                selector: (row) => row.email,
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
        var result = await table_row.filter((d) => {  if (d !== row) { return d } });
        
        setTable_row([...result])
    }

    return (
        <div className="body d-flex py-lg-3 py-md-2">
            <div className="container-xxl">
                <PageHeader1 pagetitle='Users Information' modalbutton={() => {
                    return <div className="col-auto d-flex w-sm-100">
                        <button type="button" onClick={() => { setIsmodal(true) }} className="btn btn-primary btn-set-task w-sm-100" data-bs-toggle="modal" data-bs-target="#expadd"><i className="icofont-plus-circle me-2 fs-6"></i>Add new user</button>
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
            <Modal show={iseditmodal} onHide={() => { setIseditmodal(false) }} className="" style={{ display: 'block' }}>
                <Modal.Header className="modal-header" closeButton>
                    <h5 className="modal-title  fw-bold" id="expeditLabel"> Edit Customers</h5>
                </Modal.Header>
                <Modal.Body className="modal-body">

                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-12">
                                    <label htmlhtmlFor="item1" className="form-label">Customers Name</label>
                                    <input type="text" className="form-control" id="item1" value="Joan Dyer" onChange={() => { }} />
                                </div>
                                <div className="col-sm-12">
                                    <label htmlhtmlFor="taxtno1" className="form-label">Customers Profile</label>
                                    <input type="file" className="form-control" id="taxtno1" onChange={() => { }} />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label className="form-label">Country</label>
                                    <input type="text" className="form-control" value="South Africa" onChange={() => { }} />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="abc1" className="form-label">Customers Register date</label>
                                    <input type="date" className="form-control w-100" id="abc1" value="2021-03-12" onChange={() => { }} />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="mailid" className="form-label">Mail</label>
                                    <input type="text" className="form-control" id="mailid" value="JoanDyer@gmail.com" onChange={() => { }} />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlhtmlFor="phoneid" className="form-label">Phone</label>
                                    <input type="text" className="form-control" id="phoneid" value="202-555-0983" onChange={() => { }} />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-12">
                                    <label className="form-label">Total Order</label>
                                    <input type="text" className="form-control" value="02" onChange={() => { }} />
                                </div>
                            </div>
                        </form>
                    </div>

                </Modal.Body>
                <div className="modal-footer">
                    <button type="button" onClick={() => { setIseditmodal(false) }} className="btn btn-secondary" data-bs-dismiss="modal">Done</button>
                    <button type="submit" className="btn btn-primary">Save</button>
                </div>

            </Modal>
            <Modal  show={ismodal} onHide={() => { setIsmodal(false) }} style={{ display: 'block' }}>
                <Modal.Header className="modal-header" closeButton>
                    <h5 className="modal-title  fw-bold" id="expaddLabel">Add new User</h5>
                </Modal.Header>
                <Modal.Body className="modal-body">
                    <div className="deadline-form">
                        <form onSubmit={handleSubmitAdd}>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-12">
                                    <label htmlFor="username" className="form-label">user Name</label>
                                    <input type="text" className="form-control" id="username" value={username} onChange={(e) => setUsername(e.target.value)} />
                                </div>
                                <div className="col-sm-12">
                                    <label htmlFor="password" className="form-label">password</label>
                                    <input type="password" className="form-control" id="password"  value={password} onChange={(e) => setpassword(e.target.value)}/>
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-12">
                                    <label htmlFor="fullname" className="form-label">fullname</label>
                                    <input type="text" className="form-control" id="fullname" value={fullname} onChange={(e) => setFullname(e.target.value)} />
                                </div>
                                <div className="col-sm-12">
                                    <label htmlFor="email" className="form-label">email</label>
                                    <input type="text" className="form-control" id="email"  value={email} onChange={(e) => setEmail(e.target.value)}/>
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-12">
                                    <label htmlFor="role" className="form-label">role</label>
                                    <input type="text" className="form-control" id="role"  value={role} onChange={(e) => setRole(e.target.value)}/>
                                </div>
                            </div>
                    <button type="submit" className="btn btn-primary" onClick={() => { setIsmodal(false) }} data-bs-dismiss="modal">Add</button>
                        </form>
                    </div>

                </Modal.Body>
                <Modal.Footer className="modal-footer">
                    <button type="button" onClick={() => { setIsmodal(false) }} className="btn btn-secondary" data-bs-dismiss="modal">Done</button>
                    <button type="submit" className="btn btn-primary" onClick={() => { setIsmodal(false) }} data-bs-dismiss="modal">Add</button>
                </Modal.Footer>

            </Modal>
        </div>
    )
}
export default UserList;