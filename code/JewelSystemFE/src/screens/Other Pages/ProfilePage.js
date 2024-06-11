import React from 'react';
import Profile from '../../components/Other Pages/Profile Page/Profile';
import PaymentsMethod from '../../components/Other Pages/Profile Page/PaymentsMethod'
import ProfileSetting from '../../components/Other Pages/Profile Page/ProfileSetting'
import AuthenticationDetail from '../../components/Other Pages/Profile Page/AuthenticationDetail'
import PageHeader1 from '../../components/common/PageHeader1';


function ProfilePage() {
    return (
        <div className='row g-3'>
            <PageHeader1 pagetitle='Admin Profile' />
            <div className='col-xl-4 col-lg-5 col-md-12'>

                <Profile />
                <PaymentsMethod />
            </div>
            <div className='col-xl-8 col-lg-7 col-md-12'>
                <ProfileSetting />
                <AuthenticationDetail />
            </div>

        </div>
    )
}
export default ProfilePage;