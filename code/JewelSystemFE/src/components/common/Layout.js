import Sidebar from "./Sidebar"
import AddModal from "./AddModal"
import MainIndex from "../../screens/MainIndex"

function Layout(props) {
    const { activekey } = props;
    return (
    <div id="ebazar-layout" className='theme-red'>
    <Sidebar activekey={activekey()} history={props.history} />
    <AddModal />
      <MainIndex activekey={activekey()} />
    </div>
    )
}

export default Layout
