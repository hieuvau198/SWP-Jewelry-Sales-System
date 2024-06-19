import React, { useState } from "react";

function BasicValidationForm() {

    const [t_input, setT_input] = useState('');
    const [email, setEmail] = useState('');
    const [t_area, setT_area] = useState('');
    const [check_box, setCheck_box] = useState('');
    const [radio_btn, setRadio_btn] = useState('');
    const [button, setButton] = useState('');

    const onSubmit = (e) => {
        e.preventDefault();
        setButton(true);

        if (t_input !== "" && t_area !== "" && check_box !== "" && email !== "" && radio_btn !== "" && button !== true) {

            setT_input('');
            setT_area('');
            setCheck_box('');
            setRadio_btn('');
            setEmail('');
            setButton(false);
        }
    }

    const handleDepositeAmountChange = (e) => {
        let value = e.target.value
        let name = e.target.name
        if (name === "t_input") {
            setT_input(value);
            setButton(false);
        } else if (name === "t_area") {
            setT_area(value);
            setButton(false);
        } else if (name === "email") {
            setEmail(value);
            setButton(false);
        } else if (name === "check_box") {
            setCheck_box(value);
            setButton(false);
        }
    };

    return (
        <div className="card mb-3">
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                <h6 className="mb-0 fw-bold ">Basic Validation Form</h6>
            </div>
            <div className="card-body">
                <form id="basic-form" method="post" >
                    <div className="row g-3 align-items-center">
                        <div className="col-md-12">
                            <div className="form-group">
                                <label className="form-label">Text Input</label>
                                <input name='t_input' type="text" className="form-control parsley-error" value={t_input}
                                    onChange={(e) => {
                                        handleDepositeAmountChange(e);
                                    }} />
                                {button === true ? (
                                    t_input !== "" ? (
                                        ""
                                    ) : (
                                        <small className="text-danger">
                                            This value is required.
                                        </small>
                                    )
                                ) : (
                                    ""
                                )}
                            </div>
                        </div>

                        <div className="col-md-12">
                            <div className="form-group">
                                <label className="form-label">Email Input</label>
                                <input name='email' type="email" className="form-control parsley-error" value={email}
                                    onChange={(e) => {
                                        handleDepositeAmountChange(e);
                                    }}
                                />
                                {button === true ? (
                                    email !== "" ? (
                                        ""
                                    ) : (
                                        <small className="text-danger">
                                            This value is required.
                                        </small>
                                    )
                                ) : (
                                    ""
                                )}
                            </div>
                        </div>
                        <div className="col-md-12">
                            <div className="form-group">
                                <label className="form-label">Text Area</label>
                                <textarea name="t_area" className="form-control parsley-error" rows="5" cols="30" value={t_area}
                                    onChange={(e) => {
                                        handleDepositeAmountChange(e);
                                    }}
                                ></textarea>
                                {button === true ? (
                                    t_area !== "" ? (
                                        ""
                                    ) : (
                                        <small className="text-danger">
                                            This value is required.
                                        </small>
                                    )
                                ) : (
                                    ""
                                )}
                            </div>
                        </div>
                        <div className="col-md-12">
                            <div className="form-group">
                                <label className="form-label">Checkbox</label>
                                <br />
                                <label className="fancy-checkbox parsley-error">
                                    <input type="checkbox" name="check_box" value={check_box}
                                        onChange={(e) => {
                                            handleDepositeAmountChange(e);
                                        }}
                                    />
                                    <span className="mx-1">Option 1</span>
                                </label>
                                <label className="fancy-checkbox mx-2">
                                    <input type="checkbox" name="check_box" value={check_box}
                                        onChange={(e) => {
                                            handleDepositeAmountChange(e);
                                        }}
                                    />
                                    <span className="mx-1">Option 2</span>
                                </label>
                                <label className="fancy-checkbox">
                                    <input type="checkbox" name="check_box" value={check_box}
                                        onChange={(e) => {
                                            handleDepositeAmountChange(e);
                                        }}
                                    />
                                    <span className="mx-1">Option 3</span>
                                </label>
                                <p id="error-checkbox">
                                    {button === true ? (
                                        t_area !== "" ? (
                                            ""
                                        ) : (
                                            <small className="text-danger">
                                                This value is required.
                                            </small>
                                        )
                                    ) : (
                                        ""
                                    )}
                                </p>
                            </div>
                        </div>
                        <div className="col-md-12">
                            <div className="form-group">
                                <label className="form-label">Radio Button</label>
                                <br />
                                <label className="fancy-radio parsley-error">
                                    <input name='radio_btn' type="radio" value={radio_btn}
                                        onChange={(e) => {
                                            handleDepositeAmountChange(e);
                                        }}
                                    />
                                    <span className="mx-1"><i></i>Male</span>
                                </label>
                                <label className="fancy-radio">
                                    <input name='radio_btn' type="radio" value={radio_btn}
                                        onChange={(e) => {
                                            handleDepositeAmountChange(e);
                                        }}
                                    />
                                    <span className="mx-1"><i></i>Female</span>
                                </label>
                                <p id="error-radio">
                                    {button === true ? (
                                        t_area !== "" ? (
                                            ""
                                        ) : (
                                            <small className="text-danger">
                                                This value is required.
                                            </small>
                                        )
                                    ) : (
                                        ""
                                    )}
                                </p>
                            </div>
                        </div>
                    </div>
                    <button type="submit" className="btn btn-primary" onClick={(e) => { onSubmit(e); }} >Validate</button>
                </form>
            </div>
        </div>
    );
}

export default BasicValidationForm;