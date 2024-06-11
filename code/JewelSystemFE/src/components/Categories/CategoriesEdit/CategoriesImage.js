import React from 'react';
import { connect } from 'react-redux';
import { OnchangeAddimage } from '../../../Redux/Actions/Action'


function CategoriesImage(props) {
    const { addimage } = props.Mainreducer
    return (
        <div className="card">
            <div className="card-header py-3 bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Categories Image Upload</h6>
                <small>With event and default file try to remove the image</small>
            </div>
            <div className='p-2'>
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
            </div>

        </div>
    )
}

const mapStateToProps = ({ Mainreducer }) => ({
    Mainreducer
})
export default connect(mapStateToProps, {
    OnchangeAddimage
})(CategoriesImage);