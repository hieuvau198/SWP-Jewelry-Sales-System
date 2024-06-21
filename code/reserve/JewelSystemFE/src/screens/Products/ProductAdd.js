import React from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import Categories from '../../components/Products/ProductAdd/Categories';
import InventoryInfo from '../../components/Products/ProductAdd/InventoryInfo';
import PricingInfo from '../../components/Products/ProductAdd/PricingInfo';
import PublicaSchedule from '../../components/Products/ProductAdd/PublicSchedule';
import Size from '../../components/Products/ProductAdd/Size';
import Tags from '../../components/Products/ProductAdd/Tags';
import VisibilityStatus from '../../components/Products/ProductAdd/VisibilityStatus';
import BasicInformation from '../../components/Products/ProductAdd/BasicInformation';
import ShippingCountries from '../../components/Products/ProductAdd/ShippingCountry';
import Images from '../../components/Products/ProductAdd/Images';
import CroppedImages from '../../components/Products/ProductAdd/CroppedImages';


function ProductAdd() {
    return (
        <div className="container-xxl">
            <PageHeader1 pagetitle='Products Add' button={true} />
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
export default ProductAdd;