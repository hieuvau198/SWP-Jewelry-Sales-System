import React from "react";
import SimpleChartTile from '../../components/Other Pages/Charts Example/SimpleChartTile'
import RadarTile from '../../components/Other Pages/Charts Example/RadarTile'
import OverviewTile from '../../components/Other Pages/Charts Example/OverviewTile'
import ApexSparkTile from '../../components/Other Pages/Charts Example/ApexSparkTile'

import { chartOverView, apexSparkData, radarChartData, simpleChartTileData, circleChart } from '../../components/Data/ChartData/ChartsData';
import PageHeader1 from "../../components/common/PageHeader1";

function ChartsExample() {
    return (
        <div className="body d-flex py-lg-3 py-md-2">
            <div className="container-xxl">
                <PageHeader1 pagetitle='Charts' />
                <div className="row clearfix mb-3">
                    <div className="col-xl-12 col-lg-12 col-md-12">
                        <div className="row gx-3 row-cols-sm-1 row-cols-md-2 row-cols-lg-2 row-cols-xl-4">
                            {
                                simpleChartTileData.map((data, i) => {
                                    return <div key={"dfjhg" + i} className="col"><SimpleChartTile data={data} key={"SimpleChartTile" + i} /></div>
                                })
                            }
                        </div>
                    </div>
                    <div className="col-xl-12 col-lg-12 col-md-12">
                        <div className="row gx-3 row-cols-1 row-cols-sm-1 row-cols-md-1 row-cols-lg-3 row-cols-xl-3 row-cols-xxl-3">
                            {
                                circleChart.map((data, i) => {
                                    return <div key={"dfjdhg" + i} className="col"><RadarTile data={data} key={"RadarTile" + i} /></div>
                                })
                            }
                        </div>
                    </div>
                    <div className="col-xl-12 col-lg-12 col-md-12">
                        {
                            chartOverView.map((data, i) => {
                                return <OverviewTile data={data} key={"OverviewTile" + i} index={i} />
                            })
                        }
                    </div>
                    <div className="col-xl-12 col-lg-12 col-md-12">
                        <div className="row gx-3 row-cols-1 row-cols-sm-1 row-cols-md-1 row-cols-lg-2 row-cols-xl-3 row-cols-xxl-3">
                            {
                                apexSparkData.map((data, i) => {
                                    return <div key={"dfjdhg" + i} className="col"><ApexSparkTile data={data} key={"ApexSparkTile" + i} /></div>
                                })
                            }
                            {
                                radarChartData.map((data, i) => {
                                    return <div key={"dfjdhg" + i} className="col"><RadarTile data={data} key={"RadarTile" + i} /></div>
                                })
                            }
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default ChartsExample;