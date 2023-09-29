// Import necessary modules
import React from 'react';
import { BrowserRouter as Router, Route, Switch, Link } from 'react-router-dom';

// Import your page components
import Home from './Home';
import AboutUs from './AboutUs';
import Services from './Services';
import ContactUs from './ContactUs';

function App() {
    return (
        <Router>
            <header>
                <nav>
                    <ul>
                        <li><Link to="/">Home</Link></li>
                        <li><Link to="/about-us">About Us</Link></li>
                        <li><Link to="/services">Services</Link></li>
                        <li><Link to="/contact-us">Contact Us</Link></li>
                    </ul>
                </nav>
            </header>

            <Switch>
                <Route path="/about-us" component={AboutUs} />
                <Route path="/services" component={Services} />
                <Route path="/contact-us" component={ContactUs} />
                <Route path="/" component={Home} />
            </Switch>
        </Router>
    );
}

export default App;
