import React from 'react';
import PageHeader1 from '../../components/common/PageHeader1';
import AdvancedValidationForm from '../../components/Other Pages/Form example/AdvanceValidationForm';
import BasicForm from '../../components/Other Pages/Form example/BasicForm';
import BasicValidationForm from '../../components/Other Pages/Form example/BasicValidationForm';

function FormsExample() {
    return (
        <div className='body d-flex py-3'>
            <div className="container-xxl">
                <PageHeader1 pagetitle='Forms' />
                <div className="row align-item-center">
                    <div className="col-md-12">
                        <BasicForm />
                        <BasicValidationForm />
                        <AdvancedValidationForm />
                    </div>
                </div>
            </div>
        </div>
    )
}
export default FormsExample;