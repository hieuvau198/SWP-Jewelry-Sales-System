import React, { useState } from 'react';
import ReactCrop from 'react-image-crop';
import 'react-image-crop/dist/ReactCrop.css';
import NODATA from '../../../assets/images/product/Cropimg.jpg'

function CroppedImages(props) {

    const [crop, setCrop] = useState({ unit: '%', width: 30, aspect: 16 / 9 });
    const [croppedImageUrl, setCroppedImageUrl] = useState('');
    const [imageRef, setimageRef] = useState('');
   
    var fileUrl=""; 
   
    const onImageLoaded = (image) => {
      setimageRef(image)
    };

    const onCropComplete = (crop) => {
        makeClientCrop(crop);
    };
    const onCropChange = (crop, percentCrop) => {

        setCrop(crop);
    };
    async function makeClientCrop(crop) {

        if (imageRef && crop.width && crop.height) {
            const croppedImageUrl = await getCroppedImg(
                imageRef,
                crop,
                'newFile.jpeg'
            );
            setCroppedImageUrl( croppedImageUrl );
        }
    }

    const getCroppedImg = (image, crop, fileName) => {
        const canvas = document.createElement('canvas');
        const pixelRatio = window.devicePixelRatio;
        const scaleX = image.naturalWidth / image.width;
        const scaleY = image.naturalHeight / image.height;
        const ctx = canvas.getContext('2d');

        canvas.width = crop.width * pixelRatio * scaleX;
        canvas.height = crop.height * pixelRatio * scaleY;

        ctx.setTransform(pixelRatio, 0, 0, pixelRatio, 0, 0);
        ctx.imageSmoothingQuality = 'high';

        ctx.drawImage(
            image,
            crop.x * scaleX,
            crop.y * scaleY,
            crop.width * scaleX,
            crop.height * scaleY,
            0,
            0,
            crop.width * scaleX,
            crop.height * scaleY
        );

        return new Promise((resolve, reject) => {
            canvas.toBlob(
                (blob) => {
                    if (!blob) {
                        console.error('Canvas is empty');
                        return;
                    }
                    blob.name = fileName;
                    window.URL.revokeObjectURL(fileUrl);
                    fileUrl = window.URL.createObjectURL(blob);
                    resolve(fileUrl);
                },
                'image/jpeg',
                1
            );
        });
    }

    return (

        <>
            <div className="card-header py-3 bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Cropped Images</h6>
                <small>If You Cropped Images Please Upload and croppd easily.</small>
            </div>

            <ReactCrop
                src={NODATA}
                crop={crop}
                ruleOfThirds
                onImageLoaded={onImageLoaded}
                onComplete={onCropComplete}
                onChange={onCropChange}
            />

            {croppedImageUrl && (
                <div className='p-3' style={{ display: 'flex' }}>
                    <img alt="Crop" style={{ maxWidth: '250px', padding: '2px' }} src={croppedImageUrl} />
                    <img alt="Crop" style={{ maxwidth: '100px', height: '90px', padding: '2px' }} src={croppedImageUrl} />
                    <img alt="Crop" style={{ width: '150px', height: '60px' }} src={croppedImageUrl} />
                </div>
            )}
            <div className='row g-3'>
                <div className='col-12'>
                    <button className='btn btn-primary m-3'>Save Cropped Image</button>
                </div>
            </div>
        </>
    )
}
export default CroppedImages;
