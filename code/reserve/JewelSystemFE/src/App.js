import React from "react";
import { Route, Routes as ReactRoutes } from "react-router-dom";
import MainIndex from "./screens/layout/MainIndex";
import RequireAuth from "../src/components/Auth/RequireAuth";
import Page404 from "./components/Auth/Page404";
import Dashboard from "./screens/Dashboard/Dashboard";
import UserList from "./screens/User/Userlist";
import ProductAdd from "./screens/Products/ProductAdd";
import ProductDetail from "./screens/Products/ProductDetail";
import ProductList from "./screens/Products/ProductList";
import Signup from "./components/Auth/Signup";
import SignIn from './components/Auth/SignIn';
import Verification from "./components/Auth/Verification";
import Resetpassword from "./components/Auth/Resetpassword";
import AuthIndex from "./screens/layout/AuthIndex";
import ShoppingCart from "./screens/Products/ShoppingCart"
import OrderInvoice from "./screens/Orders/OrderInvoice";

const ROLES = {
  Staff: "Staff",
  Manager: "Editor",
  Admin: "Admin",
};


function App() {

  return (
    <ReactRoutes>
        <Route path="/" element={<AuthIndex />}>   
            <Route path={process.env.PUBLIC_URL+"/sign-in"} element={ <SignIn /> }/>
            <Route path={process.env.PUBLIC_URL+"/sign-up"} element={ <Signup /> } />
            <Route path={process.env.PUBLIC_URL+"/reset-password"} element={ <Resetpassword /> } />
            <Route path={process.env.PUBLIC_URL+"/verification"} element={ <Verification /> } />
            <Route path="*" element={ <Page404 /> } />
        </Route>
        <Route element={<RequireAuth allowedRoles={[ROLES.Admin]} />}>
            <Route path="/"  element={<MainIndex />}>
              <Route index element={<Dashboard />} />
              <Route path={process.env.PUBLIC_URL + "/dashboard"} element={<Dashboard />} />
              <Route path={process.env.PUBLIC_URL + "/user-list"} element={<UserList />} />
              <Route path={process.env.PUBLIC_URL + "/product-add"} element={<ProductAdd />} />
              <Route path={process.env.PUBLIC_URL + "/product-detail"} element={<ProductDetail />} />
              <Route path={process.env.PUBLIC_URL + "/product-list"} element={<ProductList />} />          
              <Route path={process.env.PUBLIC_URL + "/shopping-cart"} element={<ShoppingCart />} />       
              {/* <Route path={process.env.PUBLIC_URL + "/invoice"} element={<Invoice />} />      */}
              <Route path={process.env.PUBLIC_URL + "/order"} element={<OrderInvoice />} />                                        
            </Route>
        </Route>
        <Route element={<RequireAuth allowedRoles={[ROLES.Staff]} />}>
            <Route path="/"  element={<MainIndex />}>
              <Route index element={<Dashboard />} />
              <Route path={process.env.PUBLIC_URL + "/product-detail"} element={<ProductDetail />} />
              <Route path={process.env.PUBLIC_URL + "/product-list"} element={<ProductList />} />                                 
            </Route>
        </Route>
    </ReactRoutes>





  );
}
export default App;
