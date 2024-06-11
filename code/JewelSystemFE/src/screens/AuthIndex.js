import React from 'react';
import AuthLeft from '../components/Auth/AuthLeft';
import { Route, Routes as ReactRoutes } from "react-router-dom";
import SignIn from '../components/Auth/SignIn';
import Signup from '../components/Auth/Signup';
import Resetpassword from '../components/Auth/Resetpassword';
import Verification from '../components/Auth/Verification';
import Page404 from '../components/Auth/Page404';

function AuthIndex () {
  
    return (
      <div className='main p-2 py-3 p-xl-5 '>
        <div className='body d-flex p-0 p-xl-5'>
          <div className='container-xxl'>
            <div className='row g-0'>
              <AuthLeft />
              {/* <Switch>
                <Route exact path={process.env.PUBLIC_URL+"/sign-in"} render={() => { return <SignIn /> }} />
                <Route exact path={process.env.PUBLIC_URL+"/sign-up"} render={() => { return <Signup /> }} />
                <Route exact path={process.env.PUBLIC_URL+"/reset-password"} render={() => { return <Resetpassword /> }} />
                <Route exact path={process.env.PUBLIC_URL+"/verification"} render={() => { return <Verification /> }} />
                <Route exact path={process.env.PUBLIC_URL+"/page-404"} render={() => { return <Page404 /> }} />
              </Switch> */}
                <ReactRoutes>
                  <Route exact path={process.env.PUBLIC_URL+"/sign-in"} element={ <SignIn /> }/>
                  <Route exact path={process.env.PUBLIC_URL+"/sign-up"} element={ <Signup /> } />
                  <Route exact path={process.env.PUBLIC_URL+"/reset-password"} element={ <Resetpassword /> } />
                  <Route exact path={process.env.PUBLIC_URL+"/verification"} element={ <Verification /> } />
                  <Route exact path={process.env.PUBLIC_URL+"/page-404"} element={ <Page404 /> } />
                </ReactRoutes>
            </div>
          </div>
        </div>
      </div>
    );
  }

export default AuthIndex;