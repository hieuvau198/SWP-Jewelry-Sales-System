import React, { useState } from 'react';

function Tags() {
    const [data, setData] = useState([]);
    const [value, setValue] = useState('');

    const Taginput = (e) => {
        if (e.key === "Enter") {
            var a = data;
            var b = value.replace(/ /g, "_");
            a.push(b);
            setData([...a]);
            setValue("");
        }
        if (e.key === "Backspace") {
            if (value === "") {
                var c = data;
                c.pop();
                setData([...c]);
            }
        }
    }
    const RemoveTags = (index) => {
        var a = data;
        a.splice(index, 1);
        setData([...a]);
    };
    return (
        <>
            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Tags</h6>
            </div>
            <div className="card-body">
                <div className="form-group demo-tagsinput-area">
                    <div className="tags">
                        <div className="taglable d-flex" style={{ flexWrap: 'wrap' }}>
                            {data.map((value, i) => {
                                return (
                                    <div className="settag" style={{
                                        borderRadius: '10px',
                                        padding: '2px',
                                        display: 'block',
                                        margin: '5px',
                                        backgroundColor: '#7258db',
                                        color: 'white'
                                    }} key={i}>
                                        <span className="ItemLable  rounded-left " style={{ margin: '10px' }}>{value}</span>
                                        <span
                                            className="CloseTag  rounded-right"
                                            onClick={() => {
                                                RemoveTags(i);
                                            }}
                                        >
                                            x
                                        </span>
                                    </div>
                                );
                            })}
                        </div>
                        <input
                            type="text"
                            className="form-control"
                            onKeyUp={(e) => {
                                Taginput(e);
                            }}
                            onChange={(e) => {
                                setValue(e.target.value);
                            }}
                            value={value}
                        />
                    </div>
                </div>
            </div>
        </>
    )
}

export default Tags;