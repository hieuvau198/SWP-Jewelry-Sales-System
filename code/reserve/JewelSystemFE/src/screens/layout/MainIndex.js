import { Outlet } from "react-router-dom";
import Header from "../../components/common/Header";
import Sidebar from "../../components/common/Sidebar";
import AddModal from "../../components/common/AddModal";


const MainIndex = () => {
  return (
    <div id="ebazar-layout" className="theme-red">
    <Sidebar />
    <AddModal />
      <div className="main px-lg-4 px-md-4">
        <Header />
        <div className="body d-flex py-3 ">
          <Outlet />
        </div>
      </div>
    </div>
  );
};

export default MainIndex;
