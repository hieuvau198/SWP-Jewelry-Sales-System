import React from 'react';
import { Route, Routes as ReactRoutes } from "react-router-dom";
import Header from '../components/common/Header';
import Help from './Help/Help';
import Dashboard from './Dashboard/Dashboard';
import RequireAuth from '../components/Auth/RequireAuth';

const ROLES = {
  'User': 'User',
  'Editor': 'Staff',
  'Admin': 'Admin'
}

function MainIndex () {
    return (
      <div className='main px-lg-4 px-md-4' ><Header />
        <div className="body d-flex py-3 ">
          <ReactRoutes>
            <Route element={<RequireAuth allowedRoles={[ROLES.User,ROLES.Admin]} />}>
              <Route exact path={process.env.PUBLIC_URL + "/"} element={<Dashboard />} />
            </Route>
            <Route exact path={process.env.PUBLIC_URL + '/help'} element={<Help />} />

          </ReactRoutes>
        </div>
      </div>
    );
  }
export default MainIndex;