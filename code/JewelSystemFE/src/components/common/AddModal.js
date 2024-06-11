import React, { useState } from 'react';
import { Modal } from 'react-bootstrap';
import { onChangeDarkMode, Onopenmodalsetting, onChangeHighcontrast, OnchangeRTLmode, OnGradientColor } from '../../Redux/Actions/Action';
import { connect } from 'react-redux';
import { SketchPicker } from "react-color";

function AddModal(props) {
    const { darkMode, openmodal, highcontrast, rtlmode } = props.Mainreducer

    const [arth, setArth] = useState(false);
    const [oncollapse, setOncollapse] = useState(false);
    const [colorpicker, setColorpicker] = useState('#9b5454');
    const [primarycolor, setPrimarycolor] = useState(false);
    const [secondarycolor, setSecondarycolor] = useState(false);
    const [chartcolor1, setChartcolor1] = useState(false);
    const [chartcolor2, setChartcolor2] = useState(false);
    const [chartcolor3, setChartcolor3] = useState(false);
    const [chartcolor4, setChartcolor4] = useState(false);
    const [chartcolor5, setChartcolor5] = useState(false);

    const Changetheme = (color) => {
        const list = document.getElementById('ebazar-layout')
        list.className = `theme-${color}`
        setArth({ arth: !arth })
    }

    const Isactivetheme = (val) => {
        var themeA = document.getElementById('ebazar-layout');
        if (themeA) {
            if (document.getElementById('ebazar-layout').classList.contains('theme-' + val)) {
                return 'active'
            }
        }
        return ''
    }
    const Isfontchange = (val) => {
        if (document.body.classList.contains('font-' + val)) {
            document.body.classList.remove('font-' + val)
        } else {
            document.body.classList.add('font-' + val)
        }
    }
    const HandleChangeComplete = (color) => {

        const att = document.createAttribute("style");
        att.value = '--primary-color:' + colorpicker
        document.getElementsByTagName("html")[0].setAttributeNode(att);
        setColorpicker(color.hex)
    };
    const HandleChangeComplete2 = (color) => {

        const att = document.createAttribute("style");
        att.value = '--secondary-color:' + colorpicker
        document.getElementsByTagName("html")[0].setAttributeNode(att);
        setColorpicker(color.hex)
    };
    const ChartcolorPicker1 = (color) => {
        const att = document.createAttribute("style");
        att.value = '--chart-color1:' + colorpicker
        document.getElementsByTagName("html")[0].setAttributeNode(att);
        setColorpicker(color.hex)
    }
    const ChartcolorPicker2 = (color) => {
        const att = document.createAttribute("style");
        att.value = '--chart-color2:' + colorpicker
        document.getElementsByTagName("html")[0].setAttributeNode(att);
        setColorpicker(color.hex)
    }
    const ChartcolorPicker3 = (color) => {
        const att = document.createAttribute("style");
        att.value = '--chart-color3:' + colorpicker
        document.getElementsByTagName("html")[0].setAttributeNode(att);
        setColorpicker(color.hex)
    }
    const ChartcolorPicker4 = (color) => {
        const att = document.createAttribute("style");
        att.value = '--chart-color4:' + colorpicker
        document.getElementsByTagName("html")[0].setAttributeNode(att);
        setColorpicker(color.hex)
    }
    const ChartcolorPicker5 = (color) => {
        const att = document.createAttribute("style");
        att.value = '--chart-color5:' + colorpicker
        document.getElementsByTagName("html")[0].setAttributeNode(att);
        setColorpicker(color.hex)
    }

    return (
        <Modal className="modal fade right " id="Settingmodal" show={openmodal} onHide={() => { props.Onopenmodalsetting(false) }}>
            <div className="modal-content" style={{}}>
                <Modal.Header className="modal-header" closeButton>
                    <Modal.Title>
                        <h5 className="modal-title">Custom Settings</h5>
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body className="modal-body custom_setting">
                    <div className="setting-theme pb-3">
                        <h6 className="card-title mb-2 fs-6 d-flex align-items-center"><i className="icofont-color-bucket fs-4 me-2 text-primary"></i>Template Color Settings</h6>
                        <ul className="list-unstyled row row-cols-3 g-2 choose-skin mb-2 mt-2">
                            <li data-theme="indigo" className={Isactivetheme('indigo')}><div className="indigo" onClick={() => { Changetheme('indigo') }}></div></li>
                            <li data-theme="tradewind" className={Isactivetheme('tradewind')}><div className="tradewind" onClick={() => { Changetheme('tradewind') }}></div></li>
                            <li data-theme="monalisa" className={Isactivetheme('monalisa')}><div className="monalisa" onClick={() => { Changetheme('monalisa') }}></div></li>
                            <li data-theme="blue" className={Isactivetheme('blue')}><div className="blue" onClick={() => { Changetheme('blue') }}></div></li>
                            <li data-theme="cyan" className={Isactivetheme('cyan')}><div className="cyan" onClick={() => { Changetheme('cyan') }}></div></li>
                            <li data-theme="green" className={Isactivetheme('green')}><div className="green" onClick={() => { Changetheme('green') }}></div></li>
                            <li data-theme="orange" className={Isactivetheme('orange')}><div className="orange" onClick={() => { Changetheme('orange') }}></div></li>
                            <li data-theme="blush" className={Isactivetheme('blush')}><div className="blush" onClick={() => { Changetheme('blush') }}></div></li>
                            <li data-theme="red" className={Isactivetheme('red')}><div className="red" onClick={() => { Changetheme('red') }}></div></li>
                        </ul>
                    </div>
                    <div className="sidebar-gradient py-3">
                        <h6 className="card-title mb-2 fs-6 d-flex align-items-center"><i className="icofont-paint fs-4 me-2 text-primary"></i>Sidebar Gradient</h6>
                        <div className="form-check form-switch gradient-switch pt-2 mb-2">
                            <input className="form-check-input" type="checkbox" id="CheckGradient" onChange={() => { props.OnGradientColor() }} />

                            <label className="form-check-label" htmlFor="CheckGradient">Enable Gradient! ( Sidebar )</label>
                        </div>
                    </div>
                    <div className="dynamic-block py-3">
                        <ul className="list-unstyled choose-skin mb-2 mt-1" >
                            <li data-theme="dynamic " onClick={() => { Changetheme('Dynamic') }}>
                                <div className='p-1 m-2'>
                                    <a className="dynamic text-light" data-bs-toggle="collapse" href='#size' role="button" onClick={() => { setOncollapse({ oncollapse: !oncollapse }) }}>
                                        <i className="icofont-paint me-2"></i>Click to Dynamic Setting</a>
                                </div>
                            </li>
                        </ul>
                        <div className={` collapse ${oncollapse ? 'show' : ''}`}>
                            <ul className="list-group list-unstyled mt-1">
                                <li className="list-group-item d-flex justify-content-between align-items-center py-1 px-2">
                                    <label>Primary Color</label>
                                    <SketchPicker
                                        color={colorpicker}
                                        onChangeComplete={HandleChangeComplete}
                                        id='sketchpicker'
                                        className={`${primarycolor === true ? '' : 'd-none'}`}
                                    />
                                    <button id="primaryColorPicker" onClick={() => { setPrimarycolor(!primarycolor) }} className="btn bg-primary avatar xs border-0 rounded-0 SketchPicker-element"></button>
                                </li>
                                <li className="list-group-item d-flex justify-content-between align-items-center py-1 px-2">
                                    <label>Secondary Color</label>
                                    <SketchPicker
                                        color={colorpicker}
                                        onChangeComplete={HandleChangeComplete2}
                                        id='sketchpicker'
                                        className={`${secondarycolor === true ? '' : 'd-none'}`}
                                    />
                                    <button id="secondaryColorPicker" onClick={() => { setSecondarycolor(!secondarycolor) }} className="btn bg-secondary avatar xs border-0 rounded-0 colorpicker-element"></button>
                                </li>
                                <li className="list-group-item d-flex justify-content-between align-items-center py-1 px-2">
                                    <label className="">Chart Color 1</label>
                                    <SketchPicker
                                        color={colorpicker}
                                        onChangeComplete={ChartcolorPicker1}
                                        id='sketchpicker'
                                        className={`${chartcolor1 === true ? '' : 'd-none'}`}
                                    />
                                    <button id="chartColorPicker1" onClick={() => { setChartcolor1(!chartcolor1) }} className="btn chart-color1 avatar xs border-0 rounded-0 colorpicker-element"></button>
                                </li>
                                <li className="list-group-item d-flex justify-content-between align-items-center py-1 px-2">
                                    <label className="">Chart Color 2</label>
                                    <SketchPicker
                                        color={colorpicker}
                                        onChangeComplete={ChartcolorPicker2}
                                        id='sketchpicker'
                                        className={`${chartcolor2 === true ? '' : 'd-none'}`}
                                    />
                                    <button id="chartColorPicker2" onClick={() => { setChartcolor2(!chartcolor2) }} className="btn chart-color2 avatar xs border-0 rounded-0 colorpicker-element"></button>
                                </li>
                                <li className="list-group-item d-flex justify-content-between align-items-center py-1 px-2">
                                    <label className="">Chart Color 3</label>
                                    <SketchPicker
                                        color={colorpicker}
                                        onChangeComplete={ChartcolorPicker3}
                                        id='sketchpicker'
                                        className={`${chartcolor3 === true ? '' : 'd-none'}`}
                                    />
                                    <button id="chartColorPicker3" onClick={() => { setChartcolor3(!chartcolor3) }} className="btn chart-color3 avatar xs border-0 rounded-0 colorpicker-element"></button>
                                </li>
                                <li className="list-group-item d-flex justify-content-between align-items-center py-1 px-2">
                                    <label className="">Chart Color 4</label>
                                    <SketchPicker
                                        color={colorpicker}
                                        onChangeComplete={ChartcolorPicker4}
                                        id='sketchpicker'
                                        className={`${chartcolor4 === true ? '' : 'd-none'}`}
                                    />
                                    <button id="chartColorPicker4" onClick={() => { setChartcolor4(!chartcolor4) }} className="btn chart-color4 avatar xs border-0 rounded-0 colorpicker-element"></button>
                                </li>
                                <li className="list-group-item d-flex justify-content-between align-items-center py-1 px-2">
                                    <label className="">Chart Color 5</label>
                                    <SketchPicker
                                        color={colorpicker}
                                        onChangeComplete={ChartcolorPicker5}
                                        id='sketchpicker'
                                        className={`${chartcolor5 === true ? '' : 'd-none'}`}
                                    />
                                    <button id="chartColorPicker5" onClick={() => { setChartcolor5(!chartcolor5) }} className="btn chart-color5 avatar xs border-0 rounded-0 colorpicker-element"></button>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div className="setting-font py-3">
                        <h6 className="card-title mb-2 fs-6 d-flex align-items-center"><i className="icofont-font fs-4 me-2 text-primary"></i> Font Settings</h6>
                        <ul className="list-group font_setting mt-1">
                            <li className="list-group-item py-1 px-2">
                                <div className="form-check mb-0">
                                    <input className="form-check-input" type="radio" name="font" id="font-poppins" value="font-poppins" onClick={() => { Isfontchange('poppins') }} />
                                    <label className="form-check-label" htmlFor="font-poppins">
                                        Poppins Google Font
                                    </label>
                                </div>
                            </li>
                            <li className="list-group-item py-1 px-2">
                                <div className="form-check mb-0">
                                    <input className="form-check-input" type="radio" name="font" id="font-opensans" value="font-opensans" onClick={() => { Isfontchange('opensans') }} />
                                    <label className="form-check-label" htmlFor="font-opensans">
                                        Open Sans Google Font
                                    </label>
                                </div>
                            </li>
                            <li className="list-group-item py-1 px-2">
                                <div className="form-check mb-0">
                                    <input className="form-check-input" type="radio" name="font" id="font-montserrat" value="font-montserrat" onClick={() => { Isfontchange('montserrat') }} />
                                    <label className="form-check-label" htmlFor="font-montserrat">
                                        Montserrat Google Font
                                    </label>
                                </div>
                            </li>
                            <li className="list-group-item py-1 px-2">
                                <div className="form-check mb-0">
                                    <input className="form-check-input" type="radio" name="font" id="font-mukta" value="font-mukta" onClick={() => { Isfontchange('mukta') }} />
                                    <label className="form-check-label" htmlFor="font-mukta">
                                        Mukta Google Font
                                    </label>
                                </div>
                            </li>
                        </ul>
                    </div>

                    <div className="setting-mode py-3">
                        <h6 className="card-title mb-2 fs-6 d-flex align-items-center"><i className="icofont-layout fs-4 me-2 text-primary"></i>Contrast Layout</h6>
                        <ul className="list-group list-unstyled mb-0 mt-1">
                            <li className="list-group-item d-flex align-items-center py-1 px-2">
                                <div className="form-check form-switch theme-switch mb-0">
                                    <input className="form-check-input" type="checkbox" id="theme-switch" checked={darkMode === 'dark'} onChange={() => { props.onChangeDarkMode(darkMode === 'dark' ? 'light' : 'dark') }} />
                                    <label className="form-check-label" htmlFor="theme-switch">Enable Dark Mode!</label>
                                </div>
                            </li>
                            <li className="list-group-item d-flex align-items-center py-1 px-2">
                                <div className="form-check form-switch theme-high-contrast mb-0">
                                    <input className="form-check-input" type="checkbox" id="theme-high-contrast" checked={highcontrast === 'high-contrast'} onChange={() => { props.onChangeHighcontrast(highcontrast === 'high-contrast' ? 'light' : 'high-contrast') }} />
                                    <label className="form-check-label" htmlFor="theme-high-contrast">Enable High Contrast</label>
                                </div>
                            </li>
                            <li className="list-group-item d-flex align-items-center py-1 px-2">
                                <div className="form-check form-switch theme-rtl mb-0">
                                    <input className="form-check-input" type="checkbox" id="theme-rtl" checked={document.body.classList.contains("rtl_mode")} onChange={() => { props.OnchangeRTLmode(rtlmode === 'rtl_mode' ? true : false) }} />
                                    <label className="form-check-label" htmlFor="theme-rtl">Enable RTL Mode!</label>
                                </div>
                            </li>
                        </ul>
                    </div>
                </Modal.Body>
                <Modal.Footer className="modal-footer justify-content-start">
                    <button type="button" className="btn btn-white border lift" data-dismiss="modal" onClick={() => { props.Onopenmodalsetting(false) }}>Close</button>
                    <button type="button" className="btn btn-primary lift">Save Changes</button>
                </Modal.Footer>
            </div>
        </Modal>
    )
}

const mapStateToProps = ({ Mainreducer }) => ({
    Mainreducer
})

export default connect(mapStateToProps, {
    onChangeDarkMode,
    Onopenmodalsetting,
    onChangeHighcontrast,
    OnchangeRTLmode,
    OnGradientColor
})(AddModal)

