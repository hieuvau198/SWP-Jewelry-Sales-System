import React, { useState } from 'react';
import Chart from "react-apexcharts";

function ExpenseCountBlock() {
    //eslint-disable-next-line
    const [options, setOptions] = useState({
        chart: {
            height: 250,
            type: 'radialBar',
            toolbar: {
                show: true
            }
        },
        colors: ['#0d6efd'],
        plotOptions: {
            radialBar: {
                startAngle: -135,
                endAngle: 225,
                hollow: {
                    margin: 0,
                    size: '70%',
                    background: '#fff',
                    image: undefined,
                    imageOffsetX: 0,
                    imageOffsetY: 0,
                    position: 'front',

                    dropShadow: {
                        enabled: true,
                        top: 3,
                        left: 0,
                        blur: 4,
                        opacity: 0.24
                    }
                },
                track: {
                    background: '#fff',
                    strokeWidth: '67%',
                    margin: 0, // margin is in pixels
                    dropShadow: {
                        enabled: true,
                        top: -3,
                        left: 0,
                        blur: 4,
                        opacity: 0.35
                    }
                },
                dataLabels: {
                    showOn: 'always',
                    name: {
                        offsetY: -10,
                        show: true,
                        color: '#888',
                        fontSize: '17px'
                    },
                    value: {
                        formatter: function (val) {
                            return parseInt(val);
                        },
                        color: '#111',
                        fontSize: '36px',
                        show: true,
                    }
                }
            }
        },
        fill: {
            type: 'gradient',
            gradient: {
                shade: 'dark',
                type: 'horizontal',
                shadeIntensity: 0.5,
                gradientToColors: ['var(--chart-color1)'],
                inverseColors: true,
                opacityFrom: 1,
                opacityTo: 1,
                stops: [0, 100]
            }
        },
        stroke: {
            lineCap: 'round'
        },
        labels: ['Percent'],
    });
    //eslint-disable-next-line
    const [series, setSeries] = useState([75]);
    return (
        <div className="card">
            <div className="card-header py-3 d-flex justify-content-between bg-transparent border-bottom-0">
                <h6 className="mb-0 fw-bold ">Expence Count</h6>
            </div>
            <div className="card-body" style={{ position: 'relative' }}>
                <div className="d-flex justify-content-end text-center">
                    <div className="p-2">
                        <h6 className="mb-0 fw-bold">$1790</h6>
                        <span className="text-muted">Total</span>
                    </div>
                    <div className="p-2 ms-4">
                        <h6 className="mb-0 fw-bold">$149.16</h6>
                        <span className="text-muted">Avg Month</span>
                    </div>
                </div>
                <Chart
                    options={options}
                    series={series}
                    type="radialBar"
                    height="250"
                />
                <div className="row">
                    <div className="col">
                        <span className="mb-3 d-block">Food</span>
                        <div className="progress-bar  bg-secondary" role="progressbar" style={{ width: '55%', height: '5px' }}></div>
                        <span className="mt-2 d-block text-secondary">$597 spend</span>
                    </div>
                    <div className="col">
                        <span className="mb-3 d-block">Cloth</span>
                        <div className="progress-bar  bg-primary" role="progressbar" style={{ width: '60%', height: '5px' }}></div>
                        <span className="mt-2 d-block text-primary">$845 spend</span>
                    </div>
                    <div className="col">
                        <span className="mb-3 d-block">Other</span>
                        <div className="progress-bar  bg-lavender-purple" role="progressbar" style={{ width: '70%', height: '5px' }}></div>
                        <span className="mt-2 d-block color-lavender-purple">$348 spend</span>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default ExpenseCountBlock;