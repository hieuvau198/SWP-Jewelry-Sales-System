import React from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import Categories from '../../components/Products/ProductEdit/Categories';
import InventoryInfo from '../../components/Products/ProductEdit/InventoryInfo';
import PricingInfo from '../../components/Products/ProductEdit/PricingInfo';
import PublicaSchedule from '../../components/Products/ProductEdit/PublicaSchedule';
import Size from '../../components/Products/ProductEdit/Size';
import Tags from '../../components/Products/ProductEdit/Tags';
import VisibilityStatus from '../../components/Products/ProductEdit/VisibilityStatus';
import BasicInformation from '../../components/Products/ProductEdit/BasicInformation';
import ShippingCountries from '../../components/Products/ProductEdit/ShippingCountries';
import Images from '../../components/Products/ProductEdit/Images';
import CroppedImages from '../../components/Products/ProductEdit/CroppedImages';


function ProductEdit() {
    return (
        <div className="container-xxl">
            <PageHeader1 pagetitle='Products Edit' button={true} />
            <div className="row g-3">
                <div className="col-xl-4 col-lg-4">
                    <div className="sticky-lg-top">
                        <div className="card mb-3">
                            <PricingInfo />
                        </div>
                        <div className="card mb-3">
                            <VisibilityStatus />
                        </div>
                        <div className="card mb-3">
                            <Size />
                        </div>
                        <div className="card mb-3">
                            <PublicaSchedule />
                        </div>
                        <div className="card mb-3">
                            <Tags />
                        </div>
                        <div className="card mb-3">
                            <Categories />
                        </div>
                        <div className="card">
                            <InventoryInfo />
                        </div>
                    </div>
                </div>
                <div className="col-xl-8 col-lg-8">
                    <div className="card mb-3">
                        <BasicInformation />
                    </div>
                    <div className="card mb-3">
                        <ShippingCountries />
                    </div>
                    <div className="card mb-3">
                        <Images />
                    </div>
                    <div className="card">
                        <CroppedImages />
                    </div>
                </div>
            </div>
        </div>
    )
}
export default ProductEdit;