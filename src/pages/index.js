import React from 'react';
import logoLanding from '../images/catchme_logo_welcome_fb_color_small.png'

export default class Index extends React.Component {

    render() {
        return <div className="App">
            <header className="App-header">
                <ul className="login-elements">
                    <li><img src={logoLanding} className="App-logo-login" alt="CatchMe" /> </li>
                    <li><p className="login">Find your friends</p></li>
                    <li><button className="btn btn-primary" variant="primary" size="lg">Login</button></li>
                </ul>
                {/* <a
                    className="App-link"
                    href="#"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Login
             </a> */}
            </header>
        </div>
    }
}