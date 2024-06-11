import Sidebar from './components/common/Sidebar';
import AuthIndex from './screens/AuthIndex';
import MainIndex from './screens/MainIndex';


function App(props) {
  const activekey = () => {
    var res = window.location.pathname
    var baseUrl = process.env.PUBLIC_URL
    baseUrl = baseUrl.split("/");
    res = res.split("/");
    res = res.length > 0 ? res[baseUrl.length] : "/";
    res = res ? "/" + res : "/";;
    const activeKey1 = res;
    console.log(process.env.PUBLIC_URL);
    return activeKey1
  }
  if (activekey() === '/sign-in' || activekey() === '/sign-up' || activekey() === '/reset-password' || activekey() === '/verification' || activekey() === '/page-404') {
    return (
      <div id="ebazar-layout" className='theme-red'>
        <AuthIndex />
      </div>
    );
  }

  return (
    <div id="ebazar-layout" className='theme-red'>
      <Sidebar activekey={activekey()} history={props.history} />
        <MainIndex activekey={activekey()} />
    </div>
  );
}

export default App;