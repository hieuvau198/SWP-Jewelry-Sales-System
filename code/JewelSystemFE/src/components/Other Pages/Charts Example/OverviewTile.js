import React, { useEffect, useState } from "react";
import ApexCharts from "apexcharts"
import { Dropdown } from "react-bootstrap";

function OverviewTile(props) {
    //eslint-disable-next-line
    const [options, setOptions] = useState(props.data.chartData ? props.data.chartData.options : "");
    //eslint-disable-next-line
    const [series, setSeries] = useState(props.data.chartData ? props.data.chartData.series : "");

    useEffect(() => {

        if (options !== "") {
            const { showBtnGroup } = props.data;
            const { index } = props;
            var opt = options;
            opt.series = series;

            var chart = new ApexCharts(
                document.getElementById("apex-AudienceOverview" + index),
                opt
            );
            chart.render();

            if (showBtnGroup) {
                var resetCssClasses = function (activeEl) {
                    var els = document.querySelectorAll("button");
                    Array.prototype.forEach.call(els, function (el) {
                        el.classList.remove('active');
                    });

                    activeEl.target.classList.add('active')
                }

                document.querySelector("#one_month").addEventListener('click', function (e) {
                    resetCssClasses(e)
                    chart.updateOptions({
                        xaxis: {
                            min: new Date('28 Jan 2013').getTime(),
                            max: new Date('27 Feb 2013').getTime(),
                        }
                    })
                })

                document.querySelector("#six_months").addEventListener('click', function (e) {
                    resetCssClasses(e)
                    chart.updateOptions({
                        xaxis: {
                            min: new Date('27 Sep 2012').getTime(),
                            max: new Date('27 Feb 2013').getTime(),
                        }
                    })
                })
                document.querySelector("#one_year").addEventListener('click', function (e) {
                    resetCssClasses(e)
                    chart.updateOptions({
                        xaxis: {
                            min: new Date('27 Feb 2012').getTime(),
                            max: new Date('27 Feb 2013').getTime(),
                        }
                    })
                })
                document.querySelector("#ytd").addEventListener('click', function (e) {
                    resetCssClasses(e)
                    chart.updateOptions({
                        xaxis: {
                            min: new Date('01 Jan 2013').getTime(),
                            max: new Date('27 Feb 2013').getTime(),
                        }
                    })
                })
                document.querySelector("#all").addEventListener('click', function (e) {
                    resetCssClasses(e)
                    chart.updateOptions({
                        xaxis: {
                            min: undefined,
                            max: undefined,
                        }
                    })
                })
            }
        }
    })



    const { title, subTitle1, subTitle2, linkText, showHeader, tableData, hideDownload, showBtnGroup } = props.data
    const { index } = props;
    return (
        <div className="card mb-4 border-0 lift">
            <div className="card-header py-3 d-flex flex-wrap  justify-content-between align-items-center bg-transparent border-bottom-0">
                <div>
                    <h6 className="m-0">{title ? title : ""}</h6>
                    <small className="text-muted">{subTitle1 ? subTitle1 : ""} <a href="#!">{linkText ? linkText : ""}</a> {subTitle2 ? subTitle2 : ""}</small>
                </div>
                <Dropdown drop="left">
                    {hideDownload ? null : <button className="btn btn-sm btn-link text-muted d-none d-sm-inline-block" type="button"><i className="fa fa-download"></i></button>}
                    <button className="btn btn-sm btn-link text-muted d-none d-sm-inline-block" type="button"><i className="fa fa-external-link"></i></button>
                    <Dropdown.Toggle variant="" className="btn btn-sm btn-link text-muted">
                    </Dropdown.Toggle>
                    <Dropdown.Menu>
                        <Dropdown.Item href="#!">Action</Dropdown.Item>
                        <Dropdown.Item href="#!">Another action</Dropdown.Item>
                        <Dropdown.Item href="#!">Something else here</Dropdown.Item>
                    </Dropdown.Menu>
                </Dropdown>
            </div>
            <div className="card-body">
                {showBtnGroup ? <div className="btn-group" role="group" aria-label="Basic example">
                    <button type="button" className="btn btn-outline-secondary active" id="one_month" onClick={() => {
                       
                    }} >1M</button>
                    <button type="button" className="btn btn-outline-secondary" id="six_months" onClick={() => {
                       

                    }}>6M</button>
                    <button type="button" className="btn btn-outline-secondary" id="one_year">1Y</button>
                    <button type="button" className="btn btn-outline-secondary" id="ytd">YTD</button>
                    <button type="button" className="btn btn-outline-secondary" id="all">ALL</button>
                </div> : null}
                {showHeader ? <div className="card-header border">
                    <div className="d-flex flex-row align-items-center">
                        <div>
                            <h6 className="mb-0 fw-bold">$3,056</h6>
                            <small className="text-muted font-11">Rate</small>
                        </div>
                        <div className="ms-lg-5 ms-md-4 ms-3">
                            <h6 className="mb-0 fw-bold">$1,998</h6>
                            <small className="text-muted font-11">Value</small>
                        </div>
                        <div className="d-none d-sm-block ms-auto">
                            <div className="btn-group" role="group">
                                <input type="radio" className="btn-check" name="btnradio" id="btnradio1" />
                                <label className="btn btn-outline-secondary" >Week</label>

                                <input type="radio" className="btn-check" name="btnradio" id="btnradio2" />
                                <label className="btn btn-outline-secondary" >Month</label>

                                <input type="radio" className="btn-check" name="btnradio" id="btnradio3" />
                                <label className="btn btn-outline-secondary" >Year</label>
                            </div>
                        </div>
                    </div>
                </div> : ""}
                <div id={"apex-AudienceOverview" + index}>
                </div>
                {
                    tableData ?
                        <div className="table-responsive">
                            <table className="table table-borderless table-hover mb-0">
                                <thead>
                                    <tr>
                                        {
                                            tableData.header.map((d, i) => {
                                                return <th key={'tableHeader' + i}>{d}</th>
                                            })
                                        }

                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        tableData.rows.map((d, i) => {
                                            return <tr key={'tableRows' + i}>
                                                <td>{d.no}</td>
                                                <td><a href={d.SOURCE} target="_blank" rel="noopener noreferrer">{d.SOURCE}</a></td>
                                                <td>{d.VISITS}</td>
                                                <td>{d.AVGTIME}</td>
                                                <td>{d.BOUNCERATE}</td>
                                            </tr>
                                        })
                                    }
                                </tbody>
                            </table>
                        </div>
                        : null
                }
            </div>
        </div>
    );
}

export default OverviewTile;