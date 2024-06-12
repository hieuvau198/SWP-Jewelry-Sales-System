import React from 'react';
import { Route, Routes as ReactRoutes } from "react-router-dom";
import Dashboard from './Dashboard/Dashboard';
import Header from '../components/common/Header';
import ProductAdd from './Products/ProductAdd';
import ProductDetail from './Products/ProductDetail';
import ProductList from './Products/ProductList';
import UserList from './User/Userlist';

function MainIndex (props) {
    const { activekey } = props;
    return (
      <div className='main px-lg-4 px-md-4' >
        {activekey === "/chat" ? "" : <Header />}
        <div className="body d-flex py-3 ">
          <ReactRoutes>
            <Route exact path={process.env.PUBLIC_URL + "/"} element={<Dashboard />} />
            <Route exact path={process.env.PUBLIC_URL + "/dashboard"} element={<Dashboard />} />
            <Route exact path={process.env.PUBLIC_URL + "/user-list"} element={<UserList />} />
            <Route exact path={process.env.PUBLIC_URL + "/product-add"} element={<ProductAdd />} />
            <Route exact path={process.env.PUBLIC_URL + "/product-detail"} element={<ProductDetail />} />
            <Route exact path={process.env.PUBLIC_URL + "/product-list"} element={<ProductList />} />

          </ReactRoutes>
        </div>
      </div>
    );
  }
export default MainIndex;