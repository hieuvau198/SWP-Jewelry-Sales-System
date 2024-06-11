import React from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import VisibilityStatus from '../../components/Categories/CategoriesAdd/VisibilityStatus';
import PublicaSchedule from '../../components/Categories/CategoriesAdd/PublicaSchedule';
import Categories from '../../components/Categories/CategoriesAdd/Categories';
import CategoriesImage from '../../components/Categories/CategoriesAdd/CategoriesImage';
import BasicInformation from '../../components/Categories/CategoriesAdd/BasicInformation';
import CroppedImages from '../../components/Categories/CategoriesAdd/CroppedImages';

function CategoriesAdd() {
    return (
        <div className="container-xxl">
            <PageHeader1 pagetitle='Categories Add' button={true} />
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
export default CategoriesAdd;