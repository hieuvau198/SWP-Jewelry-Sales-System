import React, { useState } from 'react';
import Chart from 'react-apexcharts';

function SalesStatus() {
    //eslint-disable-next-line
    const [options, setOptions] = useState({
        chart: {
            type: 'bar',
            height: 300,
            stacked: true,
            toolbar: {
                show: false,
            },
        },
        colors: ['var(--chart-color2)', 'var(--chart-color3)'],
        plotOptions: {
            bar: {
                horizontal: true,
                barHeight: '80%',
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            width: 1,
            colors: ["#fff"]
        },

        grid: {
            xaxis: {
                lines: {
                    show: false
                }
            }
        },
        yaxis: {
            min: -5,
            max: 5,
            title: {
                // text: 'Age',
            },
        },
        tooltip: {
            shared: false,
            x: {
                formatter: function (val) {
                    return val
                }
            },
            y: {
                formatter: function (val) {
                    return Math.abs(val) + "%"
                }
            }
        },
        xaxis: {
            categories: ['70+', '56-70', '36-55', '21-35', '10-20', '0-9'],
            labels: {
                formatter: function (val) {
                    return Math.abs(Math.round(val)) + "%"
                }
            }
        },
    })
    //eslint-disable-next-line
    const [series, setSeries] = useState([
        {
            name: 'Purchase',
            data: [0.4, 0.65, 0.76, 0.88, 1.5, 2.1, 2.9, 4.1, 4.2, 4.5, 3.9, 3.5, 3
            ]
        }, {
            name: 'Sell',
            data: [-0.8, -1.05, -1.06, -1.18, -1.4, -2.2, -4.4, -4.1, -4, -4.1, -3.4, -3.1, -2.8
            ]
        }
    ])


    return (
        <div className="card ">
            <div className="card-header py-3 d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Top Selling Product</h6>
            </div>
            <div className="card-body" style={{ position: 'relative' }}>
                <Chart
                    options={options}
                    series={series}
                    type='bar'
                    width='100%'
                    height={310}
                />
            </div>
        </div>

    )
}
export default SalesStatus;