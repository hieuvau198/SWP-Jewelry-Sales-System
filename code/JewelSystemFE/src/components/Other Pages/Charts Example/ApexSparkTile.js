import React, { useState } from "react";
import Chart from "react-apexcharts";

function ApexSparkTile(props) {
  //eslint-disable-next-line
  const [options, setOptions] = useState(props.data.chartData ? props.data.chartData.options : "");
  //eslint-disable-next-line
  const [series, setSeries] = useState(props.data.chartData ? props.data.chartData.series : "")
  return (
    <div className="card mb-4">
      <div className="card-body">
        {options ? <Chart
          options={options}
          series={series}
          type={options ? options.chart.type : "bar"}
          height={options ? options.chart.height : 315}
        /> : null}
      </div>
    </div>
  );
}

export default ApexSparkTile;