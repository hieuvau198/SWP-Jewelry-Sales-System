import React, { useState } from "react";
import { Link } from "react-router-dom";

function AdvancedValidationForm() {

    const [eight_char, setEight_char] = useState('');
    const [five_char, setFive_char] = useState('');
    const [min_char, setMin_char] = useState('');
    const [twenty_char, setTwenty_char] = useState('');
    const [checkbox, setCheckbox] = useState([false, false, false]);
    const [check_box, setCheck_box] = useState([false, false, false]);
    const [button, setButton] = useState(false);


    const onSubmit = (e) => {
        e.preventDefault();
        setButton(true);
        if (

            eight_char !== "" &&
            five_char !== "" &&
            min_char !== "" &&
            twenty_char !== "" &&
            checkbox !== "" &&
            button !== true
        ) {
            setEight_char("");
            setFive_char("");
            setMin_char("");
            setTwenty_char("");
            setCheckbox("");
            setButton(false)
        }
    }

    const handleDepositeAmountChange = (e) => {
        let value = e.target.value
        let name = e.target.name
        if (name === "eight_char") {
            setEight_char(value);
            setButton(false)
        } else if (name === "five_char") {
            setFive_char(value);
            setButton(false);
        } else if (name === "min_char") {
            setMin_char(value);
            setButton(false);
        } else if (name === "twenty_char") {
            setTwenty_char(value);
            setButton(false);
        } else if (name === "checkbox") {
            setCheckbox(value);
            setButton(false);
        }
    };

    return (
        <div className="card mb-3">
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                <h6 className="mb-0 fw-bold ">Advanced Validation Form</h6>
            </div>
            <div className="card-body">
                <form id="advanced-form" >
                    <div className="row g-3 align-items-center">
                        <div className="col-md-12">
                            <div className="form-group">
                                <label htmlFor="text-input1" className="form-label">Min. 8 Characters</label>
                                <input name='eight_char' type="text" id="text-input1" className="form-control" value={eight_char}
                                    onChange={(e) => {
                                        handleDepositeAmountChange(e);
                                    }}
                                />
                                {button === true ? (
                                    eight_char !== "" ? (
                                        eight_char.length < 8 ?
                                            <small className="text-danger">
                                                This value is too short. It should have 8 characters or more.
                                            </small>
                                            :
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
                                <label htmlFor="text-input2" className="form-label">Between 5-10 Characters</label>
                                <input name="five_char" type="text" id="text-input2" className="form-control" value={five_char}
                                    onChange={(e) => {
                                        handleDepositeAmountChange(e);
                                    }}
                                />
                                {button === true ? (
                                    five_char !== "" ? (
                                        five_char.length < 5 || five_char.length > 10 ?
                                            <small className="text-danger">
                                                This value length is invalid. It should be between 5 and 10 characters long.
                                            </small>
                                            :
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
                                <label htmlFor="text-input3" className="form-label">Min. Number ( &gt;= 5 )</label>
                                <input name="min_char" type="text" id="text-input3" className="form-control" value={min_char}
                                    onChange={(e) => {
                                        handleDepositeAmountChange(e);
                                    }}
                                />
                                {button === true ? (
                                    min_char !== "" ? (
                                        min_char >= 5 ?
                                            ''
                                            :
                                            <small className="text-danger">
                                                This value should be greater than or equal to 5.
                                            </small>
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
                                <label htmlFor="text-input4" className="form-label">Between 20-30</label>
                                <input name="twenty_char" type="text" id="text-input4" className="form-control" value={twenty_char}
                                    onChange={(e) => {
                                        handleDepositeAmountChange(e);
                                    }}
                                />
                                {button === true ? (
                                    twenty_char !== "" ? (
                                        twenty_char < 20 || twenty_char > 30 ?
                                            <small className="text-danger">
                                                This value should be between 20 and 30.
                                            </small>
                                            :
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
                                <label className="form-label">Select Min. 2 Options</label>
                                <br />
                                <label className="control-inline fancy-checkbox">
                                    <input name='checkbox' type="checkbox" checked={checkbox[0]}
                                        onChange={(e) => {
                                            var check1 = checkbox;
                                            check1[0] = !check1[0]
                                            setCheckbox([...check1])
                                            
                                        }}
                                    />
                                    <span className="mx-1">Option 1</span>
                                </label>
                                <label className="control-inline fancy-checkbox mx-2">
                                    <input name="checkbox" type="checkbox" value={checkbox[1]}
                                        onChange={(e) => {
                                            var check2 = checkbox;
                                            check2[1] = !check2[2]
                                            setCheckbox([...check2])
                                            
                                        }}
                                    />
                                    <span className="mx-1">Option 2</span>
                                </label>
                                <label className="control-inline fancy-checkbox">
                                    <input name="checkbox" type="checkbox" value={checkbox[2]}
                                        onChange={(e) => {
                                            var check3 = checkbox;
                                            check3[2] = !check3[2]
                                            setCheckbox([...check3])
                                            
                                        }}
                                    />
                                    <span className="mx-1">Option 3</span>
                                </label>
                                <p id="error-checkbox2">
                                    {button === true ? (
                                        checkbox !== true ? (
                                             // eslint-disable-next-line
                                            checkbox.filter((a) => {
                                                if (a) {
                                                    return a
                                                }
                                            }).length > 1 ? "" :
                                                <small className="text-danger">
                                                    You must select at least 2 choices.
                                                </small>


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
                                <label className="form-label">Select Between 1-2 Options</label>
                                <br />
                                <label className="control-inline fancy-checkbox">
                                    <input name="check_box" type="checkbox" value={check_box[0]}
                                        onChange={(e) => {
                                            var check1 = check_box;
                                            check1[0] = !check1[0]
                                            setCheck_box([...check1])
                                        }}
                                    />
                                    <span className="mx-1">Option 1</span>
                                </label>
                                <label className="control-inline fancy-checkbox mx-2">
                                    <input type="checkbox" name="check_box" value={check_box[1]}
                                        onChange={(e) => {
                                            var check2 = check_box;
                                            check2[1] = !check2[1]
                                            setCheck_box([...check2])
                                        }}
                                    />
                                    <span className="mx-1">Option 2</span>
                                </label>
                                <label className="control-inline fancy-checkbox">
                                    <input type="checkbox" name="check_box" value={check_box[2]}
                                        onChange={(e) => {
                                            var check3 = check_box;
                                            check3[2] = !check3[2]
                                            setCheck_box([...check3])
                                        }}
                                    />
                                    <span className="mx-1">Option 3</span>
                                </label>
                                <p id="error-checkbox3">
                                    {button === true ? (
                                        check_box !== true ? (
                                             // eslint-disable-next-line
                                            check_box.filter((a) => {
                                                if (a) {
                                                    return a
                                                }
                                            }).length === 0 ?
                                                <small className="text-danger">
                                                    You must select between 1 and 2 choices.
                                                </small>
                                                : ""
                                        ) || (
                                             // eslint-disable-next-line
                                                check_box.filter((a) => {
                                                    if (a) {
                                                        return a
                                                    }
                                                }).length === 3 ?
                                                    <small className="text-danger">
                                                        You must select between 1 and 2 choices.
                                                    </small>
                                                    : ""

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
                    <Link to="#!"><button type="submit" onClick={(e) => { onSubmit(e) }} className="btn btn-primary">Validate</button></Link>
                </form>
            </div>
        </div>
    );
}

export default AdvancedValidationForm;