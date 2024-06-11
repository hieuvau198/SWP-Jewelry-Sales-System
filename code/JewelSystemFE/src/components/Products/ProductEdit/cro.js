import React from 'react';

function Cro() {
    return (
        <div className="row g-3">
            <div className="col-lg-7 col-md-12 docs-buttons">
                <button type="button" className="btn btn-sm btn-info" data-method="setDragMode" data-option="move" title="Move"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;setDragMode&quot;, &quot;move&quot;)"> <i className="icofont-drag1"></i> </span></button>
                <button type="button" className="btn btn-sm btn-info" data-method="setDragMode" data-option="crop" title="Crop"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;setDragMode&quot;, &quot;crop&quot;)"> <i className="icofont-crop"></i> </span></button>

                <button type="button" className="btn btn-sm btn-success" data-method="zoom" data-option="0.1" title="Zoom In"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;zoom&quot;, 0.1)"> <i className="icofont-ui-zoom-in"></i> </span></button>
                <button type="button" className="btn btn-sm btn-success" data-method="zoom" data-option="-0.1" title="Zoom Out"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;zoom&quot;, -0.1)"> <i className="icofont-ui-zoom-out"></i> </span></button>

                <button type="button" className="btn btn-sm btn-secondary" data-method="move" data-option="-10" data-second-option="0" title="Move Left"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;move&quot;, -10, 0)"> <i className="icofont-circled-left"></i></span></button>
                <button type="button" className="btn btn-sm btn-secondary" data-method="move" data-option="10" data-second-option="0" title="Move Right"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;move&quot;, 10, 0)"> <i className="icofont-circled-right"></i> </span></button>
                <button type="button" className="btn btn-sm btn-secondary" data-method="move" data-option="0" data-second-option="-10" title="Move Up"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;move&quot;, 0, -10)"> <i className="icofont-circled-up"></i> </span></button>
                <button type="button" className="btn btn-sm btn-secondary" data-method="move" data-option="0" data-second-option="10" title="Move Down"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;move&quot;, 0, 10)"> <i className="icofont-circled-down"></i></span></button>

                <button type="button" className="btn btn-sm btn-secondary" data-method="rotate" data-option="-45" title="Rotate Left"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;rotate&quot;, -45)"> <i className="icofont-rotation"></i> </span></button>
                <button type="button" className="btn btn-sm btn-secondary" data-method="rotate" data-option="45" title="Rotate Right"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;rotate&quot;, 45)"> <i className="icofont-rotation"></i> </span></button>

                <button type="button" className="btn btn-sm btn-secondary" data-method="scaleX" data-option="-1" title="Flip Horizontal"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;scaleX&quot;, -1)"> <i className="icofont-exchange"></i> </span></button>
                <button type="button" className="btn btn-sm btn-secondary" data-method="scaleY" data-option="-1" title="Flip Vertical"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;scaleY&quot;, -1)"> <i className="icofont-expand-alt"></i> </span></button>

                <button type="button" className="btn btn-sm btn-secondary" data-method="crop" title="Crop"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;crop&quot;)"> <i className="icofont-checked"></i> </span></button>
                <button type="button" className="btn btn-sm btn-secondary" data-method="clear" title="Clear"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;clear&quot;)"> <i className="icofont-ui-delete"></i> </span></button>

                <button type="button" className="btn btn-sm btn-secondary" data-method="disable" title="Disable"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;disable&quot;)"> <i className="icofont-lock"></i> </span></button>
                <button type="button" className="btn btn-sm btn-secondary" data-method="enable" title="Enable"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;enable&quot;)"> <i className="icofont-unlock"></i> </span></button>

                <button type="button" className="btn btn-sm btn-secondary" data-method="reset" title="Reset"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;reset&quot;)"> <i className="icofont-refresh"></i> </span></button>
                <label className="btn btn-sm btn-secondary btn-upload" for="inputImage" title="Upload image file">
                    <input type="file" className="sr-only" id="inputImage" name="file" accept="image/*" />
                    <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="Import image with Blob URLs"> <i className="icofont-upload"></i> </span>
                </label>
                <button type="button" className="btn btn-sm  btn-secondary" data-method="destroy" title="Destroy"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;destroy&quot;)"> <i className="icofont-power"></i> </span></button>

                <button type="button" className="btn btn-sm btn-danger" data-method="getCroppedCanvas" data-bs-toggle="modal" data-bs-target="#getCroppedCanvasModal"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;getCroppedCanvas&quot;)"> Get Cropped Canvas </span> </button>
                <button type="button" className="btn btn-sm btn-danger" data-method="getCroppedCanvas" data-bs-toggle="modal" data-bs-target="#getCroppedCanvasModal" data-option="{ &quot;width&quot;: 160, &quot;height&quot;: 90 }"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;getCroppedCanvas&quot;, { width: 160, height: 90 })"> 160×90 </span> </button>
                <button type="button" className="btn btn-sm btn-danger" data-method="getCroppedCanvas" data-bs-toggle="modal" data-bs-target="#getCroppedCanvasModal" data-option="{ &quot;width&quot;: 320, &quot;height&quot;: 180 }"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;getCroppedCanvas&quot;, { width: 320, height: 180 })"> 320×180 </span> </button>

                <button type="button" className="btn btn-secondary" data-method="getData" data-option="" data-target="#putData"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;getData&quot;)"> Get Data </span> </button>
                <button type="button" className="btn btn-secondary" data-method="setData" data-target="#putData"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;setData&quot;, data)"> Set Data </span> </button>
                <button type="button" className="btn btn-secondary" data-method="getContainerData" data-option="" data-target="#putData"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;getContainerData&quot;)"> Get Container Data </span> </button>
                <button type="button" className="btn btn-secondary" data-method="getImageData" data-option="" data-target="#putData"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;getImageData&quot;)"> Get Image Data </span> </button>
                <button type="button" className="btn btn-secondary" data-method="getCanvasData" data-option="" data-target="#putData"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;getCanvasData&quot;)"> Get Canvas Data </span> </button>
                <button type="button" className="btn btn-secondary" data-method="setCanvasData" data-target="#putData"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;setCanvasData&quot;, data)"> Set Canvas Data </span> </button>
                <button type="button" className="btn btn-secondary" data-method="getCropBoxData" data-option="" data-target="#putData"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;getCropBoxData&quot;)"> Get Crop Box Data </span> </button>
                <button type="button" className="btn btn-secondary" data-method="setCropBoxData" data-target="#putData"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="$().cropper(&quot;setCropBoxData&quot;, data)"> Set Crop Box Data </span> </button>
                <button type="button" className="btn btn-secondary" data-method="moveTo" data-option="0"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="cropper.moveTo(0)"> 0,0 </span> </button>
                <button type="button" className="btn btn-secondary" data-method="zoomTo" data-option="1"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="cropper.zoomTo(1)"> 100% </span> </button>
                <button type="button" className="btn btn-secondary" data-method="rotateTo" data-option="180"> <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="cropper.rotateTo(180)"> 180° </span> </button>
                <input type="text" className="form-control" id="putData" placeholder="Get data to here or set data with this value" />
            </div>
            <div className="col-lg-5 col-md-12 docs-toggles">

                <div className="btn-group btn-group-justified" data-toggle="buttons">
                    <label className="btn btn-secondary active">
                        <input type="radio" className="sr-only" id="aspectRatio0" name="aspectRatio" value="1.7777777777777777" />
                        <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="aspectRatio: 16 / 9"> 16:9 </span> </label>
                    <label className="btn btn-secondary">
                        <input type="radio" className="sr-only" id="aspectRatio1" name="aspectRatio" value="1.3333333333333333" />
                        <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="aspectRatio: 4 / 3"> 4:3 </span> </label>
                    <label className="btn btn-secondary">
                        <input type="radio" className="sr-only" id="aspectRatio2" name="aspectRatio" value="1" />
                        <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="aspectRatio: 1 / 1"> 1:1 </span> </label>
                    <label className="btn btn-secondary">
                        <input type="radio" className="sr-only" id="aspectRatio3" name="aspectRatio" value="0.6666666666666666" />
                        <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="aspectRatio: 2 / 3"> 2:3 </span> </label>
                    <label className="btn btn-secondary">
                        <input type="radio" className="sr-only" id="aspectRatio4" name="aspectRatio" value="NaN" />
                        <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="aspectRatio: NaN"> Free </span> </label>
                </div>
                <div className="btn-group btn-group-justified" data-toggle="buttons">
                    <label className="btn btn-secondary active">
                        <input type="radio" className="sr-only" id="viewMode0" name="viewMode" value="0" checked="" />
                        <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="View Mode 0"> VM0 </span> </label>
                    <label className="btn btn-secondary">
                        <input type="radio" className="sr-only" id="viewMode1" name="viewMode" value="1" />
                        <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="View Mode 1"> VM1 </span> </label>
                    <label className="btn btn-secondary">
                        <input type="radio" className="sr-only" id="viewMode2" name="viewMode" value="2" />
                        <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="View Mode 2"> VM2 </span> </label>
                    <label className="btn btn-secondary">
                        <input type="radio" className="sr-only" id="viewMode3" name="viewMode" value="3" />
                        <span className="docs-tooltip" data-toggle="tooltip" title="" data-bs-original-title="View Mode 3"> VM3 </span> </label>
                </div>
                <div className="dropdown dropup docs-options">
                    <button type="button" className="btn btn-success btn-block dropdown-toggle" id="toggleOptions" data-bs-toggle="dropdown" aria-expanded="true"> Toggle Options <span className="caret"></span> </button>

                    <ul className="dropdown-menu" aria-labelledby="toggleOptions" role="menu">
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="responsive" checked="" /> responsive </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="restore" checked="" /> restore </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="checkCrossOrigin" checked="" /> checkCrossOrigin </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="checkOrientation" checked="" /> checkOrientation </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="modal" checked="" /> modal </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="guides" checked="" /> guides </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="center" checked="" /> center </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="highlight" checked="" /> highlight </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="background" checked="" /> background </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="autoCrop" checked="" /> autoCrop </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="movable" checked="" /> movable </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="rotatable" checked="" /> rotatable </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="scalable" checked="" /> scalable </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="zoomable" checked="" /> zoomable </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="zoomOnTouch" checked="" /> zoomOnTouch </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="zoomOnWheel" checked="" /> zoomOnWheel </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="cropBoxMovable" checked="" /> cropBoxMovable </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="cropBoxResizable" checked="" /> cropBoxResizable </label>
                        </li>
                        <li role="presentation">
                            <label className="checkbox-inline">
                                <input type="checkbox" name="toggleDragModeOnDblclick" checked="" /> toggleDragModeOnDblclick </label>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    )
}

export default Cro;