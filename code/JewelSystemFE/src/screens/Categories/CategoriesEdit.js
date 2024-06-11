import React from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import VisibilityStatus from '../../components/Categories/CategoriesEdit/VisibilityStatus';
import PublicaSchedule from '../../components/Categories/CategoriesEdit/PublicaSchedule';
import Categories from '../../components/Categories/CategoriesEdit/Categories';
import CategoriesImage from '../../components/Categories/CategoriesEdit/CategoriesImage';
import BasicInformation from '../../components/Categories/CategoriesEdit/BasicInformation';
import CroppedImages from '../../components/Categories/CategoriesEdit/CroppedImages';

function CategoriesEdit() {
    return (
        <div className="container-xxl">
            <PageHeader1 pagetitle='Categories Edit' button={true} />
            <div className="row g-3">
                <div className="col-xl-4 col-lg-4">
                    <div className="sticky-lg-top">

                        <div className="card mb-3">
                            <VisibilityStatus />
                        </div>

                        <div className="card mb-3">
                            <PublicaSchedule />
                        </div>

                        <div className="card mb-3">
                            <Categories />
                        </div>
                        <div className="card mb-3">
                            <CategoriesImage />
                        </div>

                    </div>
                </div>
                <div className="col-xl-8 col-lg-8">
                    <div className="card mb-3">
                        <BasicInformation />
                    </div>
                    <div className="card">
                        <CroppedImages />
                    </div>
                </div>
            </div>
        </div>
    )
}
export default CategoriesEdit;