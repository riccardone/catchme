import React from 'react';
import Navigator from 'react.cordova-navigation_controller';
// Learn more about the Navigator: https://www.npmjs.com/package/react.cordova-navigation_controller
import 'bootstrap/dist/css/bootstrap.min.css';
import './app.css';
import auth0 from 'auth0-js';
import Auth0Cordova from '@auth0/cordova';

//--pages--//
import Home from './pages/index';
import Notification from './pages/notification';
import Me from './pages/me';

export default class App extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      nowPage: "" 
    }
  }

  // following this https://community.auth0.com/t/getting-auth0cordova-is-not-a-constructor-when-using-auth0-for-react-cordova/14234

  auth0 = new auth0.Authentication({
    domain: 'catchmeapp.eu.auth0.com',
    clientID: 'JUjYBjzO6I5oxxvNu835joFo5LvNDMsv'
  });

  state = {
    authenticated: false,
    accessToken: false,
  }

  login(e) {
    e.target.disabled = true;

    var client = new Auth0Cordova({
      domain: 'fakeDomain.auth0.com',
      clientId: 'this_is_a_fake_id_for_purposes_of_this_gist',
      packageIdentifier: 'net.fake.something'
    });
    var options = {
      scope: 'openid profile',
      audience: 'https://fakeDomain.auth0.com/userinfo'
    };
    var self = this;
    client.authorize(options, function(err, authResult) {
      if (err) {
        console.log(err);
        return (e.target.disabled = false);
      }
      localStorage.setItem('access_token', authResult.accessToken);
      self.resumeApp();
    });
  };
  
  logout(e) {
    localStorage.removeItem('access_token');
    this.resumeApp();
  };

  loadProfile(cb) {
    this.auth0.userInfo(this.state.accessToken, cb);
  };

  static resumeApp() {
    var accessToken = localStorage.getItem('access_token');
    if (accessToken) {
      this.setState({
        authenticated: true,
        accessToken: accessToken
      });
    } else {
      this.setState({
        authenticated: false,
        accessToken: null
      });
    }
  };

  static run() {
    this.resumeApp();
  };

  static renderTabs() {
    return [
      {
        content: <HomePage key={'home'} {...this.props} login={e => this.login(e)} logout={e => this.logout(e)} />,
        tab: <Tab key='home' label='' icon='fa-home' />
      },
      {
        content: <DataEntryPage key={'data-entry'} {...this.props} />,
        tab: <Tab key='data-entry' label='' icon='fa-clipboard' />
      },
      {
        content: <PersonalPage key={'personal'} {...this.props} />,
        tab: <Tab key='personal' label='' icon='fa-user-circle' />
      }
    ]
  }

  menuClick(e, goToPage) {

    this.navigator.changePage(goToPage);
    //this.navigator.ch

    document.getElementsByClassName("active")[0].className = "";
    e.currentTarget.className = "active";
  } 

  render() {
    const footerMenuHeight = 0;//px 
    const navigatorHeight = window.innerHeight - footerMenuHeight;
    return (
      [
        <Navigator
        onRef={ref => (this.navigator = ref)} // Required
          key="Navigator"
          height={navigatorHeight + "px"}
          myApp={this}
          // homePageKey={"Home"}
                   
          onChangePage={(page) => {
            this.setState({ nowPage: page });
          }}
        >
          <Tabbar {...this.props} initialIndex={0} renderTabs={App.renderTabs}
      login={e => this.login(e)}
      logout={e => this.logout(e)} />
          <Home key="Home" levelPage={0}/>
          <Notification key="Notification" backgroundColor={"#282c34"} levelPage={1} />
          <Me key="Me" levelPage={2}/>
        </Navigator>

        // <div key="footerMenu" className="footerMenu" style={{ height: footerMenuHeight + "px" }}>
        //   <ul>
        //     <li><div onClick={(e) => this.menuClick(e, "Home")} className={this.state.nowPage === "Home" ? "active" : ""} >Home</div></li>
        //     <li><div onClick={(e) => this.menuClick(e, "Notification")} className={this.state.nowPage === "Notification" ? "active" : ""}>Notification</div></li>
        //     <li><div onClick={(e) => this.menuClick(e, "Me")} className={this.state.nowPage === "Me" ? "active" : ""}>Me</div></li>
        //   </ul>
        // </div>
      ]
    );
  }
}
