import React from 'react';
import { Link } from 'react-router-dom';
import PageHeader1 from '../../components/common/PageHeader1';

function CategoriesList () {
   const deletbutton1=()=> {
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
   const deletbutton3=()=> {
        const Row1 = document.getElementById('row3')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
   const deletbutton4=()=> {
        const Row1 = document.getElementById('row4')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
  const deletbutton5=() =>{
        const Row1 = document.getElementById('row5')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
  const deletbutton6=()=> {
        const Row1 = document.getElementById('row6')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
   const deletbutton7=()=> {
        const Row1 = document.getElementById('row7')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
   const deletbutton8=()=> {
        const Row1 = document.getElementById('row8')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
   const deletbutton9=()=> {
        const Row1 = document.getElementById('row9')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
   const deletbutton10=()=> {
        const Row1 = document.getElementById('row10')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
   const deletbutton11=()=> {
        const Row1 = document.getElementById('row11')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
   const deletbutton12=()=> {
        const Row1 = document.getElementById('row12')
        if (Row1) {
            Row1.setAttribute("style", "display:none");
        }
    }
        return (
            <div className="body d-flex py-3">
                <div className="container-xxl">
                    <PageHeader1 pagetitle='Categorie List' righttitle='Add Categories' link='/categories-add' routebutton={true} />
                    <div className="row g-3 mb-3">
                        <div className="col-md-12">
                            <div className="card">
                                <div className="card-body">
                                    <div id="myDataTable_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer">
                                        <div className="row">
                                            <div className="col-sm-12">
                                                <div className='table-responsive'>
                                                    <table id="myDataTable" className="table table-hover align-middle mb-0 nowrap dataTable no-footer dtr-inline" style={{ width: '100%' }} role="grid" aria-describedby="myDataTable_info">
                                                        <thead>
                                                            <tr role="row">
                                                                <th className="sorting_asc" tabIndex="0" aria-controls="myDataTable" rowSpan="1" colSpan="1" style={{ width: '32.2px' }} aria-label="Id: activate to sort column descending" aria-sort="ascending">Id</th>
                                                                <th className="sorting" tabIndex="0" aria-controls="myDataTable" rowSpan="1" colSpan="1" style={{ width: '117.2px' }} aria-label="Categorie: activate to sort column ascending">Categorie</th>
                                                                <th className="dt-body-right sorting" tabIndex="0" aria-controls="myDataTable" rowSpan="1" colSpan="1" style={{ width: '118.2px' }} aria-label="Date: activate to sort column ascending">Date</th>
                                                                <th className="sorting" tabIndex="0" aria-controls="myDataTable" rowSpan="1" colSpan="1" style={{ width: '59.2px' }} aria-label="Status: activate to sort column ascending">Status</th>
                                                                <th className="dt-body-right sorting" tabIndex="0" aria-controls="myDataTable" rowSpan="1" colSpan="1" style={{ width: '75.2px' }} aria-label="Action: activate to sort column ascending">Action</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr id="row11" role="row" className="odd">
                                                                <td className="sorting_1" tabIndex="0">#0001</td>
                                                                <td>Watch</td>
                                                                <td className=" dt-body-right">March 13, 2021</td>
                                                                <td><span className="badge bg-success">Published</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button onClick={() => { deletbutton11() }} type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id="row12" role="row" className="even">
                                                                <td className="sorting_1" tabIndex="0">#0002</td>
                                                                <td>Toy</td>
                                                                <td className=" dt-body-right">	January 14, 2021</td>
                                                                <td><span className="badge bg-warning">Scheduled</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button onClick={() => { deletbutton12() }} type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>

                                                            <tr id="row1" role="row" className="odd">
                                                                <td tabIndex="0" className="sorting_1">#0003</td>
                                                                <td>Laptop</td>
                                                                <td className=" dt-body-right">February 08, 2021</td>
                                                                <td><span className="badge bg-success">Published</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button type="button" onClick={() => { deletbutton1() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id="row2" role="row" className="even">
                                                                <td tabIndex="0" className="sorting_1">#0004</td>
                                                                <td>Mobile</td>
                                                                <td className=" dt-body-right">April  02, 2021</td>
                                                                <td><span className="badge bg-warning">Scheduled</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button type="button" onClick={() => { deletbutton2() }} className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id="row3" role="row" className="odd">
                                                                <td tabIndex="0" className="sorting_1">#0005</td>
                                                                <td>Tv</td>
                                                                <td className=" dt-body-right">June 19, 2021</td>
                                                                <td><span className="badge bg-success">Published</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button onClick={() => { deletbutton3() }} type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id="row4" role="row" className="even">
                                                                <td tabIndex="0" className="sorting_1">#0006</td>
                                                                <td>Cloths</td>
                                                                <td className=" dt-body-right">April 10, 2021</td>
                                                                <td><span className="badge bg-warning">Scheduled</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button onClick={() => { deletbutton4() }} type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id="row5" role="row" className="odd">
                                                                <td tabIndex="0" className="sorting_1">#0007</td>
                                                                <td>Footwear</td>
                                                                <td className=" dt-body-right">May 11, 2021</td>
                                                                <td><span className="badge bg-success">Published</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button onClick={() => {deletbutton5() }} type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id="row6" role="row" className="even">
                                                                <td tabIndex="0" className="sorting_1">#0008</td>
                                                                <td>Kitchenware</td>
                                                                <td className=" dt-body-right">June 13, 2021</td>
                                                                <td><span className="badge bg-danger">Hidden</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button onClick={() => { deletbutton6() }} type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id="row7" role="row" className="odd">
                                                                <td tabIndex="0" className="sorting_1">#0009</td>
                                                                <td>Beautywear</td>
                                                                <td className=" dt-body-right">June 13, 2021</td>
                                                                <td><span className="badge bg-danger">Hidden</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button onClick={() => {deletbutton7() }} type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id="row8" role="row" className="even">
                                                                <td tabIndex="0" className="sorting_1">#0010</td>
                                                                <td>Game accessories</td>
                                                                <td className=" dt-body-right">February 13, 2021</td>
                                                                <td><span className="badge bg-success">Published</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button onClick={() => { deletbutton8() }} type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id="row9" role="row" className="odd">
                                                                <td className="sorting_1" tabIndex="0">#0011</td>
                                                                <td>Flower Port</td>
                                                                <td className=" dt-body-right">February 08, 2021</td>
                                                                <td><span className="badge bg-success">Published</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button onClick={() => { deletbutton9() }} type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr id="row10" role="row" className="even">
                                                                <td className="sorting_1" tabIndex="0">#0012</td>
                                                                <td>Accessories</td>
                                                                <td className=" dt-body-right">March 28, 2021</td>
                                                                <td><span className="badge bg-success">Published</span></td>
                                                                <td className=" dt-body-right">
                                                                    <div className="btn-group" role="group" aria-label="Basic outlined example">
                                                                        <Link to="categories-edit" className="btn btn-outline-secondary"><i className="icofont-edit text-success"></i></Link>
                                                                        <button onClick={() => { deletbutton10() }} type="button" className="btn btn-outline-secondary deleterow"><i className="icofont-ui-delete text-danger"></i></button>
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
            </div>
        )
    }
export default CategoriesList;