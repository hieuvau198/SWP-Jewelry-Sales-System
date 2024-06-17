import { Outlet } from "react-router-dom"
import AuthLeft from "../../components/Auth/AuthLeft"

const Layout = () => {
    return (
        
      <div className='main p-2 py-3 p-xl-5 '>
      <div className='body d-flex p-0 p-xl-5'>
        <div className='container-xxl'>
          <div className='row g-0'>
              <AuthLeft />
            <Outlet/>
          </div>
        </div>
      </div>
    </div>
    )
}

export default Layout
