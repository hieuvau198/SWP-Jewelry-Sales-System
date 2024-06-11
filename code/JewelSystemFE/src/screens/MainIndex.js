import React from 'react';
import { Route, Routes as ReactRoutes } from "react-router-dom";
import Dashboard from './Dashboard/Dashboard';
import ProductGrid from './Products/ProductGrid';
import ProductList from './Products/ProductList';
import ProductEdit from './Products/ProductEdit';
import ProductDetail from './Products/ProductDetail';
import ProductAdd from './Products/ProductAdd';
import ShoppingCart from './Products/ShoppingCart';
import Header from '../components/common/Header';
import CheckOut from './Products/CheckOut';
import CategoriesList from './Categories/CategoriesList';
import OrderList from './Orders/OrderList';
import OrderDetail from './Orders/OrderDetail';
import OrderInvoice from './Orders/OrderInvoice';
import CustomerList from './Customers/CustomerList';
import CustomerDetail from './Customers/CustomerDetail';
import CouponsList from './SalesPromotion.js/CouponsList';
import CouponsAdd from './SalesPromotion.js/CouponsAdd';
import CouponsEdit from './SalesPromotion.js/CouponsEdit';
import StockList from './Inventory/StockList';
import Purchase from './Inventory/Purchase';
import Supplier from './Inventory/Supplier';
import Return from './Inventory/Return';
import Departments from './Inventory/Departments';
import Invoices from './Accounts/Invoices';
import Expense from './Accounts/Expense';
import Salaryslip from './Accounts/Salaryslip';
import Chat from './App/Chat';
import ProfilePage from './Other Pages/ProfilePage'
import PricePlanExample from './Other Pages/PricePlanExample';
import ContactUs from './Other Pages/ContactUs';
import Icons from './Other Pages/Icon';
import FormsExample from './Other Pages/FormsExample';
import TableExample from './Other Pages/TableExample';
import ChartsExample from './Other Pages/ChartsExample';
import Alerts from './Uicomponent/Alerts';
import Badges from './Uicomponent/Badge';
import Breadcrumb from './Uicomponent/Breadcrumb';
import Buttons from './Uicomponent/Buttons';
import Cards from './Uicomponent/Card';
import Carousel from './Uicomponent/Carousel';
import Collapse from './Uicomponent/Collapse';
import Dropdowns from './Uicomponent/Dropdowns';
import ListGroup from './Uicomponent/ListGroup';
import ModalUI from './Uicomponent/Modal';
import NavbarUI from './Uicomponent/Navbar';
import NavsUI from './Uicomponent/Navs';
import PaginationUI from './Uicomponent/Pagination';
import PopoversUI from './Uicomponent/Popovers';
import ProgressUI from './Uicomponent/Progress';
import Scrollspy from './Uicomponent/Scrollspy';
import SpinnersUI from './Uicomponent/Spinners';
import ToastsUI from './Uicomponent/Toasts';
import Calendar from './App/Calendar';
import StaterPage from './Stater Page/StaterPage';
import Documentation from './Documentation/Documentation';
import Changelog from './Changelog/Changelog';
import CategoriesEdit from './Categories/CategoriesEdit';
import CategoriesAdd from './Categories/CategoriesAdd';
import StoreLocation from './StoreLocation/Storelocation';
import Help from './Help/Help';
import SimpleInvoice from '../components/Accounts/Invoice/SimpleInvoice';

function MainIndex (props) {
    const { activekey } = props;
    return (
      <div className='main px-lg-4 px-md-4' >
        {activekey === "/chat" ? "" : <Header />}
        <div className="body d-flex py-3 ">
          <ReactRoutes>
            <Route exact path={process.env.PUBLIC_URL + "/"} element={<Dashboard />} />
            <Route exact path={process.env.PUBLIC_URL + "/dashboard"} element={<Dashboard />} />
            <Route exact path={process.env.PUBLIC_URL + '/product-grid'} element={<ProductGrid />} />
            <Route exact path={process.env.PUBLIC_URL + '/product-list'} element={<ProductList />} />
            <Route exact path={process.env.PUBLIC_URL + '/product-edit'} element={<ProductEdit />} />
            <Route exact path={process.env.PUBLIC_URL + '/product-detail'} element={<ProductDetail />} />
            <Route exact path={process.env.PUBLIC_URL + '/product-Add'} element={<ProductAdd />} />
            <Route exact path={process.env.PUBLIC_URL + '/shopping-cart'} element={<ShoppingCart />} />
            <Route exact path={process.env.PUBLIC_URL + '/check-out'} element={<CheckOut />} />
            <Route exact path={process.env.PUBLIC_URL + '/categories-list'} element={<CategoriesList />} />
            <Route exact path={process.env.PUBLIC_URL + '/categories-edit'} element={<CategoriesEdit />} />
            <Route exact path={process.env.PUBLIC_URL + '/categories-add'} element={<CategoriesAdd />} />
            <Route exact path={process.env.PUBLIC_URL + '/order-list'} element={<OrderList />} />
            <Route exact path={process.env.PUBLIC_URL + '/order-detail'} element={<OrderDetail />} />
            <Route exact path={process.env.PUBLIC_URL + '/order-invoice'} element={<OrderInvoice />} />
            <Route exact path={process.env.PUBLIC_URL + '/customer-list'} element={<CustomerList />} />
            <Route exact path={process.env.PUBLIC_URL + '/customer-detail'} element={<CustomerDetail />} />
            <Route exact path={process.env.PUBLIC_URL + '/coupons-list'} element={<CouponsList />} />
            <Route exact path={process.env.PUBLIC_URL + '/coupons-add'} element={<CouponsAdd />} />
            <Route exact path={process.env.PUBLIC_URL + '/coupons-edit'} element={<CouponsEdit />} />
            <Route exact path={process.env.PUBLIC_URL + '/stock-list'} element={<StockList />} />
            <Route exact path={process.env.PUBLIC_URL + '/purchase'} element={<Purchase />} />
            <Route exact path={process.env.PUBLIC_URL + '/supplier'} element={<Supplier />} />
            <Route exact path={process.env.PUBLIC_URL + '/return'} element={<Return />} />
            <Route exact path={process.env.PUBLIC_URL + '/departments'} element={<Departments />} />
            <Route exact path={process.env.PUBLIC_URL + '/invoices'} element={<Invoices />} />
            <Route exact path={process.env.PUBLIC_URL + '/simple-invoice'} element={<SimpleInvoice />} />

            <Route exact path={process.env.PUBLIC_URL + '/expense'} element={<Expense />} />
            <Route exact path={process.env.PUBLIC_URL + '/salaryslip'} element={<Salaryslip />} />
            <Route exact path={process.env.PUBLIC_URL + '/chat'} element={<Chat />} />
            <Route exact path={process.env.PUBLIC_URL + '/calendar'} element={<Calendar />} />
            <Route exact path={process.env.PUBLIC_URL + '/store-location'} element={<StoreLocation />} />

            <Route exact path={process.env.PUBLIC_URL + '/profile-pages'} element={<ProfilePage />} />
            <Route exact path={process.env.PUBLIC_URL + '/price-plan'} element={<PricePlanExample />} />
            <Route exact path={process.env.PUBLIC_URL + '/contact-us'} element={<ContactUs />} />
            <Route exact path={process.env.PUBLIC_URL + '/icons'} element={<Icons />} />
            <Route exact path={process.env.PUBLIC_URL + '/form-example'} element={<FormsExample />} />
            <Route exact path={process.env.PUBLIC_URL + '/table-example'} element={<TableExample />} />
            <Route exact path={process.env.PUBLIC_URL + '/charts-example'} element={<ChartsExample />} />

            <Route exact path={process.env.PUBLIC_URL + '/ui-alerts'} element={<Alerts />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-badge'} element={<Badges />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-breadcrumb'} element={<Breadcrumb />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-buttons'} element={<Buttons />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-card'} element={<Cards />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-carousel'} element={<Carousel />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-collapse'} element={<Collapse />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-dropdowns'} element={<Dropdowns />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-listgroup'} element={<ListGroup />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-modalui'} element={<ModalUI />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-navbarui'} element={<NavbarUI />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-navsui'} element={<NavsUI />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-paginationui'} element={<PaginationUI />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-popoversui'} element={<PopoversUI />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-progressui'} element={<ProgressUI />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-Scrollspyui'} element={<Scrollspy />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-spinnersui'} element={<SpinnersUI />} />
            <Route exact path={process.env.PUBLIC_URL + '/ui-toastsui'} element={<ToastsUI />} />
            <Route exact path={process.env.PUBLIC_URL + '/stater-page'} element={<StaterPage />} />
            <Route exact path={process.env.PUBLIC_URL + '/documentation'} element={<Documentation />} />
            <Route exact path={process.env.PUBLIC_URL + '/changelog'} element={<Changelog />} />

            <Route exact path={process.env.PUBLIC_URL + '/help'} element={<Help />} />

          </ReactRoutes>
        </div>
      </div>
    );
  }
export default MainIndex;