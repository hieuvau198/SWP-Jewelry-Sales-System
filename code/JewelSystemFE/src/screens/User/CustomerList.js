import React, { useState, useEffect, useContext } from 'react';
import { Modal } from 'react-bootstrap';
import DataTable from 'react-data-table-component';
import { Link } from 'react-router-dom';
import PageHeader1 from '../../components/common/PageHeader1';
import { CustomerData } from '../../components/Data/CustomerData';
import Avatar1 from '../../assets/images/xs/avatar1.svg';
import axios from '../../api/axios';
import { useCart } from 'react-use-cart';

function CustomerList() {
    const [ismodal, setIsmodal] = useState(false);
    const [iseditmodal, setIseditmodal] = useState(false);
    const [ rowdata, setrowData] = useState();
    const [ userId, setUserId] = useState();    
    const {updateCartMetadata, metadata } = useCart();

    function onSiteChanged (e) {
        setUserId(e.currentTarget.value);
        updateCartMetadata({userId:userId});
      }



    const columns = (e) => {
        return [
            {
                name: " ID",
                selector: (row) => row.customerId,
                sortable: true,
            },
            {
                name: "CUSTOMER",
                selector: (row) => row.customerName,
                cell: row => <>
                    <img className="avatar rounded lg" src={Avatar1} alt="" />
                    <span className="px-2">{row.customerName}</span>
                  </>,
                sortable: true, minWidth: "200px"
            },
            {
                name: "REGISTER DATE",
                selector: (row) => row.attendDate,
                sortable: true,
                
            },
            {
              name: "CUSTOMER POINT",
              selector: (row) => row.customerPoint,
              sortable: true,
          },
            {
              name: "CUSTOMER RANK",
              selector: (row) => row.customerRank,
              sortable: true,
          },
          {
                name: "ACTION",
                selector: (row) => row.customerId,
                sortable: true,
                cell: (row) => <div className="btn-group" role="group" aria-label="Basic outlined example">
                    <input className='form-check-input' type="radio" name="User" id={row.customerId} value={row.customerId} onChange={onSiteChanged}/>
                </div>
            }
    
        ]
    }

    useEffect(() =>{

        axios.get('/customer').then(res=>{
            const dataArr = res.data ; 
            console.log(dataArr); 
            setrowData(res.data); 
           
        }).catch(err=>{
            console.log(err); 
        }); 
    
    
    }, []);

    const CustomerData = ()=>{ 
        return( {
         
          columns: [
              
            {
              name: " ID",
              selector: (row) => row.customerId,
              sortable: true,
          },
          {
              name: "CUSTOMER",
              selector: (row) => row.customerName,
              cell: row => <Link to={process.env.PUBLIC_URL+'/customer-detail'}>
                  <img className="avatar rounded lg" src={Avatar1} alt="" />
                  <span className="px-2">{row.customerName}</span>
                </Link>,
              sortable: true, minWidth: "200px"
          },
          {
              name: "REGISTER DATE",
              selector: (row) => row.attendDate,
              sortable: true,
              
          },
          {
            name: "CUSTOMER POINT",
            selector: (row) => row.customerPoint,
            sortable: true,
        },
          {
            name: "CUSTOMER RANK",
            selector: (row) => row.customerRank,
            sortable: true,
        },
        {
              name: "ACTION",
              selector: (row) => { },
              sortable: true,
              cell: () => <div className="btn-group" role="group" aria-label="Basic outlined example">
                  <button type="button" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></button>
                  <button type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
              </div>
          }
      
      
      
          ],
          rows: rowdata
      }
      
        )
      }

    return (
        <div className="body d-flex py-lg-3 py-md-2">
            <div className="container-xxl">
                <PageHeader1 pagetitle='Customers Information' modalbutton={() => {
                    return <div className="col-auto d-flex w-sm-100">
                        <button type="button" onClick={() => { setIsmodal(true) }} className="btn btn-primary btn-set-task w-sm-100" data-bs-toggle="modal" data-bs-target="#expadd"><i className="icofont-plus-circle me-2 fs-6"></i>Add Customers</button>
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
                                                data={CustomerData()?.rows}
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
            <Modal className="modal fade show" id="expadd" show={ismodal} onHide={() => { setIsmodal(false) }} style={{ display: 'block' }}>
                <Modal.Header className="modal-header" closeButton>
                    <h5 className="modal-title  fw-bold" id="expaddLabel">Add Customers</h5>
                </Modal.Header>
                <Modal.Body className="modal-body">
                    <div className="deadline-form">
                        <form>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-12">
                                    <label htmlFor="item" className="form-label">Customers Name</label>
                                    <input type="text" className="form-control" id="item" />
                                </div>
                                <div className="col-sm-12">
                                    <label htmlFor="taxtno" className="form-label">Customers Profile</label>
                                    <input type="File" className="form-control" id="taxtno" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="depone" className="form-label">Country</label>
                                    <input type="text" className="form-control" id="depone" />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="abc" className="form-label">Customers Register date</label>
                                    <input type="date" className="form-control w-100" id="abc" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-6">
                                    <label htmlFor="abc11" className="form-label">Mail</label>
                                    <input type="text" className="form-control" id="abc11" />
                                </div>
                                <div className="col-sm-6">
                                    <label htmlFor="abc111" className="form-label">Phone</label>
                                    <input type="text" className="form-control" id="abc111" />
                                </div>
                            </div>
                            <div className="row g-3 mb-3">
                                <div className="col-sm-12">
                                    <label className="form-label">Total Order</label>
                                    <input type="text" className="form-control" />
                                </div>
                            </div>
                        </form>
                    </div>

                </Modal.Body>
                <Modal.Footer className="modal-footer">
                    <button onClick={() => { setIsmodal(false) }} type="button" className="btn btn-secondary" data-bs-dismiss="modal">Done</button>
                    <button type="submit" className="btn btn-primary">Add</button>
                </Modal.Footer>

            </Modal>
        </div>
    )
}
export default CustomerList;