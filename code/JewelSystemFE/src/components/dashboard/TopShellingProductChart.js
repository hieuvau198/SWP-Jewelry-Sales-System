import React, { useState } from 'react';
import Chart from 'react-apexcharts';

function TopShellingProductChart() {
    //eslint-disable-next-line
    const [options, setOptions] = useState({
        chart: {
            type: 'bar',
            height: 300,
            stacked: true,
            toolbar: {
                show: false
            },
            zoom: {
                enabled: true
            }
        },

        xaxis: {
            categories: ['Jan', 'Feb', 'March', 'Apr', 'May', 'Jun', 'July', 'Aug', 'Sept', 'Oct', 'Nov', 'Dec'],
        },
        legend: {
            position: 'top', // top, bottom
            horizontalAlign: 'right', // left, right
        },
        dataLabels: {
            enabled: false,
        },
        colors: ['var(--chart-color1)', 'var(--chart-color2)', 'var(--chart-color3)', 'var(--chart-color4)'],
    })
//eslint-disable-next-line
    const [series, setSeries] = useState([{
        name: 'Ui/Ux Designer',
        data: [45, 25, 44, 23, 25, 41, 32, 25, 22, 65, 22, 29]
    }, {
        name: 'App Development',
        data: [45, 12, 25, 22, 19, 22, 29, 23, 23, 25, 41, 32]
    }, {
        name: 'Quality Assurance',
        data: [45, 25, 32, 25, 22, 65, 44, 23, 25, 41, 22, 29]
    }, {
        name: 'Web Developer',
        data: [32, 25, 22, 11, 22, 29, 16, 25, 9, 23, 25, 13]
    }])
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
                    height={300}
                />
            </div>
        </div>
    )
}
export default TopShellingProductChart;