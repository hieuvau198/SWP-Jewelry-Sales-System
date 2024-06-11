import React from 'react';
import { ImageTableData } from '../../Data/ProductEditData';
import { connect } from 'react-redux';
import { OnchangeAddimage } from '../../../Redux/Actions/Action'

function Images(props) {
    const { addimage } = props.Mainreducer
    return (<>
        <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
            <h6 className="mb-0 fw-bold ">Images</h6>
        </div>
        <div className="card-body">
            <form>
                <div className="row g-3 align-items-center">
                    <div className="col-md-12">
                        <label className="form-label">Product Images Upload</label>
                        <small className="d-block text-muted mb-2">Only portrait or square images, 2M max and 2000px max-height.</small>


                        <div id='create-token' className='dropzone'>
                            {
                                addimage ?
                                    <img src={URL.createObjectURL(addimage[0])
                                    } alt='' />
                                    :
                                    <div className='dz-message '>
                                        <i className="fa   fa-picture-o" aria-hidden="true"></i>
                                    </div>
                            }
                            <input id='filesize' onChange={(e) => { props.OnchangeAddimage(e.target.files) }} name="file" type="file" accept=".jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff, .mp4, .webm, .mp3, awv, .ogg, .glb"></input>
                        </div>


                        <div className="col-md-12">
                            <label className="form-label w-100">Select Product Color</label>
                            <input type="color" id="color" />
                        </div>
                        <div className="col-md-12">
                            <div className="product-cart">
                                <div className="checkout-table table-responsive">
                                    <div id="myCartTable_wrapper" className="dataTables_wrapper dt-bootstrap5 no-footer">
                                        <div className="row">
                                            <div className="col-sm-12 col-md-6">
                                                <div className="dataTables_length" id="myCartTable_length">
                                                    <label className='d-flex'>Show <select className="mx-1">
                                                        <option value="10" >10</option>
                                                        <option value="25">25</option>
                                                        <option value="50">50</option>
                                                        <option value="100">100</option>
                                                    </select>entries</label>
                                                </div>
                                            </div>
                                            <div className="col-sm-12 col-md-6">
                                                <div id="myCartTable_filter" className="dataTables_filter">
                                                    <label className='d-flex'>Search:<div><input type="search" className="form-control form-control-sm" placeholder="" /></div></label>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="row">
                                            <div className="col-sm-12">
                                                <div className='table-responsive'>
                                                    <table id="myCartTable" className="table display dataTable table-hover align-middle nowrap no-footer dtr-inline" style={{ width: '100%' }} role="grid" aria-describedby="myCartTable_info">
                                                        <thead>
                                                            <tr role="row">
                                                                <th className="product sorting_asc" style={{ width: '102px' }} >Product</th>
                                                                <th className="product sorting" style={{ width: '267px' }}>Product Tag Name</th>
                                                                <th className="quantity dt-body-right sorting" style={{ width: '100px' }} >Color</th>
                                                                <th className="quantity sorting" style={{ width: '100px' }} >Quantity</th>
                                                                <th className="quantity dt-body-right sorting" style={{ width: '0px' }} >Action</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>

                                                            {
                                                                ImageTableData.map((d, i) => {
                                                                    return <tr key={'a' + i} role="row" className="odd">
                                                                        <td tabIndex="0" className="sorting_1">
                                                                            <div className="product-cart d-flex align-items-center">
                                                                                <div className="product-thumb">
                                                                                    <img src={d.image} className="img-fluid avatar xl" alt="Product" />
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <input type="text" className="form-control" value={`${d.inputvalue}`} onChange={() => { }} />
                                                                        </td>
                                                                        <td className=" dt-body-right">
                                                                            <input type="color" className="form-control" value={`${d.colorvalue}`} onChange={() => { }} />
                                                                        </td>
                                                                        <td>
                                                                            <div className="product-quantity d-inline-flex">
                                                                                <input type="number" value={`${d.qvalue}`} onChange={() => { }} />
                                                                            </div>
                                                                        </td>
                                                                        <td className=" dt-body-right" >
                                                                            <div className="btn-group"  >
                                                                                <button type="button" className="btn btn-outline-secondary deleterow">
                                                                                    <i className="icofont-ui-delete text-danger"></i>
                                                                                </button>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                })
                                                            }
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
            </form>
        </div>
    </>
    )
}
const mapStateToProps = ({ Mainreducer }) => ({
    Mainreducer
})
export default connect(mapStateToProps, {
    OnchangeAddimage
})(Images);