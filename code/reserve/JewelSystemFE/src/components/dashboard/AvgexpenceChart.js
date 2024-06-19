import React, { useState } from 'react';
import Chart from 'react-apexcharts';

function AvgexpenceChart() {
    //eslint-disable-next-line
    const [options, setOptions] = useState({

        chart: {
            type: 'bar',
            height: 300,
            stacked: true,
            toolbar: {
                show: false
            }
        },
        xaxis: {
            categories: ['Jan', 'Feb', 'March', 'Apr', 'May', 'Jun', 'July', 'Aug', 'Sept', 'Oct', 'Nov', 'Dec'],
        },
        dataLabels: {
            enabled: true,
            position: 'top',

        },
        fill: {
            colors: ['#e5df88']
        },
        yaxis: {
            show: false,
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    position: 'top'
                }
            }
        }
    })
    //eslint-disable-next-line
    const [series, setSeries] = useState([{
        name: '',
        data: [1131, 1180, 1114, 1109, 1112, 1016, 1317, 1213, 1014, 1199, 1251],

    }])

    return (
        <div className="card">
            <div className="card-header py-3  d-flex justify-content-between align-items-center bg-transparent border-bottom-0">
                <h6 className="m-0 fw-bold">Avg Expense Costs</h6>
            </div>
            <div className="card-body" style={{ position: 'relative' }}>
                <div className="h2 mb-0">$1105.5</div>
                <span className="text-muted small">Avg Expense Costs All Month</span>
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
export default AvgexpenceChart;